using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.Modules.Products.Products
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Product_Payments_Load();
        }

        private void Product_Payments_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Products/Products/payment.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ctl_main = LoadControl(linkFile);
                payments_ww.Controls.Add(ctl_main);
            }

        }
    }
}