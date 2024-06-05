namespace PassionProjectS2024AN01648493.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        content_Id = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        Post_date = c.DateTime(nullable: false),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.content_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contents");
        }
    }
}
