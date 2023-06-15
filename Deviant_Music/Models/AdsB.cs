using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class AdsB
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string Title { get; set; }

        [Required, StringLength(1000), Display(Name = "Ad Description")]
        public string AlternateText { get; set; }

        [Required, StringLength(100)]
        public string NavigateUrl { get; set; }

        [ StringLength(1000)]
        public string ImageUrl { get; set; }
             
    }
}
