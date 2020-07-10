namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPhonesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Number = c.String(),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Phones", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Phones", new[] { "EmployeeId" });
            DropTable("dbo.Phones");
        }
    }
}
