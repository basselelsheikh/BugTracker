using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BugTracker.Core.Domain;
using BugTracker.UI;

var builder = WebApplication.CreateBuilder(args);
#region Services Configuration
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, int>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, int>>();
builder.Services.AddAutoMapper(typeof(AutoMapperOrganizationProfile));
#endregion
var app = builder.Build();
#region Error Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
#endregion
app.UseStaticFiles(); 
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
