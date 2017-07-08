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
    public partial class AdminDisplayTrainerDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminSession"] == null)
            {
                Response.Redirect("Main.aspx");
            }

           

            if (!Page.IsPostBack)
            {
                GridView1.Visible = false;
                if (Session["trainerIsBanned"].ToString() == "Y")
                {
                    unbannedButton.Visible = true;
                }
                else
                {
                    unbannedButton.Visible = false;
                }

                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                trainerData.CommandText = "select Photo from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["trainerDisplayID"].ToString()) + "'";
               


                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        byte[] _bytes = (byte[])dr[0];
                        Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);


                    }
                    catch
                    {
                        Image1.ImageUrl = "images/userDefaultImage.jpg";

                    }
                   
                }



                conn.Close();

                conn.Open();
                string totalSales = " select ISNULL(sum( x.toplamSayi * y.ProgramPrice ),0) as Total from (select up.Program_ID, count(*) toplamSayi from UserProgram up where up.Program_ID in (select p.Program_ID from Program p where p.Trainer_ID='" + Convert.ToInt32(Session["trainerDisplayID"].ToString()) + "') group by up.Program_ID) x, Program y where x.Program_ID=y.Program_ID";
                SqlCommand com = new SqlCommand(totalSales, conn);
                int tempTotalSales = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
               // Label10.Text = tempTotalSales.ToString();


                conn.Open();
                string totalIncome = "select  count(*) toplamSayi from UserProgram up where up.Program_ID in (select p.Program_ID from Program p where p.Trainer_ID='" + Convert.ToInt32(Session["trainerDisplayID"].ToString()) + "')";
                SqlCommand com2 = new SqlCommand(totalIncome, conn);
                int totalIncomeValue = Convert.ToInt32(com2.ExecuteScalar().ToString());
                conn.Close();

                Label1.Text = totalIncomeValue.ToString();

                Label1.Text = totalIncomeValue.ToString() + " / " + tempTotalSales.ToString(); 
                trainerName.InnerText = Session["trainerDisplayNameSurname"].ToString();
                trainerBio.InnerText = Session["trainerDisplayBio"].ToString();
                trainerIntro.InnerText = Session["trainerDisplayIntro"].ToString();

                ////////////////////////

              
            }
        }
        // Session["displayProgramID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {



            Session["displayProgramID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["displayProgramTrainer"] = trainerName.InnerText;
            Session["displayProgramTittle"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;
            Session["removeProgramBan"] = (GridView1.SelectedRow.FindControl("Label5") as Label).Text;
            Response.Redirect("AdminDisplayProgramsDetails.aspx");


        }




        protected void unbannedButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = conn;
            trainerDataUpdate.CommandText = "UPDATE TrainersData SET Status_ID=1,isBanned=NULL,BannedReason=NULL,BannedDate=NULL WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerDisplayID"].ToString()) + "'";
            trainerDataUpdate.ExecuteNonQuery();
            conn.Close();
            Session["trainerIsBanned"] = "N";
            unbannedButton.Visible = false;
        }

        protected void search_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
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
        }

   
    }
}