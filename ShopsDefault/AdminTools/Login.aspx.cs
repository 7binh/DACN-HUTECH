using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librari;

namespace ShopsDefault.AdminTools
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = null;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = txtUserName.Text;
            string Password = txtPassword.Text;
            SqlConnection conn = new AccessDB().get_Conn();
            conn.Open();
            SqlCommand sqlComm = new SqlCommand("select tbUsers.ID_Catalog, tbUsersCatalogs.ID_Catalog, UserName, Password, tbUsersCatalogs.Hidden, tbUsers.Hidden " +
                                                "from tbUsers, tbUsersCatalogs " +
                                                "where " +
                                                "tbUsers.ID_Catalog = tbUsersCatalogs.ID_Catalog and " +
                                                "tbUsersCatalogs.ID_Catalog <> 3 and " +
                                                "UserName = '" + Username + "' and Password = '" + Password + "' and " +
                                                "tbUsersCatalogs.Hidden = 1 and tbUsers.Hidden = 1", conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlComm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    Session["username"] = Username;
                    Response.Redirect("/AdminTools/BanLamViec.html");
                    Session.RemoveAll();
                }
                else if (Username == "" || Password == "")
                {
                    lblError.Text = "Lỗi: Tên đăng nhập/Mật khẩu không được để rỗng!";
                    if (Username == "")
                    {
                        txtUserName.Focus();
                    }
                    else
                    {

                        txtPassword.Focus();
                    }
                }
                else
                {
                    lblError.Text = "Lỗi: Sai tên đăng nhập hoặc mật khẩu!";
                    txtUserName.Focus();
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlComm != null) sqlComm.Dispose();
                if (conn != null) conn.Close();
            }
        }
    }
}