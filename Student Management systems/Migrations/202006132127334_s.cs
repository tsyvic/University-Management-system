namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attentence", "ClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attentence", "ClassId");
            AddForeignKey("dbo.Attentence", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attentence", "ClassId", "dbo.Classes");
            DropIndex("dbo.Attentence", new[] { "ClassId" });
            DropColumn("dbo.Attentence", "ClassId");
        }
    }
}
