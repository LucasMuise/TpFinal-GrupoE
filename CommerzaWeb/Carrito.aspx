<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CommerzaWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mi Carrito</h2>

    <asp:GridView ID="gvCarrito" runat="server" CssClass="table"
        AutoGenerateColumns="False"
        OnRowCommand="gvCarrito_RowCommand">

        <Columns>
            <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Producto.Precio" DataFormatString="{0:C}" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" DataFormatString="{0:C}" />


            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkRemove" runat="server"
                        CssClass="btn btn-sm btn-danger"
                        Text="🗑"
                        CommandName="DelCart"
                        CommandArgument='<%# Eval("Producto.Id") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <h4 class="text-end">Total:
        <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold" />
    </h4>

    <asp:Button ID="btnComprar" runat="server" Text="Confirmar compra"
        CssClass="btn btn-success" OnClick="btnComprar_Click" />

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
</asp:Content>
