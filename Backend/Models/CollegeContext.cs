using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class CollegeContext : DbContext
{
    public CollegeContext()
    {
    }

    public CollegeContext(DbContextOptions<CollegeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGrade> StudentGrades { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("ConnectionString");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("Grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");

            /*entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grade_Teacher");*/
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");

            /*entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Gender");*/
        });

        modelBuilder.Entity<StudentGrade>(entity =>
        {
            entity.ToTable("StudentGrade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GradeId).HasColumnName("gradeId");
            entity.Property(e => e.Section)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("section");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            /*entity.HasOne(d => d.Grade).WithMany(p => p.StudentGrades)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_StudentGrade_Grade");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentGrades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentGrade_Student");*/
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");

            /*entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Gender)
                .HasConstraintName("FK_Teacher_Gender");*/
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
