using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Wrappers;
using ApplicationCore.DTOs.Logs;


namespace ApplicationCore.Commands.LogsR
{
    public class CreateLogsCommand :  LogsDto, IRequest<Response<int>>
    {
    }
}
