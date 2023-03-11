using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace BugTracker.UI
{
    public class IdentitySeed
    {
        private readonly Roles[] roles = (Roles[])Enum.GetValues(typeof(Roles));
        private readonly UserManager<ApplicationUser> _userManager;        
        private readonly RoleManager<ApplicationRole> _roleManager;        
        public IdentitySeed(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager) { 
            _roleManager = roleManager;
            _userManager = userManager;
        }   
        public void Initialize()
        {
            //create roles and add them to db
            foreach (Roles role in roles)
            {
                if (!_roleManager.Roles.Any(r => r.Name == role.ToString()))
                {
                    _roleManager.CreateAsync(new ApplicationRole(role.ToString()));
                }
            }

            //create demo users
            ApplicationUser demoDev1 = new ApplicationUser()
            {
                Name = "Bassel",
                Email = "bassel@demo.com",
                PhoneNumber = "0293872642",
            };
            ApplicationUser demoDev2 = new ApplicationUser()
            {
                Name = "Ahmed",
                Email = "ahmed@demo.com",
                PhoneNumber = "0987654321",
            };
            ApplicationUser demoPM = new ApplicationUser()
            {
                Name = "Kareem",
                Email = "kareem@demo.com",
                PhoneNumber = "0129587346",
            };
            ApplicationUser demoAdmin = new ApplicationUser()
            {
                Name = "Mohammad",
                Email = "mohammad@demo.com",
                PhoneNumber = "0238530987",
            };

            //add demo users to db and assign roles
            if (!_userManager.Users.Any(u => u.Name == demoDev1.Name))
            {
                _userManager.CreateAsync(demoDev1);
                _userManager.AddToRoleAsync(demoDev1, Roles.Developer.ToString());
            }
            if (!_userManager.Users.Any(u => u.Name == demoDev2.Name))
            {
                _userManager.CreateAsync(demoDev2);
                _userManager.AddToRoleAsync(demoDev1, Roles.Developer.ToString());
            }
            if (!_userManager.Users.Any(u => u.Name == demoAdmin.Name))
            {
                _userManager.CreateAsync(demoAdmin);
                _userManager.AddToRoleAsync(demoDev1, Roles.Admin.ToString());
            }
            if (!_userManager.Users.Any(u => u.Name == demoPM.Name))
            {
                _userManager.CreateAsync(demoPM);
                _userManager.AddToRoleAsync(demoDev1, Roles.ProjectManager.ToString());
            }
        }
    }
}