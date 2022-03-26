using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Entities
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(s => s.Email).IsUnique();
        }

        public DbSet<Student> Students { get; set; }
    }
}
