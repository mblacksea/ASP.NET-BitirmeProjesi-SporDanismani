using System;
using System.Collections;
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
    public partial class TrainerCreateProgram2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
       



            if (Session["trainerID"] == null)
            {
                Response.Redirect("Main.aspx");
            }

            try
            {
                if ((bool)Session["editProgramPermission"] == false)
                {
                    GridView1.Visible = false;
                    ReOrder.Visible = false;
                    searchBox.Visible = false;
                    foreach (GridViewRow row in GridView2.Rows)
                    {
                        LinkButton lb = (LinkButton)row.FindControl("LinkButtonEdit");
                        lb.Visible = false;
                        lb = (LinkButton)row.FindControl("LinkButton1");
                        lb.Visible = false;
                    }
                }
            }
            catch
            {
                if (Session["programID"] != null)
                {
                    nextStepButtonID.Visible = true;
                    ReOrder.Visible = true;

                    conn.Open();
                    SqlCommand trainerData = new SqlCommand();
                    trainerData.Connection = conn;
                    trainerData.CommandText = "select MAX(OrderExercise) from ProgramExercise where Program_ID='" + Convert.ToInt32(Session["programID"].ToString()) + "'";


                    SqlDataReader dr = trainerData.ExecuteReader();
                    while (dr.Read())
                    {
                        Session["order"] = dr[0].ToString();
                    }



                    conn.Close();



                }
                else
                {


                    nextStepButtonID.Visible = false;
                    ReOrder.Visible = false;
                }
            }
          
          
                
            

            if (!Page.IsPostBack)
            {
                header.InnerText = header.InnerText + Session["ProgramTittle"].ToString();

            }

           
        }



        protected void UpdatePreference(object sender, EventArgs e)
        {



            int[] locationIds = (from p in Request.Form["Siralama"].Split(',') select int.Parse(p)).ToArray();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            ArrayList myExercises_ID = new ArrayList();
            ArrayList mySetSayisi = new ArrayList();
            ArrayList myTekrarSayisi = new ArrayList();
            ArrayList myAgirlik = new ArrayList();
            ArrayList myRestTime = new ArrayList();
            ArrayList myExerciseTime = new ArrayList();
            ArrayList myID = new ArrayList();
            for (int i = 0; i < locationIds.Length; i++)
            {
                trainerData.CommandText = "select Exercises_ID,SetSayisi,TekrarSayisi,Agirlik,RestTime,ExerciseTime,ID from ProgramExercise where Program_ID='"+Convert.ToInt32(Session["programID"].ToString())+"' and OrderExercise='" + locationIds[i] + "' ORDER BY OrderExercise ";
                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    myExercises_ID.Add(dr[0]);
                    mySetSayisi.Add(dr[1]);
                    myTekrarSayisi.Add(dr[2]);
                    myAgirlik.Add(dr[3]);
                    myRestTime.Add(dr[4]);
                    myExerciseTime.Add(dr[5]);
                    myID.Add(dr[6]);
            

                }
                dr.Close();

            }




            int preference = 1;
            foreach (int locationId in locationIds)
            {
                this.UpdatePreference(locationId, preference, myExercises_ID, mySetSayisi, myTekrarSayisi, myAgirlik, myRestTime, myExerciseTime,myID);
                preference += 1;
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }







        private void UpdatePreference(int locationId, int preference, ArrayList myExercises_ID,ArrayList mySetSayisi,ArrayList myTekrarSayisi,ArrayList myAgirlik, ArrayList myRestTime,ArrayList myExerciseTime,ArrayList myID)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;




            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE ProgramExercise SET OrderExercise = @OrderExercise WHERE ID = @ID"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@OrderExercise", preference);
                        cmd.Parameters.AddWithValue("@ID", myID[preference - 1]);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        GridView2.DataBind();
                    }
                }
            }
        }



        protected void Next_Step(object sender, EventArgs e)
        {
            //Bu butona basildiginda circle kismina gecilecek.
            if (Session["updateSession"] != null)
            {
                Response.Redirect("TrainerCircleExerciseUpdate.aspx");
            }
            else
            {
                Response.Redirect("TrainerCircleExercise.aspx");

            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            //Label1.Text = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            // Session["trainerDetailsID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            //  Session["trainerDetailsEmail"] = (GridView1.SelectedRow.FindControl("Label4") as Label).Text;
            Session["createExerciseID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["createExerciseName"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;
            Session["ExerciseType"] = (GridView1.SelectedRow.FindControl("Label5") as Label).Text;
            Response.Redirect("TrainerCreateProgram3.aspx");


        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["order"] = Convert.ToInt32(Session["order"].ToString()) - 1;
        }

        protected void searchButton(object sender, EventArgs e)
        {
            string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'");
            SqlDataSource1.FilterParameters.Clear();
            SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField", "Text"));
            SqlDataSource1.FilterExpression = FilterExpression;
        }

       
  
       

        protected void gvMaint_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                Label labelSetSayisi = (Label)e.Row.FindControl("Label5");
                if (labelSetSayisi.Text == "")
                {
                    e.Row.FindControl("TextBoxRepeat").Visible = false;
                    e.Row.FindControl("TextBoxWeight").Visible = false;
                }
                else
                {
                    e.Row.FindControl("TextBoxExerciseTime").Visible = false;
                }


             /*   TextBox txtFreqMiles = (TextBox)e.Row.FindControl("TextBoxWeight");

                // At this point, you can change the value as normal
                txtFreqMiles.Text = "some new text";*/
            }
        }

    }
}