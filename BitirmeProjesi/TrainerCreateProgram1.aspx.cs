using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerCreateProgram1 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("SELECT ProgramSpec_ID, ProgramSpec_Name FROM ProgramSpec");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "ProgramSpec_Name";
                DropDownList1.DataValueField = "ProgramSpec_ID";
                DropDownList1.DataBind();
                con.Close();


                SqlCommand cmd2 = new SqlCommand("SELECT ProgramDiff_ID, ProgramDiff_Name FROM ProgramDifficulty");
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                con.Open();
                DropDownList2.DataSource = cmd2.ExecuteReader();
                DropDownList2.DataTextField = "ProgramDiff_Name";
                DropDownList2.DataValueField = "ProgramDiff_ID";
                DropDownList2.DataBind();
                con.Close();
                string admin = "admin";
                SqlCommand cmd3 = new SqlCommand("SELECT User_ID FROM Users where Email='"+admin.ToString()+"'");
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                con.Open();
                SqlDataReader dr = cmd3.ExecuteReader();
                while (dr.Read())
                {
                   
                       Session["AdminID"] = Convert.ToInt32(dr[0]);
                      

                    
                }

                
                con.Close();



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


        protected void next(object sender, EventArgs e)
        {


            Session["ProgramSpecID"] = DropDownList1.SelectedValue;
            Session["ProgramDiffID"] = DropDownList2.SelectedValue;
            Session["ProgramTittle"] = TextBoxProgramTittle.Text;
            Session["order"] = 0;
            if (FileUpload1.HasFile)
            {
                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
            
               
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload1);
                byte[] thumbnailImageBytes = thumbnailPhotoStream.ToArray();


               // Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage);
                Session["ProgramPhoto"] = thumbnailImageBytes;
                Response.Redirect("TrainerCreateProgram2.aspx");
            }
            else
            {
                //Photo yuklenmeli uyarisi cikar.
            }
          
           
              
         }

          
     
    }
}