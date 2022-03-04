namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addclsse : DbMigration
    {
        public override void Up()
        {
                        CreateTable(
                "dbo.Classes",
                c => new
                {
                    ClassId = c.Int(nullable: false, identity: true),
                    Descriptions = c.String(),
                    CourseId = c.Int(),
                    TrainerId = c.Int(),
                    StudentId = c.Int(),
                })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.CourseModels", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "CourseId", "dbo.CourseModels");
            DropForeignKey("dbo.Classes", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Classes", "StudentId", "dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
