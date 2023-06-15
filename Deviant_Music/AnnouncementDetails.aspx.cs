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
    public partial class AnnouncementDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Announcement> GetAnn([QueryString("annId")] int? annId, [RouteData] string announcementTitle)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Announcement> query = _db.Announcements;
            if (annId.HasValue && annId > 0)
            {
                query = query.Where(ann => ann.Id == annId);
            }
            else if (!String.IsNullOrEmpty(announcementTitle))
            {
                query = query.Where(ann =>
                          String.Compare(ann.AnnouncementUrl, announcementTitle) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}