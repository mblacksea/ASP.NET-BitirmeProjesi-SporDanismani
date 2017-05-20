using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerProfileSettings : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {


                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                trainerData.CommandText = "select Photo,Intro,Bio from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                //trainerData.CommandText = "select Photo from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                //byte[] _bytes = (byte[])trainerData.ExecuteScalar();
                // Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);  


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
                    introTextArea.InnerText = dr[1].ToString();
                    bioTextArea.InnerText = dr[2].ToString();




                }



                conn.Close();
            }
            // Response.Write(Session["trainerID"].ToString());

        }


        private MemoryStream ResizeImage(FileUpload fileUpload)
        {
            // Create a bitmap with the uploaded file content
            Bitmap originalBMP = new Bitmap(fileUpload.FileContent);

            // get the original dimensions
            int origWidth = originalBMP.Width;
            int origHeight = originalBMP.Height;

            //calculate the current aspect ratio
            int aspectRatio = origWidth / origHeight;

            //if the aspect ration is less than 0, default to 1
            if (aspectRatio <= 0)
                aspectRatio = 1;

            //new width of the thumbnail image           
            int newWidth = 300;

            //calculate the height based on the aspect ratio
            int newHeight = newWidth / aspectRatio;

            // Create a new bitmap to store the new image
            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

            // Create a graphic based on the new bitmap
            Graphics graphics = Graphics.FromImage(newBMP);

            // Set the properties for the new graphic file
            graphics.SmoothingMode = SmoothingMode.AntiAlias; graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the new graphic based on the resized bitmap
            graphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

            //save the bitmap into a memory stream
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            newBMP.Save(stream, GetImageFormat(System.IO.Path.GetExtension(fileUpload.FileName)));

            // dispose drawing objects
            originalBMP.Dispose();
            newBMP.Dispose();
            graphics.Dispose();

            return stream;
        }

        private System.Drawing.Imaging.ImageFormat GetImageFormat(string extension)
        {
            switch (extension.ToLower())
            {
                case "jpg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case "png":
                    return System.Drawing.Imaging.ImageFormat.Png;
            }
            return System.Drawing.Imaging.ImageFormat.Jpeg;
        }



        protected void profileSettingsUpdate(object sender, EventArgs e)
        {



            if (!FileUpload1.HasFile)
            {

                conn.Open();
                SqlCommand trainerDataUpdate = new SqlCommand();
                trainerDataUpdate.Connection = conn;
                trainerDataUpdate.CommandText = "UPDATE TrainersData SET Intro='" + introTextArea.InnerText + "', Bio='" + bioTextArea.InnerText + "' WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                trainerDataUpdate.ExecuteNonQuery();
            }
            else
            {  /*
                int fileSize = FileUpload1.PostedFile.ContentLength;
               
                    using (Stream fs = FileUpload1.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            Image1.ImageUrl = "data:image/jpeg;base64," + base64String;
                            trainerDataUpdate.CommandText = "UPDATE TrainersData SET Intro='" + introTextArea.InnerText + "', Photo='" + base64String + "', Bio='" + bioTextArea.InnerText + "' WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                            trainerDataUpdate.ExecuteNonQuery();
                        }
                    }

                */

                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload1);
                byte[] thumbnailImageBytes = thumbnailPhotoStream.ToArray();
                // trainerDataUpdate.CommandText = "UPDATE TrainersData SET Intro=@intro, Photo=@photo, Bio=@bio WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                // trainerDataUpdate.ExecuteNonQuery();
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(thumbnailImageBytes);
                string sql = "UPDATE TrainersData SET Intro=@intro, Photo=@photo, Bio=@bio WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@intro", introTextArea.InnerText);
                komut.Parameters.Add("@photo", SqlDbType.Image, thumbnailImageBytes.Length).Value = thumbnailImageBytes;
                komut.Parameters.Add("@bio", bioTextArea.InnerText);
                conn.Open();

                komut.ExecuteNonQuery();






            }


            conn.Close();
        }

    }
       
    }
