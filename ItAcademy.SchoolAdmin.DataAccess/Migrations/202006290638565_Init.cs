namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Surname = c.String(nullable: false, maxLength: 255),
                        Middlename = c.String(nullable: false, maxLength: 255),
                        Birthdate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.EmployeeSubjects",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        SubjectId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.SubjectId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.SubjectId);

            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.EmployeeSubjects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Subjects", new[] { "Name" });
            DropIndex("dbo.EmployeeSubjects", new[] { "SubjectId" });
            DropIndex("dbo.EmployeeSubjects", new[] { "EmployeeId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.EmployeeSubjects");
            DropTable("dbo.Employees");
        }
    }
}
