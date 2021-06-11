using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Profiles
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            CreateMap<Entities.Ticket, Models.TicketDto>();
            CreateMap<Models.TicketToAddDto, Entities.Ticket>();
            CreateMap<Models.TicketToUpdateDto, Entities.Ticket>();
            CreateMap<Entities.Ticket, Models.TicketToUpdateDto>();
        }
    }
}
