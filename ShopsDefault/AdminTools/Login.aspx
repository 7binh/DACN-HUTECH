<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="ShopsDefault.AdminTools.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập vào hệ thống</title>
    <link rel="icon" href="../images/UploadImages/icons8-technology-96.ico" type="image/x-icon" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/simple-line-icons.css" rel="stylesheet" />
    <link href="css/pace.min.css" rel="stylesheet" />
    <link href="css/login.css" rel="stylesheet" />
</head>
<body class="dark">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panel1" runat="server" DefaultButton="btnLogin">
                    <div class="login">
                        <div class="container">
                            <div class="row justify-content-center">
                                <div class="col-md-8">
                                    <div class="card-group">
                                        <div class="card p-4">
                                            <div class="card-body">
                                                <h1>Đăng nhập</h1>
                                                <p class="text-muted">Đăng nhập vào tài khoản của bạn</p>
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="icon-user"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Tên đăng nhập" autofocus></asp:TextBox>
                                                </div>
                                                <div class="input-group mb-4">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="icon-lock"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Mật khẩu"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    <div class="col-6">
                                                        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-primary px-4" Text="Đăng nhập" UseSubmitBehavior="false" OnClick="btnLogin_Click" />
                                                    </div>
                                                    <div class="col-6 text-right">
                                                        <button class="btn btn-link px-0" type="button">Quên mật khẩu?</button>
                                                    </div>
                                                    <div class="col-12">
                                                        <asp:Label runat="server" ID="lblError" CssClass="text-error"></asp:Label></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card text-white bg-primary py-5 p-4" style="width: 44%">
                                            <div class="card-body text-center">
                                                <div>
                                                    <h2>LBT Tek</h2>
                                                    <p>Bạn đang sử dụng hệ thống quản lý của LBT Tek. Nếu có lỗi trong quá trình đăng nhập vào hệ thống vui lòng liên hệ với bộ phận kỹ thuật của chúng tôi.</p>
                                                    <button class="btn btn-primary active mt-3" type="button">Liên hệ ngay!</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnLogin" />
            </Triggers>
        </asp:UpdatePanel>
    </form>

    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="js/pace.min.js"></script>
    <script type="text/javascript">
        $(document).ajaxComplete(function () {
            Pace.restart();
        });
    </script>
</body>
</html>
