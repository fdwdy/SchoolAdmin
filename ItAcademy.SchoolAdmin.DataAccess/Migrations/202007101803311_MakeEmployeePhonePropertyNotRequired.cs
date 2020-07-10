namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class MakeEmployeePhonePropertyNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.String(maxLength: 255));
        }

        public override void Down()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
