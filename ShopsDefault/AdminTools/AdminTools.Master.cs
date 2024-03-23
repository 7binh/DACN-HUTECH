using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools
{
    public partial class AdminTools : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Header_Load();
            Left_Load();
            Fotter_Load();
        }

        private void Header_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Header/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control hd_main = LoadControl(linkFile);
                Header.Controls.Add(hd_main);
            }

        }

        private void Left_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Left/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control left_main = LoadControl(linkFile);
                Left.Controls.Add(left_main);
            }

        }

        private void Fotter_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Footer/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ft_main = LoadControl(linkFile);
                Footer.Controls.Add(ft_main);
            }

        }
    }
}