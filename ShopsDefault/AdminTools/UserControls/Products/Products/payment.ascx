<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="payment.ascx.cs" Inherits="ShopsDefault.AdminTools.UserControls.Products.Products.payment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<ul class="breadcrumb">
    <li><a href="/AdminTools/BanLamViec.html">Bàn làm việc</a></li>
    <li>Hình thức thanh toán</li>
</ul>


<div class="container-fluid">
    <div class="block-default">
        <div class="block-header">
            <i class="icon-credit-card"></i>Danh sách hình thức thanh toán
        </div>
        <div class="block-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="btn-groups">
                        <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-success add-new"><i class="icon-plus"></i> Thêm</asp:LinkButton>
                    </div>
                    <asp:GridView ID="grv" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="grv_OnRowDataBound" DataKeyNames="ID_Payment" OnRowDeleting="grv_RowDeleting" OnPageIndexChanging="grv_PageIndexChanging" CssClass="table table-default">
                        <PagerStyle CssClass="pagination" />
                        <Columns>
                            <asp:BoundField DataField="ID_Payment" HeaderText="ID" HtmlEncode="true" />
                            <asp:BoundField DataField="PaymentName" HeaderText="Tên hình thức thanh toán" HtmlEncode="true" />
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
                        <div class="popup-body">
                            <div class="card">
                                <div class="card-header">
                                    <i class="icon-note"></i>Thêm hình thức thanh toán
                                </div>
                                <div class="card-body scrollbar-y-custom">
                                    <div class="form-group d-none">
                                        <label for="company">ID Thanh toán</label>
                                        <asp:TextBox ID="txtID_Payment" runat="server" placeholder="ID Thanh toán" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="company">Tên hình thức thanh toán</label>
                                        <asp:TextBox ID="txtPaymentName" runat="server" placeholder="Nhập hình thức thanh toán" CssClass="form-control"></asp:TextBox>
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
