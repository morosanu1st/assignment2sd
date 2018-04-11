namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaboratoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laboratories", t => t.LaboratoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.LaboratoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Laboratories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Title = c.String(),
                        Curricula = c.String(),
                        Description = c.String(),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LaboratoryId = c.Int(nullable: false),
                        Name = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laboratories", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Hobby = c.String(),
                        Group = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        LaboratoryId = c.Int(nullable: false),
                        Remarks = c.String(),
                        Link = c.String(),
                        Grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laboratories", t => t.LaboratoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.LaboratoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Submissions", "LaboratoryId", "dbo.Laboratories");
            DropForeignKey("dbo.Attendances", "UserId", "dbo.Users");
            DropForeignKey("dbo.Attendances", "LaboratoryId", "dbo.Laboratories");
            DropForeignKey("dbo.Assignments", "Id", "dbo.Laboratories");
            DropIndex("dbo.Submissions", new[] { "LaboratoryId" });
            DropIndex("dbo.Submissions", new[] { "StudentId" });
            DropIndex("dbo.Assignments", new[] { "Id" });
            DropIndex("dbo.Attendances", new[] { "UserId" });
            DropIndex("dbo.Attendances", new[] { "LaboratoryId" });
            DropTable("dbo.Submissions");
            DropTable("dbo.Users");
            DropTable("dbo.Assignments");
            DropTable("dbo.Laboratories");
            DropTable("dbo.Attendances");
        }
    }
}
