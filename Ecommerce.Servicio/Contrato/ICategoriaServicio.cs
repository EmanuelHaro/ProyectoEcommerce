using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;
using Ecommerce.Servicio.Contrato;


namespace Ecommerce.Servicio.Contrato
{
    public interface ICategoriaServicio
    {
        Task<List<CategoriaDTO>> Lista(string buscar);
        Task<CategoriaDTO> Obtener(int id);
        //Task<SesionDTO> Autorizacion(LoginDTO modelo);
        Task<CategoriaDTO> Crear(CategoriaDTO modelo);
        Task<bool> Editar(CategoriaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
