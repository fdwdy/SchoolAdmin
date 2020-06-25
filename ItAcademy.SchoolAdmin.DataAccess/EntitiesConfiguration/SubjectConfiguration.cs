using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration
{
    internal class SubjectConfiguration : EntityTypeConfiguration<SubjectDb>
    {
        public SubjectConfiguration()
        {
            ToTable("Subjects");
            HasKey(e => e.Id);
            HasIndex(e => e.Name)
                .IsUnique();
            Property(e => e.Id).HasColumnName("ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
