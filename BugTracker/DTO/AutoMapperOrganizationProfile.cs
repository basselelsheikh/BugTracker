using AutoMapper;
using BugTracker.UI.DTO.TicketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Core.Domain.Entities;
using BugTracker.UI.DTO.ProjectDTO;

namespace BugTracker.Core.Domain
{
    public class AutoMapperOrganizationProfile : Profile
    {
        public AutoMapperOrganizationProfile()
        {
            CreateMap<Ticket, TicketResponseDTO>();
            CreateMap<TicketUpdateDTO, Ticket>()
                .ForMember(t => t.AssignedDevs, opt => opt.Ignore());
            CreateMap<TicketAddDTO, Ticket>()
                .ForMember(t => t.AssignedDevs, opt => opt.Ignore());
            CreateMap<Project, ProjectResponseDTO>();
            CreateMap<Ticket, TicketUpdateDTO>()
                .ForMember(t => t.AssignedDevs, opt => opt.Ignore());

        }
    }
}
