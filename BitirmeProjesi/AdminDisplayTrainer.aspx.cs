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
    public partial class AdminDisplayTrainer : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["adminSession"] == null)
            {
                Response.Redirect("Main.aspx");
            }
           /* Label tb;
            if (!Page.IsPostBack)
            {
                conn.Open();
                SqlCommand trainerDataProgram = new SqlCommand();
                trainerDataProgram.Connection = conn;
                trainerDataProgram.CommandText = "select count(*) as SalesProgram from UserProgram up where up.Program_ID in(select p.Program_ID from Program p where p.Trainer_ID=1)";
                SqlDataReader drProgram = trainerDataProgram.ExecuteReader();
                int i = 0;  
                while (drProgram.Read())
                {
                    tb = (Label)GridView1.Rows[i].FindControl("TextBoxProgramNumber");
                    tb.Text =  drProgram[0].ToString();
                    i++;

                }



                conn.Close();
            }*/
             
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            
            Session["trainerDisplayID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["trainerDisplayNameSurname"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;
            Session["trainerDisplayIntro"] = (GridView1.SelectedRow.FindControl("Label4") as Label).Text;
            Session["trainerDisplayBio"] = (GridView1.SelectedRow.FindControl("Label5") as Label).Text;
            Response.Redirect("AdminDisplayTrainerDetails.aspx");


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