using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools
{
    public partial class BanLamViec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Order_Reminder_Load();
            Order_Reminder_Getback_Load();
            Contact_Reminder_Load();
        }

        private void Order_Reminder_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Products/Products/order-reminder.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ctl_main = LoadControl(linkFile);
                order_reminder_ww.Controls.Add(ctl_main);
            }

        }

        private void Order_Reminder_Getback_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Products/Products/order-reminder-getback.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ctl_main = LoadControl(linkFile);
                order_reminder_getback_ww.Controls.Add(ctl_main);
            }

        }

        private void Contact_Reminder_Load()
        {
            string linkFile = "~/AdminTools/UserControls/Contact/contact-reminder.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control ctl_main = LoadControl(linkFile);
                contact_reminder_ww.Controls.Add(ctl_main);
            }

        }
    }
}