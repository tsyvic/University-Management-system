namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newattendance : DbMigration
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
                StudentId = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.AttentenceId)
            .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attentence", "StudentId", "dbo.Students");
            DropTable("dbo.Attentence");
        }
    }
}
