namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using ItAcademy.SchoolAdmin.DataAccess.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            context.Employees.AddOrUpdate(
                x => x.Id,
                new EmployeeDb()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "Ivan",
                    Middlename = "Ivanovich",
                    Surname = "Ivanov",
                    BirthDate = System.DateTime.Now,
                    Email = "ivanov@mail.rr",
                    Phone = "+111 00 00",
                },
                new EmployeeDb()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "Petr",
                    Middlename = "Petrovich",
                    Surname = "Petrov",
                    BirthDate = System.DateTime.Now,
                    Email = "perov@mail.rr",
                    Phone = "+222 00 00",
                },
                new EmployeeDb()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "Sidor",
                    Middlename = "Sidorovich",
                    Surname = "Sidorov",
                    BirthDate = System.DateTime.Now,
                    Email = "sidorov@mail.rr",
                    Phone = "+333 00 00",
                });
        }
    }
}
