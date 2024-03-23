<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"  CodeBehind="cart.aspx.cs" Inherits="ShopsDefault.Modules.Products.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <title>Giỏ hàng - Cho Thuê và Đánh giá Sản Phẩm tại LBT Tek</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css" runat="server">
    <link href="/css/cart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Banner_Slider" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentMain" runat="server">
    <div id="cart_main_w" runat="server"></div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Right" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="js" runat="server">
    <script type="text/javascript">
        function quantityVal() {
            var quantity;
            quantity = parseInt($('.addtocart_quantity').val());
            return quantity;
        }
        function showCartInfo() {
            //alert($('.table-cart').find('table').length);
            if ($('.table-cart').find('table').length > 0) {
                $('.cart-info').addClass('show');
            } else {
                $('.cart-info').removeClass('show');
            }
        }

        $(function () {
            //showCartInfo();
            $('.btn_decrement').click(function () {
                var quantity = 0;
                var qua = $(this).closest('.prd-amount').find('.addtocart_quantity');
                if (qua.val() > 1) {
                    quantity = parseInt(qua.val()) - 1;
                    qua.attr('value', (quantity));
                }
            });

            $('.btn_increment').click(function () {
                var quantity = 0;
                var qua = $(this).closest('.prd-amount').find('.addtocart_quantity');
                quantity = parseInt(qua.val()) + 1;
                qua.attr('value', (quantity));
            });
        });
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            $('.btn_decrement').click(function () {
                var quantity = 0;
                var qua = $(this).closest('.prd-amount').find('.addtocart_quantity');
                if (qua.val() > 1) {
                    quantity = parseInt(qua.val()) - 1;
                    qua.attr('value', (quantity));
                }
            });

            $('.btn_increment').click(function () {
                var quantity = 0;
                var qua = $(this).closest('.prd-amount').find('.addtocart_quantity');
                quantity = parseInt(qua.val()) + 1;
                qua.attr('value', (quantity));
            });
        }
    </script>
</asp:Content>
