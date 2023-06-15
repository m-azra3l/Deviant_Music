using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deviant_Music.Models
{
    public class Download
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [StringLength(50)]
        public string DownloadTitle { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        [StringLength(50)]
        public string DownloadToken { get; set; }

        public int? Hits { get; set; }

        public virtual bool ExpireAfterDownload { get; set; }

        public virtual bool Downloaded { get; set; }

        public int? SongId { get; set; }

        public virtual Song Song { get; set; }
    }
}
