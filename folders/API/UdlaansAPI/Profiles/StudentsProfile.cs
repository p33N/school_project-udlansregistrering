using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Entities.Student, Models.StudentDto>();
            CreateMap<Models.StudentToAddDto, Entities.Student>();
            CreateMap<Models.StudentToUpdateDto, Entities.Student>();
            CreateMap<Entities.Student, Models.StudentToUpdateDto>();
        }
    }
}
