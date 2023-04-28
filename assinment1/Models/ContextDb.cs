using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assinment1.Models
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options)
  : base(options)
        {

        }

        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Professor_course> Professor_Courses { get; set; }
        public virtual DbSet<Professors> Professors { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor_course>().HasKey(sc => new { sc.Prof_Id, sc.Course_code });
        }



    }
}
