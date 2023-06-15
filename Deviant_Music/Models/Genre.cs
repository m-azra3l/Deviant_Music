using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class Genre
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(1000), Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(50)]
        public string GenreUrl { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        

    }
}
