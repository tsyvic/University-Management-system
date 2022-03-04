namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseModels", newName: "Courses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Courses", newName: "CourseModels");
        }
    }
}
