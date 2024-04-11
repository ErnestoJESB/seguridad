using ApplicationCore.Commands.Cliente;
using ApplicationCore.DTOs.Logs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using Infraestructure.Services;
using MediatR;
using System.Text.Json;

namespace Infraestructure.EnventHandlers.Cliente
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;

        public CreateClienteHandler(ApplicationDbContext context, IMapper mapper, IDashboardService dashboardService)
        {
            _context = context;
            _mapper = mapper;
            _dashboardService = dashboardService;

        }

        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var u = new CreateClienteCommand();
            u.nombre = request.nombre;
            u.apellido = request.apellido;
            var us = _mapper.Map<Domain.Entities.cliente>(u);
            await _context.clientes.AddAsync(us);
            await _context.SaveChangesAsync();

            var res = new Response<int>(us.id, "Registro Creado");

            //Inyeccion de datos al objeto
            var json = JsonSerializer.Serialize(request);
            var log = new LogsDto();
            log.datos = json;
            log.fecha = DateTime.Now;
            log.nombreFuncion = "CreateCliente()";
            log.response =res.Message;
            await _dashboardService.CreateLog(log);
            return res;


            //Inyeccion de datos al objeto
            //var json = JsonSerializer.Serialize(request);

            //var log = new LogsDto();
            //log.datos = json;
            //log.fecha = DateTime.Now;
            //log.nombreFuncion = "CreateCliente()";

            //try
            //{
            //    var u = new CreateClienteCommand();
            //    u.nombre = request.nombre;
            //    u.apellido = request.apellido;

            //    if (!String.IsNullOrEmpty(u.nombre))
            //    {
            //        var us = _mapper.Map<Domain.Entities.cliente>(u);
            //        await _context.clientes.AddAsync(us);
            //        await _context.SaveChangesAsync();
            //        log.response = "200";

            //        return new Response<int>(us.id, "Registro Creado");

            //    }
            //    else
            //    {
            //        throw new ArgumentException("No tienes nombre o qué");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.response = "500";
            //    throw;
            //}
            //finally
            //{
            //    await _dashboardService.CreateLog(log);
            //}




        }
    }
}
