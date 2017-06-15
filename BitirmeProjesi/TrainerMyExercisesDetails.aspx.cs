using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerMyExercisesDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //videoExercise.Src = "File.ashx?Id=" + Session["exerciseID"].ToString();
                //vlc-record-2017-04-23-20h16m30s-4snMOV_0029-.mp4
               // videoExercise.Src = "videos/vlc-record-2017-04-23-20h16m30s-4snMOV_0029-.mp4";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("SELECT Type_ID, Type_Name FROM ExercisesType");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                DropDownList2.DataSource = cmd.ExecuteReader();
                DropDownList2.DataTextField = "Type_Name";
                DropDownList2.DataValueField = "Type_ID";
                DropDownList2.DataBind();
                con.Close();




                conn.Open();
                SqlCommand exerciseDetails = new SqlCommand();
                exerciseDetails.Connection = conn;
                exerciseDetails.CommandText = "select Name,Tittle,Description,Photo1,Photo2,VideoPath,ExercisesType.Type_ID,ExercisesType.Type_Name from Exercises,ExercisesType where ExercisesType.Type_ID=Exercises.Type_ID and Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                //trainerData.CommandText = "select Photo from TrainersData where Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
                //byte[] _bytes = (byte[])trainerData.ExecuteScalar();
                // Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);  


                //name 0
                //tittle 1
                //description 2
                //photo1 3
                //photo2 4
                //videopath 5
                //type_ıd 6
                //type_name 7

                SqlDataReader dr = exerciseDetails.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        Name.Text = dr[0].ToString();
                        Tittle.Text = dr[1].ToString();
                        Description.Text = dr[2].ToString();
                        byte[] _bytes = (byte[])dr[3];
                        byte[] _bytes1 = (byte[])dr[4];
                
                        Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes);
                        Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(_bytes1);
                        videoExercise.Src = dr[5].ToString();
                        String vale = dr[7].ToString();
                        DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByText(vale));



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
            if (!FileUpload1.HasFile && !FileUpload2.HasFile && !FileUpload3.HasFile)
            {
                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Type_ID=@Type_ID WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                conn.Open();
                komut.ExecuteNonQuery();
            }

            if (FileUpload1.HasFile && FileUpload2.HasFile && FileUpload3.HasFile)
            {
                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage);

                byte[] myimage2 = new byte[FileUpload2.PostedFile.ContentLength];
                HttpPostedFile ImageTwo = FileUpload2.PostedFile;
                ImageTwo.InputStream.Read(myimage2, 0, (int)FileUpload2.PostedFile.ContentLength);
                Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage2);

             /*   BinaryReader br = new BinaryReader(FileUpload3.PostedFile.InputStream);
                byte[] bytesVideo = br.ReadBytes((int)FileUpload3.PostedFile.InputStream.Length);*/

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload3.PostedFile.FileName);

                FileUpload3.SaveAs(Server.MapPath("videos/" + FileName));


                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Photo1=@photo1,Photo2=@photo2,Type_ID=@Type_ID,VideoName=@VideoName,VideoPath=@VideoPath WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.Add("@photo1", SqlDbType.Image, myimage.Length).Value = myimage;
                komut.Parameters.Add("@photo2", SqlDbType.Image, myimage2.Length).Value = myimage2;
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                komut.Parameters.AddWithValue("@VideoName", FileName);
                komut.Parameters.AddWithValue("@VideoPath", "videos/" + FileName);
                conn.Open();
                komut.ExecuteNonQuery();
            }

            if (FileUpload1.HasFile && !FileUpload2.HasFile && FileUpload3.HasFile)
            {
                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage);

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload3.PostedFile.FileName);

                FileUpload3.SaveAs(Server.MapPath("videos/" + FileName));

               /* BinaryReader br = new BinaryReader(FileUpload3.PostedFile.InputStream);
                byte[] bytesVideo = br.ReadBytes((int)FileUpload3.PostedFile.InputStream.Length);*/


                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Photo1=@photo1,Type_ID=@Type_ID,VideoName=@VideoName,VideoPath=@VideoPath WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.Add("@photo1", SqlDbType.Image, myimage.Length).Value = myimage;
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                komut.Parameters.AddWithValue("@VideoName", FileName);
                komut.Parameters.AddWithValue("@VideoPath", "videos/" + FileName);
                conn.Open();
                komut.ExecuteNonQuery();
            }


            if (FileUpload1.HasFile && FileUpload2.HasFile && !FileUpload3.HasFile)
            {
                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage);

                byte[] myimage2 = new byte[FileUpload2.PostedFile.ContentLength];
                HttpPostedFile ImageTwo = FileUpload2.PostedFile;
                ImageTwo.InputStream.Read(myimage2, 0, (int)FileUpload2.PostedFile.ContentLength);
                Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage2);

                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Photo1=@photo1,Photo2=@photo2,Type_ID=@Type_ID WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.Add("@photo1", SqlDbType.Image, myimage.Length).Value = myimage;
                komut.Parameters.Add("@photo2", SqlDbType.Image, myimage2.Length).Value = myimage2;
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
      
                conn.Open();
                komut.ExecuteNonQuery();
            }
            if (!FileUpload1.HasFile && FileUpload2.HasFile && FileUpload3.HasFile)
            {
                

                byte[] myimage2 = new byte[FileUpload2.PostedFile.ContentLength];
                HttpPostedFile ImageTwo = FileUpload2.PostedFile;
                ImageTwo.InputStream.Read(myimage2, 0, (int)FileUpload2.PostedFile.ContentLength);
                Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage2);

               /* BinaryReader br = new BinaryReader(FileUpload3.PostedFile.InputStream);
                byte[] bytesVideo = br.ReadBytes((int)FileUpload3.PostedFile.InputStream.Length);*/
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload3.PostedFile.FileName);

                FileUpload3.SaveAs(Server.MapPath("videos/" + FileName));


                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Photo2=@photo2,Type_ID=@Type_ID,VideoName=@VideoName,VideoPath=@VideoPath WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.Add("@photo2", SqlDbType.Image, myimage2.Length).Value = myimage2;
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                komut.Parameters.AddWithValue("@VideoName", FileName);
                komut.Parameters.AddWithValue("@VideoPath", "videos/" + FileName);
                conn.Open();
                komut.ExecuteNonQuery();
            }


            if (!FileUpload1.HasFile && FileUpload2.HasFile && !FileUpload3.HasFile)
            {
                
                byte[] myimage2 = new byte[FileUpload2.PostedFile.ContentLength];
                HttpPostedFile ImageTwo = FileUpload2.PostedFile;
                ImageTwo.InputStream.Read(myimage2, 0, (int)FileUpload2.PostedFile.ContentLength);
                Image2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage2);


                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Photo2=@photo2,Type_ID=@Type_ID WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.Add("@photo2", SqlDbType.Image, myimage2.Length).Value = myimage2;
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                conn.Open();
                komut.ExecuteNonQuery();
            }
            if (FileUpload1.HasFile && !FileUpload2.HasFile && !FileUpload3.HasFile)
            {
                byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(myimage);

                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Photo1=@photo1,Type_ID=@Type_ID WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.Add("@photo1", SqlDbType.Image, myimage.Length).Value = myimage;
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
 
                conn.Open();
                komut.ExecuteNonQuery();
            
            }
            if (!FileUpload1.HasFile && !FileUpload2.HasFile && FileUpload3.HasFile)
            {
               /* BinaryReader br = new BinaryReader(FileUpload3.PostedFile.InputStream);
                byte[] bytesVideo = br.ReadBytes((int)FileUpload3.PostedFile.InputStream.Length);*/
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload3.PostedFile.FileName);
                FileUpload3.SaveAs(Server.MapPath("videos/" + FileName));

                string sql = "UPDATE Exercises SET Name=@Name,Tittle=@Tittle,Description=@Description,Type_ID=@Type_ID,VideoName=@VideoName,VideoPath=@VideoPath WHERE Exercises_ID='" + Convert.ToInt32(Session["exerciseID"].ToString()) + "'";
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.AddWithValue("@Name", Name.Text);
                komut.Parameters.AddWithValue("@Tittle", Tittle.Text);
                komut.Parameters.AddWithValue("@Description", Description.Text);
                komut.Parameters.AddWithValue("@Type_ID", Convert.ToInt32(DropDownList2.SelectedValue));
                komut.Parameters.AddWithValue("@VideoName", FileName);
                komut.Parameters.AddWithValue("@VideoPath", "videos/" + FileName);

                conn.Open();
                komut.ExecuteNonQuery();

            }
     
        }
    }
}