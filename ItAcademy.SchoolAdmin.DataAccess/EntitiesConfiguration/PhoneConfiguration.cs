using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration
{
    public class PhoneConfiguration : EntityTypeConfiguration<PhoneDb>
    {
        public PhoneConfiguration()
        {
            ToTable("Phones");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("ID");
            Property(e => e.Number).HasColumnName("Number").IsRequired().HasMaxLength(255).HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));
            HasRequired(s => s.Employee).WithMany(g => g.Phones).HasForeignKey(s => s.EmployeeId);
        }
    }
}
