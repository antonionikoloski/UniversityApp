#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Areas.Identity.Data;
using UnversityApp.Models;

namespace UniversityApp.Data
{
    public class UniversityAppContext : IdentityDbContext<UniversityAppUser>
    {
        public UniversityAppContext (DbContextOptions<UniversityAppContext> options)
            : base(options)
        {
        }

        public DbSet<UnversityApp.Models.Teachers> Teachers { get; set; }

        public DbSet<UnversityApp.Models.Subjects> Subjects { get; set; }

        public DbSet<UnversityApp.Models.Students> Students { get; set; }

        public DbSet<EnrollMent> Enrollment { get; set; }


        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EnrollMent>()
                .HasOne<Students>(p => p.Students)
                .WithMany(p => p.EnrollMent)
          
                .HasForeignKey(p => p.Pom1Id);

            builder.Entity<EnrollMent>()
                .HasOne(p => p.Subjects)
                .WithMany(p=>p.EnrollMent)
             
                .HasForeignKey(p => p.Pom2Id);

            builder.Entity<Subjects>()
             .HasOne<Teachers>(p => p.Teachers1)
            .WithMany(p => p.Subjects)
     
            .HasForeignKey(p => p.FirstTeacherId);


           

           



       
       

        }

    }
}
