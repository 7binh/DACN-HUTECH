using Librari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.News
{
    public partial class relates : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            int id = Convert.ToInt32(Request["idNews"].ToString());
            int idCata = Convert.ToInt32(Cls_News.getOject_Key(Convert.ToInt16(Request["idNews"])).ID_Catalog);
            string sql = "SELECT TOP(6) *, tbNewsCatalogs.LinkSEO as linkSEOCatalog FROM tbNews, tbNewsCatalogs WHERE tbNewsCatalogs.ID_Catalog = tbNews.ID_Catalog and tbNews.Hidden = 1 and ID_News <> " + id + " and tbNews.ID_Catalog = " + idCata;
            e.InputParameters["sSQL"] = sql;
        }
    }
}