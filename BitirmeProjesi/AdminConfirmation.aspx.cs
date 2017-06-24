using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminSession"] == null)
            {
                Response.Redirect("Main.aspx");
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
            //Label1.Text = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["trainerDetailsID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["trainerDetailsEmail"] = (GridView1.SelectedRow.FindControl("Label4") as Label).Text;
            Response.Redirect("AdminConfirmationTrainerDetails.aspx");
         
            
        }
     


    }
}