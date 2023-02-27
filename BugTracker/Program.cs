using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BugTracker.Core.DTO;

var builder = WebApplication.CreateBuilder(args);
#region Services Configuration
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, int>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, int>>();
builder.Services.AddAutoMapper(typeof(AutoMapperOrganizationProfile));
#endregion
var app = builder.Build();
app.UseStaticFiles(); 
app.UseAuthentication();
app.MapControllers();   
app.Run();
