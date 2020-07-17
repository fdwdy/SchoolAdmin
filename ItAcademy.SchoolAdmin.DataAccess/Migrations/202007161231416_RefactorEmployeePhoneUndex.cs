namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RefactorEmployeePhoneUndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Phones", "Index");
            DropIndex("dbo.Phones", new[] { "EmployeeId" });
            CreateIndex("dbo.Phones", new[] { "Number", "EmployeeId" }, unique: true, name: "IX_PhoneNumbers_Phone_EmployeeId");
        }

        public override void Down()
        {
            DropIndex("dbo.Phones", "IX_PhoneNumbers_Phone_EmployeeId");
            CreateIndex("dbo.Phones", "EmployeeId");
            CreateIndex("dbo.Phones", "Number", unique: true, name: "Index");
        }
    }
}
