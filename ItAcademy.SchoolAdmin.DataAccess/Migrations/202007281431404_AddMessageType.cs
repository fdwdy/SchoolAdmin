namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddMessageType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "MessageType", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Employees SET MessageType = 0");
        }

        public override void Down()
        {
            DropColumn("dbo.Employees", "MessageType");
        }
    }
}
