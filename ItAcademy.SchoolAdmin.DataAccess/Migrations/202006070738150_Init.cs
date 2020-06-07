using System.Data.Entity.Migrations;

namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false, maxLength: 255),
                        surname = c.String(nullable: false, maxLength: 255),
                        middlename = c.String(nullable: false, maxLength: 255),
                        birth_date = c.DateTime(nullable: false),
                        email = c.String(nullable: false, maxLength: 255),
                        phone = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
        }

        public override void Down()
        {
            DropTable("dbo.employee");
        }
    }
}
