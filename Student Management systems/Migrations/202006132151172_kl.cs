namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attentence", "ClassId", "dbo.Classes");
            DropIndex("dbo.Attentence", new[] { "ClassId" });
            DropColumn("dbo.Attentence", "ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attentence", "ClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attentence", "ClassId");
            AddForeignKey("dbo.Attentence", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
        }
    }
}
