using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.UserControls.AboutUs
{
    public partial class main : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            string sql = "SELECT * FROM tbAboutUs where ID_AboutUs = 1";
            e.InputParameters["sSQL"] = sql;
        }
    }
}