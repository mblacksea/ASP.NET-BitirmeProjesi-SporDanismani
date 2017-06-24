﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        MyEmailParameters myEmailParam = MyEmail.getEmailParameters();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendEmail(object sender, EventArgs e)
        {
            String randomPassword = generateRandomPassword();
            MyEmail.sendEmailForConfirm(randomPassword, introTextArea.InnerText, Request.Url.GetLeftPart(UriPartial.Authority), myEmailParam.FromEmail, myEmailParam.PasswordEmail, myEmailParam.PortEmail,myEmailParam.SmtpServer);

            string sql = "UPDATE Users SET Password=@Password where Email='" + introTextArea.InnerText + "'";
            SqlCommand komut = new SqlCommand(sql, conn);
            komut.Parameters.AddWithValue("@Password", FormsAuthentication.HashPasswordForStoringInConfigFile(randomPassword, "MD5"));
            conn.Open();

            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Your new password has been sent to your email address", MessageBox.MesajTipleri.Success, false, 3000);
            introTextArea.InnerText = null;
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

        protected String generateRandomPassword()
        {
            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            return passwordString;
           
        }

     


    }
}