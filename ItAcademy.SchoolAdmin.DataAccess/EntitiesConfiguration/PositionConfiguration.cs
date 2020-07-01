using System.Data.Entity.ModelConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration
{
    public class PositionConfiguration : EntityTypeConfiguration<PositionDb>
    {
        public PositionConfiguration()
        {
            ToTable("Positions");
            HasKey(e => e.Id);
            HasIndex(e => e.Name)
                .IsUnique();
            Property(e => e.Id).HasColumnName("ID");
            Property(e => e.Name).HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);
            Property(e => e.MaxEmployees).HasColumnName("MaxEmployees");
        }
    }
}
