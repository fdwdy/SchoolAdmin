using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    public partial class InsertPhonesData : DbMigration
    {
        public override void Up()
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }

            using (var context = new SchoolContext())
            {
                var employees = context.Employees;
                foreach (var emp in employees)
                {
                    var phone = new PhoneDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Number = emp.Phone,
                    };

                    emp.Phones = new List<PhoneDb>
                    {
                        phone,
                    };
                }

                context.SaveChanges();
            }
        }

        public override void Down()
        {
            Sql("UPDATE dbo.Employees " +
                "SET Phone = phone.Number " +
                "FROM Employees e LEFT JOIN Phones phone ON e.ID = phone.EmployeeId");
        }
    }
}
