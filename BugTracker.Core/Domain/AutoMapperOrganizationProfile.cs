using AutoMapper;
using BugTracker.Core.DTO.TicketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Core.Domain.Entities;

namespace BugTracker.Core.Domain
{
    public class AutoMapperOrganizationProfile : Profile
    {
        public AutoMapperOrganizationProfile()
        {
            CreateMap<Ticket, TicketResponseDTO>();
            CreateMap<TicketUpdateDTO, Ticket>();
        }
    }
}
