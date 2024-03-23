<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"  CodeBehind="main.aspx.cs" Inherits="ShopsDefault.Modules.Page.main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <title>Cho Thuê và Đánh giá Sản Phẩm tại LBT Tek</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css" runat="server">
    <link href="../../css/owl.theme.default.min.css" rel="stylesheet" />
    <link href="../../css/owl.carousel.min.css" rel="stylesheet" />
    <link href="../../css/slider.css" rel="stylesheet" />
    <link href="../../css/search-filter.css" rel="stylesheet" />
    <link href="../../css/pricing.css" rel="stylesheet" />
    <link href="../../css/why-choose.css" rel="stylesheet" />
    <link href="../../css/portfolio.css" rel="stylesheet" />
    <link href="../../css/rental-process.css" rel="stylesheet" />
    <link href="../../css/hot-news.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Banner_Slider" runat="server">
    <div id="slider_w" runat="server"></div>
    <div id="search_filter" runat="server"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentMain" runat="server">
    <div id="pricing_w" runat="server"></div>
    <div id="why_choose_w" runat="server"></div>
    <div id="portfolio_w" runat="server"></div>
    <div id="rental_process_w" runat="server"></div>
    <div id="hot_news_w" runat="server"></div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Right" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="js" runat="server">
    <script src="../../js/owl.carousel.min.js"></script>
    <script>
        $(function() {
            $(".slider-main").owlCarousel({
			    animateOut: 'fadeOutLeft',
			    animateIn: 'fadeIn',
			    items: 4,
			    nav: true,
			    dots: false,
			    autoplayTimeout: 9000,
			    autoplaySpeed: 5000,
			    autoplay: true,
			    loop: true,
                navText: ["<img src='../../images/UploadImages/slider/back_to.svg'>", "<img src='../../images/UploadImages/slider/next_page.svg'>"],
			    mouseDrag: true,
			    touchDrag: true,
			    responsive: {
				    0: {
					    items: 1
				    },
				    480: {
					    items: 1
				    },
				    600: {
					    items: 1
				    },
				    750: {
					    items: 1
				    },
				    1000: {
					    items: 1
				    },
				    1200: {
					    items: 1
				    }
			    }
		    });

		    $(".slider-main").on("translate.owl.carousel", function () {
			    $(".slider-main .item h2").removeClass("animated fadeInUp").css("opacity", "0");
			    $(".slider-main .item p").removeClass("animated fadeInDown").css("opacity", "0");
			    $(".slider-main .item .btn-default").removeClass("animated fadeInDown").css("opacity", "0");
		    });
		    $(".slider-main").on("translated.owl.carousel", function () {
			    $(".slider-main .item h2").addClass("animated fadeInUp").css("opacity", "1");
			    $(".slider-main .item p").addClass("animated fadeInDown").css("opacity", "1");
			    $(".slider-main .item .btn-default").addClass("animated fadeInDown").css("opacity", "1");
		    });
        });
    </script>
</asp:Content>
