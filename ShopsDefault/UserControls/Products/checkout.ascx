<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="checkout.ascx.cs" Inherits="ShopsDefault.UserControls.Products.checkout" %>

<script type="text/javascript">
    function payment() {
        $('.nav-tabs .nav-link:first-child').addClass('active');
        $('.nav-tabs .nav-link:first-child .custom-control-input').prop('checked', true);
        $('.tab-content .tab-pane:first-child').addClass('show active');

        $('.nav-tabs .nav-link').click(function () {
            $('.nav-tabs .nav-link').find('.custom-control-input').prop('checked', false);
            $(this).find('.custom-control-input').prop('checked', true);
        });
    }

    var hdID_Payment = "<%=hdID_Payment.ClientID%>";
    function PaymentsMethod(Payment) {
        document.getElementById(hdID_Payment).value = Payment;
    }
    $(function () {
        payment();
        $('.nav-tabs .nav-link').click(function () {
            var id = $(this).find('.payments-method').val();
            PaymentsMethod(id);
        });
    });
</script>
<script src="/js/checkout.js"></script>
<script>
    var ckName = "<%= txtFullName.ClientID%>";
    var ckPhone = "<%= txtPhoneNumber.ClientID%>";
    var ckEmail = "<%= txtEmail.ClientID%>";
    var ckAddress = "<%= txtAddress.ClientID%>";
    $(function () {
        $("#<%= txtDatePick.ClientID%>, #<%= txtDayOff.ClientID%>").focusin(function () {
            $(this).attr('readonly', 'true');
        });

        $("#<%= txtDatePick.ClientID%>, #<%= txtDayOff.ClientID%>").focusout(function () {
            $(this).removeAttr('readonly', 'true');
        });

        var dateToday = new Date();
        var dates = $("#<%= txtDatePick.ClientID%>, #<%= txtDayOff.ClientID%>").datepicker({
            dateFormat: "dd/mm/yy",
            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 1,
            //setDate: dateToday,
            minDate: dateToday.getDate + 1,
            //maxDate: 3,
            onSelect: function (selectedDate) {
                var option = this.id == "<%= txtDatePick.ClientID%>" ? "minDate" : "2",
                    instance = $(this).data("datepicker"),
                    date = $.datepicker.parseDate(instance.settings.dateFormat || $.datepicker._defaults.dateFormat, selectedDate, instance.settings);
                dates.not(this).datepicker("option", option, date);
            }
        });
        $("#<%= txtDatePick.ClientID%>").datepicker("setDate", dateToday.getDate + 1);
        $("#<%= txtDayOff.ClientID%>").datepicker("setDate", dateToday.getDate + 2);
    });
