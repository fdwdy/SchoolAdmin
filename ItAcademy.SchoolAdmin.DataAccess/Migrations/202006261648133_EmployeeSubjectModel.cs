namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EmployeeSubjectModel : DbMigration
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
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true);
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

            AddForeignKey("dbo.EmployeeSubjects", "SubjectId", "dbo.Subjects", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSubjects", "EmployeeId", "dbo.Employees", "ID", cascadeDelete: true);
        }
    }
}
