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
    public partial class AdminDisplayTrainerDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminSession"] == null)
            {
                Response.Redirect("Main.aspx");
            }

            if (!Page.IsPostBack)
            {

                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                trainerData.CommandText = "select Photo from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["trainerDisplayID"].ToString()) + "'";
               


                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        byte[] _bytes = (byte[])dr[0];
                        Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);


                    }
                    catch
                    {
                        Image1.ImageUrl = "images/userDefaultImage.jpg";

                    }
                   
                }



                conn.Close();

                trainerName.InnerText = Session["trainerDisplayNameSurname"].ToString();
                trainerBio.InnerText = Session["trainerDisplayBio"].ToString();
                trainerIntro.InnerText = Session["trainerDisplayIntro"].ToString();

                ////////////////////////

              
            }
        }
    }
}