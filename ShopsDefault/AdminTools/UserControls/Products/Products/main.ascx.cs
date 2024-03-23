using Librari;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.UserControls.Products.Products
{
    public partial class main : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ds.ConnectionString = Librari.AccessDB.sConn;
            ds.SelectCommand = "st_tbShopsCatalogs_SelectAll_Active";
            ds.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        }

        private void BindData()
        {
            grv.DataSource = Cls_ShopsProducts.getDataTableJoinShopsCatalogs("tbShopsProducts.ID_Catalog = tbShopsCatalogs.ID_Catalog");
            grv.DataBind();
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
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDelete");
                lnk.Attributes.Add("onclick", "return confirm('Bạn có muốn xóa sản phẩm " + getName + " không?')");
            }
        }

        protected void grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void RefreshText()
        {
            txtID_Catalog.SelectedValue = "0";
            txtProductName.Text = "";
            txtProductCode.Text = "";
            txtPriceOut.Text = "";
            txtTitleWeb.Text = "";
            txtColor.Text = "";
            txtAmount.Text = "";
            txtSummaryContent.Text = "";
            txtDetail.Text = "";
            txtImage.Text = "";
            txtLinkSEO.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Lưu";
            RefreshText();
            popup.Show();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Cập nhật";
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            var ID_find = Convert.ToInt32(row.Cells[0].Text);
            Cls_ShopsProducts cls = Cls_ShopsProducts.getOject_Key_Not_Date(ID_find);
            txtID_Product.Text = ID_find.ToString();
            txtID_Catalog.SelectedValue = cls.ID_Catalog.ToString();
            txtProductName.Text = cls.ProductName.ToString();
            txtProductCode.Text = cls.ProductCode.ToString();
            txtPriceOut.Text = cls.PriceOut.ToString();
            txtColor.Text = cls.Color.ToString();
            txtAmount.Text = cls.Amount.ToString();
            txtSummaryContent.Text = cls.SummaryContent.ToString();
            txtTitleWeb.Text = cls.TitleWeb.ToString();
            txtImage.Text = cls.Image.ToString();
            txtDetail.Text = cls.Description.ToString();
            txtLinkSEO.Text = cls.LinkSEO.ToString();
            Console.WriteLine(cls.Hidden.ToString());
            if (cls.Hidden == true)
            {
                cbHidden.Checked = true;
            }
            else
            {
                cbHidden.Checked = false;
            }

            popup.Show();
        }

        protected void grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(grv.DataKeys[e.RowIndex].Values[0]);
            Cls_ShopsProducts cls = new Cls_ShopsProducts();
            cls.ID_Product_find = ID;

            if (cls.doDelete() == 1)
            {
                string sMessages = "alert('Đã xóa thành công');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
            }
            else
            {
                string sMessages = "alert('Đã xảy ra lỗi trong quá trình xóa dữ liệu');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
            }
            BindData();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Lưu")
            {
                Cls_ShopsProducts cls = new Cls_ShopsProducts();
                cls.ID_Catalog = Convert.ToInt32(txtID_Catalog.SelectedValue.ToString());
                cls.ProductName = txtProductName.Text.Trim();
                cls.ProductCode = txtProductCode.Text.Trim();
                cls.Image = txtImage.Text.Trim();
                cls.PriceOut = Convert.ToDouble(txtPriceOut.Text.Trim());
                cls.Color = txtColor.Text.Trim();
                cls.Amount = Convert.ToInt32(txtAmount.Text.Trim());
                cls.SummaryContent = txtSummaryContent.Text.Trim();
                cls.Description = txtDetail.Text.Trim();
                cls.TitleWeb = txtTitleWeb.Text.Trim();
                cls.LinkSEO = txtLinkSEO.Text.Trim();
                cls.H1SEO = txtProductName.Text.Trim();
                cls.KeywordSEO = txtProductName.Text.Trim();
                cls.AddTime = DateTime.Now;
                cls.EditTime = DateTime.Now;

                if (cbHidden.Checked)
                {
                    cls.Hidden = true;
                }
                else
                {
                    cls.Hidden = false;
                }
                if (cls.doInsert() == 1)
                {
                    string sMessages = "alert('Đã thêm dữ liệu thành công!');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
                else
                {
                    string sMessages = "alert('Đã xảy ra lỗi trong quá trình thêm dữ liệu! Bạn vui lòng kiểm tra lại!');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
            }
            else if (btnSave.Text == "Cập nhật")
            {
                Cls_ShopsProducts cls = new Cls_ShopsProducts();
                cls.ID_Product_find = Convert.ToInt32(txtID_Product.Text.Trim());
                cls.ID_Catalog = Convert.ToInt32(txtID_Catalog.SelectedValue.ToString());
                cls.ProductName = txtProductName.Text.Trim();
                cls.ProductCode = txtProductCode.Text.Trim();
                cls.Image = txtImage.Text.Trim();
                cls.PriceOut = Convert.ToDouble(txtPriceOut.Text.Trim());
                cls.Color = txtColor.Text.Trim();
                cls.Amount = Convert.ToInt32(txtAmount.Text.Trim());
                cls.SummaryContent = txtSummaryContent.Text.Trim();
                cls.Description = txtDetail.Text.Trim();
                cls.TitleWeb = txtTitleWeb.Text.Trim();
                cls.LinkSEO = txtLinkSEO.Text.Trim();
                cls.H1SEO = txtProductName.Text.Trim();
                cls.KeywordSEO = txtProductName.Text.Trim();
                cls.EditTime = DateTime.Now;

                if (cbHidden.Checked)
                {
                    cls.Hidden = true;
                }
                else
                {
                    cls.Hidden = false;
                }
                if (cls.doUpdate() == 1)
                {
                    string sMessages = "alert('Đã chỉnh sửa dữ liệu thành công!');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
                else
                {
                    string sMessages = "alert('Đã xảy ra lỗi trong quá trình chỉnh sửa dữ liệu! Bạn vui lòng kiểm tra lại!');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
            }
            BindData();
        }
    }
}