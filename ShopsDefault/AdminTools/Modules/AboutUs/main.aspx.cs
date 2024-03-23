using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.Modules.AboutUs
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AboutUs_Main_Load();
        }

        private void AboutUs_Main_Load()
        {
            string linkFile = "~/AdminTools/UserControls/AboutUs/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ctl_main = LoadControl(linkFile);
                about_us_ww.Controls.Add(ctl_main);
            }
        }
    }
}