using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class Artist
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(2000), Display(Name = "Bio")]
        public string Bio { get; set; }

        [Required, StringLength(1000)]
        public string ImagePath { get; set; }

        [StringLength(50)]
        public string ArtistUrl { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
       

    }
}
