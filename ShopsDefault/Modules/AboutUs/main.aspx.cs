using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.Modules.AboutUs
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            About_Main_Load();
        }

        private void About_Main_Load()
        {
            string linkFile = "/UserControls/AboutUs/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control why_choose = LoadControl(linkFile);
                about_main_w.Controls.Add(why_choose);
            }
        }

    }
}