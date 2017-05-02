using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class RegisterSecondPart : System.Web.UI.Page
    {
        static string BaglantiAdresi = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(BaglantiAdresi);
        object userID;

        string userName;
        string userSurname;
        string userEmail;
        string userPassword;
        string userSex;
        string userBirthday ;
        string userBio;
        protected void Page_Load(object sender, EventArgs e)
        {

            
                userName = Session["userName"].ToString();
                userSurname = Session["userSurname"].ToString();
                userEmail = Session["userEmail"].ToString();
                userPassword = Session["userPassword"].ToString();
                userSex = Session["userSex"].ToString();
                userBirthday = Session["userBirthday"].ToString();
                userBio = Session["userBio"].ToString();
            
          


           /* string userEmail = Session["userEmail"].ToString();
            SqlCommand cmdUserID = new SqlCommand();
            cmdUserID.Connection = con;
            cmdUserID.CommandText = "SELECT User_ID FROM Users WHERE Email='" + userEmail + "'";
            con.Open();

            userID = cmdUserID.ExecuteScalar();
            Response.Write(userID.ToString());*/



        }

        protected void upload(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "insert into Certificate values (@Trainer_ID, @Certificate_Name, @Instution, @Date, @CertificateFile)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Trainer_ID", 2);
                            cmd.Parameters.AddWithValue("@Certificate_Name", textboxCertificateName.Text);
                            cmd.Parameters.AddWithValue("@Instution", textboxInstution.Text);
                            cmd.Parameters.AddWithValue("@Date", txtdateCertificate.Text);
                            cmd.Parameters.AddWithValue("@CertificateFile", bytes);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
    
        }


        protected void addCertificate(object sender, EventArgs e)
        {
          
            if (FileUpload1.PostedFile.ContentType == "application/pdf" || FileUpload1.PostedFile.ContentType==null)
            {
                SqlCommand cmdInsertUser = new SqlCommand();
                if (Session["userID"] == null)
                {

                    cmdInsertUser.Connection = con;
                    con.Open();
                    cmdInsertUser.CommandText = "INSERT INTO Users (Name,Surname,Email,Password,Sex,Birthday,Role_ID) VALUES (@Name,@Surname,@Email,@Password,@Sex,@Birthday,@Role_ID)";
                    cmdInsertUser.Parameters.AddWithValue("@Name", userName);
                    cmdInsertUser.Parameters.AddWithValue("@Surname", userSurname);
                    cmdInsertUser.Parameters.AddWithValue("@Email", userEmail);
                    cmdInsertUser.Parameters.AddWithValue("@Password", userPassword);

                    cmdInsertUser.Parameters.AddWithValue("@Sex", userSex);

                    cmdInsertUser.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(userBirthday));
                    cmdInsertUser.Parameters.AddWithValue("@Role_ID", 2);
                    cmdInsertUser.ExecuteNonQuery();



                    SqlCommand cmdUserID = new SqlCommand();
                    cmdUserID.Connection = con;
                    cmdUserID.CommandText = "SELECT User_ID FROM Users WHERE Email='" + userEmail + "'";


                    userID = cmdUserID.ExecuteScalar();
                    //   Response.Write(userID.ToString());


                    Session["userID"] = userID.ToString();

                    cmdInsertUser = new SqlCommand();
                    cmdInsertUser.Connection = con;
                    cmdInsertUser.CommandText = "INSERT INTO TrainersData (Trainer_ID,Bio,Status_ID) VALUES (@Trainer_ID,@Bio,@Status_ID)";
                    cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
                    cmdInsertUser.Parameters.AddWithValue("@Bio", userBio);
                    cmdInsertUser.Parameters.AddWithValue("@Status_ID", 2);
                    cmdInsertUser.ExecuteNonQuery();
                    con.Close();

                    
              
                }
                else
                {
                    userID = Session["userID"].ToString();
                }







                con.Open();
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                using (Stream fs = FileUpload1.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);



                        cmdInsertUser = new SqlCommand();
                        cmdInsertUser.Connection = con;

                        cmdInsertUser.CommandText = "insert into Certificate values (@Trainer_ID, @Certificate_Name, @Instution, @Date, @CertificateFile)";
                        cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
                        cmdInsertUser.Parameters.AddWithValue("@Certificate_Name", textboxCertificateName.Text);
                        cmdInsertUser.Parameters.AddWithValue("@Instution", textboxInstution.Text);
                        cmdInsertUser.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtdateCertificate.Text));
                        cmdInsertUser.Parameters.AddWithValue("@CertificateFile", bytes);
                        cmdInsertUser.ExecuteNonQuery();


                    }
                }


                gridview.DataBind();
                con.Close();

            }
            else
            {
                MessageBox.Show("Please, Upload files in pdf format", MessageBox.MesajTipleri.Warning, false, 3000);
            }
            

           /* cmdInsertUser = new SqlCommand();
            cmdInsertUser.Connection = con;
            cmdInsertUser.CommandText = "INSERT INTO Certificate (Trainer_ID,Certificate_Name,Instution,Date) VALUES (@Trainer_ID,@Certificate_Name,@Instution,@Date)";
            cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
            cmdInsertUser.Parameters.AddWithValue("@Certificate_Name", textboxCertificateName.Text);
            cmdInsertUser.Parameters.AddWithValue("@Instution", textboxInstution.Text);
            cmdInsertUser.Parameters.AddWithValue("@Date", txtdateCertificate.Text);

            cmdInsertUser.ExecuteNonQuery();
            con.Close();


            gridview.DataBind();*/
           
          

        }

        protected void save(object sender, EventArgs e)
        {
            Session["infoForTrainer"] = "Awaiting approval by admin. You will be notified by e-mail";
          //  MessageBox.Show("Awaiting approval by admin. You will be notified by e-mail", MessageBox.MesajTipleri.Info, false, 3000);
            Response.Redirect("Login.aspx");
               
            
            
        }

    }
}