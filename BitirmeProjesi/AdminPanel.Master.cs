using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminSession"] == null)
            {
                Response.Redirect("Main.aspx");
            }
        }

        protected void logout(object sender, EventArgs e)
        {

            Session.Remove("trainerName");
            Session.Remove("rejectedTrainer");
            Response.Redirect("Main.aspx");
        }

    }
}