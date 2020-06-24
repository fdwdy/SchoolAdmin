﻿using System.Data.Entity.ModelConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration
{
    internal class EmployeeConfiguration : EntityTypeConfiguration<EmployeeDb>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("ID");
            Property(e => e.Name).HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Middlename).HasColumnName("Middlename")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Surname).HasColumnName("Surname")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Phone).HasColumnName("Phone")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Email).HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.BirthDate).HasColumnName("Birthdate")
                .IsRequired();
        }
    }
}
