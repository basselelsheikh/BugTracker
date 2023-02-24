using BugTracker.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
/*builder.Services.AddIdentity<ApplicationUser,ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserStore<<UserStore<ApplicationUser,ApplicationRole,ApplicationDbContext, int>>()
    .Add*/
var app = builder.Build();
app.UseStaticFiles();   
app.MapControllers();   
app.Run();
