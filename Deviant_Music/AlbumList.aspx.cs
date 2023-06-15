using System;
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
    public partial class AlbumList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public IQueryable<Album> GetAlbums(
                      [QueryString("id")] int? albumId)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Album> query = _db.Albums.OrderByDescending(a =>a.Id);
            
            if (albumId.HasValue && albumId > 0)
            {
                query = query.OrderByDescending(a => a.Id == albumId);

            }

            
            return query;
        }
       
    }
}