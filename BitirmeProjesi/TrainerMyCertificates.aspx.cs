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
    public partial class TrainerMyCertificates : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showCertificateID.Visible = false;
                updateID.Visible = false;
            }
        }


        protected void OnSelectedIndexChanged1(object sender, EventArgs e)
        {
            updateID.Visible = true;
            showCertificateID.Visible = true;

            String certificate_ID = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["Certificate_ID"] = certificate_ID;

            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            trainerData.CommandText = "select Certificate_Name,Instution,Date,CertificateFile from Certificate where Certificate_ID='" + certificate_ID + "'";

            SqlDataReader dr = trainerData.ExecuteReader();
            while (dr.Read())
            {

                certificateName.Text = dr[0].ToString();
                instutionName.Text = dr[1].ToString();
                DateTime d = DateTime.Parse(dr[2].ToString());
                date.Text = d.ToString("yyyy-MM-dd");
                byte[] bytes = (byte[])dr[3];
                Session["PdfFile"] = bytes;


            }



            conn.Close();









        }

        protected void showCertificate(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('PdfDisplay.aspx','_blank')");
            Response.Write("</script>");
        }

        protected void updateCertificate(object sender, EventArgs e)
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
                        string query = "UPDATE Certificate SET Certificate_Name=@Certificate_Name, Instution=@Instution, Date=@Date, CertificateFile=@CertificateFile where Certificate_ID='" + Convert.ToInt32(Session["Certificate_ID"].ToString()) + "' ";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {

                            cmd.Connection = con;

                            cmd.Parameters.AddWithValue("@Certificate_Name", certificateName.Text);
                            cmd.Parameters.AddWithValue("@Instution", instutionName.Text);
                            cmd.Parameters.AddWithValue("@Date", date.Text);
                            cmd.Parameters.AddWithValue("@CertificateFile", bytes);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Updated certificate", MessageBox.MesajTipleri.Success, false, 3000);
                            GridView1.DataBind();
                        }
                    }
                }
            }

            conn.Open();
            SqlCommand trainerStatusUpdate = new SqlCommand();
            trainerStatusUpdate.Connection = conn;
            trainerStatusUpdate.CommandText = "UPDATE TrainersData SET Status_ID=2 WHERE Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "'";
            trainerStatusUpdate.ExecuteNonQuery();
            conn.Close();
        }
    }
}
