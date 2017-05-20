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
    public partial class TrainerMyPrograms : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        Image a;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand programPhoto = new SqlCommand();
            programPhoto.Connection = conn;
            programPhoto.CommandText = "select ProgramPhoto from Program where Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
            SqlDataReader dr = programPhoto.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                try
                {
                    byte[] _bytes = (byte[])dr[0];
                    a =  (Image)GridView1.Rows[i].FindControl("Image1");
                    a.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);


                }
                catch
                {
                    a.ImageUrl = "images/userDefaultImage.jpg";

                }
                i++;
            }
            conn.Close();
        }

        protected void MyButtonClick(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int deleteProgramID = Convert.ToInt32((gvr.FindControl("Label1") as Label).Text);
            conn.Open();
            SqlCommand programDelete = new SqlCommand();
            programDelete.Connection = conn;
            programDelete.CommandText = "Delete From ProgramExercise where Program_ID='"+ deleteProgramID+"'";
            programDelete.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand programDelete2 = new SqlCommand();
            programDelete2.Connection = conn;
            programDelete2.CommandText = "Delete From Program where Program_ID='" + deleteProgramID + "'";
            programDelete2.ExecuteNonQuery();
            conn.Close();

            GridView1.DataBind();



           /* int index = Convert.ToInt32(e.RowIndex);
            int deleteProgramID = Convert.ToInt32( (GridView1.Rows[index].FindControl("Label1") as Label).Text);
            conn.Open();
            SqlCommand programDelete = new SqlCommand();
            programDelete.Connection = conn;
            programDelete.CommandText = "Delete From Program where Program_ID='"+ deleteProgramID+"'";
            programDelete.ExecuteNonQuery();
            conn.Close();*/
         
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

  
            Session["updateProgramID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Response.Redirect("TrainerMyProgramsDetails.aspx");


        }
    }
}