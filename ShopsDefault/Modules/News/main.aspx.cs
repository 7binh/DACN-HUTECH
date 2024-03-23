using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.Modules.News
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            News_Main_Load();
        }

        private void News_Main_Load()
        {
            string linkFile = "/UserControls/News/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control main = LoadControl(linkFile);
                news_main_w.Controls.Add(main);
            }

        }
    }
}