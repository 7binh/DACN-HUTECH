<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="search-filter.ascx.cs" Inherits="ShopsDefault.UserControls.Products.search_filter" %>

 <style>
    .search-filter {
        margin-top: -70px;
    }

        .search-filter .filter-box {
            background-color: #fff;
            background-image: url(/images/UploadImages/san-pham/bg-search-filter.png);
            background-repeat: no-repeat;
            background-size: 25%;
            padding: 30px 15px;
            position: relative;
            z-index: 999;
            box-shadow: 3px 0 29px rgba(0, 0, 0, 0.26);
        }

            .search-filter .filter-box .filter-text {
                color: #fff;
                font-size: 33px;
                font-weight: 600;
                text-transform: capitalize;
                text-align: center;
                padding-top: 22px;
                padding-bottom: 22px;
                margin-bottom: 0;
            }

            .search-filter .filter-box .filter-content {
            }

                .search-filter .filter-box .filter-content .form-group {
                    margin-bottom: 0px;
                    padding-top: 7px;
                    padding-bottom: 7px;
                }

                .search-filter .filter-box .filter-content .btn-default {
                    margin: 32px 0px 0px 0px;
                }
</style>

<script>
    $(function () {
        
        $("#<%= btnSearch.ClientID%>").click(function (e) {
            if ($("#<%= txtID_Catalog.ClientID%>").val() == 0) {
                alert('Bạn chưa chọn loại sản phẩm!');
                e.preventDefault();
            }

        });

        $("#<%= txtDatePick.ClientID%>").focusin(function () {
            $(this).attr('readonly', 'true');
        });

        $("#<%= txtDatePick.ClientID%>").focusout(function () {
            $(this).removeAttr('readonly', 'true');
        });

        var dateToday = new Date();
        var dates = $("#<%= txtDatePick.ClientID%>").datepicker({
            dateFormat: "mm/dd/yy",
            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 1,
            minDate: dateToday.getDate + 1,
            onSelect: function (selectedDate) {
                var option = this.id == "<%= txtDatePick.ClientID%>" ? "minDate" : "2",
                    instance = $(this).data("datepicker"),
                    date = $.datepicker.parseDate(instance.settings.dateFormat || $.datepicker._defaults.dateFormat, selectedDate, instance.settings);
                dates.not(this).datepicker("option", option, date);
            }
        });
        $("#<%= txtDatePick.ClientID%>").datepicker("setDate", dateToday.getDate + 1);
    });
</script>
<div class="search-filter">
    <div class="container">
        <div class="filter-box">
            <div class="row">
                <div class="col-3">
                    <h3 class="filter-text">Tìm kiếm</h3>
                </div>
                <div class="col-9">
                    <div class="filter-content">
                        <div class="row">
                            <div class="col-5">
                                <div class="form-group">
                                    <label>Loại sản phẩm công nghệ</label>
                                    <asp:SqlDataSource ID="ds" runat="server" EnableCaching="false"></asp:SqlDataSource>
                                    <asp:DropDownList ID="txtID_Catalog" runat="server" DataSourceID="ds" DataTextField="CatalogName" DataValueField="ID_Catalog" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Text="Chọn loại sản phẩm" Value="0" Selected="true" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-5">
                                <div class="form-group">
                                    <label>Ngày thuê sản phẩm</label>
                                    <asp:TextBox ID="txtDatePick" runat="server" placeholder="Chọn ngày thuê sản phẩm" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-2">
                                <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Tìm kiếm" CssClass="btn-default"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
