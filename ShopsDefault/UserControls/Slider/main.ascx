<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="main.ascx.cs" Inherits="ShopsDefault.UserControls.Slider.main" %>

<div class="slider-main owl-carousel">
    <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_Slider" />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds">
        <ItemTemplate>
            <div class="item" style="background-image: url('<%# Eval("Image")%>');">
                <div class="caption-slider">
                    <div class="caption-slider-cell">
                        <div class="container">
                            <div class="row">
                                <div class="col-12">
                                    <div class="slider-text">
                                        <p><%# Eval("Title")%></p>
                                        <h2><%# Eval("SummaryContent")%></h2>
                                        <a href="/san-pham.html" class="btn-default">Đặt ngay</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
