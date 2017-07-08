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
    public partial class Deneme : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["adminSession"] != null)
            {
                // Response.Write("Hoşgeldin" + Session["trainerEmail"].ToString());
            }
            else
            {
                Response.Redirect("Main.aspx");
            }

            if (!Page.IsPostBack)
            {
                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                trainerData.CommandText = "select count(*) as Customer,(select count(*) from Users u2 where u2.Role_ID=2) as Trainer from Users u where u.Role_ID=3";
                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    Label1.Text = dr[0].ToString();
                    Label2.Text = dr[1].ToString();
                }



                conn.Close();

                conn.Open();
                trainerData.Connection = conn;
                trainerData.CommandText = "select count(*) as totalSales,sum(p.ProgramPrice) as totalIncome from UserProgram up,Program p where p.Program_ID = up.Program_ID";
                dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    Label3.Text = dr[0].ToString();
                    Label4.Text = dr[1].ToString();
                }

                conn.Close();
                //select count(*) as totalSales,sum(p.ProgramPrice) as totalIncome from UserProgram up,Program p where p.Program_ID = up.Program_ID
            }


        }
    }
}