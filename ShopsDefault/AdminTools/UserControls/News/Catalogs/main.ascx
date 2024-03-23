<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="main.ascx.cs" Inherits="ShopsDefault.AdminTools.UserControls.News.Catalogs.main" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<script type="text/javascript" language="javascript">
    function FcOut() {
        $('#<%= txtCatalogName.ClientID %>').focusout(function () {
            var str = $('#<%= txtCatalogName.ClientID %>').val();
            $('#<%= txtTitleWeb.ClientID %>').val(str);
            $('#<%= txtLinkSEO.ClientID %>').val(locdau(str));
        });
    }
    function getLinkImage() {
        $('#<%= fuImage.ClientID %>').change(function () {
            var file = $('#<%= fuImage.ClientID %>')[0].files[0]
            $('#<%= txtImage.ClientID %>').val('/images/UploadImages/san-pham/' + file.name);
        });
    }

    $(document).ready(function () {
        FcOut();
        getLinkImage();
    });
</script>

<ul class="breadcrumb">
    <li><a href="/AdminTools/BanLamViec.html">Bàn làm việc</a></li>
    <li>Nhóm tin tức</li>
</ul>
<div class="container-fluid">
    <div class="block-default">
        <div class="block-header">
            <i class="icon-grid"></i>Nhóm tin tức
        </div>
        <div class="block-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="btn-groups">
                        <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-success add-new"><i class="icon-plus"></i> Thêm</asp:LinkButton>
                    </div>
                    <asp:GridView ID="grv" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="grv_OnRowDataBound" DataKeyNames="ID_Catalog" OnRowDeleting="grv_RowDeleting" OnPageIndexChanging="grv_PageIndexChanging" CssClass="table table-default">
                        <PagerStyle CssClass="pagination" />
                        <Columns>
                            <asp:BoundField DataField="ID_Catalog" HeaderText="ID" HtmlEncode="true" />
                            <asp:BoundField DataField="CatalogName" HeaderText="Tên nhóm tin tức" HtmlEncode="true" />
                            <asp:BoundField DataField="LinkSEO" HeaderText="Đường dẫn SEO" HtmlEncode="true" />
                            <asp:TemplateField HeaderText="Trạng thái" SortExpression="Hidden">
                                <ItemTemplate><%# (Boolean.Parse(Eval("Hidden").ToString())) ? "Kích hoạt" : "Không kích hoạt" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hành động">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-info"><i class="icon-pencil"></i> Sửa</asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-danger"><i class="icon-trash"></i> Xóa </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" Style="display: none">
                        <script type="text/javascript" language="javascript">
                            var prm = Sys.WebForms.PageRequestManager.getInstance();

                            prm.add_endRequest(function () {
                                FcOut();
                                getLinkImage();
                            });
                        </script>
                        <div class="popup-body">
                            <div class="card">
                                <div class="card-header">
                                    <i class="icon-note"></i>Thêm danh mục
                                </div>
                                <div class="card-body scrollbar-y-custom">
                                    <div class="form-group d-none">
                                        <label for="company">ID danh mục</label>
                                        <asp:TextBox ID="txtID_Catalog" runat="server" placeholder="ID Danh Mục" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="company">Tên danh mục</label>
                                        <asp:TextBox ID="txtCatalogName" runat="server" placeholder="Nhập tên danh mục" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="company">Tiêu đề website</label>
                                        <asp:TextBox ID="txtTitleWeb" runat="server" placeholder="Nhập tiêu đề website" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="company">Hình ảnh</label>
                                        <div class="position-relative">
                                            <asp:TextBox ID="txtImage" runat="server" placeholder="Nhập link hình ảnh" CssClass="form-control"></asp:TextBox>
                                            <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control btn-fu" accept=".png,.jpg,.jpeg,.gif" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="street">Mô tả</label>
                                        <div class="form-control">
                                            <CKEditor:CKEditorControl ID="txtDetail" Language="Vi" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="ContentMain_ctl00_cbHidden">Kích hoạt</label>
                                        <asp:CheckBox ID="cbHidden" runat="server" Style="margin-left: 8px;"></asp:CheckBox>
                                    </div>

                                    <div class="form-group">
                                        <label for="country">Đường dẫn website</label>
                                        <asp:TextBox ID="txtLinkSEO" runat="server" placeholder="Nhập đường dẫn website" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="form-actions">
                                        <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary">Lưu</asp:LinkButton>
                                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-secondary">Hủy</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                    <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
                        PopupControlID="pnlAddEdit" TargetControlID="lnkFake"
                        BackgroundCssClass="modalBackground">
                    </cc1:ModalPopupExtender>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="grv" />
                    <asp:AsyncPostBackTrigger ControlID="btnSave" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
