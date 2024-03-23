<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="main.ascx.cs" Inherits="ShopsDefault.AdminTools.UserControls.Slider.main" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<script type="text/javascript" language="javascript">
    function getLinkImage() {
        $('#<%= fuImage.ClientID %>').change(function () {
            var file = $('#<%= fuImage.ClientID %>')[0].files[0]
            $('#<%= txtImage.ClientID %>').val('/images/UploadImages/san-pham/' + file.name);
        });
    }

    $(document).ready(function () {
        getLinkImage();
    });
</script>

<ul class="breadcrumb">
    <li><a href="/AdminTools/BanLamViec.html">Bàn làm việc</a></li>
    <li>slider</li>
</ul>


<div class="container-fluid">
    <div class="block-default">
        <div class="block-header">
            <i class="icon-bag"></i>Danh sách slider
        </div>
        <div class="block-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="btn-groups">
                        <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-success add-new"><i class="icon-plus"></i> Thêm</asp:LinkButton>
                    </div>
                    <asp:GridView ID="grv" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="grv_OnRowDataBound" DataKeyNames="ID_Slider" OnRowDeleting="grv_RowDeleting" OnPageIndexChanging="grv_PageIndexChanging" CssClass="table table-default">
                        <PagerStyle CssClass="pagination" />
                        <Columns>
                            <asp:BoundField DataField="ID_Slider" HeaderText="ID" HtmlEncode="true" />
                            <asp:BoundField DataField="Title" HeaderText="Tiêu đề" HtmlEncode="true" />
                            <asp:BoundField DataField="SummaryContent" HeaderText="Mô tả" HtmlEncode="true" />
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
                                        <label for="company">ID slider</label>
                                        <asp:TextBox ID="txtID_Slider" runat="server" placeholder="ID slider" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>                                    
                                    <div class="form-group">
                                        <label for="company">Tiêu đề</label>
                                        <asp:TextBox ID="txtTitle" runat="server" placeholder="Nhập tên tiêu đề" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="company">Mô tả</label>
                                        <asp:TextBox ID="txtSummaryContent" runat="server" placeholder="Nhập mô tả slider" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="company">Hình ảnh</label>
                                        <div class="position-relative">
                                            <asp:TextBox ID="txtImage" runat="server" placeholder="Nhập link hình ảnh" CssClass="form-control"></asp:TextBox>
                                            <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control btn-fu" accept=".png,.jpg,.jpeg,.gif" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="street">Nội dung chi tiết</label>
                                        <div class="form-control custom-editor">
                                            <CKEditor:CKEditorControl ID="txtDetail" Language="Vi" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="ContentMain_ctl00_cbHidden">Kích hoạt</label>
                                        <asp:CheckBox ID="cbHidden" runat="server" Style="margin-left: 8px;"></asp:CheckBox>
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
