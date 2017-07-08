using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminComplain : System.Web.UI.Page
    {

        int flag;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            banDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

            if (Session["adminSession"] == null)
            {
                Response.Redirect("Main.aspx");
            }

            if (!Page.IsPostBack)
            {   
                decisionButton.Visible = false;
                reasonBannedSection.Visible = false;
                feedBack.Visible = false;
            }
        }

    

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            Session["banUserID"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text; //Sikayet eden kisinin UserID
            Session["banProgramID"] = (GridView1.SelectedRow.FindControl("Label5") as Label).Text; //Sikayet edilen program ProgramID
            Session["banTrainerID"] = (GridView1.SelectedRow.FindControl("Label6") as Label).Text; //Sikayet edilen trainer TrainerID
            Session["banProgramTittle"] = (GridView1.SelectedRow.FindControl("Label11") as Label).Text; //Sikayet edilen programTittle
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }

            if ((GridView1.SelectedRow.FindControl("Label10") as Label).Text == "Done")
            {

                decisionButton.Visible = false;
                reasonBannedSection.Visible = false;
                feedBack.Visible = true;

                getProgramBanReason();
                getTrainerBanReason();
                
                //admin, bu trainer icin ne karar vermis onun bilgisini getir.
            }
            else
            {

                decisionButton.Visible = true;
                feedBack.Visible = false;
                if (reasonBannedSection.Visible == true)
                {
                    reasonBannedSection.Visible = false;
                }


               
            }

        }

        protected void getProgramBanReason()
        {
                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                trainerData.CommandText = "select BannedReason from Program where Program_ID='" + Convert.ToInt32(Session["banProgramID"].ToString()) + "'";
                
                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    programBanReason.InnerText = dr[0].ToString();
                
                }
                conn.Close();
        }

        protected void getTrainerBanReason()
        {
          
            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            trainerData.CommandText = "select BannedReason from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["banTrainerID"].ToString()) + "'";

            SqlDataReader dr = trainerData.ExecuteReader();
            while (dr.Read())
            {
                trainerBanReason.InnerText = dr[0].ToString();
       
            }
            conn.Close();

          
        }


        protected void ButtonProgramBan_Click(object sender, EventArgs e)
        {
            reasonBannedSection.Visible = true;
            textBanned.InnerText = "Ban for Program";
            banForDateSection.Visible = false;

            Session["flag"] = "1";
            
        }

        protected void ButtonTrainerBan_Click(object sender, EventArgs e)
        {
            reasonBannedSection.Visible = true;
            textBanned.InnerText = "Ban for Trainer";
            banForDateSection.Visible = true;
            Session["flag"] = "2";

        }

        protected void UpdateComplainStatusForProgram()
        {
            conn.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = conn;
            trainerDataUpdate.CommandText = "UPDATE Complain SET ComplainStatus_ID=1 WHERE Program_ID='" + Convert.ToInt32(Session["banProgramID"].ToString()) + "'";
            trainerDataUpdate.ExecuteNonQuery();
            conn.Close();
        }

        protected void UpdateComplainStatusForTrainer()
        {
            conn.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = conn;
            trainerDataUpdate.CommandText = "UPDATE Complain SET ComplainStatus_ID=1 WHERE Program_ID in (select p.Program_ID from Program p where p.Trainer_ID='" + Convert.ToInt32(Session["banTrainerID"].ToString()) + "')";
            trainerDataUpdate.ExecuteNonQuery();
            conn.Close();
        }


        protected String getTrainerEmail()
        {
            conn.Open();
            string checkUser = "select Email from Users where User_ID='" + Convert.ToInt32(Session["banTrainerID"].ToString()) + "'";
            SqlCommand com = new SqlCommand(checkUser, conn);
            String getTrainerEmail = com.ExecuteScalar().ToString();
            conn.Close();

            return getTrainerEmail;
        }

         

        protected ArrayList getUserEmail()
        {
            ArrayList listEmail = new ArrayList();
            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            trainerData.CommandText = "select u.Email from Users u where u.User_ID in(select up.User_ID from UserProgram up where up.Program_ID='" + Convert.ToInt32(Session["banProgramID"].ToString()) + "')";
            SqlDataReader dr = trainerData.ExecuteReader();
            while (dr.Read())
            {
                listEmail.Add(dr[0].ToString());
            }
            conn.Close();
            return listEmail;
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            String trainerEmail = getTrainerEmail();
            MyEmailParameters myEmailParam = MyEmail.getEmailParameters();
            if (Session["flag"].ToString() == "1")
            {
                //Programi banla
                conn.Open();
                SqlCommand trainerDataUpdate = new SqlCommand();
                trainerDataUpdate.Connection = conn;
                trainerDataUpdate.CommandText = "UPDATE Program SET Status_ID=4,isBanned='Y', BannedReason='" + reasonTextArea.Text + "' WHERE Program_ID='" + Convert.ToInt32(Session["banProgramID"].ToString()) + "'";
                trainerDataUpdate.ExecuteNonQuery();
                conn.Close();

                UpdateComplainStatusForProgram();


                MyEmail.sendEmailForTrainer(trainerEmail, reasonTextArea.Text, Session["banProgramTittle"].ToString(), myEmailParam.FromEmail, myEmailParam.PasswordEmail, myEmailParam.PortEmail, myEmailParam.SmtpServer);
                //trainer a mail gonder // tamamlandi

                ArrayList userEmailList = getUserEmail();
                foreach (string listElement in userEmailList)
                {
                    MyEmail.sendEmailForUsers(listElement, reasonTextArea.Text, Session["banProgramTittle"].ToString(), myEmailParam.FromEmail, myEmailParam.PasswordEmail, myEmailParam.PortEmail, myEmailParam.SmtpServer);
                }
                //bu programi alan userlara mail gonder



            }
            else if (Session["flag"].ToString() == "2")
            {
                //Traineri banla

                conn.Open();
                SqlCommand trainerDataUpdate = new SqlCommand();
                trainerDataUpdate.Connection = conn;

                if (banDate.Text != "")
                {
                    trainerDataUpdate.CommandText = "UPDATE TrainersData SET Status_ID=4, isBanned='Y', BannedReason='" + reasonTextArea.Text + "',BannedDate='" + banDate.Text + "' WHERE Trainer_ID='" + Convert.ToInt32(Session["banTrainerID"].ToString()) + "'";

                }
                else
                {
                    trainerDataUpdate.CommandText = "UPDATE TrainersData SET Status_ID=4, isBanned='Y', BannedReason='" + reasonTextArea.Text + "' WHERE Trainer_ID='" + Convert.ToInt32(Session["banTrainerID"].ToString()) + "'";

                }

               
                trainerDataUpdate.ExecuteNonQuery();
                conn.Close();

                UpdateComplainStatusForTrainer();
                MyEmail.sendEmailForTrainer2(trainerEmail, reasonTextArea.Text, myEmailParam.FromEmail, myEmailParam.PasswordEmail, myEmailParam.PortEmail, myEmailParam.SmtpServer);
                //trainer a banlandigi bilgisini mail olarak gonder //tamamlandi.
                

            }
            reasonTextArea.Text = null;
            GridView1.DataBind();
            decisionButton.Visible = false;
            reasonBannedSection.Visible = false;

            MessageBox.Show("Done !!!", MessageBox.MesajTipleri.Success, false, 3000);
           
        }

        protected void searchButton(object sender, EventArgs e)
        {
            decisionButton.Visible = false;
            reasonBannedSection.Visible = false;
            feedBack.Visible = false;
            string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'");
            SqlDataSource1.FilterParameters.Clear();
            SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField", "Text"));
            SqlDataSource1.FilterExpression = FilterExpression;
        }
    }
}