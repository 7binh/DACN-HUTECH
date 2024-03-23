<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="portfolio.ascx.cs" Inherits="ShopsDefault.UserControls.Products.portfolio" %>

<div class="prd-protfolio section">
    <div class="container">
        <div class="block-header">Danh mục <span>sản phẩm công nghệ cho thuê</span> tại LBT Tek</div>
        <div class="row">
            <div class="col-md-12">
                <div class="prd-protfolio-tabs">
                    <ul class="nav nav-tabs" id="protfolioTab" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" id="all-tab" data-toggle="tab" href="#all" role="tab" aria-controls="all" aria-selected="true">Tất cả</a>
                        </li>
                        <asp:ObjectDataSource ID="dsCatalog" runat="server" OnSelecting="ds_Catalogs_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsCatalogs" />
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsCatalog">
                            <ItemTemplate>
                                <li class="nav-item">
                                    <a class="nav-link" id="<%# Eval("LinkSEO")%>-tab" data-toggle="tab" href="#<%# Eval("LinkSEO")%>" role="tab" aria-controls="<%# Eval("LinkSEO")%>" aria-selected="false"><%# Eval("CatalogName")%></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="tab-content" id="offerTabContent">
                        <div class="tab-pane fade show active" id="all" role="tabpanel" aria-labelledby="all-tab">
                            <div class="row">
                                <asp:ObjectDataSource ID="dsPrdAll" runat="server" OnSelecting="ds_Prd_All_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsProducts" />
                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="dsPrdAll" EnableViewState="true">
                                    <ItemTemplate>
                                        <div class="col-lg-4">
                                            <div class="item">
                                                <asp:Label ID="lblID_Product" runat="server" Text='<%# Eval("ID_Product")%>' CssClass="d-none"></asp:Label>
                                                <div class="image">
                                                    <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"), Eval("LinkSEO"), Eval("ID_Product"))%>">
                                                        <img src="<%# Eval("Image")%>" />
                                                    </a>
                                                </div>
                                                <div class="content">
                                                    <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"),Eval("LinkSEO"), Eval("ID_Product"))%>">
                                                        <h3 class="title"><%# Eval("ProductName")%></h3>
                                                    </a>
                                                    <h4><%# Utils.getPrice(Eval("PriceOut"))%><sup>VNĐ</sup><span>/Ngày</span></h4>
                                                    <%-- %><ul>
                                                        <li><i class="fa fa-motorcycle"></i><%# Eval("Color")%></li>
                                                        <li><i class="fa fa-dashboard"></i><%# Eval("Weight")%> km/h</li>
                                                    </ul>--%>
                                                    <div class="action">
                                                        <asp:LinkButton ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ID_Product")%>' OnClick="btnAddToCart_Click" CausesValidation="false" Text="Thuê ngay" UseSubmitBehavior="false" CssClass="btn-default add-to-cart" />
                                                        <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"), Eval("LinkSEO"), Eval("ID_Product"))%>" class="btn-default">Chi tiết</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                        <asp:Repeater ID="Repeater3" runat="server" DataSourceID="dsCatalog">
                            <ItemTemplate>
                                <div class="tab-pane fade" id="<%# Eval("LinkSEO")%>" role="tabpanel" aria-labelledby="<%# Eval("LinkSEO")%>-tab">
                                    <div class="row">
                                        <asp:Repeater ID="Repeater3" runat="server" DataSource='<%# getPrdSelecting(Eval("ID_Catalog"))%>'>
                                            <ItemTemplate>
                                                <div class="col-lg-4">
                                                    <div class="item">
                                                        <asp:Label ID="lblID_Product" runat="server" Text='<%# Eval("ID_Product")%>' CssClass="d-none"></asp:Label>
                                                        <div class="image">
                                                            <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"), Eval("LinkSEO"), Eval("ID_Product"))%>">
                                                                <img src="<%# Eval("Image")%>" />
                                                            </a>
                                                        </div>
                                                        <div class="content">
                                                            <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"), Eval("linkSEO"), Eval("ID_Product"))%>">
                                                                <h3 class="title"><%# Eval("ProductName")%></h3>
                                                            </a>
                                                            <h4><%# Utils.getPrice(Eval("PriceOut"))%><sup>VNĐ</sup><span>/Ngày</span></h4>
                                                            <div class="action">
                                                                <asp:LinkButton ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ID_Product")%>' OnClick="btnAddToCart_Click" CausesValidation="false" Text="Thuê sản phẩm" UseSubmitBehavior="false" CssClass="btn-default add-to-cart" />
                                                                <a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"), Eval("LinkSEO"), Eval("ID_Product"))%>" class="btn-default">Chi tiết</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
