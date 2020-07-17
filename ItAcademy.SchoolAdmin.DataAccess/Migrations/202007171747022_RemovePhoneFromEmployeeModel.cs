namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemovePhoneFromEmployeeModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Phone");
        }

        public override void Down()
        {
            AddColumn("dbo.Employees", "Phone", c => c.String(maxLength: 255));
        }
    }
}
