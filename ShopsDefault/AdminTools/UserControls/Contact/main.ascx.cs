using Librari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.UserControls.Contact
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
            grv.DataSource = Cls_Contact.getDataTable_My();
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
                lnk.Attributes.Add("onclick", "return confirm('Bạn có muốn xóa liên hệ " + getName + " không?')");
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
            Cls_Contact cls = Cls_Contact.getOject_Key(ID_find);
            txtContactName.Text = cls.ContactName.ToString();
            txtFullName.Text = cls.FullName.ToString();
            txtPhone.Text = cls.Phone.ToString();
            txtEmail.Text = cls.Email.ToString();
            txtDetail.Text = cls.Description.ToString();
            popup.Show();
        }
        protected void grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID_Contact = Convert.ToInt32(grv.DataKeys[e.RowIndex].Values[0]);
            Cls_Contact cls = new Cls_Contact();
            cls.ID_Contact_find = ID_Contact;

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
    }
}