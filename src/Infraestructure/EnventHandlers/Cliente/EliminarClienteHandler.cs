using ApplicationCore.Commands.Cliente;
using ApplicationCore.DTOs.Logs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MimeKit;

namespace Infraestructure.EnventHandlers.Cliente
{
    public class EliminarClienteHandler : IRequestHandler<EliminarClienteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDashboardService _service;

        public EliminarClienteHandler(ApplicationDbContext context, IMapper mapper, IDashboardService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response<int>> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _context.clientes.FindAsync(request.Id);
                cliente.estatus = false;
                await _context.SaveChangesAsync();
                return new Response<int>(request.Id, "Cliente eliminado");
            }
            catch (Exception ex)
            {
                var log = new LogsDto();
                log.datos = JsonSerializer.Serialize(request);
                log.fecha = DateTime.Now;
                log.nombreFuncion = "EliminarCliente()";
                log.response = ex.Message;
                await _service.CreateLog(log);
                throw;
            }
        }

    }

    
}
