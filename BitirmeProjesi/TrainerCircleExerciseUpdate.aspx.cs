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
    public partial class TrainerCircleExerciseUpdate : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        ArrayList listExerciseName = new ArrayList();
        ArrayList listExerciseID = new ArrayList();
        ArrayList listOrderExercise = new ArrayList();
        ArrayList listExerciseCount = new ArrayList();
        ArrayList listCircleExerciseOrder = new ArrayList();
        ArrayList listCircleExerciseRepeat = new ArrayList();
        DropDownList ddl;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["trainerID"] == null)
            {
                Response.Redirect("Main.aspx");
            }




            if (!Page.IsPostBack)
            {
                try
                {
                    if ((bool)Session["editProgramPermission"] == false)
                    {
                        Button1.Visible = false;
                        GridView1.Enabled = false;
                    }
                }
                catch
                {
                    listCircleExerciseOrder.Add(0);
                    listCircleExerciseRepeat.Add(0);
                    int count = Convert.ToInt32(GridView1.Rows.Count.ToString());
                    TextBox tb = (TextBox)GridView1.Rows[0].FindControl("TextBox4");
                    tb.Visible = false;
                    DropDownList removeDD = (DropDownList)GridView1.Rows[0].FindControl("circleExercise");
                    removeDD.Visible = false;


                    conn.Open();
                    SqlCommand trainerData = new SqlCommand();
                    trainerData.Connection = conn;
                    trainerData.CommandText = "select  p1.Program_ID, p1.Exercises_ID,[Exercises].[Name],p1.OrderExercise,(select count(*) from [ProgramExercise] p2 where p2.Program_ID=p1.Program_ID and p2.Exercises_ID=p1.Exercises_ID) x,p1.CircleExercise_ID,p1.CircleExercise_Repeat FROM [ProgramExercise] p1,[Exercises] where p1.Exercises_ID=[Exercises].[Exercises_ID] and p1.Program_ID='" + Convert.ToInt32(Session["programID"].ToString()) + "' ORDER BY p1.OrderExercise ASC";
                    SqlDataReader dr = trainerData.ExecuteReader();
                    int labelId = 1;
                    while (dr.Read())
                    {
                        int exerciseID = Convert.ToInt32(dr[1].ToString());
                        string exerciseName = dr[2].ToString();
                        int orderExercise = Convert.ToInt32(dr[3].ToString());
                        int countExercise = Convert.ToInt32(dr[4].ToString());
                        int circleExerciseOrder;
                        int circleExerciseRepeat;
                        try
                        {

                            circleExerciseOrder = Convert.ToInt32(dr[5].ToString());
                            circleExerciseRepeat = Convert.ToInt32(dr[6].ToString());
                            //circle edilen egzersizlerin order i ve repeat sayisi bilgisi bu arraylist icerisinde.
                            listCircleExerciseOrder.Add(circleExerciseOrder);
                            listCircleExerciseRepeat.Add(circleExerciseRepeat);
                        }
                        catch
                        {
                            listCircleExerciseOrder.Add(0);
                            listCircleExerciseRepeat.Add(0);
                        }

                        listExerciseName.Add(exerciseName);
                        listExerciseID.Add(exerciseID);
                        listOrderExercise.Add(orderExercise);
                        listExerciseCount.Add(countExercise);



                        if (countExercise > 1)
                        {
                            Label tblabel = (Label)GridView1.Rows[orderExercise - 1].FindControl("Label3");
                            tblabel.Text = orderExercise + " " + tblabel.Text;
                            labelId++;
                        }




                    }
                    Session["myIds"] = listOrderExercise;
                    conn.Close();
                    int j;
                    for (int i = 1; i < count; i++)
                    {
                        ddl = (DropDownList)GridView1.Rows[i].FindControl("circleExercise");
                        ddl.Items.Add(new ListItem("", "NULL"));
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

                    for (int i = 1; i <= count; i++)
                    {
                        int indexForCircle = Convert.ToInt32(listCircleExerciseOrder[i]);

                        //  ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(listOrderExercise[i].ToString() + " " + listExerciseName[indexForCircle].ToString()));
                        if (indexForCircle != 0)
                        {
                            DropDownList ddNew = (DropDownList)GridView1.Rows[i - 1].FindControl("circleExercise");
                            TextBox tbNew = (TextBox)GridView1.Rows[i - 1].FindControl("TextBox4");


                            if (Convert.ToInt32(listExerciseCount[indexForCircle - 1].ToString()) > 1)
                            {
                                ddNew.SelectedIndex = ddNew.Items.IndexOf(ddNew.Items.FindByText(listOrderExercise[indexForCircle - 1].ToString() + " " + listExerciseName[indexForCircle - 1].ToString()));
                            }
                            else
                            {
                                ddNew.SelectedIndex = ddNew.Items.IndexOf(ddNew.Items.FindByText(listExerciseName[indexForCircle - 1].ToString()));

                            }
                            tbNew.Text = listCircleExerciseRepeat[i].ToString();


                        }


                    }

               
                }
               


         
              

            }
        }

        protected void Update(object sender, EventArgs e)
        {

         


            conn.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = conn;
            ArrayList idList = (ArrayList)Session["myIds"];
            int count = Convert.ToInt32(GridView1.Rows.Count.ToString());
            for (int i = 1; i < count; i++)
            {
                string c = (GridView1.Rows[i].Cells[1].FindControl("Label2") as Label).Text;
                DropDownList ddd = (DropDownList)GridView1.Rows[i].FindControl("circleExercise");
                string c1 = ddd.SelectedValue.ToString(); //dropdownlistten secilen deger
                TextBox tbb = (TextBox)GridView1.Rows[i].FindControl("TextBox4");


                if (c1 == "NULL")
                {
                   
                }
                else
                {
                    string dizi = idList[i].ToString(); //order sayisi
                    string deneme = tbb.Text;
                    trainerDataUpdate.CommandText = "UPDATE ProgramExercise SET CircleExercise_ID='" + Convert.ToInt32(c1.ToString()) + "', CircleExercise_Repeat='" + Convert.ToInt32(tbb.Text) + "' WHERE Program_ID='" + Convert.ToInt32(Session["programID"].ToString()) + "' and OrderExercise='" + Convert.ToInt32(dizi) + "'";
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
            Session.Remove("updateSession");
            Session["CreateProgramSuccess"] = "true";




            Response.Redirect("TrainerDefaultPage.aspx");

        }
    }
}