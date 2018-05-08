namespace DataMysql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Token", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Token");
        }
    }
}
