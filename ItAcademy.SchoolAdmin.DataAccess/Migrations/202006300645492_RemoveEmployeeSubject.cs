namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveEmployeeSubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeSubjects", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeSubjects", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.EmployeeSubjects", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeSubjects", new[] { "SubjectId" });
            DropTable("dbo.EmployeeSubjects");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeSubjects",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        SubjectId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.SubjectId });

            CreateIndex("dbo.EmployeeSubjects", "SubjectId");
            CreateIndex("dbo.EmployeeSubjects", "EmployeeId");
            AddForeignKey("dbo.EmployeeSubjects", "SubjectId", "dbo.Subjects", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSubjects", "EmployeeId", "dbo.Employees", "ID", cascadeDelete: true);
        }
    }
}
