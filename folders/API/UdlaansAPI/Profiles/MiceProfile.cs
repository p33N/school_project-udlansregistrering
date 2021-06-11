using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Profiles
{
    public class MiceProfile : Profile
    {
        public MiceProfile()
        {
            CreateMap<Entities.Mouse, Models.MouseDto>();
            CreateMap<Models.MouseToAddDto, Entities.Mouse>();
            CreateMap<Models.MouseToUpdateDto, Entities.Mouse>();
            CreateMap<Entities.Mouse, Models.MouseToUpdateDto>();
        }
    }
}
