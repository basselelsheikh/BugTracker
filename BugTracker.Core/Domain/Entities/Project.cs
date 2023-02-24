﻿using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Project domain model class
    /// </summary>
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> Team { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public string? RepoLink { get; set; }
    }
}