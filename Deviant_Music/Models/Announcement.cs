using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class Announcement
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, StringLength(1000), Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(1000)]
        public string ImagePath { get; set; }

        [StringLength(50)]
        public string AnnouncementUrl { get; set; }

    }
}
