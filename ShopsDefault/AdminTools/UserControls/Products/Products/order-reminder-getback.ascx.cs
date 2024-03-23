using Librari;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.UserControls.Products.Products
{
    public partial class order_reminder_getback : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = Cls_ShopsOrdersDetail.getDataTableJoinShopsPayments("tbShopsOrdersDetail.ID_Payment = tbShopsPayments.ID_Payment and DayIn = CONVERT(VARCHAR, DATEADD(DAY, 1, GETDATE()), 101) and tbShopsOrdersDetail.Hidden = 1");
            if (dt.Rows.Count == 0)
            {
                lblGridviewEmpty.Visible = true;
                lblGridviewEmpty.Text = "Không có đơn hàng trả vào ngày mai!";
            }
            else
            {
                lblGridviewEmpty.Visible = false;
                lblGridviewEmpty.Text = "";
                grv.DataSource = dt;
                grv.DataBind();
            }
        }

        private void BindDataDetail(int ID_find)
        {
            grvDetail.DataSource = Cls_ShopsOrdersDetail.getDataTable_SQL_pro("select tbShopsProducts.ID_Product, tbShopsOrdersDetail.ID_OrderProduct, ProductName, ProductCode, PriceOut, Weight, Color, tbShopsOrders.Amount, PriceTotal " +
                                                                               "from tbShopsOrdersDetail, tbShopsProducts, tbShopsOrders " +
                                                                               "where " +
                                                                                   "tbShopsProducts.ID_Product = tbShopsOrders.ID_Product and " +
                                                                                   "tbShopsOrdersDetail.ID_OrderProduct = tbShopsOrders.ID_OrderProduct and " +
                                                                                   "tbShopsOrdersDetail.ID_OrderProduct = " + ID_find);
            grvDetail.DataBind();
        }

        protected void grv_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string getName = e.Row.Cells[1].Text;
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkUpdate");
                lnk.Attributes.Add("onclick", "return confirm('Bạn có muốn hủy đơn hàng " + getName + " không?')");
            }
        }

        protected void grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            var ID_find = Convert.ToInt32(row.Cells[0].Text);
            Cls_ShopsOrdersDetail cls = Cls_ShopsOrdersDetail.getOject_Key(ID_find);

            string status = cls.Status.ToString();
            if (status == "Chưa tới ngày thuê sản phẩm")
            {
                btnUpdateStatus.Visible = true;
                btnUpdateStatus.Text = "Giao sản phẩm";
            }
            else if (status == "Đã giao sản phẩm")
            {
                btnUpdateStatus.Visible = true;
                btnUpdateStatus.Text = "Trả sản phẩm";
            }
            else if (status == "Đã trả sản phẩm")
            {
                btnUpdateStatus.Visible = false;
            }

            txtID_OrderProduct.Text = ID_find.ToString();
            int ID_Payment = Convert.ToInt32(cls.ID_Payment.ToString());
            Cls_ShopsPayments clsPayment = Cls_ShopsPayments.getOject_Key(ID_Payment);
            txtPayment.Text = clsPayment.PaymentName.ToString();
            txtOrderName.Text = cls.OrdersName.ToString();
            txtStatus.Text = cls.Status.ToString();
            txtEmail.Text = cls.UserEmail.ToString();
            txtAddress.Text = cls.UserAddress.ToString();
            txtPhone.Text = cls.UserPhone.ToString();
            txtDetail.Text = cls.Description.ToString();
            txtDayOut.Text = cls.DayOut.ToString("dd/MM/yyyy");
            txtDayIn.Text = cls.DayIn.ToString("dd/MM/yyyy");
            Console.WriteLine(cls.Hidden.ToString());
            BindDataDetail(ID_find);
            popup.Show();
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            string status = Convert.ToString(txtStatus.Text);
            Cls_ShopsOrdersDetail cls = new Cls_ShopsOrdersDetail();
            cls.ID_OrderProduct_find = Convert.ToInt32(txtID_OrderProduct.Text.Trim());
            SqlConnection conn = new AccessDB().get_Conn();
            conn.Open();
            SqlCommand sqlComm;
            if (status == "Chưa tới ngày thuê sản phẩm")
            {
                cls.Status = "Đã giao sản phẩm";
                try
                {
                    for (int i = 0; i < grvDetail.Rows.Count; i++)
                    {
                        GridViewRow row = grvDetail.Rows[i];
                        Cls_ShopsProducts clsPrd = Cls_ShopsProducts.getOject_Key(Convert.ToInt32(grvDetail.Rows[i].Cells[0].Text));
                        sqlComm = new SqlCommand("st_tbShopsProducts_UpdateQuantity", conn);
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.Parameters.Add("@ID_Product_find", SqlDbType.Int).Value = grvDetail.Rows[i].Cells[0].Text;
                        sqlComm.Parameters.Add("@Amount", SqlDbType.Int).Value = Convert.ToInt32(clsPrd.Amount) - Convert.ToInt32(grvDetail.Rows[i].Cells[3].Text);
                        sqlComm.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    //if (sqlComm != null) sqlComm.Dispose();
                    if (conn != null) conn.Close();
                }

                if (cls.doUpdateStatus() == 1)
                {
                    string sMessages = "alert('Cập nhật dữ liệu thành công');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
                else
                {
                    string sMessages = "alert('Đã xảy ra lỗi trong quá trình cập nhật dữ liệu');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
            }
            else if (status == "Đã giao sản phẩm")
            {
                cls.Status = "Đã trả sản phẩm";
                try
                {
                    for (int i = 0; i < grvDetail.Rows.Count; i++)
                    {
                        GridViewRow row = grvDetail.Rows[i];
                        Cls_ShopsProducts clsPrd = Cls_ShopsProducts.getOject_Key(Convert.ToInt32(grvDetail.Rows[i].Cells[0].Text));
                        sqlComm = new SqlCommand("st_tbShopsProducts_UpdateQuantity", conn);
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.Parameters.Add("@ID_Product_find", SqlDbType.Int).Value = grvDetail.Rows[i].Cells[0].Text;
                        sqlComm.Parameters.Add("@Amount", SqlDbType.Int).Value = Convert.ToInt32(clsPrd.Amount) + Convert.ToInt32(grvDetail.Rows[i].Cells[3].Text);
                        sqlComm.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    //if (sqlComm != null) sqlComm.Dispose();
                    if (conn != null) conn.Close();
                }

                if (cls.doUpdateStatus() == 1)
                {
                    string sMessages = "alert('Cập nhật dữ liệu thành công');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
                else
                {
                    string sMessages = "alert('Đã xảy ra lỗi trong quá trình cập nhật dữ liệu');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
            }

            BindData();
        }

        protected void grv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ID_find = Convert.ToInt32(grv.DataKeys[e.RowIndex].Values[0]);
            Cls_ShopsOrdersDetail cls = new Cls_ShopsOrdersDetail();
            cls.ID_OrderProduct_find = ID_find;
            cls.Hidden = false;
            if (cls.doUpdateHidden() == 1)
            {
                string sMessages = "alert('Đã hủy đơn hàng thành công');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
            }
            else
            {
                string sMessages = "alert('Đã xảy ra lỗi trong quá trình hủy đơn hàng dữ liệu');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
            }
            BindData();
        }
    }
}