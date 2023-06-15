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
    public partial class ManagedArtists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Artist> GetArtists([QueryString("id")] int? artistId)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Artist> query = _db.Artists.OrderByDescending(art=>art.Id);
            if (artistId.HasValue && artistId > 0)
            {
                query = query.Where(art => art.Id == artistId);
            }
           
            return query;
        }
    }
}