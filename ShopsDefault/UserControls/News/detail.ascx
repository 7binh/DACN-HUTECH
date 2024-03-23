<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="detail.ascx.cs" Inherits="ShopsDefault.UserControls.News.detail" %>

<div class="detail-news section">
    <div class="container">
        <div class="row">
            <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_News" />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds">
                <ItemTemplate>
                    <div class="col-12">
                        <div class="item">
                            <div class="title">
                                <%# Eval("Title")%>
                            </div>
                            <div class="author">
                                <i class="fa fa-user"></i>Admin | <i class="fa fa-calendar"></i><%# GetDate(Eval("AddTime"))%>
                            </div>
                            <div class="content-editor">
                                <%# Eval("Description")%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
