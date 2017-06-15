using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recaptcha.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;

namespace BitirmeProjesi
{
    public partial class Login : System.Web.UI.Page
    {
        int trainer_id;
        string password;
        int role_id;
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["infoForTrainer"]!=null){
                MessageBox.Show("Awaiting approval by admin. You will be notified by e-mail", MessageBox.MesajTipleri.Info, false, 3000);
            }
           
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
          
            //validate Recaptcha
            if (Validate())
            {
                

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                conn.Open();
                string checkUser = "select count(*) from Users where Email='" + textboxEmail.Text + "'";
                SqlCommand com = new SqlCommand(checkUser,conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                if (temp == 1)
                {
                    conn.Open();
                   // string checkPassword = "select Password from Users where Email='" + textboxEmail.Text + "'";
                    SqlCommand passCom = new SqlCommand();
                    passCom.Connection = conn;
                    passCom.CommandText = "select User_ID,Password,Role_ID,Name from Users where Email='" + textboxEmail.Text + "'";
                    SqlDataReader dr = passCom.ExecuteReader();
                 
                    while (dr.Read())
                    {
                        trainer_id = Convert.ToInt32(dr[0].ToString());
                        password = dr[1].ToString();
                        role_id = Convert.ToInt32(dr[2].ToString());
                        name = dr[3].ToString();
                        Session["trainerName"] = name;
                        Session["trainerID"] = trainer_id;
                    }


                    conn.Close();
                    if (password ==FormsAuthentication.HashPasswordForStoringInConfigFile(textboxPassword.Text, "MD5"))
                    {
                        conn.Open();
                        if (role_id == 1)
                        {   //Admin page e yonlendir......
                            Session["adminSession"] = textboxEmail.Text;
                            Response.Redirect("AdminDefaultPage.aspx");
                        }
                        else if (role_id == 2)
                        {
                            //Trainer page e yonlendir....
                            SqlCommand controlActivateTrainer = new SqlCommand();
                            controlActivateTrainer.Connection = conn;
                            controlActivateTrainer.CommandText = "select Status_ID from TrainersData where Trainer_ID='" + trainer_id + "'";
                            int status_id = Convert.ToInt32(controlActivateTrainer.ExecuteScalar().ToString());
                            if (status_id == 1)
                            {
                                //Onaylandi...
                                Session["trainerEmail"] = textboxEmail.Text;
                                Session["rejectedTrainer"] = "false";
                                Response.Redirect("TrainerDefaultPage.aspx");
                            }
                            else if(status_id==2)
                            {  //Beklemede...
                                MessageBox.Show("Account not activated", MessageBox.MesajTipleri.Warning, false, 3000);
                            }
                            else if (status_id == 3)
                            {   //Reddedildi...
                                //tekrar certifica yukleyebilsin.
                                Session["rejectedTrainer"] = "true";
                                Response.Redirect("TrainerRejectedPage.aspx");
                                MessageBox.Show("Your registration has been rejected", MessageBox.MesajTipleri.Error, false, 3000);
                            }


                           
                        }
                     
                      }
                    else
                    {
                        MessageBox.Show("Wrong email or password", MessageBox.MesajTipleri.Warning, false, 3000);
                    }


                }
                else
                {
                    MessageBox.Show("Wrong email or password", MessageBox.MesajTipleri.Warning, false, 3000);
                }

                //capcha gecerli
               // Response.Redirect("Main.aspx");
                
                

               //Session["user"] = Request.Form["user"];
              //  Response.Redirect("Register.aspx");
            }

            else
            {

            //capcha gecersiz
            }

        }

        public bool Validate()
        {

            string Response = Request["g-recaptcha-response"];//Getting Response String Appned to Post Method

            bool Valid = false;
            //Request to Google Server
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(" https://www.google.com/recaptcha/api/siteverify?secret=6LduRBMUAAAAAByUkigdzKxYto_NvNgBt3tGsIGs&response=" + Response);

            try
            {
                //Google recaptcha Responce 
                using (WebResponse wResponse = req.GetResponse())
                {

                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        MyObject data = js.Deserialize<MyObject>(jsonResponse);// Deserialize Json 

                        Valid = Convert.ToBoolean(data.success);


                    }
                }

                return Valid;

            }
            catch (WebException ex)
            {
                throw ex;
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


        public class MyObject
        {
            public string success { get; set; }
        }

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}