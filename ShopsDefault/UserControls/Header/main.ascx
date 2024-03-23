<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="main.ascx.cs" Inherits="ShopsDefault.UserControls.Header.main" %>
<script type="text/javascript">
    $(function () {
        var availableTags = [ <%= SuggestionList %>];
        var selectedOption = "";
        $("#<%= txtSearch.ClientID%>").autocomplete({
            minLength: 0,
            source: availableTags,
            focus: function (event, ui) {
                $("#<%= txtSearch.ClientID%>").val(ui.item.label);
                return false;
            },

            select: function (event, ui) {
                $("#<%= txtSearch.ClientID%>").val(ui.item.label);
                window.location.href = ui.item.value;
                selectedOption = ui.item.value;
                return false;
            }
        });
    });
</script>
<div class="hd-main">
    <div class="container">
        <div class="row flex-nowrap">
            <div class="col-3">
                <div class="item">
                    <div class="hd-logo text-center">
                        <a href="/thue-san-pham.html">
                            <img src="../../images/UploadImages/logo-tek.png" /></a>
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="item">
                    <div class="hd-search">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="search-text" placeholder="Nhập từ khóa tìm kiếm"></asp:TextBox>
                        <button class="hd-btn-search"><i class="fa fa-search"></i></button>
                    </div>
                </div>
            </div>
            <div class="col-3">
                <div class="item">
                    <div class="hd-phone text-right">
                        <div class="hd-text-hotline">Gọi cho chúng tôi</div>
                        <div class="hd-phone-number"><a href="tel:0123456789">(+84) 434 665 987</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
