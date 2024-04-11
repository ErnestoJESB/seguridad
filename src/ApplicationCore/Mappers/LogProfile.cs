﻿using ApplicationCore.Commands.LogsR;
using ApplicationCore.DTOs.Logs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappers
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogsDto, logs>()
                .ForMember(x => x.id, y => y.Ignore());
        }
    }
}