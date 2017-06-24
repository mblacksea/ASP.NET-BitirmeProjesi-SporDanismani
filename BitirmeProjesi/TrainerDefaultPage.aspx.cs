using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["trainerEmail"] != null)
            {
              // Response.Write("Hoşgeldin" + Session["trainerEmail"].ToString());
            }
            else
            {
                Response.Redirect("Main.aspx");
            }

            if (Session["CreateProgramSuccess"]!= null)
            {
                MessageBox.Show("Successful", MessageBox.MesajTipleri.Success, false, 3000);
                Session.Remove("CreateProgramSuccess");
            }

        }
    }
}