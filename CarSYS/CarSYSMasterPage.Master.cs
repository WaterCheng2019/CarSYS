using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarSYS
{
    public partial class CarSYSMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Text = System.Configuration.ConfigurationManager.AppSettings["CopyRight"].ToString();
        }
    }
}