using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();
            modelBuilder.Entity<Student>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .HasMany(x => x.StudentCourses)
                .WithOne(x => x.Student);

            modelBuilder.Entity<Course>()
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();
            modelBuilder.Entity<Course>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Course>()
                .HasMany(x => x.StudentCourses)
                .WithOne(x => x.Course);

            modelBuilder.Entity<StudentCourse>()
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Course)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
