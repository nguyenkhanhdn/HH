using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HH.Models
{
    public class HHDbContext:DbContext
    {
        public HHDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
    }
}