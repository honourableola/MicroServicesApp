using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Entities
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext>options) : base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<User>().HasIndex(s => s.Email).IsUnique();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
