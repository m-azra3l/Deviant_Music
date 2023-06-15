using System.ComponentModel.DataAnnotations;


namespace Deviant_Music.Models
{
    public class Personnel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(1000), Display(Name = "Bio")]
        public string Bio { get; set; }

        [Required, StringLength(1000), Display(Name = "Designation")]
        public string Designation { get; set; }

        [StringLength(1000)]
        public string Url { get; set; }

        [StringLength(1000)]
        public string ImagePath { get; set; }

        [StringLength(50)]
        public string PersonnelUrl { get; set; }
    }
}
