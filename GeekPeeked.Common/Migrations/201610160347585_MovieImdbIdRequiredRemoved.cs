namespace GeekPeeked.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieImdbIdRequiredRemoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ImdbId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ImdbId", c => c.String(nullable: false));
        }
    }
}
