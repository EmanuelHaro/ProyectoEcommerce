using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Ecommerce.Modelo;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.DBContext;

namespace Ecommerce.Repositorio.Implementacion
{
    public class VentaRepositorio: GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly DbecommerceContext _dbContext;
        public VentaRepositorio(DbecommerceContext dbContext): base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalleVenta detalle in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.
                            Where(p => p.IdProducto == detalle.IdProducto).First(); //Encuentro producto con idProducto

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - detalle.Cantidad; //Resto la cantidad para actualizar stock

                        _dbContext.Productos.Update(producto_encontrado); //Actualizo db
                    }

                    await _dbContext.SaveChangesAsync(); //Guardo cambios

                    await _dbContext.Venta.AddAsync(modelo); //Agrego de manera asyncrona 
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = modelo;
                    transaction.Commit(); //La transaccion ha sido exitosa
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return ventaGenerada;
        }
    }
}
