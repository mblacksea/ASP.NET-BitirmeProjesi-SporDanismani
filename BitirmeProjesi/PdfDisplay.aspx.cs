using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class PdfDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite((byte[])Session["PdfFile"]);
        Response.End();
        }
    }
}