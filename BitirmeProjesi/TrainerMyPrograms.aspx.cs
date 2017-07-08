using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerMyPrograms : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
       // Image a;
        protected void Page_Load(object sender, EventArgs e)
        {
         //  if (!Page.IsPostBack)
         //  {

            if (Session["trainerID"] == null)
            {
                Response.Redirect("Main.aspx");
            }

            if (!Page.IsPostBack)
            {


                Session.Remove("ProgramSpecID");
                Session.Remove("ProgramDiffID");
                Session.Remove("order");
                Session.Remove("createExerciseID");
                Session.Remove("ExerciseType");
                Session.Remove("programID");
                Session.Remove("adminID");
                Session.Remove("updateSession");
                Session.Remove("editProgramPermission");
                conn.Open();
                SqlCommand programPhoto = new SqlCommand();
                programPhoto.Connection = conn;
                programPhoto.CommandText = "select ProgramPhoto,Status_ID,isBanned from Program where Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                SqlDataReader dr = programPhoto.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    try
                    {

                        byte[] _bytes = (byte[])dr[0];
                        //   a = (Image)GridView1.Rows[i].FindControl("Image1");
                        //  a.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);
                        LinkButton link = (LinkButton)GridView1.Rows[i].FindControl("LinkButton2");

                        int status_ID = Convert.ToInt32(dr[1]);
                        if (status_ID == 1 || status_ID==4)
                        {

                            link.Enabled = false;
                            link.OnClientClick = null;
                            link.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {

                            link.Enabled = true;
                            link.BackColor = System.Drawing.Color.Yellow;

                        }

                        if (dr[2].ToString() == "Y")
                        {
                            GridView1.Rows[i].BackColor = System.Drawing.Color.PeachPuff;
                        }
                      


                    }
                    catch
                    {

                        //  a.ImageUrl = "images/userDefaultImage.jpg";

                    }
                    i++;
                }
                conn.Close();
                //  }


            }
        }

        protected void MyButtonClick(object sender, EventArgs e)
        {



            LinkButton btn = (LinkButton)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int deleteProgramID = Convert.ToInt32((gvr.FindControl("Label1") as Label).Text);

            conn.Open();
            string checkUser = "select count(*) from UserProgram where Program_ID='" + deleteProgramID + "'";
            SqlCommand com = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp > 0)
            {
                //silemezsin.
                MessageBox.Show("Can not be deleted because this program is purchased!", MessageBox.MesajTipleri.Warning, false, 3000);

            }
            else
            {
                conn.Open();
                SqlCommand programDelete = new SqlCommand();
                programDelete.Connection = conn;
                programDelete.CommandText = "Delete From ProgramExercise where Program_ID='" + deleteProgramID + "'";
                programDelete.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand programDelete2 = new SqlCommand();
                programDelete2.Connection = conn;
                programDelete2.CommandText = "Delete From Program where Program_ID='" + deleteProgramID + "'";
                programDelete2.ExecuteNonQuery();
                conn.Close();

                GridView1.DataBind();

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
                        // a = (Image)GridView1.Rows[i].FindControl("Image1");
                        // a.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);


                    }
                    catch
                    {
                        //  a.ImageUrl = "images/userDefaultImage.jpg";

                    }
                    i++;
                }
                conn.Close();
                refreshGridview();
                MessageBox.Show("Deleted!", MessageBox.MesajTipleri.Success, false, 3000);
            }


           



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

        protected void LinkButton2_Publish(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int publishProgramID = Convert.ToInt32((gvr.FindControl("Label1") as Label).Text);
            conn.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = conn;
            trainerDataUpdate.CommandText = "UPDATE Program SET Status_ID=1 WHERE Program_ID='" + publishProgramID + "'";
            trainerDataUpdate.ExecuteNonQuery();

            conn.Close();
            GridView1.DataBind();
            refreshGridview();
           
            MessageBox.Show("Congratulations! Program published", MessageBox.MesajTipleri.Success, false, 3000);

        }

        protected void refreshGridview()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label lb = (Label)row.FindControl("Label5");
                Label lb2 = (Label)row.FindControl("Label7");
                LinkButton link = (LinkButton)GridView1.Rows[row.RowIndex].FindControl("LinkButton2");
                if (lb.Text == "Y")
                {
                    row.BackColor = System.Drawing.Color.PeachPuff;
                }

                if (lb2.Text == "2")
                {

                    link.Enabled = true;
                    link.BackColor = System.Drawing.Color.Yellow;

                }
                else
                {
                    link.Enabled = false;
                    link.OnClientClick = null;
                    link.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }


        protected void searchButton(object sender, EventArgs e)
        {
         
            if (DateStart.Text == "" && DateEnd.Text == "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text != "" && DateEnd.Text != "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'   AND CreationDate>='{1}' AND CreationDate<='{2}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text != "" && DateEnd.Text != "" && textField2.Text == "")
            {
                string FilterExpression = string.Concat("CreationDate>='{0}' AND CreationDate<='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text != "" && DateEnd.Text == "" && textField2.Text == "")
            {
                string FilterExpression = string.Concat("CreationDate>='{0}'  ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text == "" && DateEnd.Text != "" && textField2.Text == "")
            {
                string FilterExpression = string.Concat("CreationDate<='{0}'  ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;
            }
            else if (DateStart.Text != "" && DateEnd.Text == "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'   AND CreationDate>='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
             
                SqlDataSource1.FilterExpression = FilterExpression;
            }
            else if (DateStart.Text == "" && DateEnd.Text != "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'   AND CreationDate<='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));

                SqlDataSource1.FilterExpression = FilterExpression;
            }


            else if (DateStart.Text == "" && DateEnd.Text == "" && textField2.Text == "")
            {
                SqlDataSource1.FilterParameters.Clear();
            }

            GridView1.DataBind();


            foreach (GridViewRow row in GridView1.Rows)
            {
                 Label lb = (Label)row.FindControl("Label5");
                 Label lb2 = (Label)row.FindControl("Label7");
                 LinkButton link = (LinkButton)GridView1.Rows[row.RowIndex].FindControl("LinkButton2");
                        if (lb.Text == "Y")
                        {
                            row.BackColor = System.Drawing.Color.PeachPuff;
                        }
                   
                        if(lb2.Text=="2")
                        {
                          
                            link.Enabled = true;
                            link.BackColor = System.Drawing.Color.Yellow;

                        }
                        else
                        {
                            link.Enabled = false;
                            link.OnClientClick = null;
                            link.ForeColor = System.Drawing.Color.Gray;
                        }
            }











        }


    }
}