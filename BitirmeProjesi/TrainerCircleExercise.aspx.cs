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
        ArrayList listOrderExercise = new ArrayList();
        ArrayList listExerciseCount = new ArrayList();
        DropDownList ddl;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["trainerID"] == null)
            {
                Response.Redirect("Main.aspx");
            }


            if (!Page.IsPostBack)
            {
              
                int count = Convert.ToInt32(GridView1.Rows.Count.ToString());
                TextBox tb = (TextBox)GridView1.Rows[0].FindControl("TextBox4");
                tb.Visible = false;
                DropDownList removeDD =  (DropDownList)GridView1.Rows[0].FindControl("circleExercise");
                removeDD.Visible = false;
                conn.Open();
                SqlCommand trainerData = new SqlCommand();
                trainerData.Connection = conn;
                //trainerData.CommandText = "select Distinct [ProgramExercise].[Program_ID], [ProgramExercise].[Exercises_ID],[Exercises].[Name],MIN([ProgramExercise].[OrderExercise]) FROM [ProgramExercise],[Exercises] where [ProgramExercise].[Exercises_ID]=[Exercises].[Exercises_ID] and [ProgramExercise].[Program_ID]='" + Convert.ToInt32(Session["programID"].ToString()) + "' GROUP BY [ProgramExercise].[Exercises_ID],[Exercises].[Name],[ProgramExercise].[Program_ID] ORDER BY MIN([ProgramExercise].[OrderExercise] ) ASC";
              //  trainerData.CommandText = "select  [ProgramExercise].[Program_ID], [ProgramExercise].[Exercises_ID],[Exercises].[Name],[ProgramExercise].[OrderExercise] FROM [ProgramExercise],[Exercises] where [ProgramExercise].[Exercises_ID]=[Exercises].[Exercises_ID] and [ProgramExercise].[Program_ID]='" + Convert.ToInt32(Session["programID"].ToString()) + "'ORDER BY [ProgramExercise].[OrderExercise] ASC";
                trainerData.CommandText = "select  p1.Program_ID, p1.Exercises_ID,[Exercises].[Name],p1.OrderExercise,(select count(*) from [ProgramExercise] p2 where p2.Program_ID=p1.Program_ID and p2.Exercises_ID=p1.Exercises_ID) x FROM [ProgramExercise] p1,[Exercises] where p1.Exercises_ID=[Exercises].[Exercises_ID] and p1.Program_ID='"+Convert.ToInt32(Session["programID"].ToString()) +"' ORDER BY p1.OrderExercise ASC";

                SqlDataReader dr = trainerData.ExecuteReader();
               int labelId = 1; 
                while (dr.Read())
                {
                    int exerciseID = Convert.ToInt32(dr[1].ToString());
                    string exerciseName = dr[2].ToString();
                    int orderExercise = Convert.ToInt32(dr[3].ToString());
                    int countExercise = Convert.ToInt32(dr[4].ToString());
                    listExerciseName.Add(exerciseName);
                    listExerciseID.Add(exerciseID);
                    listOrderExercise.Add(orderExercise);
                    listExerciseCount.Add(countExercise);
                    if (countExercise > 1)
                    {
                        Label tblabel = (Label)GridView1.Rows[orderExercise - 1].FindControl("Label3");
                        tblabel.Text = orderExercise + " " +  tblabel.Text;
                        labelId++;
                    }
                  
                    


                }
                Session["myIds"] = listOrderExercise;
                conn.Close();
                int j;
                for (int i = 1; i < count; i++)
                {
                    ddl = (DropDownList)GridView1.Rows[i].FindControl("circleExercise");
                    ddl.Items.Add(new ListItem("","NULL"));
                    j = i;
                    while (j >= 0)
                    {
                        string c = GridView1.Rows[i].Cells[3].Text;
                        if ((j - 1) != -1)
                        {
                            j = j - 1;
                            if (Convert.ToInt32(listExerciseCount[j].ToString()) > 1) 
                            {
                                ddl.Items.Add(new ListItem(listOrderExercise[j].ToString() + " " + listExerciseName[j].ToString(), listOrderExercise[j].ToString()));
                            }
                            else
                            {
                                ddl.Items.Add(new ListItem(listExerciseName[j].ToString(), listOrderExercise[j].ToString()));

                            }
       
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
            conn.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = conn;
            ArrayList idList = (ArrayList)Session["myIds"];
            int count = Convert.ToInt32(GridView1.Rows.Count.ToString());
            for (int i = 1; i < count; i++)
            {
                string c = (GridView1.Rows[i].Cells[1].FindControl("Label2") as Label).Text;
                DropDownList dd = (DropDownList)GridView1.Rows[i].FindControl("circleExercise");
                string c1 = dd.SelectedValue.ToString(); //dropdownlistten secilen deger
                TextBox tb = (TextBox)GridView1.Rows[i].FindControl("TextBox4");
               

                if (c1=="NULL")
                {

                }
                else
                {
                    string dizi = idList[i].ToString(); //order sayisi
                    //listOrderExercise[j].ToString()
                    trainerDataUpdate.CommandText = "UPDATE ProgramExercise SET CircleExercise_ID='" + Convert.ToInt32(c1.ToString()) + "', CircleExercise_Repeat='" + Convert.ToInt32(tb.Text) + "' WHERE Program_ID='" + Convert.ToInt32(Session["programID"].ToString()) + "' and OrderExercise='" + Convert.ToInt32(dizi) + "'";
                    trainerDataUpdate.ExecuteNonQuery();
                }
               


   
            }
            conn.Close();
            Session.Remove("ProgramSpecID");
            Session.Remove("ProgramDiffID");
            Session.Remove("order");
            Session.Remove("createExerciseID");
            Session.Remove("ExerciseType");
            Session.Remove("programID");
            Session.Remove("adminID");
            Session["CreateProgramSuccess"] = true;
            Response.Redirect("TrainerDefaultPage.aspx");

        }
        protected void CreateWithoutCircle(object sender, EventArgs e)
        {

            Session.Remove("ProgramSpecID");
            Session.Remove("ProgramDiffID");
            Session.Remove("order");
            Session.Remove("createExerciseID");
            Session.Remove("ExerciseType");
            Session.Remove("programID");
            Session.Remove("adminID");
            Session["CreateProgramSuccess"] = "true";
            Response.Redirect("TrainerDefaultPage.aspx");

        }
    }
}