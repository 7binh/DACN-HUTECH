<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="contact-reminder.ascx.cs" Inherits="ShopsDefault.AdminTools.UserControls.Contact.contact_reminder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div class="block-body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grv" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="ID_Contact" OnRowDeleting="grv_RowDeleting" OnRowDataBound="grv_OnRowDataBound" OnPageIndexChanging="grv_PageIndexChanging" CssClass="table table-default">
                <PagerStyle CssClass="pagination" />
                <Columns>
                    <asp:BoundField DataField="ID_Contact" HeaderText="ID" HtmlEncode="true" />
                    <asp:BoundField DataField="FullName" HeaderText="Tên người gởi" HtmlEncode="true" />
                    <asp:BoundField DataField="Phone" HeaderText="Số điện thoại" HtmlEncode="true" />
                    <asp:BoundField DataField="Email" HeaderText="Địa chỉ Email" HtmlEncode="true" />
                    <asp:TemplateField HeaderText="Hành động">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-info"><i class="icon-pencil"></i> Chi tiết</asp:LinkButton>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-danger"><i class="icon-trash"></i> Xóa</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" Style="display: none">
                <div class="popup-body">
                    <div class="card">
                        <div class="card-header">
                            <i class="icon-note"></i>Chi tiết liên hệ
                        </div>
                        <div class="card-body scrollbar-y-custom">
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label for="company">Tiêu đề</label>
                                        <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="company">Tên người gởi</label>
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <label for="country">SĐT người gởi</label>
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="country">Email người gởi</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="country">Chi tiết</label>
                                <CKEditor:CKEditorControl ID="txtDetail" Language="Vi" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
                            </div>
                            <div class="form-actions">
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-secondary">Tắt</asp:LinkButton>
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
        </Triggers>
    </asp:UpdatePanel>
</div>
