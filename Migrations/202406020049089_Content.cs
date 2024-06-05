namespace PassionProjectS2024AN01648493.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Content : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "title");
        }
    }
}
