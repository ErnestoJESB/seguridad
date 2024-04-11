using ApplicationCore.Commands.Cliente;
using ApplicationCore.DTOs.Logs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using MediatR;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Infraestructure.EnventHandlers.Cliente
{
    public class ActualizarClienteHandler : IRequestHandler<ActualizarClienteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDashboardService _service;


        public ActualizarClienteHandler(ApplicationDbContext context, IMapper mapper, IDashboardService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
            
        }

        public async Task<Response<int>> Handle(ActualizarClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var l = await _context.clientes.FindAsync(request.id);
                l.nombre = request.nombre;
                l.apellido = request.apellido;

                await _context.SaveChangesAsync();

                return new Response<int>(l.id, "El nombre se ha actualizado");
            }
            catch(Exception ex)
            {
                var log = new LogsDto();
                log.datos = JsonSerializer.Serialize(request);
                log.fecha = DateTime.Now;
                log.nombreFuncion = "ActualizarCliente()";
                log.response = ex.Message;
                await _service.CreateLog(log);
                throw;
            }
        }
    }
}
