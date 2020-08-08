namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPrimaryPhoneId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PrimaryPhoneId", c => c.String());
            Sql("UPDATE Employees " +
                "SET PrimaryPhoneId = Phones.ID " +
                "FROM Phones, Employees " +
                "WHERE Phones.EmployeeId = Employees.ID");
        }

        public override void Down()
        {
            DropColumn("dbo.Employees", "PrimaryPhoneId");
        }
    }
}
