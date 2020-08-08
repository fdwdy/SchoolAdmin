namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangePrimaryPhoneIdDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PrimaryPhoneId", c => c.String(maxLength: 128));
        }

        public override void Down()
        {
            AlterColumn("dbo.Employees", "PrimaryPhoneId", c => c.String());
        }
    }
}
