namespace GeekPeeked.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        TypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TmdbId = c.Int(nullable: false),
                        ImdbId = c.String(),
                        Title = c.String(nullable: false),
                        OriginalTitle = c.String(),
                        Description = c.String(),
                        Tagline = c.String(),
                        Runtime = c.Int(nullable: false),
                        PosterPath = c.String(),
                        HomePage = c.String(),
                        Budget = c.Double(nullable: false),
                        Revenue = c.Double(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        IsVisible = c.Boolean(nullable: false),
                        IsAdult = c.Boolean(nullable: false),
                        IsVideo = c.Boolean(nullable: false),
                        OldMovieId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsBackdrop = c.Boolean(nullable: false),
                        FilePath = c.String(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        AspectRatio = c.Double(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Deathday = c.DateTime(nullable: false),
                        Biography = c.String(),
                        Gender = c.Int(nullable: false),
                        HomePage = c.String(),
                        ImdbId = c.String(),
                        FacebookId = c.String(),
                        InstagramId = c.String(),
                        TwitterId = c.String(),
                        BirthPlace = c.String(),
                        ProfilePath = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductionCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Key = c.String(),
                        Name = c.String(),
                        Site = c.String(),
                        Size = c.Int(nullable: false),
                        Type = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Department = c.String(nullable: false),
                        JobTitle = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OldProfileId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieCertificationRelationship",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CertificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CertificationId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Certifications", t => t.CertificationId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CertificationId);
            
            CreateTable(
                "dbo.MovieGenreRelationship",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.GenreId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.PersonImageRelationship",
                c => new
                    {
                        Persond = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Persond, t.ImageId })
                .ForeignKey("dbo.People", t => t.Persond, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.Persond)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.MoviePosterRelationship",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        PosterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.PosterId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.PosterId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.PosterId);
            
            CreateTable(
                "dbo.MovieKeywordRelationship",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.KeywordId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Keywords", t => t.KeywordId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.KeywordId);
            
            CreateTable(
                "dbo.MovieProductionCompanyRelationship",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ProductionCompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ProductionCompanyId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.ProductionCompanies", t => t.ProductionCompanyId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ProductionCompanyId);
            
            CreateTable(
                "dbo.MovieVideoRelationship",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        VideoId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MovieId, t.VideoId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.VideoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MovieVideoRelationship", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.MovieVideoRelationship", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieProductionCompanyRelationship", "ProductionCompanyId", "dbo.ProductionCompanies");
            DropForeignKey("dbo.MovieProductionCompanyRelationship", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieKeywordRelationship", "KeywordId", "dbo.Keywords");
            DropForeignKey("dbo.MovieKeywordRelationship", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MoviePosterRelationship", "PosterId", "dbo.Images");
            DropForeignKey("dbo.MoviePosterRelationship", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.PersonImageRelationship", "ImageId", "dbo.Images");
            DropForeignKey("dbo.PersonImageRelationship", "Persond", "dbo.People");
            DropForeignKey("dbo.MovieGenreRelationship", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieGenreRelationship", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieCertificationRelationship", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.MovieCertificationRelationship", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieVideoRelationship", new[] { "VideoId" });
            DropIndex("dbo.MovieVideoRelationship", new[] { "MovieId" });
            DropIndex("dbo.MovieProductionCompanyRelationship", new[] { "ProductionCompanyId" });
            DropIndex("dbo.MovieProductionCompanyRelationship", new[] { "MovieId" });
            DropIndex("dbo.MovieKeywordRelationship", new[] { "KeywordId" });
            DropIndex("dbo.MovieKeywordRelationship", new[] { "MovieId" });
            DropIndex("dbo.MoviePosterRelationship", new[] { "PosterId" });
            DropIndex("dbo.MoviePosterRelationship", new[] { "MovieId" });
            DropIndex("dbo.PersonImageRelationship", new[] { "ImageId" });
            DropIndex("dbo.PersonImageRelationship", new[] { "Persond" });
            DropIndex("dbo.MovieGenreRelationship", new[] { "GenreId" });
            DropIndex("dbo.MovieGenreRelationship", new[] { "MovieId" });
            DropIndex("dbo.MovieCertificationRelationship", new[] { "CertificationId" });
            DropIndex("dbo.MovieCertificationRelationship", new[] { "MovieId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.MovieVideoRelationship");
            DropTable("dbo.MovieProductionCompanyRelationship");
            DropTable("dbo.MovieKeywordRelationship");
            DropTable("dbo.MoviePosterRelationship");
            DropTable("dbo.PersonImageRelationship");
            DropTable("dbo.MovieGenreRelationship");
            DropTable("dbo.MovieCertificationRelationship");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Jobs");
            DropTable("dbo.Videos");
            DropTable("dbo.ProductionCompanies");
            DropTable("dbo.Keywords");
            DropTable("dbo.People");
            DropTable("dbo.Images");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Certifications");
        }
    }
}
