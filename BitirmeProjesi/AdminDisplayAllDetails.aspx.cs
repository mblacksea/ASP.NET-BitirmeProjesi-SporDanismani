using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminDisplayAllDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label100.Text = Label100.Text + Session["trainerDisplayNameSurname"].ToString();
            }
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