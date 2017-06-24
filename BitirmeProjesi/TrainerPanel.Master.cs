using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["rejectedTrainer"].ToString() == "true")
                {
                    programVisible.Visible = false;
                }
                if (Session["trainerName"] == null)
                {
                    Response.Redirect("Main.aspx");
                }
             
              
                else
                {
                    Label1.Text = Session["trainerName"].ToString();
                }
            }
            catch
            {
                Response.Redirect("Main.aspx");
            }
           
       
        }

        protected void logout(object sender, EventArgs e)
        {
        
            Session.Remove("trainerEmail");
            Session.Remove("trainerName");
            Session.Remove("rejectedTrainer");
            Response.Redirect("Main.aspx");
        }

     

       
    }
}