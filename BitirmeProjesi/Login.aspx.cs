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

namespace BitirmeProjesi
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
          
            //validate Recaptcha
            if (Validate())
            {

          //capcha gecerli
               // Response.Redirect("Main.aspx");
                

                Session["user"] = Request.Form["user"];
                Response.Redirect("Register.aspx");
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


        public class MyObject
        {
            public string success { get; set; }
        }
    }
}