namespace PassionProjectS2024AN01648493.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Content_content_Id", c => c.Int());
            AddColumn("dbo.Teachers", "Content_content_Id", c => c.Int());
            CreateIndex("dbo.Students", "Content_content_Id");
            CreateIndex("dbo.Teachers", "Content_content_Id");
            AddForeignKey("dbo.Students", "Content_content_Id", "dbo.Contents", "content_Id");
            AddForeignKey("dbo.Teachers", "Content_content_Id", "dbo.Contents", "content_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Content_content_Id", "dbo.Contents");
            DropForeignKey("dbo.Students", "Content_content_Id", "dbo.Contents");
            DropIndex("dbo.Teachers", new[] { "Content_content_Id" });
            DropIndex("dbo.Students", new[] { "Content_content_Id" });
            DropColumn("dbo.Teachers", "Content_content_Id");
            DropColumn("dbo.Students", "Content_content_Id");
        }
    }
}
