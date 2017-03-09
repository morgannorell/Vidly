namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Action')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Thriller')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Family')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Romance')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
