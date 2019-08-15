using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using static BANDS.Models.IdentityModel.ApplicationDbContext;

namespace BANDS.Models
{
    public class IdentityModel
    {


        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Band> Bands { get; set; }
            public DbSet<Member> Members { get; set; }

            public DbSet<Event> Events { get;set; }
            public DbSet<EventSchedule> EventSchedules{ get; set; }
             
            public ApplicationDbContext()
                : base("DefaultConnections", throwIfV1Schema: false)
            {
            }
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
            public class ApplicationUser : IdentityUser
            {
                public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
                {
                    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                    // Add custom user claims here
                    return userIdentity;
                }
            }

            //protected override void OnModelCreating(DbModelBuilder modelBuilder)
            //{
            //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //    modelBuilder.Entity<EventSchedule>()
            //        .Map(t => t.("BandId")
                       
            //            .ToTable("Band"));
            //}
        }

    }
}