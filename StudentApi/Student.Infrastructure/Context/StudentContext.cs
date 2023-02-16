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
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<LessonNote> LessonNote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("student");
            modelBuilder.Entity<Lesson>().ToTable("lesson");
            modelBuilder.Entity<LessonNote>().ToTable("lesson_note");

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres",
                b=> b.MigrationsAssembly("StudentInfo.API"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
