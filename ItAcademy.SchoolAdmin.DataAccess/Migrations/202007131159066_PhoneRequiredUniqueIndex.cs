namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PhoneRequiredUniqueIndex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phones", "Number", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Phones", "Number", unique: true, name: "Index");
        }

        public override void Down()
        {
            DropIndex("dbo.Phones", "Index");
            AlterColumn("dbo.Phones", "Number", c => c.String());
        }
    }
}
