namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrainer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainers",
                c => new
                {
                    TrainerId = c.Int(nullable: false, identity: true),
                    TrainerIdNum = c.Int(nullable: false),
                    TrainerFirstName = c.String(),
                    TrainerLastName = c.String(),
                    DateofBirth = c.DateTime(nullable: false),
                    PhoneNumber = c.Int(),
                    Address = c.String(),
                })
                .PrimaryKey(t => t.TrainerId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Trainers");
        }
    }
}
