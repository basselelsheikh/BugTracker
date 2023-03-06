using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using BugTracker.UI.DTO.ProjectDTO;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Core.Domain.Entities;
using AutoMapper;

namespace BugTracker.UI.ViewComponents
{
    public class ProjectsTableViewComponent : ViewComponent
    {
        private readonly IProjectGetter _ProjectGetter;
        private readonly IMapper _mapper;
        public ProjectsTableViewComponent(IProjectGetter ProjectGetter, IMapper mapper)
        {
            _ProjectGetter = ProjectGetter;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? developerUsername, string? pmUsername)
        {
            if (pmUsername is not null)
            {
                Project? project = await _ProjectGetter.GetManagedProject(pmUsername);
                if (project is not null)
                {
                    return View(_mapper.Map<ProjectResponseDTO>(project));
                }
                else
                {
                    //NOTE: raise exception, project not found
                }
            }
            else if (developerUsername is not null)
            {
                Project? project = await _ProjectGetter.GetProjectAssignedToDeveloper(developerUsername);
                if (project is not null)
                {
                    return View(_mapper.Map<ProjectResponseDTO>(project));
                }
                else
                {
                    //NOTE: raise exception, project not found
                }
            }
            else
            {
                //If no condition provided, return all projects, this is for admin roles only
                IEnumerable<Project>? projects = await _ProjectGetter.GetAllProjects();
                if (projects is not null)
                {
                    return View(projects.Select(p => _mapper.Map<ProjectResponseDTO>(p)));
                }
            }
            return View();
        }
    }
}