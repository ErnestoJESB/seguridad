using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using ApplicationCore.Commands.Cliente;
using ApplicationCore.Commands.LogsR;
using ApplicationCore.DTOs.Logs;
using Microsoft.VisualBasic;
using ApplicationCore.DTOs.Cliente;

namespace Host.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly IMediator _mediator;
        public DashboardController(IDashboardService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [Route("getData")]
        [HttpGet]

        public async Task<IActionResult> GetUsuarios()
        {
            var result = await _service.GetData();
            return Ok(result);
        }

        //<sumary>
        // Create
        //</sumary>
        //<returns></returns>

        [HttpPost("createCliente")]
        public async Task<ActionResult<Response<int>>> CreateCliente(CreateClienteCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetIp")]
        public async Task<IActionResult> GetIp()
        {
            var result = await _service.GetIp();
            return Ok(result);
        }

        [HttpPost("createlog")]
        public async Task<ActionResult<Response<int>>> createlog([FromBody] LogsDto request)
        {
            var result = await _service.CreateLog(request);
            return Ok(result);
        }

        [HttpPut("ActualizarCliente/{id}")]
        public async Task<ActionResult<Response<int>>> ActualizarCliente(ActualizarClienteCommand request, int id)
        {
            request.id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("eliminarCliente/{id}")]
        public async Task<ActionResult<Response<int>>> EliminarCliente(int id)
        {
            var command = new EliminarClienteCommand{ Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [Route("getDataPaginate")]
        [HttpGet]
        public async Task<IActionResult> GetDataPaginate()
        {
            var result = await _service.GetDataPaginate();
            return Ok(result);
        }
    }
}
