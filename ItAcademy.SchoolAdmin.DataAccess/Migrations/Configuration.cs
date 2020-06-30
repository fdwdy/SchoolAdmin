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

            ////var employeeSubjects = new List<EmployeeSubject>
            ////{
            ////    new EmployeeSubject
            ////    {
            ////        EmployeeId = context.Employees.FirstOrDefault(e => e.Name == "Petr").Id,
            ////        SubjectId = context.Subjects.FirstOrDefault(s => s.Name == "English").Id,
            ////    },
            ////    new EmployeeSubject
            ////    {
            ////        EmployeeId = context.Employees.FirstOrDefault(e => e.Name == "Sidor").Id,
            ////        SubjectId = context.Subjects.FirstOrDefault(s => s.Name == "Russian").Id,
            ////    },
            ////};

            ////foreach (EmployeeSubject e in employeeSubjects)
            ////{
            ////    var empDb = context.EmployeeSubjects.Where(
            ////        s =>
            ////             s.Employee.Id == e.EmployeeId &&
            ////             s.Subject.Id == e.SubjectId).SingleOrDefault();
            ////    if (empDb == null)
            ////    {
            ////        context.EmployeeSubjects.AddOrUpdate(e);
            ////    }
            ////}

            ////context.SaveChanges();
        }
    }
}
