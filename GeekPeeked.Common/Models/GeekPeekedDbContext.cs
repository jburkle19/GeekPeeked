using System.Data.Entity;
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
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        //public DbSet<CastMember> CastMembers { get; set; }
        //public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Movie / Genre Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Genre>(s => s.Genres)
                        .WithMany(c => c.Movies)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MovieRefId");
                            cs.MapRightKey("GenreRefId");
                            cs.ToTable("MovieGenreRef");
                        });
            #endregion Movie / Genre Many-to-Many Relationship 

            #region Movie / Certification Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Certification>(s => s.Certifications)
                        .WithMany(c => c.Movies)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MovieRefId");
                            cs.MapRightKey("CertificationRefId");
                            cs.ToTable("MovieCertificationRef");
                        });
            #endregion Movie / Certification Many-to-Many Relationship 

            #region Movie / Production Company Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<ProductionCompany>(s => s.ProductionCompanies)
                        .WithMany(c => c.Movies)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MovieRefId");
                            cs.MapRightKey("ProductionCompanyRefId");
                            cs.ToTable("MovieProductionCompanyRef");
                        });
            #endregion Movie / Production Company Many-to-Many Relationship 

            //#region Movie / Cast Member Many-to-Many Relationship 
            //modelBuilder.Entity<Movie>()
            //            .HasMany<CastMember>(s => s.CastMembers)
            //            .WithMany(c => c.Movies)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("MovieRefId");
            //                cs.MapRightKey("CastMemberRefId");
            //                cs.ToTable("MovieCastMemberRef");
            //            });
            //#endregion Movie / Cast Member Many-to-Many Relationship 

            //#region Movie / Crew Member Many-to-Many Relationship 
            //modelBuilder.Entity<Movie>()
            //            .HasMany<CrewMember>(s => s.CrewMembers)
            //            .WithMany(c => c.Movies)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("MovieRefId");
            //                cs.MapRightKey("CrewMemberRefId");
            //                cs.ToTable("MovieCrewMemberRef");
            //            });
            //#endregion Movie / Crew Member Many-to-Many Relationship 

            #region Movie / Movie Poster Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Poster>(s => s.Posters)
                        .WithMany(c => c.Movies)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MovieRefId");
                            cs.MapRightKey("PosterRefId");
                            cs.ToTable("MoviePosterRef");
                        });
            #endregion Movie / Movie Poster Many-to-Many Relationship 

            #region Movie / Movie Video Many-to-Many Relationship 
            modelBuilder.Entity<Movie>()
                        .HasMany<Video>(s => s.Videos)
                        .WithMany(c => c.Movies)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MovieRefId");
                            cs.MapRightKey("VideoRefId");
                            cs.ToTable("MovieVideoRef");
                        });
            #endregion Movie / Movie Video Many-to-Many Relationship 
        }

        public static GeekPeekedDbContext Create()
        {
            return new GeekPeekedDbContext();
        }
    }
}
