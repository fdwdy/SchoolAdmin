using System.Data.Entity.Migrations;

namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    public partial class InsertPhonesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Phones (ID, Number, EmployeeId) " +
                "SELECT NEWID() AS Expr1, Phone, ID " +
                "FROM Employees");
        }

        public override void Down()
        {
            Sql("UPDATE dbo.Employees " +
                "SET Phone = phone.Number " +
                "FROM Employees e LEFT JOIN Phones phone ON e.ID = phone.EmployeeId");
        }
    }
}
