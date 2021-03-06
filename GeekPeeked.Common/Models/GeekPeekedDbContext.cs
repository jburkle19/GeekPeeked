﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GeekPeeked.Common.Models
{
    public class GeekPeekedDbContext : IdentityDbContext<ApplicationUser>
    {
        public GeekPeekedDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Credit> Credits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Movie / Genre Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Genre>(g => g.Genres)
                        .WithMany(m => m.Movies)
                        .Map(mg =>
                        {
                            mg.MapLeftKey("MovieId");
                            mg.MapRightKey("GenreId");
                            mg.ToTable("MovieGenreRelationships");
                        });
            #endregion Movie / Genre Many-to-Many Relationship 

            #region Movie / Keyword Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Keyword>(k => k.Keywords)
                        .WithMany(m => m.Movies)
                        .Map(mg =>
                        {
                            mg.MapLeftKey("MovieId");
                            mg.MapRightKey("KeywordId");
                            mg.ToTable("MovieKeywordRelationships");
                        });
            #endregion Movie / Keyword Many-to-Many Relationship 

            #region Movie / Certification Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Certification>(c => c.Certifications)
                        .WithMany(m => m.Movies)
                        .Map(mc =>
                        {
                            mc.MapLeftKey("MovieId");
                            mc.MapRightKey("CertificationId");
                            mc.ToTable("MovieCertificationRelationships");
                        });
            #endregion Movie / Certification Many-to-Many Relationship 

            #region Movie / Production Company Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<ProductionCompany>(pc => pc.ProductionCompanies)
                        .WithMany(m => m.Movies)
                        .Map(mpc =>
                        {
                            mpc.MapLeftKey("MovieId");
                            mpc.MapRightKey("ProductionCompanyId");
                            mpc.ToTable("MovieProductionCompanyRelationships");
                        });
            #endregion Movie / Production Company Many-to-Many Relationship 

            #region Movie / Image Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Image>(i => i.Images)
                        .WithMany(m => m.Movies)
                        .Map(mi =>
                        {
                            mi.MapLeftKey("MovieId");
                            mi.MapRightKey("ImageId");
                            mi.ToTable("MovieImageRelationships");
                        });
            #endregion Movie / Image Many-to-Many Relationship 

            #region Movie / Video Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Video>(v => v.Videos)
                        .WithMany(m => m.Movies)
                        .Map(mv =>
                        {
                            mv.MapLeftKey("MovieId");
                            mv.MapRightKey("VideoId");
                            mv.ToTable("MovieVideoRelationships");
                        });
            #endregion Movie / Video Many-to-Many Relationship 

            #region People / Image Many-to-Many Relationship 
            modelBuilder.Entity<Person>()
                        .HasMany<Image>(i => i.Images)
                        .WithMany(p => p.People)
                        .Map(pi =>
                        {
                            pi.MapLeftKey("Persond");
                            pi.MapRightKey("ImageId");
                            pi.ToTable("PersonImageRelationships");
                        });
            #endregion People / Image Many-to-Many Relationship 

            #region Movie / Person MovieCredit Many-to-Many Relationship 
            modelBuilder.Entity<Credit>()
                        .HasRequired(c => c.Person)
                        .WithMany()
                        .HasForeignKey(c => c.PersonId);

            modelBuilder.Entity<Credit>()
                        .HasRequired(c => c.Movie)
                        .WithMany()
                        .HasForeignKey(c => c.MovieId);
            #endregion Movie / Person MovieCredit Many-to-Many Relationship 
        }

        public static GeekPeekedDbContext Create()
        {
            return new GeekPeekedDbContext();
        }
    }
}
