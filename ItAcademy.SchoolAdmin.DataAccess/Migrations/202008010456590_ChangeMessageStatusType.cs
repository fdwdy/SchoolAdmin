namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeMessageStatusType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Status", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Messages", "Status", c => c.String());
        }
    }
}
