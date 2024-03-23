using Librari;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.UserControls.Products.Catalogs
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

        private void BindData()
        {
            grv.DataSource = Cls_ShopsCatalogs.getDataTable_Where("ID_Catalog <> 1");
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
                lnk.Attributes.Add("onclick", "return confirm('Bạn có muốn xóa nhóm sản phẩm " + getName + " không?')");
            }
        }

        protected void grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void RefreshText()
        {
            txtCatalogName.Text = "";
            txtTitleWeb.Text = "";
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
            Cls_ShopsCatalogs cls = Cls_ShopsCatalogs.getOject_Key_Not_Date(ID_find);
            txtID_Catalog.Text = ID_find.ToString();
            txtCatalogName.Text = cls.CatalogName.ToString();
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //List<Object> selectItems = grv.GetSelectedFieldValues("ID_Catalog");
            //List<Object> selectItems = grv.Se
        }

        protected void grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID_Catalog = Convert.ToInt32(grv.DataKeys[e.RowIndex].Values[0]);
            Cls_ShopsCatalogs cls = new Cls_ShopsCatalogs();
            cls.ID_Catalog_find = ID_Catalog;

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
                Cls_ShopsCatalogs cls = new Cls_ShopsCatalogs();
                cls.ID_Parent = 1;
                cls.CatalogName = txtCatalogName.Text.Trim();
                cls.Image = txtImage.Text.Trim();
                if (fuImage.HasFile)
                {
                    string fileName = Path.Combine(txtImage.Text.Trim(), fuImage.FileName);
                    fuImage.SaveAs(fileName);
                }
                cls.Description = txtDetail.Text.Trim();
                cls.TitleWeb = txtTitleWeb.Text.Trim();
                cls.LinkSEO = txtLinkSEO.Text.Trim();
                cls.H1SEO = txtCatalogName.Text.Trim();
                cls.KeywordSEO = txtCatalogName.Text.Trim();
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
                    string sMessages = "alert('Đã xảy ra lỗi trong quá trình lưu dữ liệu! Bạn vui lòng kiểm tra lại!');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", sMessages, true);
                }
            }
            else if (btnSave.Text == "Cập nhật")
            {
                Cls_ShopsCatalogs cls = new Cls_ShopsCatalogs();
                cls.ID_Catalog_find = Convert.ToInt32(txtID_Catalog.Text);
                cls.ID_Parent = 1;
                cls.CatalogName = txtCatalogName.Text.Trim();
                cls.Image = txtImage.Text.Trim();
                if (fuImage.HasFile)
                {
                    fuImage.SaveAs(Path.Combine(txtImage.Text.Trim()));
                }

                cls.Description = txtDetail.Text.Trim();
                cls.TitleWeb = txtTitleWeb.Text.Trim();
                cls.LinkSEO = txtLinkSEO.Text.Trim();
                cls.H1SEO = txtCatalogName.Text.Trim();
                cls.KeywordSEO = txtCatalogName.Text.Trim();
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