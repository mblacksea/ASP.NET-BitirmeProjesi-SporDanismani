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
    public partial class TrainerAddExercise : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MessageBox.Show("Account not activated", MessageBox.MesajTipleri.Warning, false, 3000);
               
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


                        //Photo 1 file
                        byte[] myimage = new byte[FileUpload2.PostedFile.ContentLength];
                        HttpPostedFile Image = FileUpload2.PostedFile;
                        Image.InputStream.Read(myimage, 0, (int)FileUpload2.PostedFile.ContentLength);

                        //Photo 2 file
                        byte[] myimage2 = new byte[FileUpload3.PostedFile.ContentLength];
                        HttpPostedFile Image2 = FileUpload3.PostedFile;
                        Image2.InputStream.Read(myimage2, 0, (int)FileUpload3.PostedFile.ContentLength);

                        SqlConnection con = new SqlConnection(constr);
                        string query = "insert into Exercises values (@Name, @Tittle, @Description, @Video, @Photo1, @Photo2, @Type_ID,@Trainer_ID)";
                        SqlCommand cmd = new SqlCommand(query);

                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", exerciseName.Text);
                        cmd.Parameters.AddWithValue("@Tittle", tittleName.Text);
                        cmd.Parameters.AddWithValue("@Description", descriptionarea.InnerText);
                        cmd.Parameters.AddWithValue("@Video", bytes);
                        cmd.Parameters.Add("@Photo1", SqlDbType.Image, myimage.Length).Value = myimage;
                        cmd.Parameters.Add("@Photo2", SqlDbType.Image, myimage2.Length).Value = myimage2;
                        cmd.Parameters.AddWithValue("@Type_ID", DropDownList1.SelectedValue);
                        cmd.Parameters.AddWithValue("@Trainer_ID", Convert.ToInt32(Session["trainerID"].ToString()));

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            
               
           

          
            
        }
    }
}