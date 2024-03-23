<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="relates.ascx.cs" Inherits="ShopsDefault.UserControls.Products.relates" %>
<style>
    .prd-relates.section {
        padding-top: 0;
    }
</style>
<div class="prd-relates prd-default section">
    <div class="container">
        <div class="block-header style1">Sản phẩm liên quan</div>
        <div class="row">
            <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsProducts" />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds">
                <ItemTemplate>
                    <div class="col-lg-4">
                        <div class="item">
                            <asp:Label ID="lblID_Product" runat="server" Text='<%# Eval("ID_Product")%>' CssClass="d-none"></asp:Label>
                            <div class="image">
                                <a href="<%# Utils.getAHrefURL222(Eval("LinkSEO"), Eval("ID_Product"))%>">
                                    <img src="<%# Eval("Image")%>" />
                                </a>
                            </div>
                            <div class="content">
                                <a href="<%# Utils.getAHrefURL222(Eval("LinkSEO"), Eval("ID_Product"))%>">
                                    <h3 class="title"><%# Eval("ProductName")%></h3>
                                </a>
                                <h4><%# Utils.getPrice(Eval("PriceOut"))%><sup>VNĐ</sup><span>/Ngày</span></h4>
                                <div class="action">
                                    <asp:LinkButton ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ID_Product")%>' OnClick="btnAddToCart_Click" CausesValidation="false" Text="Thuê ngay" UseSubmitBehavior="false" CssClass="btn-default add-to-cart" />
                                    <a href="<%# Utils.getAHrefURL222(Eval("LinkSEO"), Eval("ID_Product"))%>" class="btn-default">Chi tiết</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
