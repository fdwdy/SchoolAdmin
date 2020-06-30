namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddEmployeeSubjectManyToMany : DbMigration
    {
        public override void Up()
        {
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
        }

        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.EmployeeSubjects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeSubjects", new[] { "SubjectId" });
            DropIndex("dbo.EmployeeSubjects", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeSubjects");
        }
    }
}
