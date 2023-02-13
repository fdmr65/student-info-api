using Microsoft.EntityFrameworkCore;
using StudentInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Infrastructure.Context
{
    public  class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("student");

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
