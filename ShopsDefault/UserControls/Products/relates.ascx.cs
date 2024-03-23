using Librari;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.Products
{
    public partial class relates : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            int id = Convert.ToInt32(Request["idProduct"].ToString());
            int idCata = Convert.ToInt32(Cls_ShopsProducts.getOject_Key(Convert.ToInt16(Request["idProduct"])).ID_Catalog);
            string sql = "SELECT TOP(6) *, tbShopsCatalogs.LinkSEO as linkSEOCatalog FROM tbShopsProducts, tbShopsCatalogs WHERE tbShopsCatalogs.ID_Catalog = tbShopsProducts.ID_Catalog and tbShopsProducts.Hidden = 1 and ID_Product <> " + id + " and tbShopsProducts.ID_Catalog = " + idCata;
            e.InputParameters["sSQL"] = sql;
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            Label lblID = (Label)item.FindControl("lblID_Product");
            int idPrd = Convert.ToInt32(lblID.Text);
            int quantity = 1;
            if (Session["cart_items"] != null)
            {
                DataTable dt = (DataTable)Session["cart_items"];
                DataTable dtProduct = Cls_ShopsProducts.getDataTable_Join_ShopsCatalogs(idPrd);
                DataRow[] checkPrd = dt.Select("ID_Product = " + idPrd);
                if (checkPrd.Length > 0)
                {
                    DataRow dr = checkPrd[0];
                    dr["Quantity"] = Convert.ToInt32(dr["Quantity"]) + quantity;
                    dr["Total"] = Convert.ToInt32(dr["Quantity"]) * Convert.ToDouble(dtProduct.Rows[0]["PriceOut"]);
                    dt.AcceptChanges();
                    Session["cart_items"] = dt;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["ID_Product"] = idPrd;
                    dr["ProductName"] = Convert.ToString(dtProduct.Rows[0]["ProductName"]);
                    dr["Amount"] = Convert.ToString(dtProduct.Rows[0]["Amount"]);
                    dr["Quantity"] = quantity;
                    dr["PriceOut"] = Convert.ToString(dtProduct.Rows[0]["PriceOut"]);
                    dr["Total"] = Convert.ToInt32(dr["Quantity"]) * Convert.ToDouble(dtProduct.Rows[0]["PriceOut"]);
                    dr["LinkSEO"] = Convert.ToString(dtProduct.Rows[0]["LinkSEO"]);
                    dr["CatalogName"] = Convert.ToString(dtProduct.Rows[0]["CatalogName"]);
                    dr["linkSEOCatalog"] = Convert.ToString(dtProduct.Rows[0]["linkSEOCatalog"]);
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                    Session["cart_items"] = dt;
                }
            }
            else
            {
                DataTable dtProduct = Cls_ShopsProducts.getDataTable_Join_ShopsCatalogs(idPrd);

                DataTable dt = new DataTable();
                dt.Columns.Add("ID_Product", typeof(int));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("Amount", typeof(int));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("PriceOut", typeof(double));
                dt.Columns.Add("Total", typeof(double));
                dt.Columns.Add("LinkSEO", typeof(string));
                dt.Columns.Add("CatalogName", typeof(string));
                dt.Columns.Add("linkSEOCatalog", typeof(string));


                DataRow dr = dt.NewRow();
                dr["ID_Product"] = idPrd;
                dr["ProductName"] = Convert.ToString(dtProduct.Rows[0]["ProductName"]);
                dr["Amount"] = Convert.ToString(dtProduct.Rows[0]["Amount"]);
                dr["Quantity"] = quantity;
                dr["PriceOut"] = Convert.ToString(dtProduct.Rows[0]["PriceOut"]);
                dr["Total"] = Convert.ToInt32(dr["Quantity"]) * Convert.ToDouble(dtProduct.Rows[0]["PriceOut"]);
                dr["LinkSEO"] = Convert.ToString(dtProduct.Rows[0]["LinkSEO"]);
                dr["CatalogName"] = Convert.ToString(dtProduct.Rows[0]["CatalogName"]);
                dr["linkSEOCatalog"] = Convert.ToString(dtProduct.Rows[0]["linkSEOCatalog"]);
                dt.Rows.Add(dr);
                dt.AcceptChanges();


                Session["cart_items"] = dt;
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}