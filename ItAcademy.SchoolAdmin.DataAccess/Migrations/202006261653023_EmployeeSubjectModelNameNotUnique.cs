namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EmployeeSubjectModelNameNotUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Subjects", new[] { "Name" });
        }

        public override void Down()
        {
            CreateIndex("dbo.Subjects", "Name", unique: true);
        }
    }
}
