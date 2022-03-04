namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Classes", "StudentId", "dbo.Students");
            DropTable("dbo.Classes");

        }
        
        public override void Down()
        {
            CreateTable(
               "dbo.Classes",
               c => new
               {
                   ClassId = c.Int(nullable: false, identity: true),
                   Course_name = c.String(nullable: false),
                   Descriptions = c.String(),
                   TrainerId = c.Int(),
                   StudentId = c.Int(),
               })
               .PrimaryKey(t => t.ClassId)
               .ForeignKey("dbo.Students", t => t.StudentId)
               .ForeignKey("dbo.Trainers", t => t.TrainerId);

        }
    }
}
