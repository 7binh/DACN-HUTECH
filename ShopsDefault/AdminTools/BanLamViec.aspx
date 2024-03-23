<%@ Page Title="" Language="C#" MasterPageFile="~/AdminTools/AdminTools.Master" AutoEventWireup="true"  CodeBehind="BanLamViec.aspx.cs" Inherits="ShopsDefault.AdminTools.BanLamViec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <title>LBT Tek - Bàn làm việc</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Banner_Slider" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="main">
        <ul class="breadcrumb">
            <li>Bàn làm việc</li>
        </ul>
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="block-default">
                        <div class="block-header">
                            <i class="icon-bag"></i>Danh sách đơn hàng ngày mai
                        </div>
                        <div class="block-body">
                            <div id="order_reminder_ww" runat="server">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12">
                    <div class="block-default my-md-3">
                        <div class="block-header">
                            <i class="icon-bag"></i>Danh sách đơn hàng tới ngày trả
                        </div>
                        <div class="block-body">
                            <div id="order_reminder_getback_ww" runat="server">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12">
                    <div class="block-default">
                        <div class="block-header">
                            <i class="icon-bubble"></i>Khách hàng liên hệ gần đây
                        </div>
                        <div class="block-body">
                            <div id="contact_reminder_ww" runat="server">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Right" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="js" runat="server">
</asp:Content>
