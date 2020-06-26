namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSubjects : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.employee", newName: "Employees");
            RenameColumn(table: "dbo.Employees", name: "birth_date", newName: "Birthdate");
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);

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
            DropIndex("dbo.Subjects", new[] { "Name" });
            DropTable("dbo.EmployeeSubjects");
            DropTable("dbo.Subjects");
            RenameColumn(table: "dbo.Employees", name: "Birthdate", newName: "birth_date");
            RenameTable(name: "dbo.Employees", newName: "employee");
        }
    }
}
