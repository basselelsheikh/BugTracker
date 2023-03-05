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
        public virtual DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Project>().ToTable("Projects");
            #region Relationships Configuration
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Reporter)
                .WithMany(u => u.ReportedTickets)
                .HasForeignKey(t => t.ReporterId);
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.AssignedDevs)
                .WithMany(u => u.AssignedInTickets);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.ProjectId);
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Ticket)
                .HasForeignKey(c => c.TicketId);
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Team)
                .WithOne(u => u.AssignedProject)
                .HasForeignKey(u => u.AssignedProjectId);
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithOne(u => u.ManagedProject)
                .HasForeignKey<Project>(p => p.ProjectManagerId);
            #endregion
        }

    }
}
