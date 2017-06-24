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
    public partial class TrainerMyProgramsDetails : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["trainerID"] == null)
            {
                Response.Redirect("Main.aspx");
            }
         

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

                SqlCommand cmd3 = new SqlCommand("SELECT ProgramTittle,ProgramPhoto,ProgramSpec_Name,ProgramDiff_Name FROM Program,ProgramDifficulty,ProgramSpec where ProgramSpec.ProgramSpec_ID=Program.ProgramSpec_ID and Program.ProgramDiff_ID=ProgramDifficulty.ProgramDiff_ID and Program.Program_ID='" + Convert.ToInt32(Session["updateProgramID"].ToString()) + "'");
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                con.Open();
                SqlDataReader dr = cmd3.ExecuteReader();
                while (dr.Read())
                {

                    TextBoxProgramTittle.Text = dr[0].ToString();
                    Session["ProgramTittle"] = TextBoxProgramTittle.Text;
                    byte[] _bytes = (byte[])dr[1];
                    Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);
                    String value1 = dr[2].ToString();
                    String value2 = dr[3].ToString();
                    DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(value1));
                    DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByText(value2));
                    //DropDownList1.SelectedValue = dr[2].ToString();
                    //DropDownList2.SelectedValue = dr[3].ToString();


                }

              
                con.Close();




                con.Open();
                string checkSalesProgram = "select count(*) from UserProgram where Program_ID='" + Convert.ToInt32(Session["updateProgramID"].ToString()) + "'";
                SqlCommand com = new SqlCommand(checkSalesProgram, con);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                con.Close();
                //Bu program birileri tarafindan satin alinmistir. Edit edilemez.
                if (temp > 0)
                {
                    Session["editProgramPermission"] = false;
                    updateButton.Visible = false;
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    TextBoxProgramTittle.Enabled = false;
                    FileUpload1.Enabled = false;
                    MessageBox.Show(" Can not be edited because this program is purchased!", MessageBox.MesajTipleri.Info, false, 3000);

                   
                }
                else
                {
                    Session.Remove("editProgramPermission");
                }
              


          


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

        protected void update(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = con;
            if (!FileUpload1.HasFile)
            {
                trainerDataUpdate.CommandText = "UPDATE Program SET ProgramSpec_ID='" + Convert.ToInt32(DropDownList1.SelectedValue) + "', ProgramDiff_ID='" + Convert.ToInt32(DropDownList2.SelectedValue) + "', ProgramTittle='" + TextBoxProgramTittle.Text + "' WHERE Program_ID='" + Convert.ToInt32(Session["updateProgramID"].ToString()) + "'";
                trainerDataUpdate.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Close();
                MemoryStream thumbnailPhotoStream = ResizeImage(FileUpload1);
                byte[] thumbnailImageBytes = thumbnailPhotoStream.ToArray();
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(thumbnailImageBytes);
                string sql = "UPDATE Program SET ProgramSpec_ID=@ProgramSpec_ID,ProgramDiff_ID=@ProgramDiff_ID,ProgramTittle=@ProgramTittle,ProgramPhoto=@ProgramPhoto where Program_ID='" + Convert.ToInt32(Session["updateProgramID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, con);
                komut.Parameters.AddWithValue("@ProgramSpec_ID", Convert.ToInt32(DropDownList1.SelectedValue));
                komut.Parameters.AddWithValue("@ProgramDiff_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                komut.Parameters.AddWithValue("@ProgramTittle", TextBoxProgramTittle.Text);
                komut.Parameters.Add("@ProgramPhoto", SqlDbType.Image, thumbnailImageBytes.Length).Value = thumbnailImageBytes;
                con.Open();

                komut.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Updated!", MessageBox.MesajTipleri.Success, false, 3000);


           
        }
        protected void continueWithoutUpdate(object sender, EventArgs e)
        {
          //Response.Redirect("TrainerMyProgramsDetails2.aspx");
            Session["updateSession"] = "1";
            Session["programID"] = Session["updateProgramID"].ToString();
            Response.Redirect("TrainerCreateProgram2.aspx");
        }

    }
}