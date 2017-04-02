using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class RegisterSecondPart : System.Web.UI.Page
    {
        static string BaglantiAdresi = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(BaglantiAdresi);
        object userID;

        string username;
        string usersurname;
        string useremail;
        string userpassword;
        string usersex;
        string userbirthday;
        static string userbio;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Session["username"] = Request.Form["textboxName"];
                Page.Session["usersurname"] = Request.Form["textboxSurname"];
                Page.Session["useremail"] = Request.Form["textboxEmail"];
                Page.Session["userpassword"] = Request.Form["textboxPassword"];
                Page.Session["usersex"] = Request.Form["radio"];
                Page.Session["userbirthday"] = Request.Form["txtDate"];
                userbio = Request.Form["textboxBio"];

                StringWriter strWrt = new StringWriter();

                HttpUtility.HtmlEncode(userbio, strWrt);
                userbio = strWrt.ToString();
                Page.Session["userbio"] = userbio;
                testberk.InnerHtml = userbio;
            }
           

            
            



            
            //Response.Write(username + userbio + usersurname + useremail + userpassword + "\"" + usersex  + "\"" + userbirthday);


            //string username = session["username"].tostring();
            //string usersurname = session["usersurname"].tostring();
            //string useremail = session["useremail"].tostring();
            //string userpassword = session["userpassword"].tostring();
            //string usersex = session["usersex"].tostring();
            //string userbirthday = session["userbirthday"].tostring();


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

            username = Page.Session["username"].ToString();
            usersurname = Page.Session["usersurname"].ToString();
            useremail = Page.Session["useremail"].ToString();
            userpassword = Page.Session["userpassword"].ToString();
            usersex = Page.Session["usersex"].ToString();
            userbirthday = Page.Session["userbirthday"].ToString();
            userbio = Page.Session["userbio"].ToString();


            SqlCommand cmdInsertUser = new SqlCommand();
            cmdInsertUser.Connection = con;
            cmdInsertUser.CommandText = "INSERT INTO Users (Name,Surname,Email,Password,Sex,Birthday,Role_ID) VALUES (@Name,@Surname,@Email,@Password,@Sex,@Birthday,@Role_ID)";
            cmdInsertUser.Parameters.AddWithValue("@Name", username);
            cmdInsertUser.Parameters.AddWithValue("@Surname", usersurname);
            cmdInsertUser.Parameters.AddWithValue("@Email", useremail);
            cmdInsertUser.Parameters.AddWithValue("@Password", FormsAuthentication.HashPasswordForStoringInConfigFile(userpassword, "MD5"));
            
            cmdInsertUser.Parameters.AddWithValue("@Sex", usersex);
            

            cmdInsertUser.Parameters.AddWithValue("@Birthday", userbirthday);
            cmdInsertUser.Parameters.AddWithValue("@Role_ID", 2);
            cmdInsertUser.ExecuteNonQuery();
            con.Close();


            //önce user oluşturuldu

            SqlCommand cmdUserID = new SqlCommand();
            cmdUserID.Connection = con;
            cmdUserID.CommandText = "SELECT User_ID FROM Users WHERE Email='" + useremail + "'";
            con.Open();

            userID = cmdUserID.ExecuteScalar();
            Response.Write(userID.ToString());


            cmdInsertUser = new SqlCommand();

               cmdInsertUser.Connection = con;
               cmdInsertUser.CommandText = "INSERT INTO TrainersData (Trainer_ID,Bio,Status_ID) VALUES (@Trainer_ID,@Bio,@Status_ID)";
               cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
               cmdInsertUser.Parameters.AddWithValue("@Bio", userbio);
               cmdInsertUser.Parameters.AddWithValue("@Status_ID", 2);
               
              
               cmdInsertUser.ExecuteNonQuery();
               con.Close();



            //cmdInsertUser = new SqlCommand();
            //cmdInsertUser.Connection = con;
            //cmdInsertUser.CommandText = "INSERT INTO Certificate (Trainer_ID,Certificate_Name,Instution,Date) VALUES (@Trainer_ID,@Certificate_Name,@Instution,@Date)";
            //cmdInsertUser.Parameters.AddWithValue("@Trainer_ID", userID);
            //cmdInsertUser.Parameters.AddWithValue("@Certificate_Name", textboxCertificateName.Text);
            //cmdInsertUser.Parameters.AddWithValue("@Instution", textboxInstution.Text);
            //cmdInsertUser.Parameters.AddWithValue("@Date", txtdateCertificate.Text);
            
            //cmdInsertUser.ExecuteNonQuery();
            //con.Close();
        }
    }
}