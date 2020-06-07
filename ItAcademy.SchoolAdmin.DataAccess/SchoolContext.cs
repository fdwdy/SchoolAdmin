namespace ItAcademy.SchoolAdmin.DataAccess
{
    using System.Data.Entity;
    using ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration;
    using ItAcademy.SchoolAdmin.DataAccess.Models;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("SchoolAdmin")
        {
            Database.SetInitializer<SchoolContext>(null);
        }

        public virtual DbSet<EmployeeDb> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }
    }
}
