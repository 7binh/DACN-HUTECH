<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="main.ascx.cs" Inherits="ShopsDefault.UserControls.AboutUs.main" %>
<div class="about-main section">
    <div class="container">
        <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_AboutUs" />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds">
            <ItemTemplate>
                <div class="block-header"><%# Eval("Title")%></div>
                <div class="row">
                    <div class="content-editor">
                        <%# Eval("Description")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
