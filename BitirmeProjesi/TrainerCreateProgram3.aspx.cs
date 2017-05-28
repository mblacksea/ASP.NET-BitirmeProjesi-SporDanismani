

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerCreateProgram3 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                TextBox4.Visible = false;
                TextBox5.Visible = false;
                TextBox6.Visible = false;
                TextBox7.Visible = false;
                TextBox8.Visible = false;
                TextBox9.Visible = false;
                TextBox10.Visible = false;

                TextBoxxx1.Visible = false;
                TextBoxxx2.Visible = false;
                TextBoxxx3.Visible = false;
                TextBoxxx4.Visible = false;
                TextBoxxx5.Visible = false;
                TextBoxxx6.Visible = false;
                TextBoxxx7.Visible = false;
                TextBoxxx8.Visible = false;
                TextBoxxx9.Visible = false;
                TextBoxxx10.Visible = false;

                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }

            if (Session["ExerciseType"].ToString() == "Cardio")
            {
                setnumberGroup.Visible = false;
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
                TextBoxxx1.Visible = true;
            }
            else
            {
                timeGroup.Visible = false;
            }
        }
        protected void Add(object sender, EventArgs e)
        {
            if (Session["programID"] != null)
            {
               // Session["order"] = Convert.ToInt32(Session["order"].ToString()) + 1;
                //ProgramExcercise tabloasuna insert yap.
                using (SqlConnection con = new SqlConnection(constr))
                {
                    if (Session["ExerciseType"].ToString() == "Cardio")
                    {
                        Panel3.Visible = true;
                        (Panel3.FindControl("TextBoxxx1") as TextBox).Visible = true;
                 
                        TextBoxxx1.Visible = true;
                        string query = "insert into ProgramExercise values (@Program_ID, @Exercises_ID, @OrderExercise, @SetSayisi, @TekrarSayisi, @Agirlik,@CircleExercise_ID,@CircleExercise_Repeat,@RestTime,@ExerciseTime)SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            Session["order"] = Convert.ToInt32(Session["order"].ToString()) + 1;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Program_ID", Convert.ToInt32(Session["programID"].ToString()));
                            cmd.Parameters.AddWithValue("@Exercises_ID", Convert.ToInt32(Session["createExerciseID"].ToString()));
                            cmd.Parameters.AddWithValue("@OrderExercise", Convert.ToInt32(Session["order"].ToString()));
                            cmd.Parameters.AddWithValue("@SetSayisi", DBNull.Value);
                            cmd.Parameters.AddWithValue("@TekrarSayisi", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Agirlik", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CircleExercise_ID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CircleExercise_Repeat", DBNull.Value);
                         
                      
                            cmd.Parameters.AddWithValue("@RestTime", Convert.ToInt32(TextBoxxx1.Text));
                            cmd.Parameters.AddWithValue("@ExerciseTime", Convert.ToInt32(timeEx.Text));
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("TrainerCreateProgram2.aspx");
               
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= Convert.ToInt32(setNumber.Text); i++)
                        {
                            string texboxID = "TextBox" + i;
                            string query = "insert into ProgramExercise values (@Program_ID, @Exercises_ID, @OrderExercise, @SetSayisi, @TekrarSayisi, @Agirlik,@CircleExercise_ID,@CircleExercise_Repeat,@RestTime,@ExerciseTime)SELECT SCOPE_IDENTITY()";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                Session["order"] = Convert.ToInt32(Session["order"].ToString()) + 1;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Program_ID", Convert.ToInt32(Session["programID"].ToString()));
                                cmd.Parameters.AddWithValue("@Exercises_ID", Convert.ToInt32(Session["createExerciseID"].ToString()));
                                cmd.Parameters.AddWithValue("@OrderExercise", Convert.ToInt32(Session["order"].ToString()));
                                cmd.Parameters.AddWithValue("@SetSayisi", Convert.ToInt32(setNumber.Text));
                                cmd.Parameters.AddWithValue("@TekrarSayisi", (Panel1.FindControl(texboxID.ToString()) as TextBox).Text);
                                cmd.Parameters.AddWithValue("@Agirlik", (Panel2.FindControl("TextBoxx" + i) as TextBox).Text);
                                cmd.Parameters.AddWithValue("@CircleExercise_ID", DBNull.Value);
                                cmd.Parameters.AddWithValue("@CircleExercise_Repeat", DBNull.Value);
                                cmd.Parameters.AddWithValue("@RestTime", (Panel3.FindControl("TextBoxxx" + i) as TextBox).Text);
                                cmd.Parameters.AddWithValue("@ExerciseTime", DBNull.Value);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                              
          

                            }
                        }
                        Response.Redirect("TrainerCreateProgram2.aspx");
                    }
                }
            }
            else
            {
               
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "insert into Program values (@Trainer_ID, @ProgramSpec_ID, @ProgramDiff_ID,@User_ID,@ProgramTittle,@ProgramPhoto,@ProgramDescription)SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {

                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Trainer_ID", Convert.ToInt32(Session["trainerID"].ToString()));
                        cmd.Parameters.AddWithValue("@ProgramSpec_ID", Convert.ToInt32(Session["ProgramSpecID"].ToString()));
                        cmd.Parameters.AddWithValue("@ProgramDiff_ID", Convert.ToInt32(Session["ProgramDiffID"].ToString()));
                        cmd.Parameters.AddWithValue("@User_ID", Convert.ToInt32(Session["AdminID"].ToString()));
                        cmd.Parameters.AddWithValue("@ProgramTittle", Session["ProgramTittle"].ToString());
                        cmd.Parameters.AddWithValue("@ProgramDescription", Session["ProgramDescription"].ToString());
                        var res = (byte[])Session["ProgramPhoto"];
                        cmd.Parameters.Add("@ProgramPhoto", SqlDbType.Image, res.Length).Value = res;
                        con.Open();
                        int programID = Convert.ToInt32(cmd.ExecuteScalar());
                        Session["programID"] = programID.ToString();
                        con.Close();

                    }
                }

                using (SqlConnection con = new SqlConnection(constr))
                {
                    if (Session["ExerciseType"].ToString() == "Cardio")
                    {
                        Panel3.Visible = true;
                        (Panel3.FindControl("TextBoxxx1") as TextBox).Visible = true;
                        string query = "insert into ProgramExercise values (@Program_ID, @Exercises_ID, @OrderExercise, @SetSayisi, @TekrarSayisi, @Agirlik,@CircleExercise_ID,@CircleExercise_Repeat,@RestTime, @ExerciseTime)SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            Session["order"] = Convert.ToInt32(Session["order"].ToString()) + 1;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Program_ID", Convert.ToInt32(Session["programID"].ToString()));
                            cmd.Parameters.AddWithValue("@Exercises_ID", Convert.ToInt32(Session["createExerciseID"].ToString()));
                            cmd.Parameters.AddWithValue("@OrderExercise", Convert.ToInt32(Session["order"].ToString()));
                            cmd.Parameters.AddWithValue("@SetSayisi", DBNull.Value);
                            cmd.Parameters.AddWithValue("@TekrarSayisi", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Agirlik", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CircleExercise_ID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CircleExercise_Repeat", DBNull.Value);
                       
                            cmd.Parameters.AddWithValue("@RestTime", Convert.ToInt32(TextBoxxx1.Text));
                            cmd.Parameters.AddWithValue("@ExerciseTime", Convert.ToInt32(timeEx.Text));
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("TrainerCreateProgram2.aspx");

                        }
                    }
                    else
                    {
                        for (int i = 1; i <= Convert.ToInt32(setNumber.Text); i++)
                        {
                            string texboxID = "TextBox" + i;
                            string query = "insert into ProgramExercise values (@Program_ID, @Exercises_ID, @OrderExercise, @SetSayisi, @TekrarSayisi, @Agirlik,@CircleExercise_ID,@CircleExercise_Repeat,@RestTime,@ExerciseTime)SELECT SCOPE_IDENTITY()";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {


                                Session["order"] = Convert.ToInt32(Session["order"].ToString()) + 1;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Program_ID", Convert.ToInt32(Session["programID"].ToString()));
                                cmd.Parameters.AddWithValue("@Exercises_ID", Convert.ToInt32(Session["createExerciseID"].ToString()));
                                cmd.Parameters.AddWithValue("@OrderExercise", Convert.ToInt32(Session["order"].ToString()));
                                cmd.Parameters.AddWithValue("@SetSayisi", Convert.ToInt32(setNumber.Text));
                                cmd.Parameters.AddWithValue("@TekrarSayisi", (Panel1.FindControl("TextBox"+i) as TextBox).Text);
                                cmd.Parameters.AddWithValue("@Agirlik", (Panel2.FindControl("TextBoxx" + i) as TextBox).Text);
                                cmd.Parameters.AddWithValue("@CircleExercise_ID", DBNull.Value);
                                cmd.Parameters.AddWithValue("@CircleExercise_Repeat", DBNull.Value);
                                cmd.Parameters.AddWithValue("@RestTime", (Panel3.FindControl("TextBoxxx" + i) as TextBox).Text);
                                cmd.Parameters.AddWithValue("@ExerciseTime", DBNull.Value);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                               
                                //  
                            }
                        }
                        Response.Redirect("TrainerCreateProgram2.aspx");
                    }


                }

            }





        }

    

        protected void CreateSets(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
            int setSayisi = Convert.ToInt32(setNumber.Text);
            for (int i = 1; i <= setSayisi; i++)
            {
                string texboxIDPanel1 = "TextBox" + i;
                string texboxIDPanel2 = "TextBoxx" + i;
                string texboxIDPanel3 = "TextBoxxx" + i;
                (Panel1.FindControl(texboxIDPanel1) as TextBox).Visible = true;
                (Panel2.FindControl(texboxIDPanel2) as TextBox).Visible = true;
                (Panel2.FindControl(texboxIDPanel3) as TextBox).Visible = true;
            
            }
            for (int j = setSayisi + 1; j <= 10; j++)
            {
                string texboxID1 = "TextBox" + j;
                string texboxID2 = "TextBoxx" + j;
                string texboxID3 = "TextBoxxx" + j;
                if ((Panel1.FindControl(texboxID1) as TextBox).Visible == true)
                {
                    (Panel1.FindControl(texboxID1) as TextBox).Visible = false;
                }
                if ((Panel2.FindControl(texboxID2) as TextBox).Visible == true)
                {
                    (Panel2.FindControl(texboxID2) as TextBox).Visible = false;
                }
                if ((Panel3.FindControl(texboxID3) as TextBox).Visible == true)
                {
                    (Panel3.FindControl(texboxID3) as TextBox).Visible = false;
                }
                
            }
            
                
            













          /*  for (int i = 0; i < setSayisi; i++)
            {
                repetitionGroup.Visible = true;
                TextBox txt = new TextBox();
                txt.ID = "TextBox" + i;
                txt.Text = i + ".Set";
                txt.CssClass = "form-control";



                repetitionGroup.Controls.Add(txt);

            }*/

        }




    }
}