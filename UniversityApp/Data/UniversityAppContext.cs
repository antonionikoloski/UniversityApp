#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnversityApp.Models;

namespace UniversityApp.Data
{
    public class UniversityAppContext : DbContext
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
           



            builder.Entity<Subjects>()
           .HasOne<Teachers>(p => p.Teachers2)
          .WithMany(p => p.Subjects2)
       
          .HasForeignKey(p => p.SecondTeacherId);

        }

    }
}
