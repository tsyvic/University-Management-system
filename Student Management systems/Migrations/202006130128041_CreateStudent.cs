namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStudent : DbMigration
    {
        public override void Up()
        {
            
                        CreateTable(
                "dbo.Classes",
                c => new
                {
                    ClassId = c.Int(nullable: false, identity: true),
                    Course_name = c.String(nullable: false),
                    Descriptions = c.String(),
                    TrainerId = c.Int()
                })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId);


            CreateTable(
                "dbo.Students",
                c => new
                {
                    StudentId = c.Int(nullable: false, identity: true),
                    StudentIdNum = c.Int(),
                    StudentFirstName = c.String(nullable: false, maxLength: 40),
                    StudentLastName = c.String(nullable: false, maxLength: 40),
                    DateofBirth = c.DateTime(nullable: false),
                    Address = c.String(maxLength: 300),
                    PhoneNumber = c.Int(),
                    ClassId = c.Int()


                })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.ClassModels", t => t.ClassId);

            CreateTable(
            "dbo.Attentence",
            c => new
            {
                AttentenceId = c.Int(nullable: false, identity: true),
                Start_Time = c.DateTime(nullable: false),
                End_Time = c.DateTime(nullable: false),
                Comments = c.String(),
                Status = c.String(),
                StudentId = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.AttentenceId)
            .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attentence", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "TrainerId", "dbo.Trainers");
            DropTable("dbo.Attentence");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
            

        }
    }
}
