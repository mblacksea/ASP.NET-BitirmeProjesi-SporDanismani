using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminConfirmationTrainerDetails : System.Web.UI.Page
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
                reasonDeclineSection.Visible = false;
                if (Session["trainerDetailsID"] == null)
                {
                    Response.Redirect("AdminConfirmation.aspx");
                }
                else
                {
                    conn.Open();
                    SqlCommand trainerData = new SqlCommand();
                    trainerData.Connection = conn;
                    trainerData.CommandText = "select Bio from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["trainerDetailsID"].ToString()) + "'";
                    SqlDataReader dr = trainerData.ExecuteReader();
                    while (dr.Read())
                    {

                        TextArea1.InnerText = dr[0].ToString();



                    }



                    conn.Close();
                }
               
               
            }
           // Response.Write(Session["trainerID"].ToString());

        }



        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
         
            //Label1.Text = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            string certificateID= (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            byte[] bytes;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select CertificateFile from Certificate where Certificate_ID='" + Convert.ToInt32(certificateID) + "'";
           // cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(certificateID));
            cmd.Connection = conn;
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                sdr.Read();
                bytes = (byte[])sdr["CertificateFile"];
                
            }
            conn.Close();
            Session["PdfFile"] = bytes;
            Response.Write("<script>");
            Response.Write("window.open('PdfDisplay.aspx','_blank')");
            Response.Write("</script>");
            
         /*Response.Clear();
           Response.Buffer = true;
           Response.ContentType = "application/pdf";
           Response.Cache.SetCacheability(HttpCacheability.NoCache);
           Response.BinaryWrite(bytes);
           Response.End();*/

        }



        protected void Button1_Click(object sender, EventArgs e)
        {

               
            conn.Open();
            SqlCommand trainerStatusUpdate = new SqlCommand();
            trainerStatusUpdate.Connection = conn;
            trainerStatusUpdate.CommandText = "UPDATE TrainersData SET Status_ID=1 WHERE Trainer_ID='"+Convert.ToInt32(Session["trainerDetailsID"].ToString())+"'";
            trainerStatusUpdate.ExecuteNonQuery();
            conn.Close();
            MyEmailParameters myEmailParam = MyEmail.getEmailParameters();
            Session["trainerDetailsID"] = null;
            MyEmail.sendEmailForConfirm(Session["trainerDetailsEmail"].ToString(), myEmailParam.FromEmail, myEmailParam.PasswordEmail, myEmailParam.PortEmail,myEmailParam.SmtpServer);
            Response.Redirect("AdminConfirmation.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            reasonDeclineSection.Visible = true;
            Button1.Visible = false;
            Button2.Visible = false;
          
           /* conn.Open();
            SqlCommand trainerStatusUpdate = new SqlCommand();
            trainerStatusUpdate.Connection = conn;
            trainerStatusUpdate.CommandText = "UPDATE TrainersData SET Status_ID=3 WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerDetailsID"].ToString()) + "'";
            trainerStatusUpdate.ExecuteNonQuery();
            conn.Close();
            
            Session["trainerDetailsID"] = null;
            Response.Redirect("AdminConfirmation.aspx");*/
        }

        

        

        protected void Button3_Click(object sender, EventArgs e)
        {
            MyEmailParameters myEmailParam = MyEmail.getEmailParameters();
            conn.Open();
            SqlCommand trainerStatusUpdate = new SqlCommand();
            trainerStatusUpdate.Connection = conn;
            trainerStatusUpdate.CommandText = "UPDATE TrainersData SET Status_ID=3 WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerDetailsID"].ToString()) + "'";
            trainerStatusUpdate.ExecuteNonQuery();
            conn.Close();

            //Burada decline reason i al ve database e kaydet.
            conn.Open();
            SqlCommand trainerStatusUpdate2 = new SqlCommand();
            trainerStatusUpdate2.Connection = conn;
            trainerStatusUpdate2.CommandText = "UPDATE Users SET DeclineReason='" + reasonTextArea.InnerText + "' WHERE User_ID='" + Convert.ToInt32(Session["trainerDetailsID"].ToString()) + "'";
            trainerStatusUpdate2.ExecuteNonQuery();
            conn.Close();



            Session["trainerDetailsID"] = null;
            reasonDeclineSection.Visible = false;
            MessageBox.Show("Your reply has been sent", MessageBox.MesajTipleri.Info, false, 3000);
            MyEmail.sendEmailForDecline(reasonTextArea.InnerText, Session["trainerDetailsEmail"].ToString(), myEmailParam.FromEmail, myEmailParam.PasswordEmail, myEmailParam.PortEmail,myEmailParam.SmtpServer);

            
          
        }

    



           // Label1.Text = Session["trainerDetailsID"].ToString();
        }
    }
