using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Header_Load();
            Footer_Load();
        }

        private void Header_Load()
        {
            string linkFile = "/UserControls/Header/header-top.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control hd_top = LoadControl(linkFile);
                Header.Controls.Add(hd_top);
            }
            linkFile = "/UserControls/Header/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control hd_main = LoadControl(linkFile);
                Header.Controls.Add(hd_main);
            }
            linkFile = "/UserControls/Header/header-menu.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control hd_menu = LoadControl(linkFile);
                Header.Controls.Add(hd_menu);
            }

        }

        private void Footer_Load()
        {
            string linkFile = "/UserControls/Footer/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ft_main = LoadControl(linkFile);
                Footer.Controls.Add(ft_main);
            }
        }
    }
}