<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="menu_catalogs_product.ascx.cs" Inherits="ShopsDefault.UserControls.Left.menu_catalogs_product" %>
<div class="block-header-left">Danh mục sản phẩm</div>
<ul class="menu_left">
    <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsCatalogs" />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds">
        <ItemTemplate>
            <li>
                <a href="">
                    <%# Eval("CatalogName")%>
                </a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
