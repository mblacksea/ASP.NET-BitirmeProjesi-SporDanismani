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

        protected void addCertificate(object sender, EventArgs e)
        {


            SqlCommand cmdInsertUser = new SqlCommand();
            cmdInsertUser.Connection = con;
            con.Open();
            cmdInsertUser.CommandText = "INSERT INTO Users (Name,Surname,Email,Password,Sex,Birthday,Role_ID) VALUES (@Name,@Surname,@Email,@Password,@Sex,@Birthday,@Role_ID)";
            cmdInsertUser.Parameters.AddWithValue("@Name", userName);
            cmdInsertUser.Parameters.AddWithValue("@Surname", userSurname);
            cmdInsertUser.Parameters.AddWithValue("@Email", userEmail);
            cmdInsertUser.Parameters.AddWithValue("@Password", userPassword);

            cmdInsertUser.Parameters.AddWithValue("@Sex", userSex);

            cmdInsertUser.Parameters.AddWithValue("@Birthday", userBirthday);
            cmdInsertUser.Parameters.AddWithValue("@Role_ID", 2);
            cmdInsertUser.ExecuteNonQuery();
          


            SqlCommand cmdUserID = new SqlCommand();
            cmdUserID.Connection = con;
            cmdUserID.CommandText = "SELECT User_ID FROM Users WHERE Email='" + userEmail + "'";
            

            userID = cmdUserID.ExecuteScalar();
            Response.Write(userID.ToString());

            cmdInsertUser = new SqlCommand();
            cmdInsertUser.Connection = con;
            cmdInsertUser.CommandText = "INSERT INTO TrainersData (Trainer_ID,Bio,Status_ID) VALUES (@Trainer_ID,@Bio,@Status_ID)";
            cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
            cmdInsertUser.Parameters.AddWithValue("@Bio", userBio);
            cmdInsertUser.Parameters.AddWithValue("@Status_ID", 2);

            cmdInsertUser.ExecuteNonQuery();

            cmdInsertUser = new SqlCommand();
            cmdInsertUser.Connection = con;
            cmdInsertUser.CommandText = "INSERT INTO Certificate (Trainer_ID,Certificate_Name,Instution,Date) VALUES (@Trainer_ID,@Certificate_Name,@Instution,@Date)";
            cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
            cmdInsertUser.Parameters.AddWithValue("@Certificate_Name", textboxCertificateName.Text);
            cmdInsertUser.Parameters.AddWithValue("@Instution", textboxInstution.Text);
            cmdInsertUser.Parameters.AddWithValue("@Date", txtdateCertificate.Text);

            cmdInsertUser.ExecuteNonQuery();
            con.Close();

        }
    }
}