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
    public partial class DMPersonnel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Personnel> GetPersonnels([QueryString("id")] int? personnelId)
        {
            var _db = new Deviant_Music.Models.DeviantContext();
            IQueryable<Personnel> query = _db.Personnels.OrderByDescending(person=>person.Id);
            if (personnelId.HasValue && personnelId > 0)
            {
                query = query.Where(person => person.Id == personnelId);
            }

            return query;
        }
    }
}