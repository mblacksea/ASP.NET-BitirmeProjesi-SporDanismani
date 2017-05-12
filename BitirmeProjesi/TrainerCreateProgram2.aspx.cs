using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerCreateProgram2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["programID"] != null)
            {
                nextStepButtonID.Visible = true;
            }
            else
            {
                nextStepButtonID.Visible = false;
            }
        }

        protected void Next_Step(object sender, EventArgs e)
        {
            //Bu butona basildiginda circle kismina gecilecek.
            Response.Redirect("TrainerCircleExercise.aspx");
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            //Label1.Text = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            // Session["trainerDetailsID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            //  Session["trainerDetailsEmail"] = (GridView1.SelectedRow.FindControl("Label4") as Label).Text;
            Session["createExerciseID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["ExerciseType"] = (GridView1.SelectedRow.FindControl("Label5") as Label).Text;
            Response.Redirect("TrainerCreateProgram3.aspx");


        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["order"] = Convert.ToInt32(Session["order"].ToString()) - 1;
        }
    }
}