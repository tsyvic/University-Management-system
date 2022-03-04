namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idk : DbMigration
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
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TrainerId", "dbo.Trainers");
            DropTable("dbo.Classes");
        }
    }
}
