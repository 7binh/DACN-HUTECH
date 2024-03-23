<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="detail.ascx.cs" Inherits="ShopsDefault.UserControls.Products.detail" %>
<script type="text/javascript">
    function quantityVal() {
        var quantity;
        quantity = parseInt($('.addtocart_quantity').val());
        return quantity;
    }

    $(function () {
        $('.btn_decrement').click(function () {
            var quantity = 0;
            var that = $('.addtocart_quantity');
            if (that.val() > 1) {
                quantity = parseInt(that.val()) - 1;
                that.attr('value', (quantity));
            }
        });
        $('.btn_increment').click(function () {
            $('.btn_decrement').css('cursor', 'pointer');
            var quantity = 0;
            var that = $('.addtocart_quantity');
            var total = parseInt($('.total-amount').text());
            if (that.val() < total) {
                quantity = parseInt(that.val()) + 1;
                that.attr('value', (quantity));
            }
        });
    });

    function checkItem(quantity, e) {
        var totalamout = parseInt($('.total-amount').text());
        if (totalamout == 0) {
            alert("Sản phẩm này đã hết hàng trong kho nên không thêm vào giỏ hàng được!");
            e.preventDefault();
        } else if (totalamout - parseInt(quantity) < 0) {
            alert("Sản phẩm cần mua chênh lệch cho với sản phẩm còn trong kho nên không thêm vào giỏ hàng được!");
            e.preventDefault();
        } else {
            //var cartCount = parseInt($('.hd-cart-item').text()) + parseInt(quantity);
            //$('.hd-cart-item').text(cartCount);
            $('.total-amount').text(totalamout - quantity);
        }
        return true;
    }
</script>
<div class="prd-detail section">
    <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsProducts" />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds" EnableViewState="true">
        <ItemTemplate>
            <div class="container">
                <div class="block-header style1"><%# Eval("ProductName")%></div>
                <div class="row">
                    <div class="col-6">
                        <img src="<%# Eval("Image")%>" alt="<%# Eval("ProductName")%>" />
                    </div>
                    <div class="col-6">
                        <div class="_line"><strong>Loại sản phẩm:</strong> <%# Eval("CatalogName")%></div>
                        <div class="_line"><strong>Mã sản phẩm:</strong> <%# Eval("ProductCode")%></div>
                        <div class="_line"><strong>Màu sắc:</strong> <%# Eval("Color")%></div>
                        <div class="_line"><strong>Giá thuê:</strong> <%# Utils.getPrice(Eval("PriceOut"))%><sup>VNĐ</sup><span>/Ngày</span></div>
                        <div class="_line prd-amount"><strong>Số lượng:</strong> <span class="btn-amount btn_decrement"><i class="fa fa-minus"></i></span><asp:TextBox ID="txtQuantity" runat="server" class="addtocart_quantity" type="text" value="1"></asp:TextBox><span class="btn-amount btn_increment"><i class="fa fa-plus"></i></span>
                            <asp:Label ID="lblAmount" runat="server" class="total-amount"></asp:Label>
                            chiếc có sẵn</div>
                        <div>
                            <asp:Button ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ID_Product")%>' OnClientClick="checkItem(quantityVal());" OnClick="btnAddToCart_Click" CausesValidation="false" Text="Thuê Ngay" UseSubmitBehavior="false" CssClass="btn-default add-to-cart" />
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="content-editor">
                            <%# Eval("Description")%>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
