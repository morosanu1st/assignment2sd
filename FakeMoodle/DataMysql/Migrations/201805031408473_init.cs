namespace DataMysql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaboratoryId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                        DueDate = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laboratories", t => t.LaboratoryId, cascadeDelete: true)
                .Index(t => t.LaboratoryId);
            
            CreateTable(
                "dbo.Laboratories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Curricula = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordHash = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Hobby = c.String(unicode: false),
                        Group = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        Remarks = c.String(unicode: false),
                        Link = c.String(unicode: false),
                        Grade = c.Int(nullable: false),
                        Attempt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AssignmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Submissions", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Attendances", "UserId", "dbo.Users");
            DropForeignKey("dbo.Attendances", "LaboratoryId", "dbo.Laboratories");
            DropForeignKey("dbo.Assignments", "LaboratoryId", "dbo.Laboratories");
            DropIndex("dbo.Submissions", new[] { "AssignmentId" });
            DropIndex("dbo.Submissions", new[] { "StudentId" });
            DropIndex("dbo.Attendances", new[] { "UserId" });
            DropIndex("dbo.Attendances", new[] { "LaboratoryId" });
            DropIndex("dbo.Assignments", new[] { "LaboratoryId" });
            DropTable("dbo.Submissions");
            DropTable("dbo.Users");
            DropTable("dbo.Attendances");
            DropTable("dbo.Laboratories");
            DropTable("dbo.Assignments");
        }
    }
}
