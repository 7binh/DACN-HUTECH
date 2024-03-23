using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.Modules.Products
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Cart_Main_Load();
        }

        private void Cart_Main_Load()
        {
            string linkFile = "/UserControls/Products/checkout.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control main = LoadControl(linkFile);
                checkout_main_w.Controls.Add(main);
            }
        }
    }
}