using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration
{
    public class MessageConfiguration : EntityTypeConfiguration<MessageDb>
    {
        public MessageConfiguration()
        {
            ToTable("Messages");
            Property(e => e.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Type).HasColumnName("Type");
            Property(e => e.RecipientId).HasColumnName("RecipientId");
            Property(e => e.Status).HasColumnName("Status");
            Property(e => e.Text).HasColumnName("Text");
            Property(e => e.Time).HasColumnName("Time");
        }
    }
}
