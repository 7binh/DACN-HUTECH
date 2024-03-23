<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="search-result.ascx.cs" Inherits="ShopsDefault.UserControls.Products.search_result" %>
<div class="prd-default search-result">
    <div class="section-1">
        <div class="block-header">Kết quả tìm kiếm</div>
        <div class="container">
            <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsProducts" />
            <asp:Repeater ID="Repeater4" runat="server" DataSourceID="ds">
                <ItemTemplate>
                    <div class="item">
                        <asp:Label ID="lblID_Product" runat="server" Text='<%# Eval("ID_Product")%>' CssClass="d-none"></asp:Label>
                        <div class="image col-3">
                            <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"),Eval("LinkSEO"), Eval("ID_Product"))%>">
                                <img src="<%# Eval("Image")%>" />
                            </a>
                        </div>
                        <div class="content col-6">
                            <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"),Eval("LinkSEO"), Eval("ID_Product"))%>">
                                <h3 class="title"><%# Eval("ProductName")%></h3>
                            </a>
                            <div><%# Utils.subString(Convert.ToString(Eval("Description")), 120)%></div>
                        </div>
                        <div class="action col-3">
                            <h5>Giá thuê</h5>
                            <h4><%# Utils.getPrice(Eval("PriceOut"))%><sup>VNĐ</sup><span>/Ngày</span></h4>
                            <div>
                                <asp:LinkButton ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ID_Product")%>' OnClick="btnAddToCart_Click" CausesValidation="false" Text="Thuê" UseSubmitBehavior="false" CssClass="btn-default add-to-cart" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="dss" runat="server" OnSelecting="dss_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsProducts" />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dss">
                <ItemTemplate>
                    <div class="item">
                        <asp:Label ID="lblID_Product" runat="server" Text='<%# Eval("ID_Product")%>' CssClass="d-none"></asp:Label>
                        <div class="image col-3">
                            <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"),Eval("LinkSEO"), Eval("ID_Product"))%>">
                                <img src="<%# Eval("Image")%>" />
                            </a>
                        </div>
                        <div class="content col-6">
                            <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"),Eval("LinkSEO"), Eval("ID_Product"))%>">
                                <h3 class="title"><%# Eval("ProductName")%></h3>
                            </a>
                            <div><%# Utils.subString(Convert.ToString(Eval("Description")), 120)%></div>
                        </div>
                        <div class="action col-3">
                            <h5>Giá thuê</h5>
                            <h4><%# Utils.getPrice(Eval("PriceOut"))%><sup>VNĐ</sup><span>/Ngày</span></h4>
                            <div>
                                <asp:LinkButton ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ID_Product")%>' OnClick="btnAddToCart_Click" CausesValidation="false" Text="Thuê ngay" UseSubmitBehavior="false" CssClass="btn-default add-to-cart" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
