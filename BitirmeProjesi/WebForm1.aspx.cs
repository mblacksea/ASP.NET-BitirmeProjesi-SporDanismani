using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitirmeProjesi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int Sure
        {
            get
            {
                return Convert.ToInt32(txtSure.Text);
            }
        }
        bool OtoKapa
        {
            get
            {
                return cbOtoKapa.Checked;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Success, OtoKapa, Sure);
        }

        protected void btnWarning_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Warning, OtoKapa, Sure);
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Info, OtoKapa, Sure);
        }

        protected void btnError_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Error, OtoKapa, Sure);
        }
    }
}