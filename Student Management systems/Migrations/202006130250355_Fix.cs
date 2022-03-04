namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentFullName", c => c.String(nullable: false));
            AddColumn("dbo.Trainers", "TrainerFullName", c => c.String(nullable: false));
            DropColumn("dbo.Students", "StudentFirstName");
            DropColumn("dbo.Students", "StudentLastName");
            DropColumn("dbo.Trainers", "TrainerFirstName");
            DropColumn("dbo.Trainers", "TrainerLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "TrainerLastName", c => c.String(nullable: false));
            AddColumn("dbo.Trainers", "TrainerFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "StudentLastName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "StudentFirstName", c => c.String(nullable: false));
            DropColumn("dbo.Trainers", "TrainerFullName");
            DropColumn("dbo.Students", "StudentFullName");
        }
    }
}
