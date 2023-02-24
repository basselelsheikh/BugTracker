using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Project>? Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Project>().ToTable("Projects");
        
            


        }

    }
}
