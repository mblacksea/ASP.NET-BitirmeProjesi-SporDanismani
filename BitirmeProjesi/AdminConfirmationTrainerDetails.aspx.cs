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
             if (!Page.IsPostBack)
            {
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
           Response.Clear();
           Response.Buffer = true;
            Response.ContentType = "application/pdf";
//Response.AddHeader("content-disposition", "attachment;filename="test.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();

        }



        protected void Button1_Click(object sender, EventArgs e)
        {

               
            conn.Open();
            SqlCommand trainerStatusUpdate = new SqlCommand();
            trainerStatusUpdate.Connection = conn;
            trainerStatusUpdate.CommandText = "UPDATE TrainersData SET Status_ID=1 WHERE Trainer_ID='"+Convert.ToInt32(Session["trainerDetailsID"].ToString())+"'";
            trainerStatusUpdate.ExecuteNonQuery();
            conn.Close();
            Session["trainerDetailsID"] = null;
            //sendEmailForConfirm();
            Response.Redirect("AdminConfirmation.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand trainerStatusUpdate = new SqlCommand();
            trainerStatusUpdate.Connection = conn;
            trainerStatusUpdate.CommandText = "UPDATE TrainersData SET Status_ID=3 WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerDetailsID"].ToString()) + "'";
            trainerStatusUpdate.ExecuteNonQuery();
            conn.Close();
            Session["trainerDetailsID"] = null;
            Response.Redirect("AdminConfirmation.aspx");
        }

        protected void sendEmailForConfirm()
        {
            MailMessage mail = new MailMessage(); 
 
            //mesaj sınıfından mail nesnesi oluşturuyoruz. 
 
            mail.To.Add("mustafa.blacksea93@gmail.com"); 
 
            //gönderilecek olan mail adresi

            mail.From = new MailAddress("mustafa.blacksea93@gmail.com");
 
            //kimden gönderilecek. 

            mail.Subject = "arifceylan.com üzerinden... Adı: ";
 
            //mailin konusu... txtad adlı texboxtan da ismini aldırdım. kaldırabilirsiniz... 

            mail.Body = "deneme123";
 
            //mailin içeriği. txtmesaj ve txteposta textboxları kullandım. 
 
            mail.IsBodyHtml = true;
 
            //html kodlarına izin verilsin. 
 
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
 
            //gmail smtp adresi tanımlaması
 
            client.EnableSsl = true;
 
            // Gmail için sslin aktif olması gerekiyor. 

            NetworkCredential credentials = new NetworkCredential("mustafa.blacksea93@gmail.com", "WalkAlone3442");
 
            //gmail kullanıcı adı ve şifre... Şifre bölümünü değiştirin(***)
 
            client.Credentials = credentials;
 
            try
 
            {
 
            client.Send(mail);
 
           
 
            }
 
            catch (Exception hata)
 
            {
 
            Response.Write(hata);  //hata ayıklama ile hata olduğunda hata mesajı yazdırılacak.
 
            }
       }

    



           // Label1.Text = Session["trainerDetailsID"].ToString();
        }
    }
