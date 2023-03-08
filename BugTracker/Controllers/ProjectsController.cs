using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using BugTracker.Core.Services;
using BugTracker.UI.DTO.TicketDTO;
using BugTracker.UI.DTO.ProjectDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;

namespace BugTracker.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class ProjectsController : Controller
    {

        private readonly ITicketAdder _projectAdder;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProjectGetter _projectGetter;
        private readonly IProjectDeleter _projectDeleter;
        private readonly IProjectUpdater _projectUpdater;
        private readonly IMapper _mapper;
        public ProjectsController(IProjectUpdater projectUpdater, IProjectDeleter projectDeleter, IProjectGetter projectGetter, ITicketAdder projectAdder, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _projectGetter = projectGetter;
            _projectAdder = projectAdder;
            _projectDeleter = projectDeleter;
            _projectUpdater = projectUpdater;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("{projectID:int}")]
        public async Task<IActionResult> Details(int projectID)
        {
            Project? project = await _projectGetter.GetProject(projectID);
            if (project is not null)
            {
                return View(project);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> CreateTicket(int projectId)
        {
            List<ApplicationUser> developersInProject = await _userManager.Users.Where(u => u.AssignedProjectId == projectId).ToListAsync();
            List<DeveloperCheckboxItem> _checkboxItems = new List<DeveloperCheckboxItem>();
            foreach (ApplicationUser developer in developersInProject)
            {
                _checkboxItems.Add(new DeveloperCheckboxItem()
                {
                    DeveloperName = developer.Name,
                    DeveloperId = developer.Id,
                });
            }
            TicketAddDTO model = new()
            {
                AssignedDevs = _checkboxItems
            };
            return View(model);

        }
        [HttpPost("{projectId:int}")]
        public async Task<IActionResult> CreateTicket(TicketAddDTO model, int projectId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Ticket project = _mapper.Map<Ticket>(model);
            project.AssignedDevs = new List<ApplicationUser>();
            foreach (DeveloperCheckboxItem temp in model.AssignedDevs)
            {
                if(temp.IsChecked)
                {
                    ApplicationUser dev = await _userManager.FindByIdAsync(temp.DeveloperId.ToString());
                    project.AssignedDevs.Add(dev);
                }
            }
            await _projectAdder.AddTicket(project);
            return RedirectToAction(nameof(Details), new { id = projectId });
        }

        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> Delete(int projectId)
        {
            await _projectDeleter.DeleteProject(projectId);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> Edit(int projectId)
        {
            Project? project = await _projectGetter.GetProject(projectId);
            if (project is not null)
            {
                ProjectUpdateDTO model = _mapper.Map<ProjectUpdateDTO>(project);
                List<DeveloperCheckboxItem> _checkboxItems = new();
                List<ApplicationUser> availableDevs = await
                    _userManager.Users.Where(u => u.AssignedProjectId == null).ToListAsync();
                foreach (ApplicationUser developer in availableDevs)
                {
                    if (project.Team.Contains(developer))
                    {
                        _checkboxItems.Add(new DeveloperCheckboxItem()
                        {
                            DeveloperName = developer.Name,
                            DeveloperId = developer.Id,
                            IsChecked = true
                        });
                    }
                    else
                    {
                        _checkboxItems.Add(new DeveloperCheckboxItem()
                        {
                            DeveloperName = developer.Name,
                            DeveloperId = developer.Id,
                            IsChecked = false
                        });
                    }
                }
                model.Team = _checkboxItems;
                return View(model);
            }
            else
            {
                return new NotFoundResult();
            }

        }
        [HttpPost("{projectId:int}")]
        public async Task<IActionResult> Edit(ProjectUpdateDTO model, int projectId)
        {
            if (!ModelState.IsValid) { 
                return View(model); 
            }
            Project project = _mapper.Map<Project>(model);
            project.Team = new List<ApplicationUser>();
            foreach (DeveloperCheckboxItem temp in model.Team)
            {
                if (temp.IsChecked)
                {
                    ApplicationUser dev = await _userManager.FindByIdAsync(temp.DeveloperId.ToString());
                    project.Team.Add(dev);
                }
            }
            await _projectUpdater.UpdateProject(project);
            return RedirectToAction(nameof(Details), new { id = projectId });
        }
    }
}
