namespace Student_Management_systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newstudent : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Classes", t => t.ClassId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropTable("dbo.Students");
        }
    }
}
