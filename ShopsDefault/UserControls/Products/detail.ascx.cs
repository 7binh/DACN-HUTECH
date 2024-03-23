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
    public partial class detail : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }
        protected void ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            int id = Convert.ToInt32(Request["idProduct"].ToString());
            string sql = "SELECT * FROM tbShopsProducts, tbShopsCatalogs WHERE tbShopsCatalogs.ID_Catalog = tbShopsProducts.ID_Catalog and ID_Product = " + id;
            e.InputParameters["sSQL"] = sql;
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            int idPrd = Convert.ToInt32(Request["idProduct"].ToString());
            int quantity = Convert.ToInt32((item.FindControl("txtQuantity") as TextBox).Text);
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

        protected string getAmount(object Amount)
        {
            string txtAmount = "0";
            int idPrd = Convert.ToInt32(Request["idProduct"].ToString());
            DataTable dt = (DataTable)Session["cart_items"];
            DataTable dtProduct = Cls_ShopsProducts.getDataTable_Join_ShopsCatalogs(idPrd);
            if (Session["cart_items"] != null)
            {
                DataRow[] checkPrd = dt.Select("ID_Product = " + idPrd);
                if (checkPrd.Length > 0)
                {
                    DataRow dr = checkPrd[0];
                    txtAmount = Convert.ToString(Convert.ToInt32(dtProduct.Rows[0]["Amount"]) - Convert.ToInt32(dr["Quantity"]));
                }
                else
                {
                    txtAmount = Convert.ToString(dtProduct.Rows[0]["Amount"]);
                }
            }
            else
            {
                txtAmount = Convert.ToString(dtProduct.Rows[0]["Amount"]);
            }
            return txtAmount;
        }
    }
}