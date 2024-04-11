using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using ApplicationCore.DTOs.Cliente;

namespace ApplicationCore.Commands.Cliente
{
    public class CreateClienteCommand :  ClienteDto, IRequest<Response<int>>
    {
    }
}
