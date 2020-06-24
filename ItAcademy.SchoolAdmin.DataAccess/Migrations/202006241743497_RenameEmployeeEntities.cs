namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameEmployeeEntities : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.employee", newName: "Employees");
            RenameColumn(table: "dbo.Employees", name: "birth_date", newName: "Birthdate");
        }

        public override void Down()
        {
            RenameColumn(table: "dbo.Employees", name: "Birthdate", newName: "birth_date");
            RenameTable(name: "dbo.Employees", newName: "employee");
        }
    }
}
