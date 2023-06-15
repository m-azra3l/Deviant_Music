using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Deviant_Music.Models;
using System.Web.ModelBinding;
using System.Web.Routing;
using System.Data;
using System.Data.SqlClient;

namespace Deviant_Music
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              
        }
       
        public IQueryable<Song> GetSongs(
                        [QueryString("id")] int? genreId,
                        [RouteData] string genreName)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Song> query = _db.Songs.OrderByDescending(s=>s.Id);

            if (genreId.HasValue && genreId > 0)
            {
                query = query.Where(s => s.Id == genreId);
            }
            
            if (!String.IsNullOrEmpty(genreName))
            {
                query = query.Where(s =>String.Compare(s.Genre.GenreUrl, genreName) == 0).OrderByDescending(s=>s.Id);
            }
            return query;
        }
        
    }
}