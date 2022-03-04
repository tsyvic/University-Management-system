namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plsfixs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attentence", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attentence", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Classes", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Classes", "StudentId", "dbo.Students");
            DropIndex("dbo.Attentence", new[] { "TrainerId" });
            DropIndex("dbo.Attentence", new[] { "CourseId" });
            DropIndex("dbo.Classes", new[] { "StudentId" });
            DropIndex("dbo.Classes", new[] { "CourseId" });
            AddColumn("dbo.Students", "ClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "Course_Name", c => c.String());
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
            DropColumn("dbo.Attentence", "TrainerId");
            DropColumn("dbo.Attentence", "CourseId");
            DropColumn("dbo.Classes", "StudentId");
            DropColumn("dbo.Classes", "CourseId");
            DropTable("dbo.Courses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Course_Name = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            AddColumn("dbo.Classes", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Attentence", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Attentence", "TrainerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropColumn("dbo.Classes", "Course_Name");
            DropColumn("dbo.Students", "ClassId");
            CreateIndex("dbo.Classes", "CourseId");
            CreateIndex("dbo.Classes", "StudentId");
            CreateIndex("dbo.Attentence", "CourseId");
            CreateIndex("dbo.Attentence", "TrainerId");
            AddForeignKey("dbo.Classes", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Classes", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Attentence", "TrainerId", "dbo.Trainers", "TrainerId", cascadeDelete: true);
            AddForeignKey("dbo.Attentence", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
