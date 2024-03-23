using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.News
{
    public partial class main : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            string sql = "SELECT *, tbNews.LinkSEO as linkSEO, tbNewsCatalogs.LinkSEO as linkSEOCatalog FROM tbNews, tbNewsCatalogs where tbNewsCatalogs.ID_Catalog = tbNews.ID_Catalog and tbNews.Hidden = 1 order by tbNews.AddTime";
            e.InputParameters["sSQL"] = sql;
        }
    }
}