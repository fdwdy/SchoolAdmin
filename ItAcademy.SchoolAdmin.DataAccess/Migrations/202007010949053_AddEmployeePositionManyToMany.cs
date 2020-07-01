namespace ItAcademy.SchoolAdmin.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddEmployeePositionManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        MaxEmployees = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);

            CreateTable(
                "dbo.EmployeePositions",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        PositionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.PositionId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PositionId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.EmployeePositions", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.EmployeePositions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeePositions", new[] { "PositionId" });
            DropIndex("dbo.EmployeePositions", new[] { "EmployeeId" });
            DropIndex("dbo.Positions", new[] { "Name" });
            DropTable("dbo.EmployeePositions");
            DropTable("dbo.Positions");
        }
    }
}
