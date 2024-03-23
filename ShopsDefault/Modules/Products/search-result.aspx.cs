using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.Modules.Products
{
    public partial class search_result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Products_Search_Load();
        }

        private void Products_Search_Load()
        {
            string linkFile = "/UserControls/Products/search-result.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control main = LoadControl(linkFile);
                product_search_w.Controls.Add(main);
            }

        }
    }
}