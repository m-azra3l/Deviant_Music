
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class DeviantSocial
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Url { get; set; }

        [Required, StringLength(100)]
        public string ImagePath { get; set; }

    }
}
