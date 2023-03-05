using BugTracker.Core.DTO.ProjectDTO;
using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.UI.ViewComponents
{
    public class ProjectsTableViewComponent : ViewComponent
    {
        private readonly IProjectGetter _ProjectGetter;
        public ProjectsTableViewComponent(IProjectGetter ProjectGetter)
        {
            _ProjectGetter = ProjectGetter;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? developerUsername, string? pmUsername)
        {
            if (pmUsername is not null)
            {
                IEnumerable<ProjectResponseDTO>? Projects = await _ProjectGetter.GetManagedProject(pmUsername);
                return View(Projects);
            }
            if (developerUsername is not null)
            {
                IEnumerable<ProjectResponseDTO>? Projects = await _ProjectGetter.GetProjectAssignedToDeveloper(developerUsername);
                return View(Projects);
            }
            else
            {
                //If no condition provided, return all projects, this is for admin roles only
                IEnumerable<ProjectResponseDTO>? Projects = await _ProjectGetter.GetProjects();
                return View(Projects);
            }
        }
    }
}