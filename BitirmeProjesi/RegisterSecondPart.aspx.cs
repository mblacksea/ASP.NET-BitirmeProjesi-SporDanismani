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
    public partial class RegisterSecondPart : System.Web.UI.Page
    {
        static string BaglantiAdresi = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(BaglantiAdresi);
        object userID;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["userName"].ToString();
            string userSurname = Session["userSurname"].ToString();
            string userEmail = Session["userEmail"].ToString();
            string userPassword = Session["userPassword"].ToString();
            string userSex = Session["userSex"].ToString();
            string userBirthday = Session["userBirthday"].ToString();


           /* string userEmail = Session["userEmail"].ToString();
            SqlCommand cmdUserID = new SqlCommand();
            cmdUserID.Connection = con;
            cmdUserID.CommandText = "SELECT User_ID FROM Users WHERE Email='" + userEmail + "'";
            con.Open();

            userID = cmdUserID.ExecuteScalar();
            Response.Write(userID.ToString());*/



        }

        protected void addCertificate(object sender, EventArgs e)
        {
             /*  SqlCommand cmdInsertUser = new SqlCommand();
               cmdInsertUser.Connection = con;
               cmdInsertUser.CommandText = "INSERT INTO Users (Name,Surname,Email,Password,Sex,Birthday,Role_ID) VALUES (@Name,@Surname,@Email,@Password,@Sex,@Birthday,@Role_ID)";
               cmdInsertUser.Parameters.AddWithValue("@Name", textboxName.Text);
               cmdInsertUser.Parameters.AddWithValue("@Surname", textboxSurname.Text);
               cmdInsertUser.Parameters.AddWithValue("@Email", textboxEmail.Text);
               cmdInsertUser.Parameters.AddWithValue("@Password", FormsAuthentication.HashPasswordForStoringInConfigFile(textboxPassword.Text,"MD5"));
               if (radio1.Checked == true && radio2.Checked==false)
               {
                   cmdInsertUser.Parameters.AddWithValue("@Sex", radio1.Value);
               }
               else
               {
                   cmdInsertUser.Parameters.AddWithValue("@Sex", radio2.Value);
               }

               cmdInsertUser.Parameters.AddWithValue("@Birthday", txtDate.Text);
               cmdInsertUser.Parameters.AddWithValue("@Role_ID", 2);
               cmdInsertUser.ExecuteNonQuery();
               con.Close();



            SqlCommand cmdInsertUser = new SqlCommand();
            cmdInsertUser.Connection = con;
            cmdInsertUser.CommandText = "INSERT INTO Certificate (Trainer_ID,Certificate_Name,Instution,Date) VALUES (@Trainer_ID,@Certificate_Name,@Instution,@Date)";
            cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
            cmdInsertUser.Parameters.AddWithValue("@Certificate_Name", textboxCertificateName.Text);
            cmdInsertUser.Parameters.AddWithValue("@Instution", textboxInstution.Text);
            cmdInsertUser.Parameters.AddWithValue("@Date", txtdateCertificate.Text);
            
            cmdInsertUser.ExecuteNonQuery();
            con.Close();*/

        }
    }
}