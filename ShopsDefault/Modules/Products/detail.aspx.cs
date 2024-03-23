using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.Modules.Products
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Products_Detail_Load();
            Products_Relates_Load();
        }

        private void Products_Detail_Load()
        {
            string linkFile = "/UserControls/Products/detail.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control main = LoadControl(linkFile);
                product_detail_w.Controls.Add(main);
            }

        }

        private void Products_Relates_Load()
        {
            string linkFile = "/UserControls/Products/relates.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control main = LoadControl(linkFile);
                product_relates_w.Controls.Add(main);
            }

        }
    }
}