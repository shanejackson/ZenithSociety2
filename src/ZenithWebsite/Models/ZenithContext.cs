using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Models;
using ZenithWebsite.Models.RoleViewModels;


namespace ZenithWebsite.Models
{
    public class ZenithContext : IdentityDbContext<ApplicationUser>
    {
        public ZenithContext(DbContextOptions<ZenithContext> options)
            : base(options) { }

       
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<IdentityRoleViewModel> IdentityRoleViewModel { get; set; }
       


    }
}
