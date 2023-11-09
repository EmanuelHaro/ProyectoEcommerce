using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;

namespace Ecommerce.Servicio.Contrato
{
    public interface IDetalleVentaServicio
    {
        Task<List<DetalleVentaDTO>> Lista(string buscar);
        Task<DetalleVentaDTO> Obtener(int id);
        Task<DetalleVentaDTO> Crear(DetalleVentaDTO modelo);
        Task<bool> Editar(DetalleVentaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
