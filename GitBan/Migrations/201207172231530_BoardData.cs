namespace GitBan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Columns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Name = c.String(),
                        WipLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Issues");
            DropTable("dbo.Columns");
            DropTable("dbo.Boards");
        }
    }
}
