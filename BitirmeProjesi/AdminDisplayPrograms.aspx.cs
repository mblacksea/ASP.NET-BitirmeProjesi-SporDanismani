using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminDisplayPrograms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {



            Session["displayProgramID"] = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            String deneme = (GridView1.SelectedRow.FindControl("Label1") as Label).Text;
            Session["displayProgramTrainer"] = (GridView1.SelectedRow.FindControl("Label13") as Label).Text;
            Session["displayProgramTittle"] = (GridView1.SelectedRow.FindControl("Label6") as Label).Text;
            Session["removeProgramBan"] = (GridView1.SelectedRow.FindControl("Label10") as Label).Text;
            Session["displayTittle"] = "AllPrograms";
            Response.Redirect("AdminDisplayProgramsDetails.aspx");


        }

        protected void searchButton(object sender, EventArgs e)
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
        }
    }
}