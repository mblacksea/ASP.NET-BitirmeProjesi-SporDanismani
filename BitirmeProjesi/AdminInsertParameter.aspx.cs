using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminInsertParameter : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminSession"] == null)
            {
                Response.Redirect("Main.aspx");
            }
            if (DropDownList1.SelectedValue == "Program Difficulty")
            {
                FirstGridview.Visible = true;
                SecondGridview.Visible = false;
                textID.Visible = true;
                TextBox1.Attributes.Add("placeholder", "Program Difficulty");
            }
          
            else if(DropDownList1.SelectedValue=="Program Spec")
            {
                SecondGridview.Visible = true;
                FirstGridview.Visible = false;
                textID.Visible = true;
                TextBox1.Attributes.Add("placeholder", "Program Spec");
            }
            else
            {
                SecondGridview.Visible = false;
                FirstGridview.Visible = false;
                textID.Visible = false;
            }
           
            if (!Page.IsPostBack)
            {
                List<ListItem> items = new List<ListItem>();
                items.Add(new ListItem("Select", "Select"));
                items.Add(new ListItem("Program Difficulty", "Program Difficulty"));
                items.Add(new ListItem("Program Spec", "Program Spec"));
                DropDownList1.Items.AddRange(items.ToArray());
                SecondGridview.Visible = false;
                FirstGridview.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            string query;
            using (SqlConnection con = new SqlConnection(constr))
            {
                if (DropDownList1.SelectedValue == "Program Difficulty")
                {
                     query = "insert into ProgramDifficulty values (@ProgramDiff_Name)";
                     using (SqlCommand cmd = new SqlCommand(query))
                     {

                         cmd.Connection = con;
                         cmd.Parameters.AddWithValue("@ProgramDiff_Name", TextBox1.Text);
                         con.Open();
                         try
                         {
                             cmd.ExecuteNonQuery();
                             con.Close();
                             GridView1.DataBind();
                             MessageBox.Show("Record added", MessageBox.MesajTipleri.Success, false, 3000);
                         }
                         catch
                         {

                             con.Close();
                             MessageBox.Show("You cannot insert same value!", MessageBox.MesajTipleri.Error, false, 3000);
                         }
                        
                         
                     }
                }
                else
                {
                     query = "insert into ProgramSpec values (@ProgramSpec_Name)";
                     using (SqlCommand cmd = new SqlCommand(query))
                     {

                         cmd.Connection = con;
                         cmd.Parameters.AddWithValue("@ProgramSpec_Name", TextBox1.Text);
                         con.Open();

                         try
                         {
                             cmd.ExecuteNonQuery();
                             con.Close();
                             GridView2.DataBind();
                             MessageBox.Show("Record added", MessageBox.MesajTipleri.Success, false, 3000);
                         }
                         catch
                         {

                             con.Close();
                             MessageBox.Show("You cannot insert same value!", MessageBox.MesajTipleri.Error, false, 3000);
                         }


                   
                          }
                }
               
                
            }
            TextBox1.Text = null;
        }

        protected void OnSelectedIndexChanged1(object sender, EventArgs e)
        {

           
           String programDiff_ID = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
        

           conn.Open();
           SqlCommand trainerData = new SqlCommand();
           trainerData.Connection = conn;
           trainerData.CommandText = "select count(*) sayi from Program where ProgramDiff_ID='" + programDiff_ID + "'";
           SqlDataReader dr = trainerData.ExecuteReader();

           String count = null;
           while (dr.Read())
           {

               count = dr[0].ToString();

             

           }

           conn.Close();

           if (Convert.ToInt32(count) > 0)
           {
               //silmesine izin verme.
               MessageBox.Show("You cannot delete this record! There is a program connected to it", MessageBox.MesajTipleri.Error, false, 3000);
           }
           else
           {
               conn.Open();
               SqlCommand trainerDataUpdate = new SqlCommand();
               trainerDataUpdate.Connection = conn;
               trainerDataUpdate.CommandText = "Delete from ProgramDifficulty where ProgramDiff_ID='" + programDiff_ID + "'";
               trainerDataUpdate.ExecuteNonQuery();
               conn.Close();
               MessageBox.Show("Deletion successful", MessageBox.MesajTipleri.Success, false, 3000);
               GridView1.DataBind();
               //sildir
           }



         




        }

        protected void OnSelectedIndexChanged2(object sender, EventArgs e)
        {
            String programSpec_ID = (GridView2.SelectedRow.FindControl("Label1") as Label).Text;
           


            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            trainerData.CommandText = "select count(*) sayi from Program where ProgramSpec_ID='" + programSpec_ID + "'";
            SqlDataReader dr = trainerData.ExecuteReader();

            String count = null;
            while (dr.Read())
            {

                count = dr[0].ToString();



            }

            conn.Close();

            if (Convert.ToInt32(count) > 0)
            {
                //silmesine izin verme.
                MessageBox.Show("You cannot delete this record! There is a program connected to it", MessageBox.MesajTipleri.Error, false, 3000);

            }
            else
            {
                conn.Open();
                SqlCommand trainerDataUpdate = new SqlCommand();
                trainerDataUpdate.Connection = conn;
                trainerDataUpdate.CommandText = "Delete from ProgramSpec where ProgramSpec_ID='" + programSpec_ID + "'";
                trainerDataUpdate.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deletion successful", MessageBox.MesajTipleri.Success, false, 3000);
                GridView2.DataBind();
                //sildir
            }



         

        }
    }
}