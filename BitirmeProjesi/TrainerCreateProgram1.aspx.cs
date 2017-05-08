using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerCreateProgram1 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("SELECT ProgramSpec_ID, ProgramSpec_Name FROM ProgramSpec");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "ProgramSpec_Name";
                DropDownList1.DataValueField = "ProgramSpec_ID";
                DropDownList1.DataBind();
                con.Close();


                SqlCommand cmd2 = new SqlCommand("SELECT ProgramDiff_ID, ProgramDiff_Name FROM ProgramDifficulty");
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                con.Open();
                DropDownList2.DataSource = cmd2.ExecuteReader();
                DropDownList2.DataTextField = "ProgramDiff_Name";
                DropDownList2.DataValueField = "ProgramDiff_ID";
                DropDownList2.DataBind();
                con.Close();



            }
        }
        protected void next(object sender, EventArgs e)
        {


            Session["ProgramSpecID"] = DropDownList1.SelectedValue;
            Session["ProgramDiffID"] = DropDownList2.SelectedValue;
            Session["order"] = 0;
            Response.Redirect("TrainerCreateProgram2.aspx");
               /* using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "insert into Program values (@Trainer_ID, @ProgramSpec_ID, @ProgramDiff_ID,@User_ID)SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {

                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Trainer_ID", Convert.ToInt32(Session["trainerID"].ToString()));
                        cmd.Parameters.AddWithValue("@ProgramSpec_ID", Convert.ToInt32(DropDownList1.SelectedValue));
                        cmd.Parameters.AddWithValue("@ProgramDiff_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                        cmd.Parameters.AddWithValue("@User_ID", 3);
                        con.Open();
                        int programID = Convert.ToInt32(cmd.ExecuteScalar());
                        Session["programID"] = programID.ToString();
                        con.Close();
                        Response.Redirect("TrainerCreateProgram2.aspx");
                    }
                }*/
         }

          
     
    }
}