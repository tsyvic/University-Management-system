namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attentence",
                c => new
                    {
                        AttentenceId = c.Int(nullable: false, identity: true),
                        Start_Time = c.DateTime(nullable: false),
                        End_Time = c.DateTime(nullable: false),
                        Comments = c.String(),
                        Status = c.String(),
                        TrainerId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttentenceId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attentence", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Attentence", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attentence", "CourseId", "dbo.Courses");
            DropIndex("dbo.Attentence", new[] { "CourseId" });
            DropIndex("dbo.Attentence", new[] { "StudentId" });
            DropIndex("dbo.Attentence", new[] { "TrainerId" });
            DropTable("dbo.Attentence");
        }
    }
}
