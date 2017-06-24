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
    public partial class AdminEmailSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               MyEmailParameters myEmailParam =  MyEmail.getEmailParameters();
               textEmail.Text = myEmailParam.FromEmail;
               textPassword.Attributes.Add("value", myEmailParam.PasswordEmail);
              // textPassword.Text = myEmailParam.PasswordEmail;
               textPort.Text = myEmailParam.PortEmail.ToString();
               DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(myEmailParam.SmtpServer));
            }
        }

        protected void ServerClick_Update(object sender, EventArgs e)
        {
            if (textEmail.Text.Contains("@gmail.com"))
            {
                if (DropDownList1.SelectedValue.Contains("smtp.gmail.com"))
                {
                    //no problem
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                    conn.Open();
                    SqlCommand trainerDataUpdate = new SqlCommand();
                    trainerDataUpdate.Connection = conn;
                    trainerDataUpdate.CommandText = "UPDATE MyEmail SET FromEmail='" + textEmail.Text + "', PasswordEmail='" + textPassword.Text + "',PortEmail='" + Convert.ToInt32(textPort.Text) + "',SmtpServer='" + DropDownList1.SelectedValue + "'";
                    trainerDataUpdate.ExecuteNonQuery();
                    conn.Close();
                    textEmail.Text = textEmail.Text;
                    textPassword.Attributes.Add("value", textPassword.Text);
                    textPort.Text = textPort.Text;
                    MessageBox.Show("Successful !!!", MessageBox.MesajTipleri.Success, false, 3000);
                }
                else
                {
                    MessageBox.Show("Invalid Smtp Server Name! Please select 'smtp.gmail.com'", MessageBox.MesajTipleri.Error, false, 3000);
                }
            }
            else if (textEmail.Text.Contains("@hotmail.com"))
            {
                if (DropDownList1.SelectedValue.Contains("smtp.live.com"))
                {
                    //no problem
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                    conn.Open();
                    SqlCommand trainerDataUpdate = new SqlCommand();
                    trainerDataUpdate.Connection = conn;
                    trainerDataUpdate.CommandText = "UPDATE MyEmail SET FromEmail='" + textEmail.Text + "', PasswordEmail='" + textPassword.Text + "',PortEmail='" + Convert.ToInt32(textPort.Text) + "',SmtpServer='" + DropDownList1.SelectedValue + "'";
                    trainerDataUpdate.ExecuteNonQuery();
                    conn.Close();
                    textEmail.Text = textEmail.Text;
                    textPassword.Attributes.Add("value", textPassword.Text);
                    textPort.Text = textPort.Text;
                    MessageBox.Show("Successful !!!", MessageBox.MesajTipleri.Success, false, 3000);
                }
                else
                {
                    MessageBox.Show("Invalid Smtp Server Name! Please select 'smtp.live.com' ", MessageBox.MesajTipleri.Error, false, 3000);
                }
            }




        }
    }
}