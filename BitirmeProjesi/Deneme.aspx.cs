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
    public partial class Deneme1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

             BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream);
             byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length); 


             string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
             SqlConnection con = new SqlConnection(constr);
             string query = "insert into Exercises values (@Name, @Tittle, @Description, @Video, @Photo1, @Photo2, @Type_ID,@Trainer_ID)";
             SqlCommand cmd = new SqlCommand(query);
                        
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                            cmd.Parameters.AddWithValue("@Tittle", TextBox2.Text);
                            cmd.Parameters.AddWithValue("@Description", TextBox3.Text);
                            cmd.Parameters.AddWithValue("@Video", bytes);
                            cmd.Parameters.AddWithValue("@Photo1", bytes);
                            cmd.Parameters.AddWithValue("@Photo2", bytes);
                            cmd.Parameters.AddWithValue("@Type_ID", 2);
                            cmd.Parameters.AddWithValue("@Trainer_ID", 2);
                    
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        
                    
                
            
        }
    }
}