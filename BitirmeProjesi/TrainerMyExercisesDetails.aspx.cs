using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerMyExercisesDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                videoExercise.Src = "File.ashx?Id=" + Session["exerciseID"].ToString();
        
      

                conn.Open();
                SqlCommand exerciseDetails = new SqlCommand();
                exerciseDetails.Connection = conn;
                exerciseDetails.CommandText = "select Photo1,Photo2,Video from Exercises where Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                //trainerData.CommandText = "select Photo from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                //byte[] _bytes = (byte[])trainerData.ExecuteScalar();
                // Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);  


                SqlDataReader dr = exerciseDetails.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        byte[] _bytes = (byte[])dr[0];
                        byte[] _bytes1 = (byte[])dr[1];
                
                        Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);
                        Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes1);




                    }
                    catch
                    {
                        Image1.ImageUrl = "images/userDefaultImage.jpg";
                        Image2.ImageUrl = "images/userDefaultImage.jpg";

                    }
                   
                }



                conn.Close();
            }



        }
        protected void updateExerciseDetails(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && FileUpload2.HasFile)
            {
                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage);

                byte[] myimage2 = new byte[FileUpload2.PostedFile.ContentLength];
                HttpPostedFile ImageTwo = FileUpload2.PostedFile;
                ImageTwo.InputStream.Read(myimage2, 0, (int)FileUpload2.PostedFile.ContentLength);
                Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage2);


                string sql = "UPDATE Exercises SET Photo1=@photo1,Photo2=@photo2 WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.Add("@photo1", SqlDbType.Image, myimage.Length).Value = myimage;
                komut.Parameters.Add("@photo2", SqlDbType.Image, myimage2.Length).Value = myimage2;
                conn.Open();
                komut.ExecuteNonQuery();
            }
            if (!FileUpload1.HasFile && FileUpload2.HasFile)
            {
                
                byte[] myimage2 = new byte[FileUpload2.PostedFile.ContentLength];
                HttpPostedFile ImageTwo = FileUpload2.PostedFile;
                ImageTwo.InputStream.Read(myimage2, 0, (int)FileUpload2.PostedFile.ContentLength);
                Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage2);


                string sql = "UPDATE Exercises SET Photo2=@photo2 WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.Add("@photo2", SqlDbType.Image, myimage2.Length).Value = myimage2;
                conn.Open();
                komut.ExecuteNonQuery();
            }
            if (FileUpload1.HasFile && !FileUpload2.HasFile)
            {
                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage);

                string sql = "UPDATE Exercises SET Photo1=@photo1 WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.Add("@photo1", SqlDbType.Image, myimage.Length).Value = myimage;
 
                conn.Open();
                komut.ExecuteNonQuery();
            
            }
     
        }
    }
}