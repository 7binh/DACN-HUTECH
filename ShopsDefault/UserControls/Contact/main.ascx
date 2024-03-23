<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="main.ascx.cs" Inherits="ShopsDefault.UserControls.Contact.main" %>
<style>
    .btn-default {
        margin-bottom: 0;
        margin-top: 0;
    }

    .card-body .form-group label {
        font-weight: 500;
    }

    .block-header.custome-block-header {
        padding-top: 20px;
        margin-bottom: 20px;
        font-size: 25px;
    }

        .block-header.custome-block-header:before {
            bottom: -13px;
        }

        .block-header.custome-block-header:after {
            bottom: -10px;
        }
</style>
<script>
    $(function () {
        $('.btn-contact').click(function (e) {
            if ($('.check-contact-name').val() == '') {
                alert('Nhập tiêu đề để gởi liên hệ');
                $('.check-contact-name').focus();
                e.preventDefault();
            } else if ($('.check-full-name').val() == '') {
                alert('Nhập họ tên để gởi liên hệ');
                $('.check-full-name').focus();
                e.preventDefault();
            } else if ($('.check-phone').val() == '') {
                alert('Nhập số điện thoại để gởi liên hệ');
                $('.check-phone').focus();
                e.preventDefault();
            } else if ($('.check-email').val() == '') {
                alert('Nhập email để gởi liên hệ');
                $('.check-email').focus();
                e.preventDefault();
            } else if ($('.check-detail').val() == '') {
                alert('Nhập nội dung để gởi liên hệ');
                $('.check-detail').focus();
                e.preventDefault();
            }
        });
    });
</script>
<div class="contact-default">
    <div class="container">
        <div class="row">
            <div class="col-6">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.1257424099144!2d106.7122433153342!3d10.801680261679465!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317528a501281b1f%3A0x6f43044e459b3132!2zNDc1YSDEkGnhu4duIEJpw6puIFBo4bunLCBQaMaw4budbmcgMjUsIELDrG5oIFRo4bqhbmgsIEjhu5MgQ2jDrSBNaW5oIDcwMDAwLCBWaWV0bmFt!5e0!3m2!1sen!2s!4v1558778550318!5m2!1sen!2s" width="100%" height="570" frameborder="0" style="border: 0;" allowfullscreen=""></iframe>
            </div>
            <div class="col-6">
                <div class="block-header custome-block-header">Liên hệ với chúng tôi</div>
                <div>
                    <div class="form-group">
                        <label for="company">Tiêu đề</label>
                        <asp:TextBox ID="txtContactName" runat="server" placeholder="Nhập tiêu đề" CssClass="form-control check-contact-name"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="company">Họ và tên</label>
                        <asp:TextBox ID="txtFullName" runat="server" placeholder="Nhập họ tên" CssClass="form-control check-full-name"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="company">Số điện thoại</label>
                        <asp:TextBox ID="txtPhone" runat="server" placeholder="Nhập số điện thoại" CssClass="form-control check-phone"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="company">Địa chỉ email</label>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Nhập địa chỉ Email" CssClass="form-control check-email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="street">Nội dung</label>
                        <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" placeholder="Nhập nội dung" CssClass="form-control check-detail"></asp:TextBox>
                    </div>
                    <div class="form-actions text-center">
                        <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn-default btn-contact" Text="Gởi liên hệ"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

