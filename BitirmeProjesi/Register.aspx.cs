using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace BitirmeProjesi
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            radio1.Checked = true;
        
        }
        public string encryption(String password)
        {
          
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }  
        protected void nextButton(object sender, EventArgs e)
        {

            string BaglantiAdresi = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(BaglantiAdresi);
            SqlCommand cmdEmailControl = new SqlCommand();
            cmdEmailControl.Connection = con;
            cmdEmailControl.CommandText = "SELECT Email FROM Users WHERE Email='"+textboxEmail.Text+"'";
            con.Open();
            
            object emailControl = cmdEmailControl.ExecuteScalar();
            if (emailControl!=null)
            {
                MessageBox.Show("This email is being used", MessageBox.MesajTipleri.Warning, false, 3000);
            }
            else
            {
                Session["userName"] = textboxName.Text.ToString();
                Session["userSurname"] = textboxSurname.Text.ToString();
                Session["userEmail"] = textboxEmail.Text.ToString();
                Session["userPassword"] = encryption(textboxPassword.Text);
                 if (radio1.Checked == true && radio2.Checked==false)
                {
                    Session["userSex"] = radio1.Value;
                }
                else
                {
                    Session["userSex"] = radio2.Value;
                }

                 Session["userBirthday"] = txtDate.Text.ToString();

                // StringWriter strWrtr = new StringWriter();
                 //HttpUtility.HtmlEncode(textboxBio.Text.ToString(), strWrtr);
                 Session["userBio"] = textBio.Text;
               
               


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
                con.Close();*/
                Response.Redirect("RegisterSecondPart.aspx");
                
            }
            
      
           
        
        }
    }
}