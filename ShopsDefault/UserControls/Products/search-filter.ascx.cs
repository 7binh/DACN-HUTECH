using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.Products
{
    public partial class search_filter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ds.ConnectionString = Librari.AccessDB.sConn;
            ds.SelectCommand = "select * from tbShopsCatalogs where ID_Catalog <> 1 and Hidden = 1";
            ds.SelectCommandType = SqlDataSourceCommandType.Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var date = DateTime.ParseExact(txtDatePick.Text, "MM/dd/yyyy", null);
            Session["searchID_Catalog"] = Convert.ToInt32(txtID_Catalog.SelectedValue.ToString());
            Session["searchDatePick"] = date.ToString("MM/dd/yyyy");
            Response.Redirect("/ket-qua-tim-kiem.html");
        }
    }
}