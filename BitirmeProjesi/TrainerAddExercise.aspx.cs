using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerAddExercise : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
               
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Type_ID, Type_Name FROM ExercisesType"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        DropDownList1.DataSource = cmd.ExecuteReader();
                        DropDownList1.DataTextField = "Type_Name";
                        DropDownList1.DataValueField = "Type_ID";
                        DropDownList1.DataBind();
                        con.Close();
                    }
                }
                //DropDownList1.Items.Insert(0, new ListItem("--Select Type--", "0"));
            }
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


        protected void addNewExercise(object sender, EventArgs e)
        {
            LabelVideo.Visible = false;
            LabelPhoto1.Visible = false;
            LabelPhoto2.Visible = false;
        

            if (!FileUpload1.HasFile)
            {
                LabelVideo.Visible = true;
            }
            else
            {
                if (!FileUpload2.HasFile)
                {
                    LabelPhoto1.Visible = true;
                }
                else
                {
                    if (!FileUpload3.HasFile)
                    {
                        LabelPhoto2.Visible = true;
                    }
                    else
                    {
                        //Video file
                        BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream);
                        byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
                        //video file server a kaydetme islemi.

                        string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") +Path.GetFileName(FileUpload1.PostedFile.FileName);
                   
                        FileUpload1.SaveAs(Server.MapPath("mustafa/" + FileName));


                        //Photo 1 file
                        MemoryStream thumbnailPhotoStream1 = ResizeImage(FileUpload2);
                        byte[] thumbnailImageBytes1 = thumbnailPhotoStream1.ToArray();

                     /*   byte[] myimage = new byte[FileUpload2.PostedFile.ContentLength];
                        HttpPostedFile Image = FileUpload2.PostedFile;
                        Image.InputStream.Read(myimage, 0, (int)FileUpload2.PostedFile.ContentLength);*/

                        //Photo 2 file
                        MemoryStream thumbnailPhotoStream2 = ResizeImage(FileUpload3);
                        byte[] thumbnailImageBytes2 = thumbnailPhotoStream2.ToArray();



                      /*  byte[] myimage2 = new byte[FileUpload3.PostedFile.ContentLength];
                        HttpPostedFile Image2 = FileUpload3.PostedFile;
                        Image2.InputStream.Read(myimage2, 0, (int)FileUpload3.PostedFile.ContentLength);*/

                        SqlConnection con = new SqlConnection(constr);
                        string query = "insert into Exercises values (@Name, @Tittle, @Description, @Photo1, @Photo2, @Type_ID,@Trainer_ID,@VideoName,@VideoPath)";
                        SqlCommand cmd = new SqlCommand(query);

                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", exerciseName.Text);
                        cmd.Parameters.AddWithValue("@Tittle", tittleName.Text);
                        cmd.Parameters.AddWithValue("@Description", descriptionarea.InnerText);
                   
                        cmd.Parameters.Add("@Photo1", SqlDbType.Image, thumbnailImageBytes1.Length).Value = thumbnailImageBytes1;
                        cmd.Parameters.Add("@Photo2", SqlDbType.Image, thumbnailImageBytes2.Length).Value = thumbnailImageBytes2;
                        cmd.Parameters.AddWithValue("@Type_ID", DropDownList1.SelectedValue);
                        cmd.Parameters.AddWithValue("@Trainer_ID", Convert.ToInt32(Session["trainerID"].ToString()));
                        cmd.Parameters.AddWithValue("@VideoName",FileName);
                        cmd.Parameters.AddWithValue("@VideoPath", "mustafa/" + FileName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Added exercise", MessageBox.MesajTipleri.Success, false, 3000);
                    }
                }
            }
            
               
           

          
            
        }
    }
}