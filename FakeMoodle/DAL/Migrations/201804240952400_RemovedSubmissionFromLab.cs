namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSubmissionFromLab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "LaboratoryDto_Id", "dbo.Laboratories");
            DropIndex("dbo.Submissions", new[] { "LaboratoryDto_Id" });
            DropColumn("dbo.Submissions", "LaboratoryDto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "LaboratoryDto_Id", c => c.Int());
            CreateIndex("dbo.Submissions", "LaboratoryDto_Id");
            AddForeignKey("dbo.Submissions", "LaboratoryDto_Id", "dbo.Laboratories", "Id");
        }
    }
}
