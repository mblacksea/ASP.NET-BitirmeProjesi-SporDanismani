using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

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

            if (!Page.IsPostBack)
            {
              //  Session["trainerID"]
                conn.Open();
                string checkTotalSales = "select count(*) as totalSales from Program p,UserProgram up where p.Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "' and up.Program_ID=p.Program_ID";
                SqlCommand com = new SqlCommand(checkTotalSales, conn);
                int tempTotalSales = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                conn.Open();
                string checkUserTotalIncome = "select isnull(sum(p.ProgramPrice),0) as totalIncome from Program p,UserProgram up where p.Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "' and up.Program_ID=p.Program_ID";
                com = new SqlCommand(checkUserTotalIncome, conn);
               
                    int tempTotalIncome = Convert.ToInt32(com.ExecuteScalar().ToString());

                    conn.Close();

                    Label1.Text = tempTotalSales.ToString();
                    Label2.Text = tempTotalIncome.ToString() + "$";


                    Session["tempTotalSales"] = tempTotalSales.ToString();
                    Session["tempTotalIncome"] = tempTotalIncome.ToString();


               


            }

        }
    }
}