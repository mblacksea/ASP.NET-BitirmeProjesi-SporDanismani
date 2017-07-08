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
    public partial class TrainerGraphicsProgramDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
         
                conn.Open();
                string checkTotalSales = "select count(*) as totalSales from UserProgram up where up.Program_ID='" +Convert.ToInt32(Session["ProgramIDGraphics"] .ToString())+ "'";
                SqlCommand com = new SqlCommand(checkTotalSales, conn);
                int tempTotalSales = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                conn.Open();
                string checkUserTotalIncome = "select isnull(sum(p.ProgramPrice),0) as totalIncome from Program p,UserProgram up where up.Program_ID='" + Convert.ToInt32(Session["ProgramIDGraphics"].ToString()) + "' and up.Program_ID=p.Program_ID";
                com = new SqlCommand(checkUserTotalIncome, conn);
                int tempTotalIncome = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();

                Label1.Text = tempTotalSales.ToString();
                Label2.Text = tempTotalIncome.ToString() + "$";
                Label100.Text = Label100.Text + Session["ProgramTittleGraphics"].ToString();

            }
        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {


            Session["userDisplayGraphicsID"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;
            Session["userDisplayGraphicsUsername"] = (GridView1.SelectedRow.FindControl("Label200") as Label).Text;
            Response.Redirect("TrainerDisplayUsersGraphics.aspx");


        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (DateStart.Text != "" && DateEnd.Text != "")
            {
                string FilterExpression = string.Concat("BuyDate2>='{0}' AND BuyDate2<='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

                string FilterExpression2 = string.Concat("BuyDate2>='{0}' AND BuyDate2<='{1}' ");
                SqlDataSource2.FilterParameters.Clear();
                SqlDataSource2.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource2.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource2.FilterExpression = FilterExpression2;

            }
            if (DateStart.Text != "" && DateEnd.Text == "")
            {
                string FilterExpression = string.Concat("BuyDate2>='{0}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

                string FilterExpression2 = string.Concat("BuyDate2>='{0}' ");
                SqlDataSource2.FilterParameters.Clear();

                SqlDataSource2.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource2.FilterExpression = FilterExpression2;

            }
            if (DateStart.Text == "" && DateEnd.Text != "")
            {
                string FilterExpression = string.Concat(" BuyDate2<='{0}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

                string FilterExpression2 = string.Concat(" BuyDate2<='{0}' ");
                SqlDataSource2.FilterParameters.Clear();
                SqlDataSource2.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource2.FilterExpression = FilterExpression2;

            }
        }
    }
}