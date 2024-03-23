<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="relates.ascx.cs" Inherits="ShopsDefault.UserControls.News.relates" %>

<link href="/css/hot-news.css" rel="stylesheet" />
<div class="news-hot-news section">
    <div class="container">
        <div class="block-header style1">Tin tức liên quan</div>
        <div class="row">
            <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsProducts" />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds">
                <ItemTemplate>
                    <div class="col-4">
                        <div class="item">
                            <div class="image">
                                <a href="<%# Utils.getAHrefURL222(Eval("linkSEO"), Eval("ID_News"))%>">
                                    <img src="<%# Eval("Image")%>" /></a>
                            </div>
                            <div class="content">
                                <a href="<%# Utils.getAHrefURL222(Eval("linkSEO"), Eval("ID_News"))%>">
                                    <h3 class="title"><%# Eval("Title")%></h3>
                                </a>
                                <div class="desc"><%# Utils.subString(Convert.ToString(Eval("SummaryContent")), 120)%>...</div>
                            </div>
                            <div class="author">
                                <div class="poster">Admin</div>
                                <div class="date-post"><%#Eval("AddTime", "{0:dd/MM/yyyy}")%></div>
                                <div class="read-more"><a href="<%# Utils.getAHrefURL222( Eval("linkSEO"), Eval("ID_News"))%>" class="btn-default">Xem thêm</a></div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>