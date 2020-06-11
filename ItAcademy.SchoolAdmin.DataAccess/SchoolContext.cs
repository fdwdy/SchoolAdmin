namespace ItAcademy.SchoolAdmin.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration;
    using ItAcademy.SchoolAdmin.DataAccess.Models;

    public class SchoolContext : DbContext
    {
        public delegate void EventHandler(object sender, OnChangesSavedArgs e);

        public event EventHandler OnChangesSaved;

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

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            OnChangesSaved?.Invoke(this, new OnChangesSavedArgs(this.Employees));
            return result;
        }
    }

}
