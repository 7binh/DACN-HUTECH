using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.Products
{
    public partial class cartold : System.Web.UI.UserControl
    {
        public List<ShopsCartItem> ShopsCart
        {
            get
            {
                return Session["cart_items"] as List<ShopsCartItem>;
            }
            set
            {
                Session["cart_items"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable cart = Session["cart_items"] as DataTable;
            if (!IsPostBack)
            {
                GridView1.DataSource = cart;
                GridView1.DataBind();
            }
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Sửa thông tin giỏ hàng
            string id = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            TextBox quantity = GridView1.Rows[e.NewSelectedIndex].Cells[2].FindControl("txtQuantity")
                as TextBox;
            //Duyệt qua Giỏ hàng và tăng số lượng
            DataTable cart = Session["cart_items"] as DataTable;
            foreach (DataRow dr in cart.Rows)
            {
                //Kiểm tra mã sản phẩm phù hợp để gán số lượng khách hàng mua
                if (dr["ID_Product"].ToString() == id)
                {
                    dr["Amount"] = int.Parse(quantity.Text);
                    break;
                }
            }
            //Lưu lại vào Session
            Session["cart"] = cart;
            //Hiển thị giỏ hàng với thông tin mới
            GridView1.DataSource = cart;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Xóa sản phẩm khỏi giỏ hàng
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //Duyệt qua Giỏ hàng và xóa sản phẩm phù hợp
            DataTable cart = Session["cart_items"] as DataTable;
            foreach (DataRow dr in cart.Rows)
            {
                //Kiểm tra mã sản phẩm phù hợp để tăng số lượng
                if (dr["Amount"].ToString() == id)
                {
                    dr.Delete();
                    break;
                }
            }
            //Lưu lại vào Session
            Session["cart"] = cart;
            //Hiển thị giỏ hàng với thông tin mới
            GridView1.DataSource = cart;
            GridView1.DataBind();
        }
    }
}