namespace CrudApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeOrganization", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "EmployeeAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeContact", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeeContact", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeAddress", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String());
            DropColumn("dbo.Employees", "EmployeeOrganization");
        }
    }
}
