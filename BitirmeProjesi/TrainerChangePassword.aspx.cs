using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerChangePassword : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["trainerID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            conn.Open();
            // string checkPassword = "select Password from Users where Email='" + textboxEmail.Text + "'";
            SqlCommand passCom = new SqlCommand();
            passCom.Connection = conn;
            passCom.CommandText = "select Password from Users where Email='" + Session["trainerEmail"].ToString() + "'";
            SqlDataReader dr = passCom.ExecuteReader();
            String oldPassword=null;
            while (dr.Read())
            {
                oldPassword = dr[0].ToString();
            }
            conn.Close();
            if (oldPassword == FormsAuthentication.HashPasswordForStoringInConfigFile(exampleInputPassword1.Text, "MD5"))
            {
               //sifresini guncellet.
                string sql = "UPDATE Users SET Password=@Password where Email='" + Session["trainerEmail"].ToString() + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Password",FormsAuthentication.HashPasswordForStoringInConfigFile(exampleInputPassword2.Text, "MD5"));
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();


                MessageBox.Show("Updated your password !", MessageBox.MesajTipleri.Success, false, 3000);
            }
            else
            {
                MessageBox.Show("Old password is wrong !", MessageBox.MesajTipleri.Error, false, 3000);
                //eski sifren hatali mesaji ver.
            }
           
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

    }
}