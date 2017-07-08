using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class AdminDisplayProgramsDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

    

        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!Page.IsPostBack)
            {

                if (Session["removeProgramBan"].ToString() == "Y")
                {
                    removeProgramBan.Visible = true;
                }
                else
                {
                    removeProgramBan.Visible = false;
                }

              detailProgramDesc.InnerText = Session["displayTittle"].ToString() + " -> " + Session["displayProgramTrainer"].ToString() + " -> " + Session["displayProgramTittle"].ToString();
              conn.Open();
              string checkUser = "select count(*), (isnull(sum(p.ProgramPrice),0)) from UserProgram up,Program p where p.Program_ID=up.Program_ID and up.Program_ID='" + Convert.ToInt32(Session["displayProgramID"].ToString()) + "'";
              SqlCommand com = new SqlCommand(checkUser, conn);
              SqlDataReader dr = com.ExecuteReader();
              while (dr.Read())
              {

                  Label1.Text = dr[0].ToString();
                  Label2.Text = dr[1].ToString();


              }
              conn.Close();
               
              if (Convert.ToInt32(Label1.Text) == 0)
              {
                 
                  chartRow.Visible = false;
                  H1.Visible = false;
              }
     
            }


        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {


            Session["userDisplayID"] = (GridView1.SelectedRow.FindControl("Label2") as Label).Text;
            Session["userDisplayUsername"] = (GridView1.SelectedRow.FindControl("Label200") as Label).Text;
            Response.Redirect("AdminDisplayUsersDetails.aspx");


        }

        protected void RemoveProgramBan_ServerClick(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand trainerDataUpdate = new SqlCommand();
            trainerDataUpdate.Connection = conn;
            trainerDataUpdate.CommandText = "UPDATE Program SET Status_ID=1,isBanned='N',BannedReason=NULL WHERE Program_ID='" + Convert.ToInt32(Session["displayProgramID"].ToString()) + "'";
            trainerDataUpdate.ExecuteNonQuery();
            conn.Close();
            Session["removeProgramBan"] = "N";
            removeProgramBan.Visible = false;
            MessageBox.Show("Successful!", MessageBox.MesajTipleri.Success, false, 3000);

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