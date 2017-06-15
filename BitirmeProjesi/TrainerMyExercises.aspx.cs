﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerMyExercises : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            //Label1.Text = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
          // Session["trainerDetailsID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
          //  Session["trainerDetailsEmail"] = (GridView1.SelectedRow.FindControl("Label4") as Label).Text;
            Session["exerciseID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Response.Redirect("TrainerMyExercisesDetails.aspx");


        }

      


   

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            String exercise_ID = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            trainerData.CommandText = "select count(*) sayi from ProgramExercise where Exercises_ID='" + exercise_ID + "'";
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
                MessageBox.Show("You cannot this record!", MessageBox.MesajTipleri.Error, false, 3000);
            }
            else
            {
                conn.Open();
                SqlCommand trainerDataUpdate = new SqlCommand();
                trainerDataUpdate.Connection = conn;
                trainerDataUpdate.CommandText = "Delete from Exercises where Exercises_ID='" + exercise_ID + "'";
                trainerDataUpdate.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deletion successful", MessageBox.MesajTipleri.Success, false, 3000);
                GridView1.DataBind();
                //sildir
            }
        }

     
      


    }
}