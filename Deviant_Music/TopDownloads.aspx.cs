using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Deviant_Music.Models;
using System.Web.ModelBinding;
using System.Web.Routing;

namespace Deviant_Music
{
    public partial class TopDownloads : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Song> GetSongs(
                        [QueryString("songId")] int? songDownloadCount)

        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Song> query = _db.Songs.OrderByDescending(s => s.DownloadCount);
            if (songDownloadCount.HasValue && songDownloadCount > 0)
            {
                query = query.Where(s => s.DownloadCount == songDownloadCount);
            }
           
            return query;
        }
    }
}