</script>
<div class="prd-checkout section">
    <div class="block-header">Đặt hàng</div>
    <div class="container">
        <div class="row">
            <div class="col-8">
                <div class="checkout-item">
                    <div class="title-header">Địa điểm nhận hàng</div>
                    <div class="checkout-content">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <label for="company">Họ tên</label>
                                    <asp:TextBox ID="txtFullName" runat="server" onKeyUp='validateName(ckName)' placeholder="Nhập họ tên" CssClass="form-control"></asp:TextBox>
                                    <label class="error-message d-none" id="name-error"></label>
                                </div>
                                <div class="form-group">
                                    <label for="company">Số điện thoại</label>
                                    <asp:TextBox ID="txtPhoneNumber" runat="server" onKeyUp='validatePhone(ckPhone)' placeholder="Nhập số điện thoại" CssClass="form-control"></asp:TextBox>
                                    <label class="error-message d-none" id="phone-error"></label>
                                </div>
                                <div class="form-group">
                                    <label for="company">Ngày Thuê</label>
                                    <asp:TextBox ID="txtDatePick" runat="server" placeholder="Chọn ngày mượn sản phẩm" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group">
                                    <label for="company">Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" onKeyUp='validateEmail(ckEmail)' placeholder="Nhập email" CssClass="form-control"></asp:TextBox>
                                    <label class="error-message d-none" id="email-error"></label>
                                </div>
                                <div class="form-group">
                                    <label for="company">Địa chỉ nhận hàng</label>
                                    <asp:TextBox ID="txtAddress" runat="server" onKeyUp='validateAddress(ckAddress)' placeholder="Nhập địa chỉ nhận hàng" CssClass="form-control"></asp:TextBox>
                                    <label class="error-message d-none" id="address-error"></label>
                                </div>
                                <div class="form-group">
                                    <label for="company">Ngày Trả</label>
                                    <asp:TextBox ID="txtDayOff" runat="server" placeholder="Chọn ngày trả sản phẩm" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label for="company">Ghi chú</label>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" placeholder="Nhập ghi chú đơn hàng" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="checkout-item">
                    <div class="title-header">Hình thức thanh toán</div>
                    <div class="checkout-content">
                        <asp:ObjectDataSource ID="ds" runat="server" OnSelecting="ds_Selecting" SelectMethod="GetDataTable_SQL_pro" TypeName="Librari.Cls_ShopsPayments" />
                        <div class="nav nav-tabs" id="nav-tab" role="tablist">
                            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ds">
                                <ItemTemplate>
                                    <a class="nav-link" id="nav-<%# Eval("ID_Payment")%>-tab" data-toggle="tab" role="tab" href="#nav-<%# Eval("ID_Payment")%>" aria-controls="nav-<%# Eval("ID_Payment")%>" aria-selected="false">
                                        <div class="custom-radio">
                                            <input type="radio" class="payments-method custom-control-input" id="radio-<%# Eval("ID_Payment")%>" name="radio-payment" value='<%# Eval("ID_Payment")%>'>
                                            <label class="custom-control-label" for="radio-<%# Eval("ID_Payment")%>"><%# Eval("PaymentName")%></label>
                                            <%--<asp:Label ID="lblID_Payment" runat="server" CssClass="d-none" Text='<%# Eval("ID_Payment")%>'></asp:Label>--%>
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="tab-content" id="nav-tabContent">
                            <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ds">
                                <ItemTemplate>
                                    <div class="tab-pane fade" id="nav-<%# Eval("ID_Payment")%>" role="tabpanel" aria-labelledby="nav-<%# Eval("ID_Payment")%>-tab"><%# Eval("Description")%></div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-4">
                <div class="checkout-item-info">
                    <div class="title-header">Thông tin đơn hàng</div>
<div class="checkout-content">
    <div class="checkout-cart">
        <asp:Repeater ID="Repeater3" runat="server" OnInit="dsCart_OnLoad">
            <ItemTemplate>
                <div class="item">
                    <div class="row">
                        <div class="col-8">
                            <div>
                                <span class="quantity"><%# Eval("Quantity")%>x</span>
                                <span class="prd-name"><a href="<%# Utils.getAHrefURL("san-pham", Eval("linkSEOCatalog"),Eval("LinkSEO"), Eval("ID_Product"))%>"><%# Eval("ProductName")%></a></span>
                            </div>
                            <div>
                                Thuộc loại <strong style="font-weight: 600;"><%# Eval("CatalogName")%></strong>
                            </div>
                        </div>
                        <div class="col-4 checkout-item-info">
                            <div class="price text-right"><%# Utils.getPrice(Eval("Total"))%><sup>đ</sup></div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <div class="item">
                    <div class="row">
                        <div class="col-6">
                            Thành tiền:
                        </div>
                        <div class="col-6">
                            <div class="total">
                                <%= Utils.getPrice(getTotal()) %><sup>đ</sup>
                            </div>
                        </div>
                    </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="text-center">
        <a href="gio-hang.html" class="btn-default">Giỏ hàng</a>
        <asp:LinkButton ID="btnCheckout" runat="server" OnClientClick="return validateForm(ckName, ckPhone, ckEmail, ckAddress)" OnClick="btnCheckout_Click" CssClass="btn-default">Đặt hàng</asp:LinkButton>
    </div>
    <div class="checkout-warning-text">
        Quý khách vui lòng kiểm tra lại thông tin đơn hàng trước khi nhấn vào nút đặt hàng
    </div>
</div>
                </div>

                
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdID_Payment" runat="server" Value="1" />
</div>
