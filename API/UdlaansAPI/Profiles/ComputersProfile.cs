using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Profiles
{
    public class ComputersProfile : Profile
    {
        public ComputersProfile()
        {
            CreateMap<Entities.Computer, Models.ComputerDto>();
            CreateMap<Models.ComputerToAddDto, Entities.Computer>();
            CreateMap<Models.ComputerToUpdateDto, Entities.Computer>();
            CreateMap<Entities.Computer, Models.ComputerToUpdateDto>();
        }
    }
}
