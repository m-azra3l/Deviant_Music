using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.ModelBinding;
using Deviant_Music.Models;

namespace Deviant_Music
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Song> GetSearch(string search)
        {
            search = Request.QueryString["val"];
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Song> query = _db.Songs.OrderBy(s => s.Title);
            if(search !="")
            {
                query = query.Where(s => (s.Title.Contains(search) || s.AlbumName.Contains(search) || s.ArtistName.Contains(search)));
            }
            else
            {
                searchList.Visible = false;
                searcherror.Visible = true;
                searcherror.Text = "Song Not Found! Try searching by using keywords like Artist Name, Album Title, or Song Title";
            }
            return query;
        }
        
    }
}