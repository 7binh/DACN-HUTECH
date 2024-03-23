using Librari;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.Header
{
    public partial class main : System.Web.UI.UserControl
    {
        public string SuggestionList = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT *, tbShopsCatalogs.LinkSEO as linkSEOCatalog FROM tbShopsProducts, tbShopsCatalogs WHERE tbShopsCatalogs.ID_Catalog = tbShopsProducts.ID_Catalog and tbShopsProducts.Hidden = 1 order by ProductName";
            using (SqlConnection sConn = new AccessDB().get_Conn())
            {
                using (SqlCommand command = new SqlCommand(queryString, sConn))
                {
                    sConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(SuggestionList))
                            {
                                SuggestionList += "{value: \"" + Utils.getAHrefURL("/san-pham", reader["linkSEOCatalog"].ToString(), reader["LinkSEO"].ToString(), reader["ID_Product"].ToString()) + "\",label: \"" + reader["ProductName"].ToString() + "\",},";
                            }
                            else
                            {
                                SuggestionList += "{value: \"" + Utils.getAHrefURL("/san-pham", reader["linkSEOCatalog"].ToString(), reader["LinkSEO"].ToString(), reader["ID_Product"].ToString()) + "\",label: \"" + reader["ProductName"].ToString() + "\",},";
                            }
                        }
                    }
                }
            }
        }
    }
}