<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="cart.old.ascx.cs" Inherits="ShopsDefault.UserControls.Products.cartold" %>

    <div class="prd-cart section">
        <div class="block-header">Giỏ hàng</div>
        <div class="container">
            <div class="row">
                <div class="col-8">
                    <div class="table-cart">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_Product" EnableModelValidation="True" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Eval("ProductName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="prd-amount">
                                            <div class="row">
                                            <div class="col-4"><span class="btn-amount btn_decrement"><i class="fa fa-minus"></i></span><asp:TextBox ID="txtAmount" runat="server" class="addtocart_quantity" type="text" Text='<%# Eval("Amount") %>'></asp:TextBox><span class="btn-amount btn_increment"><i class="fa fa-plus"></i></span></div>
                                            
                                            <div class="col-4 prd-price"><%# Convert.ToDouble(Eval("PriceOut")).ToString("#,##0")%></div>
                                            <div class="col-4 prd-total"><%# Convert.ToDouble(Eval("Total")).ToString("#,##0")%></div>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
                <div class="col-4">
                </div>
            </div>
        </div>
    </div>
