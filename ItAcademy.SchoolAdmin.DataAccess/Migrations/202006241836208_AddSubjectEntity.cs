namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSubjectEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SubjectDbEmployeeDbs",
                c => new
                    {
                        SubjectDb_Id = c.Int(nullable: false),
                        EmployeeDb_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SubjectDb_Id, t.EmployeeDb_Id })
                .ForeignKey("dbo.SubjectDbs", t => t.SubjectDb_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeDb_Id, cascadeDelete: true)
                .Index(t => t.SubjectDb_Id)
                .Index(t => t.EmployeeDb_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.SubjectDbEmployeeDbs", "EmployeeDb_Id", "dbo.Employees");
            DropForeignKey("dbo.SubjectDbEmployeeDbs", "SubjectDb_Id", "dbo.SubjectDbs");
            DropIndex("dbo.SubjectDbEmployeeDbs", new[] { "EmployeeDb_Id" });
            DropIndex("dbo.SubjectDbEmployeeDbs", new[] { "SubjectDb_Id" });
            DropTable("dbo.SubjectDbEmployeeDbs");
            DropTable("dbo.SubjectDbs");
        }
    }
}
