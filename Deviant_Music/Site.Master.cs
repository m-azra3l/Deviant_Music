using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.ModelBinding;
using System.Web.Routing;
using Deviant_Music.Models;

namespace Deviant_Music
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        string searchtext, url;
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
       
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                BindImageRepeater();
               
            }
            if (HttpContext.Current.User.IsInRole("Administrator Level1"))
            {
                adminLink.Visible = true;

            }
            if (HttpContext.Current.User.IsInRole("Administrator Level2"))
            {
                adminLink.Visible = true;

            }
            if (HttpContext.Current.User.IsInRole("SuperAdministrator"))
            {
                adminLink.Visible = true;

            }
        }
        #endregion
        #region data
        public IQueryable<Genre> GetGenres()
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Genre> query = _db.Genres;
            return query;
        }
        public IQueryable<DeviantSocial> GetSocials()
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<DeviantSocial> query = _db.DeviantSocials.OrderBy(social => social.Name);
            return query;
        }
        /*public IQueryable<Announcement> GetAnn([QueryString("Id")] int? annId)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Announcement> query = _db.Announcements;
            if (annId.HasValue && annId > 0)
            {
                query = query.Where(ann => ann.Id == annId);
            }
           
            else
            {
                query = null;
            }
            return query;
        }*/

        protected void search_click(object sender, EventArgs e)
        {
            searchtext = searchbox.Text;
            url = "SearchResult.aspx?val=" + searchtext;
            Response.Redirect(url);
        }

        protected void search1_click(object sender, EventArgs e)
        {
            searchtext = searchbox1.Text;
            url = "SearchResult.aspx?val=" + searchtext;
            Response.Redirect(url);
        }

        private void BindImageRepeater()
        {
            string config = ConfigurationManager.ConnectionStrings["DeviantMusic"].ConnectionString;
            SqlConnection con = new SqlConnection(config);
            string picker = "SELECT * FROM Announcements Order by Id desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(picker, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            announcelist.DataSource = ds;
            announcelist.DataBind();
        }

        #endregion




    }

}