namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Gender", c => c.String());
            AddColumn("dbo.Trainers", "Email", c => c.String());
            AddColumn("dbo.Students", "Gender", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String());

        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Trainers", "Email");
            DropColumn("dbo.Trainers", "Gender");
        }
    }
}
