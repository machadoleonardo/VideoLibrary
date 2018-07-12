namespace VideoLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablesFilmesAndGeneros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameGenre = c.String(),
                        CreationDateGenre = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameMovie = c.String(),
                        CreationDateMovie = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        GenreId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
