using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Profiles
{
    public class ComputerStatusesProfile : Profile
    {
        public ComputerStatusesProfile()
        {
            CreateMap<Entities.ComputerStatus, Models.ComputerDto>();
            CreateMap<Models.ComputerToAddDto, Entities.ComputerStatus>();
            CreateMap<Models.ComputerToUpdateDto, Entities.ComputerStatus>();
            CreateMap<Entities.ComputerStatus, Models.ComputerToUpdateDto>();
        }
    }
}
