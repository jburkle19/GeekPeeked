//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using PersonDetails = GeekPeeked.Common.Models.TMDb.Response.PersonDetails;
//namespace GeekPeeked.Common.Models
//{
//    public class Person : ITrackable
//    {
//        [Key]
//        [Required]
//        [DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public int Id { get; set; }                         // "id"

//        [Required]
//        public string Name { get; set; }                    // "name"

//        public DateTime? Birthday { get; set; }              // "birthday"
//        public DateTime? Deathday { get; set; }              // "deathday"

//        public string Biography { get; set; }               // "biography"
//        public int Gender { get; set; }                     // "gender"
//        public string HomePage { get; set; }                // "homepage"

//        public string ImdbId { get; set; }                  // "imdb_id"
//        public string FacebookId { get; set; }              // "facebook_id"
//        public string InstagramId { get; set; }             // "instagram_id"
//        public string TwitterId { get; set; }               // "twitter_id"

//        public string BirthPlace { get; set; }              // "place_of_birth"
//        public string ProfilePath { get; set; }             // "profile_path"

//        public DateTime? CreatedDate { get; set; }
//        public DateTime? ModifiedDate { get; set; }

//        public virtual ICollection<Image> Images { get; set; }     // "images -> profiles"

//        public virtual ICollection<CastCredit> CastCredits { get; set; }        // "movie_credits -> cast"
//        public virtual ICollection<CrewCredit> CrewCredits { get; set; }        // "movie_credits -> crew"

//        public Person()
//        {
//            Images = new HashSet<Image>();

//            CastCredits = new HashSet<CastCredit>();
//            CrewCredits = new HashSet<CrewCredit>();
//        }

//        public Person(PersonDetails.ResponseModel tmdbPerson)
//        {
//            Images = new HashSet<Image>();

//            CastCredits = new HashSet<CastCredit>();
//            CrewCredits = new HashSet<CrewCredit>();

//            this.Id = tmdbPerson.id;
//            this.Name = tmdbPerson.name;

//            DateTime birthday = new DateTime();
//            if(DateTime.TryParse(tmdbPerson.birthday, out birthday))
//                this.Birthday = birthday;

//            DateTime deathday = new DateTime();
//            if(DateTime.TryParse(tmdbPerson.deathday, out deathday))
//                this.Deathday = deathday;

//            this.Gender = tmdbPerson.gender;
//            this.Biography = tmdbPerson.biography;
//            this.HomePage = tmdbPerson.homepage;
//            this.ImdbId = tmdbPerson.imdb_id;

//            if(tmdbPerson.external_ids.facebook_id != null)
//                this.FacebookId = tmdbPerson.external_ids.facebook_id.ToString();

//            if (tmdbPerson.external_ids.instagram_id != null)
//                this.InstagramId = tmdbPerson.external_ids.instagram_id.ToString();

//            if (tmdbPerson.external_ids.twitter_id != null)
//                this.TwitterId = tmdbPerson.external_ids.twitter_id.ToString();

//            if(tmdbPerson.place_of_birth != null)
//                this.BirthPlace = tmdbPerson.place_of_birth;

//            if (tmdbPerson.profile_path != null)
//                this.ProfilePath = tmdbPerson.profile_path;
//        }
//    }
//}