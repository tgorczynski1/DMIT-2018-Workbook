using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admin.Security
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //redirects user from security page if they are not an admin
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.AdminRole))
                Response.Redirect("~/", true);
        }
    }
}