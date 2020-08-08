namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPrimaryPhoneForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employees", "PrimaryPhoneId");
            AddForeignKey("dbo.Employees", "PrimaryPhoneId", "dbo.Phones", "ID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PrimaryPhoneId", "dbo.Phones");
            DropIndex("dbo.Employees", new[] { "PrimaryPhoneId" });
        }
    }
}
