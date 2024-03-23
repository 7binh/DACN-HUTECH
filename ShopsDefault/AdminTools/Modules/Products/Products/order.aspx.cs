using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.Modules.Products.Products
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Product_Order_Load();
        }

        private void Product_Order_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Products/Products/order.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ctl_main = LoadControl(linkFile);
                order_ww.Controls.Add(ctl_main);
            }

        }
    }
}