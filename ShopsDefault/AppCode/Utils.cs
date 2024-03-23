using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public class Utils
{
    public Utils()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public static string getAHrefURL(object module, object LinkSEOCatalog, object linkSEO, object ID)
    {
        string link = "";
        if (LinkSEOCatalog.ToString() != "")
        {
            link = module + "/" + LinkSEOCatalog + "/" + linkSEO + "-" + ID + ".html";
        }
        else
        {
            link = module + "/" + linkSEO + "-" + ID + ".html";

        }
        return link;
    }

    public static string getAHrefURL222(object linkSEO, object ID)
    {
        string link = "";
        link = linkSEO + "-" + ID + ".html";

        return link;
    }

    public static string subString(string str, int maxLength)
    {
        return str.Substring(0, Math.Min(str.Length, maxLength));
    }

    public static string getPrice(object price)
    {
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        string pr = double.Parse(price.ToString()).ToString("#,###", cul.NumberFormat);
        return pr;
    }

    public static string GetCountItemCart()
    {
        int count = 0;
        object total;
        DataTable dt = (DataTable)HttpContext.Current.Session["cart_items"];
        if (dt != null)
        {
            total = dt.Compute("Sum(Quantity)", "");
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
}