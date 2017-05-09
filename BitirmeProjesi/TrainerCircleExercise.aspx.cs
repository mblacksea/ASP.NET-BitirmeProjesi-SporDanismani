using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerCircleExercise : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        ArrayList listExerciseName = new ArrayList();
        ArrayList listExerciseID = new ArrayList();
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                string c = GridView1.Rows[i].Cells[0].Text;
              
            
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                int count = Convert.ToInt32(GridView1.Rows.Count.ToString());


                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                trainerData.CommandText = "select Distinct [ProgramExercise].[Program_ID], [ProgramExercise].[Exercises_ID],[Exercises].[Name],MIN([ProgramExercise].[OrderExercise]) FROM [ProgramExercise],[Exercises] where [ProgramExercise].[Exercises_ID]=[Exercises].[Exercises_ID] and [ProgramExercise].[Program_ID]='" + Convert.ToInt32(Session["programID"].ToString()) + "' GROUP BY [ProgramExercise].[Exercises_ID],[Exercises].[Name],[ProgramExercise].[Program_ID] ORDER BY MIN([ProgramExercise].[OrderExercise] ) ASC";
                SqlDataReader dr = trainerData.ExecuteReader();
                while (dr.Read())
                {
                    int exerciseID = Convert.ToInt32(dr[1].ToString());
                    string exerciseName = dr[2].ToString();
                    listExerciseName.Add(exerciseName);
                    listExerciseID.Add(exerciseID);




                }
                conn.Close();
                int j;
                for (int i = 1; i < count; i++)
                {
                    DropDownList ddl = (DropDownList)GridView1.Rows[i].FindControl("circleExercise");
                    j = i;
                    while (j >= 0)
                    {
                        string c = GridView1.Rows[i].Cells[3].Text;
                        if ((j - 1) != -1)
                        {
                            j = j - 1;

                            ddl.Items.Add(new ListItem(listExerciseName[j].ToString(), listExerciseID[j].ToString()));
                        }
                        else
                        {
                            j = j - 1;
                        }



                    }

                }
            }
          





        }
        protected void Create(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(GridView1.Rows.Count.ToString());
            for (int i = 0; i < count; i++)
            {
                string c = (GridView1.Rows[i].Cells[1].FindControl("Label2") as Label).Text;
                Label4.Text = c.ToString();
                string a;
            }

        }
        protected void CreateWithoutCircle(object sender, EventArgs e)
        {

            Session.Remove("ProgramSpecID");
            Session.Remove("ProgramDiffID");
            Session.Remove("order");
            Session.Remove("createExerciseID");
            Session.Remove("ExerciseType");
            Session.Remove("programID");
            Response.Redirect("TrainerDefaultPage.aspx");

        }
    }
}