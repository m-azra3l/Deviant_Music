using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class Song
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Display(Name = "Artist")]
        public int? ArtistId { get; set; }

        [Display(Name = "Album")]
        public int? AlbumId { get; set; }

        [Required, StringLength(2000), Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(50),Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }
        
        [StringLength(50),Display(Name = "Upload Date")]
        public string UploadDate { get; set; }

        [StringLength(1000)]
        public string ImagePath { get; set; }

        [StringLength(1000), Display(Name = "Audiomack")]
        public string AudiomackUrl { get; set; }

        [StringLength(1000), Display(Name = "Fanlink")]
        public string Fanlink { get; set; }

        [StringLength(100), Display(Name = "License")]
        public string License { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [StringLength(100), Display(Name = "Producer")]
        public string Producer { get; set; }

        [StringLength(1000)]
        public string Featuring { get; set; }

        [StringLength(1000)]
        public string Writter { get; set; }

        [StringLength(1000)]
        public string PurchaseURL { get; set; }

        [StringLength(1000)]
        public string AudioPath { get; set; }

        [StringLength(1000)]
        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        [Display(Name = "Downloads")]
        public int DownloadCount { get; set; }

        [StringLength(50)]
        public string ArtistName { get; set; }

        [StringLength(50)]
        public string AlbumName { get; set; }

        [StringLength(50)]
        public string GenreName { get; set; }

        [StringLength(50)]
        public string SongUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Album Album { get; set; }

    }
}
