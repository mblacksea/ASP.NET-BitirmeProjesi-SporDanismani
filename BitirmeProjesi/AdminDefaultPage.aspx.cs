﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class Deneme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminSession"] != null)
            {
                // Response.Write("Hoşgeldin" + Session["trainerEmail"].ToString());
            }
            else
            {
                Response.Redirect("Main.aspx");
            }

        }
    }
}