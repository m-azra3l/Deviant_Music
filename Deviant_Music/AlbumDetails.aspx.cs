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
    public partial class AlbumDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Song> GetSongs(
                        [QueryString("id")] int? albumId,
                        [RouteData] string albumTitle)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Song> query = _db.Songs.OrderByDescending(s=>s.Id);

            if (albumId.HasValue && albumId > 0)
            {
                query = query.Where(s => s.Id == albumId);
            }

             if (!String.IsNullOrEmpty(albumTitle))
              {
                  query = query.Where(s =>String.Compare(s.Album.AlbumUrl,albumTitle) == 0);
              }
            return query;
        }
        public IQueryable<Album> GetAlbum([QueryString("albumId")] int? albumId, [RouteData] string albumTitle)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Album> query = _db.Albums;
            if (albumId.HasValue && albumId > 0)
            {
                query = query.Where(a => a.Id == albumId);
            }
            else if (!String.IsNullOrEmpty(albumTitle))
            {
                query = query.Where(a =>
                          String.Compare(a.AlbumUrl, albumTitle) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}