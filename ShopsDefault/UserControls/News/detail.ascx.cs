using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.News
{
    public partial class detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            int id = Convert.ToInt32(Request["idNews"].ToString());
            string sql = "SELECT * FROM tbNews, tbNewsCatalogs where tbNewsCatalogs.ID_Catalog = tbNews.ID_Catalog and ID_News = " + id;
            e.InputParameters["sSQL"] = sql;
        }

        protected string GetDate(object date)
        {
            string th = Convert.ToDateTime(date).ToString("R").Substring(0, 3).ToUpper();
            string thu = "";
            if (th.Substring(0, 3) == "MON")
            {
                thu = "Thứ 2";
            }
            else if (th.Substring(0, 3) == "TUE")
            {
                thu = "Thứ 3";
            }
            else if (th.Substring(0, 3) == "WED")
            {
                thu = "Thứ 4";
            }
            else if (th.Substring(0, 3) == "THU")
            {
                thu = "Thứ 5";
            }
            else if (th.Substring(0, 3) == "FRI")
            {
                thu = "Thứ 6";
            }
            else if (th.Substring(0, 3) == "SAT")
            {
                thu = "Thứ 7";
            }
            else if (th.Substring(0, 3) == "SUN")
            {
                thu = "Chủ nhật";
            }
            return thu + ", " + Convert.ToDateTime(date).ToString("dd/MM/yyyy") + ", " + Convert.ToDateTime(date).ToString("HH:mm tt");
        }
    }
}