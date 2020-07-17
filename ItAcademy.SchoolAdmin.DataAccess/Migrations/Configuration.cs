namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
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
                },
                new EmployeeDb()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "Petr",
                    Middlename = "Petrovich",
                    Surname = "Petrov",
                    BirthDate = System.DateTime.Now,
                    Email = "perov@mail.rr",
                },
                new EmployeeDb()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "Sidor",
                    Middlename = "Sidorovich",
                    Surname = "Sidorov",
                    BirthDate = System.DateTime.Now,
                    Email = "sidorov@mail.rr",
                });

            context.SaveChanges();

            var subjects = new List<SubjectDb>
            {
                new SubjectDb
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "English",
                },
                new SubjectDb
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "Russian",
                },
                new SubjectDb
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Name = "German",
                }
            };

            foreach (SubjectDb e in subjects)
            {
                var sbj = context.Subjects.SingleOrDefault(s => s.Name == e.Name);
                if (sbj == null)
                {
                    context.Subjects.AddOrUpdate(e);
                }
            }

            context.SaveChanges();
        }
    }
}
