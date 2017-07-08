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
    public partial class AdminDisplayUsersDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label1.Text = Label1.Text + Session["userDisplayUsername"].ToString() + "-> All Programs";

                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                trainerData.CommandText = "SELECT sum([Program].[ProgramPrice]) FROM [UserProgram],[Program],[Users] WHERE [Users].[User_ID]=[Program].[Trainer_ID] and ([UserProgram].[User_ID] = '" + Session["userDisplayID"].ToString() + "') and [Program].[Program_ID]=[UserProgram].[Program_ID]";
                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    Label7.Text = dr[0].ToString();
   
                }



                conn.Close();



            }
        }

        protected void searchButton(object sender, EventArgs e)
        {
            string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'");
            SqlDataSource1.FilterParameters.Clear();
            SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField", "Text"));
            SqlDataSource1.FilterExpression = FilterExpression;
        }
    }
}