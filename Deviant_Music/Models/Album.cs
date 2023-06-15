using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class Album
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name ="Genre")]
        public int? GenreId { get; set; }

        [Display(Name = "Artist")]
        public int? ArtistId { get; set; }

        [Required, StringLength(1000), Display(Name = "Description")]
        public string Description { get; set; }

        [Required,StringLength(50), Display(Name ="Release Date")]
        public string ReleaseDate { get; set;}

        [Required, StringLength(50), Display(Name = "Upload Date")]
        public string UploadDate { get; set; }

        [StringLength(1000)]
        public string ImagePath { get; set; }

        [StringLength(1000), Display(Name ="Audiomack")]
        public string AudiomackUrl { get; set; }

        [StringLength(1000), Display(Name = "Fanlink")]
        public string Fanlink { get; set; }

        [StringLength(50)]
        public string ArtistName { get; set; }

        [StringLength(50)]
        public string GenreName { get; set; }

        [StringLength(50)]
        public string AlbumUrl { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
         
        public virtual Genre Genre { get; set; }

        public virtual Artist Artist { get; set; }

    }
}
