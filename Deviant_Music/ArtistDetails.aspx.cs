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
    public partial class ArtistDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region ListQuery
        public IQueryable<Artist> GetArtist([QueryString("artistId")] int? artistId, [RouteData] string artistName)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Artist> query = _db.Artists;
            if (artistId.HasValue && artistId > 0)
            {
                query = query.Where(art => art.Id == artistId);
            }
            else if (!String.IsNullOrEmpty(artistName))
            {
                query = query.Where(art =>
                          String.Compare(art.ArtistUrl, artistName) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public IQueryable<Song> GetSongs(
                       [QueryString("id")] int? artistId,
                       [RouteData] string artistName)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Song> query = _db.Songs.OrderByDescending(s=>s.Id);

            if (artistId.HasValue && artistId > 0)
            {
                query = query.Where(s => s.Id == artistId);
            }

             if (!String.IsNullOrEmpty(artistName))
              {
                  query = query.Where(s =>String.Compare(s.Artist.ArtistUrl,artistName) == 0);
              }
            return query;
        }

        public IQueryable<Album> GetAlbums(
                      [QueryString("id")] int? artistId,
                      [RouteData] string artistName)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Album> query = _db.Albums.OrderByDescending(a=>a.Id);

            if (artistId.HasValue && artistId > 0)
            {
                query = query.Where(a => a.Id == artistId);
            }

              if (!String.IsNullOrEmpty(artistName))
              {
                  query = query.Where(a =>String.Compare(a.Artist.ArtistUrl,artistName) == 0);
              }
            return query;
        }
        #endregion
    }
}