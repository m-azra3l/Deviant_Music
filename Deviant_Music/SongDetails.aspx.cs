using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using Deviant_Music.Models;
using System.Data;
using System.Data.SqlClient;

namespace Deviant_Music
{
    public partial class SongDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void dload_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as Button).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                var c = _db.Songs.Find(id);
                c.DownloadCount = c.DownloadCount + 1;
                _db.SaveChanges();
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\deviantmusic.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select AudioPath, ContentType, Data from Songs where Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            bytes = (byte[])dr["Data"];
                            contentType = dr["ContentType"].ToString();
                            fileName = dr["AudioPath"].ToString();
                        }
                        con.Close();
                    }
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("Content-Disposition", "inline;filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }

        public IQueryable<Song> GetSong([QueryString("songId")] int? songId, [RouteData] string songTitle)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Song> query = _db.Songs;
            if (songId.HasValue && songId > 0)
            {
                query = query.Where(s => s.Id == songId);
            }
            else if (!String.IsNullOrEmpty(songTitle))
            {
                query = query.Where(s =>
                          String.Compare(s.SongUrl, songTitle) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}