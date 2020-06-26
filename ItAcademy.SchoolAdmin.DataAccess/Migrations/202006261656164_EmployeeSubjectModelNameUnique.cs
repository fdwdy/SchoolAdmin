namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EmployeeSubjectModelNameUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Subjects", "Name", unique: true);
        }

        public override void Down()
        {
            DropIndex("dbo.Subjects", new[] { "Name" });
        }
    }
}
