using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerCreateProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addNewCertificate(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "insert into Certificate values (@Trainer_ID, @Certificate_Name, @Instution, @Date, @CertificateFile)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
             
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Trainer_ID", Convert.ToInt32(Session["trainerID"].ToString()));
                            cmd.Parameters.AddWithValue("@Certificate_Name", certificateName.Text);
                            cmd.Parameters.AddWithValue("@Instution", instutionName.Text);
                            cmd.Parameters.AddWithValue("@Date", date.Text);
                            cmd.Parameters.AddWithValue("@CertificateFile", bytes);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
         
        }
    }
}