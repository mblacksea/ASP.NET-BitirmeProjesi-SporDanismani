using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BitirmeProjesi
{
    /// <summary>
    /// Summary description for File
    /// </summary>
    public class File : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int id = int.Parse(context.Request.QueryString["id"]);
            byte[] bytes;
            string strConnString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Video from Exercises where Exercises_ID="+id;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    bytes = (byte[])sdr["Video"];
                    con.Close();
                    context.Response.Clear();
                    context.Response.Buffer = true;
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=deneme");
                    context.Response.ContentType = "video/mp4";
                    context.Response.BinaryWrite(bytes);
                    context.Response.End();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}