using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Profiles
{
    public class KeyboardsProfile : Profile
    {
        public KeyboardsProfile()
        {
            CreateMap<Entities.Keyboard, Models.KeyboardDto>();
            CreateMap<Models.KeyboardToAddDto, Entities.Keyboard>();
            CreateMap<Models.KeyboardToUpdateDto, Entities.Keyboard>();
            CreateMap<Entities.Keyboard, Models.KeyboardToUpdateDto>();
        }
    }
}
