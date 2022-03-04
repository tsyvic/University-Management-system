namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attentence", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attentence", "Date");
        }
    }
}
