using System;
using System.Collections;
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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
             
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string query = "SELECT Type_ID, Type_Name,Siralama FROM ExercisesType ORDER BY Siralama";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvLocations.DataSource = dt;
                            gvLocations.DataBind();
                           
                        }
                    }
                }
            }
        }


        protected void UpdatePreference(object sender, EventArgs e)
        {
        
            int[] locationIds = (from p in Request.Form["Siralama"].Split(',') select int.Parse(p)).ToArray();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            ArrayList myString = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                trainerData.CommandText = "select Type_Name from ExercisesType where Siralama='" + locationIds[i] + "' ORDER BY Siralama ";
                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    string a = dr[0].ToString();
                    myString.Add(a);
                    Response.Write(a);

                }
                dr.Close();

            }

           


            int preference = 1;
            foreach (int locationId in locationIds)
            {
                this.UpdatePreference(locationId, preference,myString);
                preference += 1;
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }



        private void UpdatePreference(int locationId, int preference,ArrayList myString)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            


            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE ExercisesType SET Siralama = @Siralama WHERE Type_Name = @Type_Name"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                     
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Siralama", preference);
                        cmd.Parameters.AddWithValue("@Type_Name", myString[preference-1]);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
    }
    
}