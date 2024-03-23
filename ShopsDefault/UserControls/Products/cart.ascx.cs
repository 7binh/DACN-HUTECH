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
    public partial class cart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataTable cart = Session["cart_items"] as DataTable;
            grv.DataSource = cart;
            grv.DataBind();
        }

        protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string getName = e.Row.Cells[1].Text;
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDelete");
                lnk.Attributes.Add("onclick", "return confirm('Bạn có muốn xóa sản phẩm " + getName + " không?')");
            }
        }
        protected void grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = Session["cart_items"] as DataTable;
            int ID = Convert.ToInt32(grv.DataKeys[e.RowIndex].Values[0]);
            DataRow[] dr = dt.Select(" ID_Product = '" + ID + "'");
            if (dt.Rows.Count > 0)
            {
                dt.Rows.Remove(dr[0]);
                Session["cart_items"] = dt;
                BindData();
            }
            Response.Redirect("/gio-hang.html");
        }

        protected void grv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DataTable dt = Session["cart_items"] as DataTable;
            int ID = Convert.ToInt32(grv.DataKeys[e.RowIndex].Values[0]);
            int quantity = Convert.ToInt32(((TextBox)grv.Rows[e.RowIndex].FindControl("txtQuantity")).Text);
            DataRow[] checkPrd = dt.Select(" ID_Product = '" + ID + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = checkPrd[0];
                dr["Quantity"] = quantity;
                dr["Total"] = Convert.ToInt32(dr["Quantity"]) * Convert.ToInt32(dr["PriceOut"]);
                dt.AcceptChanges();
                Session["cart_items"] = dt;
                BindData();
            }
            Response.Redirect("/gio-hang.html");
        }

        protected string getTotal()
        {
            int count = 0;
            object total;
            DataTable dt = (DataTable)Session["cart_items"];
            if (dt != null)
            {
                total = dt.Compute("Sum(Total)", "");
                if (total == null || total.ToString() == "")
                {
                    count = 0;
                }
                else
                {
                    count = Convert.ToInt32(total.ToString());
                }

            }
            else
            {
                count = 0;
            }
            return count.ToString();
        }

        protected void UpdatePanel1_Init(object sender, EventArgs e)
        {
            DataTable dt = Session["cart_items"] as DataTable;

            if (dt == null || dt.Compute("Sum(Total)", "") == null || dt.Compute("Sum(Total)", "").ToString() == "")
            {
                UpdatePanel1.Visible = false;
                lblEmpty.Text = "Không có sản phẩm nào trong giỏ hàng!";
            } else
            {
                UpdatePanel1.Visible = true;
                lblEmpty.Text = "";
            }
        }
    }
}