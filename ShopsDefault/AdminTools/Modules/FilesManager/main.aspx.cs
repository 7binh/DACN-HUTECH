using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.Modules.FilesManager
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Files_Manager_Main_Load();
        }

        private void Files_Manager_Main_Load()
        {
            string linkFile = "~/AdminTools/UserControls/FilesManager/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ctl_main = LoadControl(linkFile);
                files_manager_ww.Controls.Add(ctl_main);
            }

        }
    }
}