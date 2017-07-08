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
    public partial class TrainerGraphics : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        int tempTotalSales;
        int tempTotalIncome;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                conn.Open();
                string checkTotalSales = "select isnull(count(*),0) as totalSales from Program p,UserProgram up where p.Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "' and up.Program_ID=p.Program_ID";
                SqlCommand com = new SqlCommand(checkTotalSales, conn);
                tempTotalSales = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                conn.Open();
                string checkUserTotalIncome = "select isnull(sum(p.ProgramPrice),0) as totalIncome from Program p,UserProgram up where p.Trainer_ID='" + Convert.ToInt32(Session["trainerID"].ToString()) + "' and up.Program_ID=p.Program_ID";
                com = new SqlCommand(checkUserTotalIncome, conn);
                tempTotalIncome = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                Session["tempTotalSales"] = tempTotalSales.ToString();
                Session["tempTotalIncome"] = tempTotalIncome.ToString();
                LabelShowDetails.Text = tempTotalSales + " / " + tempTotalIncome + "$";
            }



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            Session["ProgramIDGraphics"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["ProgramTittleGraphics"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;

            Response.Redirect("TrainerGraphicsProgramDetails.aspx");
       
           
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (DateStart.Text == "" && DateEnd.Text == "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text != "" && DateEnd.Text != "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'   AND CreationDate>='{1}' AND CreationDate<='{2}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text != "" && DateEnd.Text != "" && textField2.Text == "")
            {
                string FilterExpression = string.Concat("CreationDate>='{0}' AND CreationDate<='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text != "" && DateEnd.Text == "" && textField2.Text == "")
            {
                string FilterExpression = string.Concat("CreationDate>='{0}'  ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
            else if (DateStart.Text == "" && DateEnd.Text != "" && textField2.Text == "")
            {
                string FilterExpression = string.Concat("CreationDate<='{0}'  ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;
            }
            else if (DateStart.Text != "" && DateEnd.Text == "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'   AND CreationDate>='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));

                SqlDataSource1.FilterExpression = FilterExpression;
            }
            else if (DateStart.Text == "" && DateEnd.Text != "" && textField2.Text != "")
            {
                string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'   AND CreationDate<='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField2", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));

                SqlDataSource1.FilterExpression = FilterExpression;
            }


            else if (DateStart.Text == "" && DateEnd.Text == "" && textField2.Text == "")
            {
                SqlDataSource1.FilterParameters.Clear();
            }

            GridView1.DataBind();
        }
    }
}