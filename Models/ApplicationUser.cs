using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Test.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Headline { get; set; }
        public string Summary { get; set; }

        [Required]
        public bool IsHealthProfessional { get; set; }
        public bool IsSuspended { get; set; }

        [Required]
        public string Gender { get; set; }
        public string ThingsILove { get; set; }
        public string FavoriteExercises { get; set; }
        public string FavoriteHealthFoods { get; set; }
        public string NeverCatchMe { get; set; }
        public string MyPlaylist { get; set; }
        public string CheatMeal { get; set; }
        public string WhenNotInGym { get; set; }
        public string DontTellAnyoneBut { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public string TwitterUrl { get; set; }
        public long ProfileViews { get; set; }
        public string ProfessionalType { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public string EmailOTP { get; set; }
    }
}
