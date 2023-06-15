using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Web.Security;
using System.Data.SqlClient;
using Deviant_Music.Models;
using System.Xml;
using System.Web.Routing;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;


namespace Deviant_Music.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        XmlDocument doc;
        XmlDocument doc1;
        string config1 = ConfigurationManager.ConnectionStrings["DeviantMusic"].ConnectionString;
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            var userscount = new IdentityDbContext();
            var userscount1 = userscount.Users.ToList();
            usercount.Text = " "+ userscount1.Count.ToString()+" Users";
            doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/AdPB.xml"));
            doc1 = new XmlDocument();
            doc1.Load(Server.MapPath("~/App_Data/AdB.xml"));
            string myAction = Request.QueryString["Action"];
            if (myAction == "create")
            {
                alertsuccess.InnerText = "Created Successfully!";
            }
           
            if (myAction == "update")
            {
                alertsuccess.InnerText = "Updated Successfully!";
            }

            if (myAction == "delete")
            {
                alertsuccess.InnerText = "Deleted Successfully!";
            }

            if (HttpContext.Current.User.IsInRole("Administrator Level1"))
            {
                iadmin1.Visible = true;
            }
            if (HttpContext.Current.User.IsInRole("Administrator Level2"))
            {
                iadmin2.Visible = true;
                ADBs.Visible = true;
                ADPBs.Visible = true;
                ALBs.Visible = true;
                ANNs.Visible = true;
                mailing1.Visible = true;
            }
            if (HttpContext.Current.User.IsInRole("SuperAdministrator"))
            {
                superADMIN.Visible = true;
                ADBs.Visible = true;
                ADPBs.Visible = true;
                ALBs.Visible = true;
                ANNs.Visible = true;
                arts.Visible = true;
                dms.Visible = true;
                GENs.Visible = true;
                pers.Visible = true;
                ABdelete.Visible = true;
                APBdelete.Visible = true;
                iAdeletes.Visible = true;
                Sdeletes.Visible = true;
                role1.Visible = true;
                user1.Visible = true;
                mailing1.Visible = true;
                downloadurlgen1.Visible = true;
                tempdownloadgen1.Visible = true;
            }
        }
        #endregion

        #region AdB
        public IQueryable GetAdsBs()
        {
            ABdrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.AdsBs;
            return query;
        }
        private void clearAB()
        {
            ABtitle.Text = string.Empty;
            ABurl.Text = string.Empty;
            ABalte.Text = string.Empty;
            ABImage.AppRelativeTemplateSourceDirectory = string.Empty;
            adBsearch.Text = string.Empty;
        }
        private void SaveDoc1()
        {
            doc1.Save(Server.MapPath("~/App_Data/AdB.xml"));
        }

        protected void ABcreate_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            string img = "~/Catalog/AdB/";
            String path = Server.MapPath("~/Catalog/AdB/");
            if (ABImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ABImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif",".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    ABImage.PostedFile.SaveAs(path + ABImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
                if (ABtitle.Text!="")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("insert into AdsBs(Title,AlternateText,NavigateUrl,ImageUrl) values('"+ABtitle.Text+"','"+ABalte.Text+"','"+ABurl.Text+"','"+ img + ABImage.FileName + "')" , con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                XmlElement newelem = doc1.CreateElement("Ad");
                XmlAttribute Id = doc1.CreateAttribute("Id");
                Id.InnerText = adBId.Text;
                newelem.Attributes.Append(Id);
                newelem.InnerXml = "<ImageUrl>" + img + ABImage.FileName + "</ImageUrl><NavigateUrl>" + ABurl.Text + "</NavigateUrl><AlternateText>" + ABalte.Text + "</AlternateText><Impressions>1</Impressions>";
                doc1.DocumentElement.AppendChild(newelem);
                SaveDoc1();
                clearAB();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
                else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void ABdelete_Click(object sender, EventArgs e)
        {
            if (adBId.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("delete from AdsBs where Id='" + adBId.Text + "'", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                XmlNode deleteNode = doc1.SelectSingleNode("//Advertisements/Ad[@Id=" + adBId.Text + "]");
                if (deleteNode != null)
                {
                    deleteNode.ParentNode.RemoveChild(deleteNode);
                }
                SaveDoc1();
                clearAB();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=delete");
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        protected void ABclear_Click(object sender, EventArgs e)
        {
            clearAB();
        }
        protected void ABupdate_Click(object sender, EventArgs e)
        {
            Boolean fileOK1 = false;
            string img1 = "~/Catalog/AdB/";
            String path1 = Server.MapPath("~/Catalog/AdB/");
            if (ABImage.HasFile)
            {
                String fileExtension1 = System.IO.Path.GetExtension(ABImage.FileName).ToLower();
                String[] allowedExtensions1 = { ".gif",".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions1.Length; i++)
                {
                    if (fileExtension1 == allowedExtensions1[i])
                    {
                        fileOK1 = true;
                    }
                }
            }

            if (fileOK1)
            {
                try
                {
                    // Save to Images folder.
                    ABImage.PostedFile.SaveAs(path1 + ABImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (adBId.Text!="")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("update AdsBs set Title='"+ABtitle.Text+ "', AlternateText='" + ABalte.Text + "', NavigateUrl='" + ABurl.Text + "', ImageUrl='" +img1+ ABImage.FileName + "' where Id='" + adBId.Text + "'", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                XmlNode deleteNode = doc1.SelectSingleNode("//Advertisements/Ad[@Id=" + adBId.Text + "]");
                if (deleteNode != null)
                {
                    deleteNode.ParentNode.RemoveChild(deleteNode);
                }
                SaveDoc1();
                XmlElement newelem = doc1.CreateElement("Ad");
                XmlAttribute Id = doc1.CreateAttribute("Id");
                Id.InnerText = adBId.Text;
                newelem.Attributes.Append(Id);
                newelem.InnerXml = "<ImageUrl>" + img1 + ABImage.FileName + "</ImageUrl><NavigateUrl>" + ABurl.Text + "</NavigateUrl><AlternateText>" + ABalte.Text + "</AlternateText><Impressions>1</Impressions>";
                doc1.DocumentElement.AppendChild(newelem);
                SaveDoc1();
                clearAB();
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot update record";
            }
        }
        protected void adBsearch1_Click(object sender, EventArgs e)
        {
            if (adBsearch.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from AdsBs where  Title='" + adBsearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    adBId.Text = (dr["Id"].ToString());
                    ABtitle.Text = (dr["Title"].ToString());
                    ABalte.Text = (dr["AlternateText"].ToString());
                    ABurl.Text = (dr["NavigateUrl"].ToString());
                }
                con1.Close();
                adBsearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        #endregion

        #region AdPB
        public IQueryable GetAdsPBs()
        {
            APBdrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.AdsPBs;
            return query;
        }
        private void SaveDoc()
        {
            doc.Save(Server.MapPath("~/App_Data/AdPB.xml"));
        }
        private void clearAPB()
        {
            APBtitle.Text = string.Empty;
            APBurl.Text = string.Empty;
            APBalte.Text = string.Empty;
            APBImage.AppRelativeTemplateSourceDirectory = string.Empty;
            adPBsearch.Text = string.Empty;
        }
        protected void APBcreate_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            string img = "~/Catalog/AdPB/";
            String path = Server.MapPath("~/Catalog/AdPB/");
            if (APBImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(APBImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif",".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                     APBImage.PostedFile.SaveAs(path + APBImage.FileName);
                    // Save to Images/Thumbs folder.
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (APBtitle.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("insert into AdsPBs(Title,AlternateText,NavigateUrl,ImageUrl) values('" + APBtitle.Text + "','" + APBalte.Text + "','" + APBurl.Text + "','" + img + APBImage.FileName + "')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                XmlElement newelem = doc.CreateElement("Ad");
                XmlAttribute Id = doc.CreateAttribute("Id");
                Id.InnerText = adPBId.Text;
                newelem.Attributes.Append(Id);
                newelem.InnerXml = "<ImageUrl>" + img + APBImage.FileName + "</ImageUrl><NavigateUrl>" + APBurl.Text + "</NavigateUrl><AlternateText>" + APBalte.Text + "</AlternateText><Impressions>1</Impressions>";
                doc.DocumentElement.AppendChild(newelem);
                SaveDoc();
                clearAPB();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void APBdelete_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(config1);
            if (adPBId.Text != "")
                {
                SqlCommand cmd = new SqlCommand("delete from AdsPBs where Id='"+adPBId.Text+"'", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                XmlNode deleteNode = doc.SelectSingleNode("//Advertisements/Ad[@Id=" + adPBId.Text + "]");
                if (deleteNode!=null)
                {
                    deleteNode.ParentNode.RemoveChild(deleteNode);
                }
                SaveDoc();
                clearAPB();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=delete");
                }
                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
        }
        protected void APBclear_Click(object sender, EventArgs e)
        {
            clearAPB();
        }
        protected void APBupdate_Click(object sender, EventArgs e)
        {
            Boolean fileOK1 = false;
            string img1 = "~/Catalog/AdPB/";
            String path1 = Server.MapPath("~/Catalog/AdPB/");
            if (APBImage.HasFile)
            {
                String fileExtension1 = System.IO.Path.GetExtension(APBImage.FileName).ToLower();
                String[] allowedExtensions1 = { ".gif",".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions1.Length; i++)
                {
                    if (fileExtension1 == allowedExtensions1[i])
                    {
                        fileOK1 = true;
                    }
                }
            }

            if (fileOK1)
            {
                try
                {
                    // Save to Images folder.
                    APBImage.PostedFile.SaveAs(path1 + APBImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (adPBId.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("update AdsPBs set Title='" + APBtitle.Text + "', AlternateText='" + APBalte.Text + "', NavigateUrl='" + APBurl.Text + "', ImageUrl='" + img1+APBImage.FileName+ "' where Id='" + adPBId.Text+"'", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                XmlNode deleteNode = doc.SelectSingleNode("//Advertisements/Ad[@Id=" + adPBId.Text + "]");
                if (deleteNode != null)
                {
                    deleteNode.ParentNode.RemoveChild(deleteNode);
                }
                SaveDoc();
                XmlElement newelem = doc.CreateElement("Ad");
                XmlAttribute Id = doc.CreateAttribute("Id");
                Id.InnerText = adPBId.Text;
                newelem.Attributes.Append(Id);
                newelem.InnerXml = "<ImageUrl>" + img1 + APBImage.FileName + "</ImageUrl><NavigateUrl>" + APBurl.Text + "</NavigateUrl><AlternateText>" + APBalte.Text + "</AlternateText><Impressions>1</Impressions>";
                doc.DocumentElement.AppendChild(newelem);
                SaveDoc();
                clearAPB();
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot update record";
            }
        }
        protected void adPBsearch1_Click(object sender, EventArgs e)
        {
            if (adPBsearch.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from AdsPBs where  Title='" + adPBsearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    adPBId.Text = (dr["Id"].ToString());
                    APBtitle.Text = (dr["Title"].ToString());
                    APBalte.Text = (dr["AlternateText"].ToString());
                    APBurl.Text = (dr["NavigateUrl"].ToString());
                }
                con1.Close();
                adPBsearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }

        #endregion

        #region Album
        public IQueryable GetAlbum()
        {
            iAdrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Albums;
            return query;
        }
        public IQueryable GetAlbumGenre()
        {
            iAgenre.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Genres;
            return query;
        }
        public IQueryable GetAlbumArtist()
        {
            iAartist.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Artists;
            return query;
        }
        private void clearAlb()
        {
            AlBtitle.Text = string.Empty;
            iAGname.Text = string.Empty;
            iAAname.Text = string.Empty;
            iARdate.Text = string.Empty;
            iAUdate.Text = string.Empty;
            iAAmack.Text = string.Empty;
            iAdesc.InnerText = string.Empty;
            iAimage.AppRelativeTemplateSourceDirectory = string.Empty;
            albroute.Text = string.Empty;
        }

        protected void iAcreate_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(config1);
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Album/");
            if (iAimage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(iAimage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    iAimage.PostedFile.SaveAs(path + iAimage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (AlBtitle.Text != "" && iAartist.Text!="")
            {
                SqlCommand cmd = new SqlCommand("insert into Albums(Title,GenreId,ArtistId,Description,ReleaseDate,UploadDate,ImagePath,AudiomackUrl,ArtistName,GenreName,AlbumUrl) values('" + AlBtitle.Text + "','" + iAgenre.Text + "','" + iAartist.Text + "','" + iAdesc.InnerText + "','"+iARdate.Text+"','"+iAUdate.Text+"','" + iAimage.FileName + "','"+iAAmack.Text+"','"+iAAname.Text+"','"+iAGname.Text+"','"+albroute.Text+"')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearAlb();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else if (AlBtitle.Text != "" && iAartist.Text != null)
            {
                SqlCommand cmd = new SqlCommand("insert into Albums(Title,GenreId,Description,ReleaseDate,UploadDate,ImagePath,AudiomackUrl,ArtistName,GenreName) values('" + AlBtitle.Text + "','" + iAgenre.Text + "','" + iAdesc.InnerText + "','" + iARdate.Text + "','" + iAUdate.Text + "','" + iAimage.FileName + "','" + iAAmack.Text + "','" + iAAname.Text + "','" + iAGname.Text + "')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearAlb();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void iAdelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int albId = Convert.ToInt16(iAdrop.SelectedValue);
                var myalb = (from alb in _db.Albums where alb.Id == albId select alb).FirstOrDefault();
                if (myalb != null)
                {
                    _db.Albums.Remove(myalb);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        protected void iAclear_Click(object sender, EventArgs e)
        {
            clearAlb();
        }
        #endregion

        #region Announcements
        public IQueryable GetAnns()
        {
            Androp.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Announcements;
            return query;
        }
        private void clearAN()
        {
            Antitle.Text = string.Empty;
            Andesc.InnerText = string.Empty;
            AnImage.AppRelativeTemplateSourceDirectory = string.Empty;
            Ansearch.Text = string.Empty;
            Anroute.Text = string.Empty;
        }

        protected void Ancreate_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Announcement/");
            if (AnImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(AnImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    AnImage.PostedFile.SaveAs(path + AnImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (Antitle.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("insert into Announcements(Title,Description,ImagePath,AnnouncementUrl) values('" + Antitle.Text + "','" + Andesc.InnerText + "','" + AnImage.FileName + "','"+Anroute.Text+"')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearAN();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void Andelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int annId = Convert.ToInt16(Androp.SelectedValue);
                var myann = (from ann in _db.Announcements where ann.Id == annId select ann).FirstOrDefault();
                if (myann != null)
                {
                    _db.Announcements.Remove(myann);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        protected void Anclear_Click(object sender, EventArgs e)
        {
            clearAN();
        }
        protected void Ansearch1_Click(object sender, EventArgs e)
        {
            if (Ansearch.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Announcements where  Title='" + Ansearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AnID.Text = (dr["Id"].ToString());
                    Antitle.Text = (dr["Title"].ToString());
                    Andesc.InnerText = (dr["Description"].ToString());
                    Anroute.Text = (dr["AnnouncementUrl"].ToString());
                }
                con1.Close();
                Ansearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        protected void Anupdate_Click(object sender, EventArgs e)
        {
            Boolean fileOK1 = false;
            String path1 = Server.MapPath("~/Catalog/Annoucement/");
            if (AnImage.HasFile)
            {
                String fileExtension1 = System.IO.Path.GetExtension(AnImage.FileName).ToLower();
                String[] allowedExtensions1 = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions1.Length; i++)
                {
                    if (fileExtension1 == allowedExtensions1[i])
                    {
                        fileOK1 = true;
                    }
                }
            }

            if (fileOK1)
            {
                try
                {
                    // Save to Images folder.
                    AnImage.PostedFile.SaveAs(path1 + AnImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (AnID.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("update Annoucements set Title=@antt, Description=@andes,ImagePath=@animg,AnnouncementUrl=@anrt where Id=@anid", con1);
                cmd.Parameters.AddWithValue("@anid", AnID.Text);
                cmd.Parameters.AddWithValue("@antt", Antitle.Text);
                cmd.Parameters.AddWithValue("@andes", Andesc.InnerText);
                cmd.Parameters.AddWithValue("@animg", AnImage.FileName);
                cmd.Parameters.AddWithValue("@anrt", Anroute.Text);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearAN();
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot update record";
            }
        }
        #endregion

        #region Artists
        public IQueryable GetArtist()
        {
            Artdrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Artists;
            return query;
        }
        private void clearArt()
        {
            Artname.Text = string.Empty;
            Artbio.InnerText = string.Empty;
            ArtImage.AppRelativeTemplateSourceDirectory = string.Empty;
            ArtId.Text = string.Empty;
            Artroute.Text = string.Empty;
        }

        protected void Artcreate_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Artist/");
            if (ArtImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ArtImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    ArtImage.PostedFile.SaveAs(path + ArtImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (Artname.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("insert into Artists(Name,Bio,ImagePath,ArtistUrl) values('" + Artname.Text + "','" + Artbio.InnerText + "','" + ArtImage.FileName + "','"+Artroute.Text+"')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearArt();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void Artdelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int artId = Convert.ToInt16(Artdrop.SelectedValue);
                var myart = (from art in _db.Artists where art.Id == artId select art).FirstOrDefault();
                if (myart != null)
                {
                    _db.Artists.Remove(myart);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        protected void Artclear_Click(object sender, EventArgs e)
        {
            clearArt();
        }
        protected void Artsearch1_Click(object sender, EventArgs e)
        {
            if (Artsearch.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Artists where  Name='" + Artsearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ArtId.Text = (dr["Id"].ToString());
                    Artname.Text = (dr["Name"].ToString());
                    Artbio.InnerText = (dr["Bio"].ToString());
                    Artroute.Text = (dr["ArtistUrl"].ToString());
                }
                con1.Close();
                Artsearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        protected void Artupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(config1);
            Boolean fileOK1 = false;
            String path1 = Server.MapPath("~/Catalog/Artist/");
            if (ArtImage.HasFile)
            {
                String fileExtension1 = System.IO.Path.GetExtension(ArtImage.FileName).ToLower();
                String[] allowedExtensions1 = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions1.Length; i++)
                {
                    if (fileExtension1 == allowedExtensions1[i])
                    {
                        fileOK1 = true;
                    }
                }
            }

            if (fileOK1)
            {
                try
                {
                    // Save to Images folder.
                    ArtImage.PostedFile.SaveAs(path1 + ArtImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (ArtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update Artists set Name=@artn, Bio=@artb,ImagePath=@artimg,ArtistUrl=@arturl where Id=@arti", con1);
                cmd.Parameters.AddWithValue("@arti", ArtId.Text);
                cmd.Parameters.AddWithValue("@artn", Artname.Text);
                cmd.Parameters.AddWithValue("@artb", Artbio.InnerText);
                cmd.Parameters.AddWithValue("@artimg", ArtImage.FileName);
                cmd.Parameters.AddWithValue("@arturl", Artroute.Text);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearArt();
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot update record";
            }
        }
        #endregion

        #region DeviantSM
        public IQueryable GetDMS()
        {
            DMSdrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.DeviantSocials;
            return query;
        }
        private void clearDMS()
        {
            DMSAM.Text = string.Empty;
            DMSFB.Text = string.Empty;
            DMUP.AppRelativeTemplateSourceDirectory = string.Empty;
            DMSsearch.Text = string.Empty;
        }

        protected void DMScreate_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Artist/");
            if (DMUP.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(DMUP.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    DMUP.PostedFile.SaveAs(path + DMUP.FileName);
                    // Save to Images/Thumbs folder.
                    DMUP.PostedFile.SaveAs(path + "Thumbs/" + DMUP.FileName);

                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (DMSAM.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("insert into DeviantSocials(Name,Url,ImagePath) values('" + DMSAM.Text + "','" + DMSFB.Text + "','" + DMUP.FileName + "')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearDMS();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void DMSdelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int dmsId = Convert.ToInt16(DMSdrop.SelectedValue);
                var mydms = (from dms in _db.DeviantSocials where dms.Id == dmsId select dms).FirstOrDefault();
                if (mydms != null)
                {
                    _db.DeviantSocials.Remove(mydms);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        protected void DMSclear_Click(object sender, EventArgs e)
        {
            clearDMS();
        }
        protected void DMSsearch1_Click(object sender, EventArgs e)
        {
            if (DMSsearch.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from DeviantSocials where  Id='" + DMSsearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DMSId.Text = (dr["Id"].ToString());
                    DMSFB.Text = (dr["Url"].ToString());
                    DMSAM.Text = (dr["Name"].ToString());
                }
                con1.Close();
                DMSsearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        protected void DMSupdate_Click(object sender, EventArgs e)
        {
            if (DMSId.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("update DeviantSocials Url=@dfb, Name=@dam where Id=dmi", con1);
                cmd.Parameters.AddWithValue("@dmi", DMSId.Text);
                cmd.Parameters.AddWithValue("@dfb", DMSFB.Text);
                cmd.Parameters.AddWithValue("@dam", DMSAM.Text);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearDMS();
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot update record";
            }
        }
        #endregion

        #region Genres
        public IQueryable GetGenre()
        {
            Gdrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Genres;
            return query;
        }
        private void clearGen()
        {
            Gname.Text = string.Empty;
            GId.Text = string.Empty;
            Groute.Text = string.Empty;
        }

        protected void Gcreate_Click(object sender, EventArgs e)
        {

            if (Gname.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("insert into Genres(Name,GenreUrl) values('" + Gname.Text + "','"+Groute.Text+"')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearGen();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void Gdelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int gId = Convert.ToInt16(Gdrop.SelectedValue);
                var myg = (from g in _db.Genres where g.Id == gId select g).FirstOrDefault();
                if (myg != null)
                {
                    _db.Genres.Remove(myg);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        protected void Gclear_Click(object sender, EventArgs e)
        {
            clearGen();
        }
        protected void Gsearch1_Click(object sender, EventArgs e)
        {
            if (Gsearch.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Genres where  Name='" + Gsearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    GId.Text = (dr["Id"].ToString());
                    Gname.Text = (dr["Name"].ToString());
                    Groute.Text = (dr["GenreUrl"].ToString());
                }
                con1.Close();
                Gsearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        protected void Gupdate_Click(object sender, EventArgs e)
        {
            if(GId.Text!="")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("update Genres set Name=@gn, Description=@gd, GenreUrl=@gurl where Id=gi",con1);
                cmd.Parameters.AddWithValue("@gi", GId.Text);
                cmd.Parameters.AddWithValue("@gn", Gname.Text);
                cmd.Parameters.AddWithValue("@gd", DBNull.Value);
                cmd.Parameters.AddWithValue("@gurl", Groute.Text);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearGen();
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot update record";
            }
        }
        #endregion

        #region personnels
        public IQueryable GetPers()
        {
            Pedrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Personnels;
            return query;
        }
        private void clearPers()
        {
            Pename.Text = string.Empty;
            Pedes.Text = string.Empty;
            Peurl.Text = string.Empty;
            Pebio.InnerText = string.Empty;
            PeImage.AppRelativeTemplateSourceDirectory = string.Empty;
            PeID.Text = string.Empty;
            Peroute.Text = string.Empty;
        }

        protected void Pecreate_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Personnel/");
            if (PeImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(PeImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    PeImage.PostedFile.SaveAs(path + PeImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (Pename.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("insert into Personnels(Name,Bio,Designation,Url,ImagePath,PersonnelUrl) values('" + Pename.Text + "','" + Pebio.InnerText + "','"+Pedes.Text+"','"+Peurl.Text+"','" + PeImage.FileName + "','"+Peroute.Text+"')", con1);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearPers();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void Pedelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int perId = Convert.ToInt16(Pedrop.SelectedValue);
                var myper = (from per in _db.Personnels where per.Id == perId select per).FirstOrDefault();
                if (myper != null)
                {
                    _db.Personnels.Remove(myper);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        protected void Peclear_Click(object sender, EventArgs e)
        {
            clearPers();
        }
        protected void Pesearch1_Click(object sender, EventArgs e)
        {
            if (Pesearch.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Personnels where  Name='" + Pesearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PeID.Text = (dr["Id"].ToString());
                    Pename.Text = (dr["Name"].ToString());
                    Pebio.InnerText = (dr["Bio"].ToString());
                    Peurl.Text = (dr["Url"].ToString());
                    Pedes.Text = (dr["Designation"].ToString());
                    Peroute.Text = (dr["PersonnelUrl"].ToString());
                }
                con1.Close();
                Pesearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        protected void Peupdate_Click(object sender, EventArgs e)
        {
            Boolean fileOK1 = false;
            String path1 = Server.MapPath("~/Catalog/Personnel/");
            if (PeImage.HasFile)
            {
                String fileExtension1 = System.IO.Path.GetExtension(PeImage.FileName).ToLower();
                String[] allowedExtensions1 = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions1.Length; i++)
                {
                    if (fileExtension1 == allowedExtensions1[i])
                    {
                        fileOK1 = true;
                    }
                }
            }

            if (fileOK1)
            {
                try
                {
                    // Save to Images folder.
                    PeImage.PostedFile.SaveAs(path1 + PeImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
            if (PeID.Text != "")
            {
                SqlConnection con1 = new SqlConnection(config1);
                SqlCommand cmd = new SqlCommand("update Personnels set Name=@pen, Bio=@peb,Designation=@pede,Url=@peu,ImagePath=@peimg, PersonnelUrl=@purl where Id=@pei", con1);
                cmd.Parameters.AddWithValue("@pei", PeID.Text);
                cmd.Parameters.AddWithValue("@pen", Pename.Text);
                cmd.Parameters.AddWithValue("@peb", Pebio.InnerText);
                cmd.Parameters.AddWithValue("@pede", Pedes.Text);
                cmd.Parameters.AddWithValue("@peu", Peurl.Text);
                cmd.Parameters.AddWithValue("@peimg", PeImage.FileName);
                cmd.Parameters.AddWithValue("@purl", Peroute.Text);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                clearPers();
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot update record";
            }
        }
        #endregion

        #region Songs
        public IQueryable GetSong()
        {
            Sdrop.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Songs;
            return query;
        }
        public IQueryable GetSongGenre()
        {
            Sgenre.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Genres;
            return query;
        }
        public IQueryable GetSongArtist()
        {
            Sartist.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Artists;
            return query;
        }
        public IQueryable GetSongAlbum()
        {
            Salb.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Albums;
            return query;
        }
        private void clearSng()
        {
            Stitle.Text = string.Empty;
            SGname.Text = string.Empty;
            SArtname.Text = string.Empty;
            SAlbname.Text = string.Empty;
            SRdate.Text = string.Empty;
            SUdate.Text = string.Empty;
            SAmack.Text = string.Empty;
            SFlink.Text = string.Empty;
            SLi.Text = string.Empty;
            SPri.Text = string.Empty;
            SProd.Text = string.Empty;
            Sfeat.Text = string.Empty;
            Swriter.Text = string.Empty;
            SPurc.Text = string.Empty;
            SAudio.AppRelativeTemplateSourceDirectory = string.Empty;
            SDcount.Text = string.Empty;
            Sdesc.InnerText = string.Empty;
            SImage.AppRelativeTemplateSourceDirectory = string.Empty;
            Sroute.Text = string.Empty;
        }

        protected void Screate_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(config1);
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Song/");
            if (SImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(SImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    SImage.PostedFile.SaveAs(path + SImage.FileName);
                }
                catch (Exception ex)
                {
                    alertfail.InnerText = ex.Message;
                }
            }
           
            if (Stitle.Text != "" && Sartist.Text!="" && Salb.Text!="")
            {
                string filename = Path.GetFileName(SAudio.PostedFile.FileName);
                string contentType = SAudio.PostedFile.ContentType;
                using (Stream fs = SAudio.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        using (SqlCommand cmd = new SqlCommand("insert into Songs values(@Title,@GenreId,@ArtistId,@AlbumId,@Description,@ReleaseDate,@UploadDate,@ImagePath,@AudiomackUrl,@Fanlink,@License,@Price,@Producer,@Featuring,@Writter,@PurchaseURL,@AudioPath,@ContentType,@Data,@DownloadCount,@ArtistName,@AlbumName,@GenreName,@SongUrl)", con1))
                        {
                            cmd.Parameters.AddWithValue("@Title", Stitle.Text);
                            cmd.Parameters.AddWithValue("@GenreId", Sgenre.Text);
                            cmd.Parameters.AddWithValue("@ArtistId", Sartist.Text);
                            cmd.Parameters.AddWithValue("@AlbumId", Salb.Text);
                            cmd.Parameters.AddWithValue("@Description", Sdesc.InnerText);
                            cmd.Parameters.AddWithValue("@ReleaseDate", SRdate.Text);
                            cmd.Parameters.AddWithValue("@UploadDate", SUdate.Text);
                            cmd.Parameters.AddWithValue("@ImagePath", SImage.FileName);
                            cmd.Parameters.AddWithValue("@AudiomackUrl", SAmack.Text);
                            cmd.Parameters.AddWithValue("@Fanlink", SFlink.Text);
                            cmd.Parameters.AddWithValue("@License", SLi.Text);
                            cmd.Parameters.AddWithValue("@Price", SPri.Text);
                            cmd.Parameters.AddWithValue("@Producer", SProd.Text);
                            cmd.Parameters.AddWithValue("@Featuring", Sfeat.Text);
                            cmd.Parameters.AddWithValue("@Writter", Swriter.Text);
                            cmd.Parameters.AddWithValue("@PurchaseURL", SPurc.Text);
                            cmd.Parameters.AddWithValue("@AudioPath", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@DownloadCount", SDcount.Text);
                            cmd.Parameters.AddWithValue("@ArtistName", SArtname.Text);
                            cmd.Parameters.AddWithValue("@AlbumName", SAlbname.Text);
                            cmd.Parameters.AddWithValue("@GenreName", SGname.Text);
                            cmd.Parameters.AddWithValue("@SongUrl", Sroute.Text);
                            con1.Open();
                            cmd.ExecuteNonQuery();
                            con1.Close();
                            clearSng();
                        }

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?Action=create");
                    }
                }       
                
            }
            else if (Stitle.Text != "" && Sartist.Text != null && Salb.Text != "")
            {
                string filename = Path.GetFileName(SAudio.PostedFile.FileName);
                string contentType = SAudio.PostedFile.ContentType;
                using (Stream fs = SAudio.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        using (SqlCommand cmd = new SqlCommand("insert into Songs values(@Title,@GenreId,@ArtistId,@AlbumId,@Description,@ReleaseDate,@UploadDate,@ImagePath,@AudiomackUrl,@Fanlink,@License,@Price,@Producer,@Featuring,@Writter,@PurchaseURL,@AudioPath,@ContentType,@Data,@DownloadCount,@ArtistName,@AlbumName,@GenreName,@SongUrl)", con1))
                        {
                            cmd.Parameters.AddWithValue("@Title", Stitle.Text);
                            cmd.Parameters.AddWithValue("@GenreId", Sgenre.Text);
                            cmd.Parameters.AddWithValue("@ArtistId",DBNull.Value);
                            cmd.Parameters.AddWithValue("@AlbumId", Salb.Text);
                            cmd.Parameters.AddWithValue("@Description", Sdesc.InnerText);
                            cmd.Parameters.AddWithValue("@ReleaseDate", SRdate.Text);
                            cmd.Parameters.AddWithValue("@UploadDate", SUdate.Text);
                            cmd.Parameters.AddWithValue("@ImagePath", SImage.FileName);
                            cmd.Parameters.AddWithValue("@AudiomackUrl", SAmack.Text);
                            cmd.Parameters.AddWithValue("@Fanlink", SFlink.Text);
                            cmd.Parameters.AddWithValue("@License", SLi.Text);
                            cmd.Parameters.AddWithValue("@Price", SPri.Text);
                            cmd.Parameters.AddWithValue("@Producer", SProd.Text);
                            cmd.Parameters.AddWithValue("@Featuring", Sfeat.Text);
                            cmd.Parameters.AddWithValue("@Writter", Swriter.Text);
                            cmd.Parameters.AddWithValue("@PurchaseURL", SPurc.Text);
                            cmd.Parameters.AddWithValue("@AudioPath", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@DownloadCount", SDcount.Text);
                            cmd.Parameters.AddWithValue("@ArtistName", SArtname.Text);
                            cmd.Parameters.AddWithValue("@AlbumName", SAlbname.Text);
                            cmd.Parameters.AddWithValue("@GenreName", SGname.Text);
                            cmd.Parameters.AddWithValue("@SongUrl", Sroute.Text);
                            con1.Open();
                            cmd.ExecuteNonQuery();
                            con1.Close();
                            clearSng();
                        }

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?Action=create");
                    }
                }     
                
            }
            else if (Stitle.Text != "" && Sartist.Text != "" && Salb.Text != null)
            {
                string filename = Path.GetFileName(SAudio.PostedFile.FileName);
                string contentType = SAudio.PostedFile.ContentType;
                using (Stream fs = SAudio.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        using (SqlCommand cmd = new SqlCommand("insert into Songs values(@Title,@GenreId,@ArtistId,@AlbumId,@Description,@ReleaseDate,@UploadDate,@ImagePath,@AudiomackUrl,@Fanlink,@License,@Price,@Producer,@Featuring,@Writter,@PurchaseURL,@AudioPath,@ContentType,@Data,@DownloadCount,@ArtistName,@AlbumName,@GenreName,@SongUrl)", con1))
                        {
                            cmd.Parameters.AddWithValue("@Title", Stitle.Text);
                            cmd.Parameters.AddWithValue("@GenreId", Sgenre.Text);
                            cmd.Parameters.AddWithValue("@ArtistId", Sartist.Text);
                            cmd.Parameters.AddWithValue("@AlbumId",  DBNull.Value );
                            cmd.Parameters.AddWithValue("@Description", Sdesc.InnerText);
                            cmd.Parameters.AddWithValue("@ReleaseDate", SRdate.Text);
                            cmd.Parameters.AddWithValue("@UploadDate", SUdate.Text);
                            cmd.Parameters.AddWithValue("@ImagePath", SImage.FileName);
                            cmd.Parameters.AddWithValue("@AudiomackUrl", SAmack.Text);
                            cmd.Parameters.AddWithValue("@Fanlink", SFlink.Text);
                            cmd.Parameters.AddWithValue("@License", SLi.Text);
                            cmd.Parameters.AddWithValue("@Price", SPri.Text);
                            cmd.Parameters.AddWithValue("@Producer", SProd.Text);
                            cmd.Parameters.AddWithValue("@Featuring", Sfeat.Text);
                            cmd.Parameters.AddWithValue("@Writter", Swriter.Text);
                            cmd.Parameters.AddWithValue("@PurchaseURL", SPurc.Text);
                            cmd.Parameters.AddWithValue("@AudioPath", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@DownloadCount", SDcount.Text);
                            cmd.Parameters.AddWithValue("@ArtistName", SArtname.Text);
                            cmd.Parameters.AddWithValue("@AlbumName", SAlbname.Text);
                            cmd.Parameters.AddWithValue("@GenreName", SGname.Text);
                            cmd.Parameters.AddWithValue("@SongUrl", Sroute.Text);
                            con1.Open();
                            cmd.ExecuteNonQuery();
                            con1.Close();
                            clearSng();
                        }

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?Action=create");
                    }
                }     
            }
            else if (Stitle.Text != "" && Sartist.Text != null && Salb.Text != null)
            {
                string filename = Path.GetFileName(SAudio.PostedFile.FileName);
                string contentType = SAudio.PostedFile.ContentType;
                using (Stream fs = SAudio.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        using (SqlCommand cmd = new SqlCommand("insert into Songs values(@Title,@GenreId,@ArtistId,@AlbumId,@Description,@ReleaseDate,@UploadDate,@ImagePath,@AudiomackUrl,@Fanlink,@License,@Price,@Producer,@Featuring,@Writter,@PurchaseURL,@AudioPath,@ContentType,@Data,@DownloadCount,@ArtistName,@AlbumName,@GenreName,@SongUrl)", con1))
                        {
                            cmd.Parameters.AddWithValue("@Title", Stitle.Text);
                            cmd.Parameters.AddWithValue("@GenreId", Sgenre.Text);
                            cmd.Parameters.AddWithValue("@ArtistId",  DBNull.Value);
                            cmd.Parameters.AddWithValue("@AlbumId",  DBNull.Value );
                            cmd.Parameters.AddWithValue("@Description", Sdesc.InnerText);
                            cmd.Parameters.AddWithValue("@ReleaseDate", SRdate.Text);
                            cmd.Parameters.AddWithValue("@UploadDate", SUdate.Text);
                            cmd.Parameters.AddWithValue("@ImagePath", SImage.FileName);
                            cmd.Parameters.AddWithValue("@AudiomackUrl", SAmack.Text);
                            cmd.Parameters.AddWithValue("@Fanlink", SFlink.Text);
                            cmd.Parameters.AddWithValue("@License", SLi.Text);
                            cmd.Parameters.AddWithValue("@Price", SPri.Text);
                            cmd.Parameters.AddWithValue("@Producer", SProd.Text);
                            cmd.Parameters.AddWithValue("@Featuring", Sfeat.Text);
                            cmd.Parameters.AddWithValue("@Writter", Swriter.Text);
                            cmd.Parameters.AddWithValue("@PurchaseURL", SPurc.Text);
                            cmd.Parameters.AddWithValue("@AudioPath", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@DownloadCount", SDcount.Text);
                            cmd.Parameters.AddWithValue("@ArtistName", SArtname.Text);
                            cmd.Parameters.AddWithValue("@AlbumName", SAlbname.Text);
                            cmd.Parameters.AddWithValue("@GenreName", SGname.Text);
                            cmd.Parameters.AddWithValue("@SongUrl", Sroute.Text);
                            con1.Open();
                            cmd.ExecuteNonQuery();
                            con1.Close();
                            clearSng();
                        }

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?Action=create");
                    }
                }     
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void Sdelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int sId = Convert.ToInt16(Sdrop.SelectedValue);
                var mys = (from s in _db.Songs where s.Id == sId select s).FirstOrDefault();
                if (mys != null)
                {
                    _db.Songs.Remove(mys);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        protected void Sclear_Click(object sender, EventArgs e)
        {
            clearSng();
        }
        #endregion

        #region Roles

        public IQueryable GetUsers()
        {
            users.Items.Insert(0,new ListItem("",""));
            var _db = new ApplicationDbContext();
            IQueryable query = _db.Users;
            return query;
        }

        public IQueryable GetRoles()
         {
            roles.Items.Insert(0, new ListItem("", ""));
            var _db = new ApplicationDbContext();
             IQueryable query = _db.Roles;
             return query;
         }
        protected void rcreate_Click(object sender, EventArgs e)
        {
            if (users.Text != "")
            {
                string config = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(config);
                SqlCommand cmd = new SqlCommand("insert into AspNetUserRoles values (@name,@role)", con);
                cmd.Parameters.AddWithValue("@name", users.Text);
                cmd.Parameters.AddWithValue("@role", roles.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                alertfail.InnerText = "Cannot create";
            }
        }
        protected void rupdate_Click(object sender, EventArgs e)
        {
            if (users.Text != "")
            {
                string config = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(config);
                SqlCommand cmd = new SqlCommand("update AspNetUserRoles set UserId=@name,RoleId=@role where UserId=@name", con);
                cmd.Parameters.AddWithValue("@name", users.Text);
                cmd.Parameters.AddWithValue("@role", roles.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=update");
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }

        protected void rdelete_Click(object sender, EventArgs e)
        {
             if (users.Text != "")
             {
                string config = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(config);
                SqlCommand cmd = new SqlCommand("delete from AspNetUserRoles where UserID=@name", con);
                 cmd.Parameters.AddWithValue("@name", users.Text);
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 // Reload the page.
                 string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                 Response.Redirect(pageUrl + "?Action=delete");
            }
             else
             {
                 alertfail.InnerText = "Cannot find record";
             }
        }
        #endregion

        #region Users
        public IQueryable GetUserss()
        {
            DropDownList1.Items.Insert(0, new ListItem("", ""));
            var _db = new ApplicationDbContext();
            IQueryable query = _db.Users;
            return query;
        }

        public IQueryable GetEmails()
        {
            var _db = new ApplicationDbContext();
            IQueryable query = _db.Users;
            return query;
        }

        protected void userdelete_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text != "")
            {
                string config = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(config);
                SqlCommand cmd = new SqlCommand("delete from AspNetUsers where Id=@name", con);
                cmd.Parameters.AddWithValue("@name", DropDownList1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=delete");
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }
        #endregion

        #region Mailing
        private void clearmail()
        {
            inputEmail.Text = string.Empty;
            inputMessage.Text = string.Empty;
            inputSubject.Text = string.Empty;
            upload1.AppRelativeTemplateSourceDirectory = string.Empty;
        }
        protected void request_Click(object sender, EventArgs e)
        {
            using (var mailClient = new SmtpClient())
            {
                MailMessage email = new MailMessage(new MailAddress("noreply@deviantmusic.com", "(Do not reply)"), new MailAddress(inputEmail.Text));
                email.Subject = inputSubject.Text;
                email.Body =  inputMessage.Text;
                email.IsBodyHtml = true;
                if (upload1.HasFile)
                {
                    HttpFileCollection fc = Request.Files;
                    for (int i = 0; i <= fc.Count - 1; i++)
                    {
                        HttpPostedFile pf = fc[i];
                        Attachment attach = new Attachment(pf.InputStream, pf.FileName);
                        email.Attachments.Add(attach);
                    }
                }
                mailClient.Host = "smtp.gmail.com";
                mailClient.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "your email";
                NetworkCred.Password = "your password";
                mailClient.UseDefaultCredentials = true;
                mailClient.Credentials = NetworkCred;
                mailClient.Port = 587;
                mailClient.Send(email);
            }
            respsuccess.Text = "Email sent successfully";
            clearmail();
        }
        #endregion

        #region DownloadGen
        private void clearDown()
        {
            DownUrl.Text = string.Empty;
            TempoDown.Checked = false;
        }

        public IQueryable GetSongsss()
        {
            SongDrop.Items.Insert(0, new ListItem("", ""));
            string songlicense = "Paid";
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Songs.Where( s => s.License == songlicense );
            return query;
        }

        private string GetDownloadToken(int length)
        {
            int intZero = '0';
            int intNine = '9';
            int intA = 'A';
            int intZ = 'Z';
            int intCount = 0;
            int intRandomNumber = 0;
            string strDownloadToken = "";
            Random objRandom = new Random(System.DateTime.Now.Millisecond);
            while (intCount < length)
            {
                intRandomNumber = objRandom.Next(intZero, intZ);
                if (((intRandomNumber >= intZero) &&
                    (intRandomNumber <= intNine) ||
                    (intRandomNumber >= intA) &&
                    (intRandomNumber <= intZ)))
                {
                    strDownloadToken = strDownloadToken + (char)intRandomNumber;
                    intCount++;
                }
            }
            return strDownloadToken;
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            HyperLink HyperLink1 = new HyperLink();
            var _db = new DeviantContext();
            int sId = Convert.ToInt16(SongDrop.SelectedValue);
            Song s = new Song();
            s.Id = sId;
            if(TempoDown.Checked)
            {
                var _db1 = new DeviantContext();
                Download d = new Download();
                d.DownloadTitle = "Temporary " + DownTT.Text;
                d.Url = "~/temporarydownloads/" + DownUrl.Text + ".mp3";
                d.ExpireAfterDownload = true;
                d.DownloadToken = GetDownloadToken(10);
                d.Hits = 0;
                d.SongId = sId;
                d.Downloaded = false;
                _db1.Downloads.Add(d);
                _db1.SaveChanges();
                HyperLink1.NavigateUrl = string.Format("~/temporarydownloads/{0}", d.DownloadToken);
                HyperLink1.Text = Page.ResolveClientUrl(HyperLink1.NavigateUrl);
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            else
            {
                var _db1 = new DeviantContext();
                Download d = new Download();
                d.DownloadTitle = DownTT.Text;
                d.Url = "~/downloads/" + DownUrl.Text + ".mp3";
                d.ExpireAfterDownload = false;
                d.DownloadToken = GetDownloadToken(10);
                d.Hits = 0;
                d.SongId = sId;
                d.Downloaded = false;
                _db1.Downloads.Add(d);
                _db1.SaveChanges();
                HyperLink1.NavigateUrl = string.Format("~/downloads/{0}", d.DownloadToken);
                HyperLink1.Text = Page.ResolveClientUrl(HyperLink1.NavigateUrl);
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=create");
            }
            clearDown();
        }

        #endregion

        #region DownloadList
        public IQueryable GetDownloads()
        {
            SongDrop1.Items.Insert(0, new ListItem("", ""));
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable query = _db.Downloads;
            return query;
        }

        protected void urlsearch1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(config1);
            var _db = new DeviantContext();
            Download d = new Download();
            if (urlsearch.Text != "" || d.ExpireAfterDownload.Equals(true))
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Downloads where  Title='" + urlsearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TempDownUrl.Text = "temporarydownloads/" + (dr["DownloadToken"].ToString());
                }
                con1.Close();
                urlsearch.Text = string.Empty;
            }
            else if(urlsearch.Text!="" || d.ExpireAfterDownload.Equals(false))
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Downloads where  Title='" + urlsearch.Text + "'", con1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TempDownUrl.Text = "downloads/" + (dr["DownloadToken"].ToString());
                }
                con1.Close();
                urlsearch.Text = string.Empty;
            }
            else
            {
                alertfail.InnerText = "Cannot find record";
            }
        }

        protected void Downdelete_Click(object sender, EventArgs e)
        {
            using (var _db = new Deviant_Music.Models.DeviantContext())
            {
                int dId = Convert.ToInt16(SongDrop1.SelectedValue);
                var myd = (from d in _db.Downloads where d.Id == dId select d).FirstOrDefault();
                if (myd != null)
                {
                    _db.Downloads.Remove(myd);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Action=delete");
                }

                else
                {
                    alertfail.InnerText = "Cannot find record";
                }
            }
        }
        #endregion

        

    }
}