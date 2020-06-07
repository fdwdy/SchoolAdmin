using System.Data.Entity.ModelConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration
{
    internal class EmployeeConfiguration : EntityTypeConfiguration<EmployeeDb>
    {
        public EmployeeConfiguration()
        {
            ToTable("employee");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id");
            Property(e => e.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Middlename).HasColumnName("middlename")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Surname).HasColumnName("surname")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Phone).HasColumnName("phone")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.Email).HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.BirthDate).HasColumnName("birth_date")
                .IsRequired();
        }
    }
}
