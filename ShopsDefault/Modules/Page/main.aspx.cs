using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.Modules.Page
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Search_Filter_Load();
            Slider_Load();
            Pricing_Load();
            Why_Choose_Load();
            Portfolio_Load();
            Rental_Process_Load();
            Hot_News_Load();
        }

        private void Search_Filter_Load()
        {
            string linkFile = "/UserControls/Products/search-filter.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control main = LoadControl(linkFile);
                search_filter.Controls.Add(main);
            }

        }

        private void Slider_Load()
        {
            string linkFile = "/UserControls/Slider/main.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control main = LoadControl(linkFile);
                slider_w.Controls.Add(main);
            }

        }

        private void Pricing_Load()
        {
            string linkFile = "/UserControls/Products/pricing.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control pricing = LoadControl(linkFile);
                pricing_w.Controls.Add(pricing);
            }
        }

        private void Why_Choose_Load()
        {
            string linkFile = "/UserControls/AboutUs/why-choose.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control why_choose = LoadControl(linkFile);
                why_choose_w.Controls.Add(why_choose);
            }
        }

        private void Portfolio_Load()
        {
            string linkFile = "/UserControls/Products/portfolio.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control portfolio = LoadControl(linkFile);
                portfolio_w.Controls.Add(portfolio);
            }
        }

        private void Rental_Process_Load()
        {
            string linkFile = "/UserControls/AboutUs/rental-process.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control rental_process = LoadControl(linkFile);
                rental_process_w.Controls.Add(rental_process);
            }
        }

        private void Hot_News_Load()
        {
            string linkFile = "/UserControls/News/hot-news.ascx";
            if (File.Exists(Server.MapPath(linkFile)))
            {
                Control hot_news = LoadControl(linkFile);
                hot_news_w.Controls.Add(hot_news);
            }
        }
    }
}