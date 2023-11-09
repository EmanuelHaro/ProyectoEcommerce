using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Modelo;
using Ecommerce.DTO;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Servicio.Contrato;
using AutoMapper;

namespace Ecommerce.Servicio.Implementacion
{
    public class DetalleVentaServicio : IDetalleVentaServicio
    {
        private readonly IGenericoRepositorio<DetalleVenta> _modeloRepositorio;
        private readonly IMapper _mapper;

        public DetalleVentaServicio(IGenericoRepositorio<DetalleVenta> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public Task<DetalleVentaDTO> Crear(DetalleVentaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(DetalleVentaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleVentaDTO>> Lista(string buscar)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleVentaDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
