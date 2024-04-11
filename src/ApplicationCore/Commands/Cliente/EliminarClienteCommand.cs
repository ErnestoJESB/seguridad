using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands.Cliente
{
    public class EliminarClienteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
