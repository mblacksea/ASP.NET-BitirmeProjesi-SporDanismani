using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BitirmeProjesi
{
    public class MyEmail
    {
        public static MyEmailParameters getEmailParameters()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            conn.Open();
            SqlCommand trainerData = new SqlCommand();
            trainerData.Connection = conn;
            trainerData.CommandText = "select FromEmail,PasswordEmail,PortEmail,SmtpServer from MyEmail";
            SqlDataReader dr = trainerData.ExecuteReader();
            MyEmailParameters myEmailParam=null;
            while (dr.Read())
            {
                 myEmailParam = new MyEmailParameters(dr[0].ToString(),dr[1].ToString(),Convert.ToInt32(dr[2].ToString()),dr[3].ToString());
          
            }

            conn.Close();
            return myEmailParam;
        }

        public static void sendEmailForTrainer(String toEmail,String reason,String programTittle,String fromEmail,String passwordEmail,int portEmail,String smtpServer){
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toEmail);
            mail.From = new MailAddress(fromEmail, "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Program Banned";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Your '" + programTittle + "' named program is banned cause --> " + reason;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(fromEmail, passwordEmail);
            client.Port = portEmail;
            client.Host = smtpServer;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }

        public static void sendEmailForConfirm(String randomPassword, String toEmail, String domainName, String fromEmail, String passwordEmail, int portEmail, String smtpServer)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toEmail);
            mail.From = new MailAddress(fromEmail, "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Password Refresh";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Your Temporary Password = " + randomPassword + "  " + domainName + "/Login.aspx";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(fromEmail, passwordEmail);
            client.Port = portEmail;
            client.Host = smtpServer;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }

        public static void sendEmailForConfirm(String toEmail, String fromEmail, String passwordEmail, int portEmail, String smtpServer)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toEmail);
            mail.From = new MailAddress("mustafa.blacksea93@gmail.com", "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Trainer Confirmantion";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Your membership is approved. Congratulations !!!";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("mustafa.blacksea93@gmail.com", "WalkAlone3442");
            client.Port = 587;
            client.Host = smtpServer;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }

        public static void sendEmailForTrainer2(String trainerEmail, String reason, String fromEmail, String passwordEmail, int portEmail, String smtpServer)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(trainerEmail);
            mail.From = new MailAddress(fromEmail, "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Account Banned";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Your account is banned cause --> " + reason;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(fromEmail, passwordEmail);
            client.Port = portEmail;
            client.Host = smtpServer;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }

        public static void sendEmailForUsers(String userEmail, String reason, String programTittle, String fromEmail, String passwordEmail, int portEmail, String smtpServer)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(userEmail);
            mail.From = new MailAddress(fromEmail, "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Your '" + programTittle + "' named program is banned cause --> " + reason;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "cause --> " + reason;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(fromEmail, passwordEmail);
            client.Port = portEmail;
            client.Host = smtpServer;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }

        public static void sendEmailForDecline(String text, String trainerEmail, String fromEmail, String passwordEmail, int portEmail, String smtpServer)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(trainerEmail);
            mail.From = new MailAddress(fromEmail, "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Trainer Confirmantion";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Your request was rejected for this reason << " + text + " >> ";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(fromEmail, passwordEmail);
            client.Port = portEmail;
            client.Host = smtpServer;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //  Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }


    }
}