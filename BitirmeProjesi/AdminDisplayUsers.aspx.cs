using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminDisplayUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton(object sender, EventArgs e)
        {
            string FilterExpression = string.Concat(DropDownList1.SelectedValue, " LIKE '%{0}%'");
            SqlDataSource1.FilterParameters.Clear();
            SqlDataSource1.FilterParameters.Add(new ControlParameter(DropDownList1.SelectedValue, "textField", "Text"));
            SqlDataSource1.FilterExpression = FilterExpression;
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {


            Session["userDisplayID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["userDisplayUsername"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;
            Response.Redirect("AdminDisplayUsersDetails.aspx");


        }
    }
}