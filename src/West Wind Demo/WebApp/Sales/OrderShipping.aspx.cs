using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security; //for the settings class

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole)) //this allows only certain user types to access the page
                Response.Redirect("~", true);

            if (!IsPostBack)
            {
                // Load up the info on the supplier 
                // TODO: Replace hard-coded supplier ID with the user's supplier ID
                SupplierInfo.Text = "Temp supplier: ID 2";

            }
        }
    }
}