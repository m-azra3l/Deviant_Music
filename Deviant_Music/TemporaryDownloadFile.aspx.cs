using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Deviant_Music.Models;
using System.IO;

namespace Deviant_Music
{
    public partial class TemporaryDownloadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string downloadtoken = Page.RouteData.Values["downloadtoken"].ToString();
            DeviantContext _db = new DeviantContext();
            var data = from d in _db.Downloads where d.DownloadToken == downloadtoken select d;
            Download obj = data.SingleOrDefault();
            if(obj.ExpireAfterDownload.Equals(true))
            {
                if(obj.Downloaded.Equals(true))
                {
                    Response.Redirect("~/DownloadError.aspx");
                }
            }
            if (obj.ExpireAfterDownload.Equals(true))
            {
                obj.Downloaded = true;
                obj.Hits = obj.Hits + 1;
                _db.SaveChanges();
            }
            int? songid = obj.SongId;
            byte[] bytes;
            string fileName, contentType;
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\deviantmusic.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select AudioPath, ContentType, Data from Songs where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", songid);
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
}