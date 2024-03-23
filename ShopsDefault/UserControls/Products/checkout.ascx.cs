using Librari;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.Products
{
    public partial class checkout : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = Session["cart_items"] as DataTable;

            if (dt == null || dt.Compute("Sum(Total)", "") == null || dt.Compute("Sum(Total)", "").ToString() == "")
            {
                Response.Redirect("/gio-hang.html");
            }
        }

        protected void ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            string sql = "SELECT * FROM tbShopsPayments where Hidden = 1";
            e.InputParameters["sSQL"] = sql;
        }

        protected void dsCart_OnLoad(object sender, EventArgs e)
        {
            DataTable cart = Session["cart_items"] as DataTable;
            Repeater3.DataSource = cart;
            Repeater3.DataBind();
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

        public static string GenCodeOrder()
        {
            try
            {
                object ob = Cls_ShopsOrdersDetail.getMaxIdAuto();
                if (ob == DBNull.Value)
                    return "0000001";
                else
                    return (Convert.ToInt32(ob)).ToString("0000000");
            }
            catch (Exception ex) { throw ex; }
        }

        private void SendMailInfor(string MailTo)
        {
            string Code = GenCodeOrder();
            DataTable cart = Session["cart_items"] as DataTable;
            double Total = Convert.ToDouble(getTotal());
            string domain = Request.Url.GetLeftPart(UriPartial.Authority);
            string paymentMethod = "Thanh toán tại cửa hàng";
            string str = "<div style='font-size: 14px;'>" +
                "<div>" +
                    "<div>" +
                        "<div>" +
                            "<a href='" + domain + "/thue-san-pham.html' target='_blank'>" +
                            "</a>" +
                        "</div>" +
                        "<div>" +
                            "<p><b>LBT Tek là nơi cung cấp cho quý khách những sản phẩm chất lượng, phù hợp đạt tiêu chuẩn lượng tốt với mức giá sẽ giúp quý khách sử dụng thoải mái bên sản phẩm công nghệ của chúng tôi, tiết kiệm được chi phí mà vẫn đảm bảo an toàn.</b></p>" +
                        "</div>" +
                    "</div>" +
                    "<div>" +
                        "<div>" +
                            "<p>Kính chào <b>" + txtFullName.Text + "</b></p>" +
                            "<p>Thông tin đơn hàng thuê sản phẩm công nghệ tại LBT Tek</b> .</p>" +
                            "<ul>" +
                                "<li>" +
                                    "<strong>Mã đơn hàng :</strong>" +
                                    "<span> " + Code + "</span>" +
                                "</li>" +
                                "<li>" +
                                    "<strong>Trạng thái đơn hàng :</strong>" +
                                    "<span> Đặt hàng thành công </span>" +
                                "</li>" +
                                "<li>" +
                                    "<strong>Thời gian giao dịch :</strong>" +
                                    "<span> " + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "</span>" +
                                "</li>" +
                                "<li>" +
                                    "<strong>Hình thức thanh toán :</strong>" +
                                    "<span> " + paymentMethod + "</span>" +
                                "</li>" +
                            "</ul>" +
                            "<table>" +
                                "<tr style='font-weight: 600;'>" +
                                    "<td style='width: 200px'>Sản phẩm</td>" +
                                    "<td style='width: 100px; text-align: center'>Số lượng</td>" +
                                    "<td style='width: 100px; text-align: center'>Đơn giá</td>" +
                                    "<td style='width: 100px; text-align: center'>Thành tiền</td>" +
                                "</tr>";
                                foreach (DataRow drCart in cart.Rows)
                                {
                                    str += "<tr class='prd_row'>" +
                                               "<td>" +
                                                   "<a href='#' target='_blank'>" + drCart["ProductName"].ToString() + "</a></td>" +
                                               "<td style='text-align: center'><b>" + drCart["Quantity"].ToString() + "</b></td>" +
                                               "<td style='text-align: center'>" + Convert.ToDouble(drCart["PriceOut"]).ToString("#,0") + " đ</td>" +
                                               "<td style='text-align: center'><b>" + (Convert.ToDouble(drCart["PriceOut"]) * Convert.ToInt32(drCart["Quantity"].ToString())).ToString("#,0") + " ₫</b></td>" +
                                           "</tr>";
                                }
                                str += "<tr>" +
                                   "<td colspan='3' style='padding-top: 5px;padding-bottom: 5px;'>Tổng giá trị đơn hàng <br /><b>(chưa bao gồm phí ship hàng)</b>" +
                                   "</td>" +
                                   "<td style='padding-top: 5px;padding-bottom: 5px;text-align: center;font-size: 18px;'>" +
                                       "<b style='color: #f53030'>" + Total.ToString("#,0") + " ₫</b>" +
                                   "</td>" +
                               "</tr>" +
                           "</table>" +
                       "</div>" +
                    "</div>" +
                    "<div style='line-height: 24px;' class='_footer_ckout fr_col12'>" +
                       "<b>Cảm ơn quý khách đã thuê sản phẩm công nghệ tại " +
                       "<a href='" + domain + "/Thue-San-Pham.html' target='_blank'>LBT Tek</a>!</b>" +
                    "</div>" +

                    "<div style='line-height: 24px;'>" +
                       "Mọi thắc mắc xin liên hệ SĐT: (+84) 434 665 987 <b></b>" +
                    "</div>" +
                    "</div>" +
                    "</div>";


            System.Net.NetworkCredential login_cred = new System.Net.NetworkCredential("nguyenhuuminhluan@gmail.com", "crbzibxcinjmamwm");
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress("nguyenhuuminhluan@gmail.com");
            mail.To.Add(new System.Net.Mail.MailAddress(MailTo));
            mail.CC.Add(new System.Net.Mail.MailAddress("nguyenhuuminhluan@gmail.com"));
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.Subject = "Thông tin đặt hàng tại LBT Tek!";
            mail.Body = str;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = login_cred;
            client.Send(mail);


        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            DataTable dtCart = (DataTable)Session["cart_items"];
            SqlConnection conn = new AccessDB().get_Conn();
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            SqlCommand sqlComm;
            try
            {
                sqlComm = new SqlCommand("st_tbShopsOrdersDetail_Insert", conn, trans);
                sqlComm.CommandType = CommandType.StoredProcedure;

                sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = Convert.ToInt32(hdID_Payment.Value);
                sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = 2;
                sqlComm.Parameters.Add("@OrdersName", SqlDbType.NVarChar).Value = txtFullName.Text;
                sqlComm.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = "";
                sqlComm.Parameters.Add("@UserEmail", SqlDbType.NVarChar).Value = txtEmail.Text;
                sqlComm.Parameters.Add("@UserAddress", SqlDbType.NVarChar).Value = txtAddress.Text;
                sqlComm.Parameters.Add("@UserPhone", SqlDbType.NVarChar).Value = txtPhoneNumber.Text;
                sqlComm.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "Chưa tới ngày thuê sản phẩm";
                sqlComm.Parameters.Add("@DayIn", SqlDbType.DateTime).Value = DateTime.ParseExact(txtDayOff.Text, "dd/MM/yyyy", null);
                sqlComm.Parameters.Add("@DayOut", SqlDbType.DateTime).Value = DateTime.ParseExact(txtDatePick.Text, "dd/MM/yyyy", null);
                sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = txtDescription.Text;
                sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = DateTime.Now;
                sqlComm.Parameters.Add("@EditTime", SqlDbType.DateTime).Value = DateTime.Now;
                sqlComm.Parameters.Add("@Hidden", SqlDbType.Bit).Value = true;

                sqlComm.ExecuteNonQuery();


                if (Session["cart_items"] != null)
                {
                    if (dtCart.Rows.Count > 0)
                    {
                        sqlComm = new SqlCommand("select top 1 * from tbShopsOrdersDetail order by ID_OrderProduct desc", conn, trans);
                        sqlComm.CommandType = CommandType.Text;
                        SqlDataReader dr = sqlComm.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        foreach (DataRow drCart in dtCart.Rows)
                        {
                            sqlComm = new SqlCommand("st_tbShopsOrders_Insert", conn, trans);
                            sqlComm.CommandType = CommandType.StoredProcedure;
                            sqlComm.Parameters.Add("@ID_OrderProduct", SqlDbType.Int).Value = dt.Rows[0]["ID_OrderProduct"].ToString();
                            Session["OrderCode"] = dt.Rows[0]["ID_OrderProduct"].ToString();
                            sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = Convert.ToInt32(drCart["ID_Product"].ToString());
                            sqlComm.Parameters.Add("@Amount", SqlDbType.Int).Value = Convert.ToInt32(drCart["Quantity"].ToString());
                            sqlComm.Parameters.Add("@PriceTotal", SqlDbType.Float).Value = Convert.ToDouble(drCart["Total"].ToString());
                            sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = DateTime.Now;
                            sqlComm.Parameters.Add("@EditTime", SqlDbType.DateTime).Value = DateTime.Now;
                            sqlComm.Parameters.Add("@Hidden", SqlDbType.Bit).Value = true;

                            sqlComm.ExecuteNonQuery();

                        }
                    }
                }
                trans.Commit();
                SendMailInfor(txtEmail.Text);
                string sMessages = "alert('Đã đặt hàng thành công! Vui lòng kiểm tra lại đơn hàng trong Email của bạn');";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "", sMessages, true);
                Session["cart_items"] = null;
            }
            catch (SqlException ex)
            {
                trans.Rollback();

            }
            finally
            {
                conn.Close();
            }
        }
    }
}