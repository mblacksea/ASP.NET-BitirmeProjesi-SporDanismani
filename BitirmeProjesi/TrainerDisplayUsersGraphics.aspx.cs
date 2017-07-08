using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class TrainerDisplayUsersGraphics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label100.Text = Label100.Text + Session["userDisplayGraphicsUsername"].ToString();
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
         
            if (DateStart.Text != "" && DateEnd.Text != "" )
            {
                string FilterExpression = string.Concat("UserBodyRateDate>='{0}' AND UserBodyRateDate<='{1}' ");
                SqlDataSource1.FilterParameters.Clear();
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateStart.Text, "DateStart", "Text"));
                SqlDataSource1.FilterParameters.Add(new ControlParameter(DateEnd.Text, "DateEnd", "Text"));
                SqlDataSource1.FilterExpression = FilterExpression;

            }
           
        }
    }
}