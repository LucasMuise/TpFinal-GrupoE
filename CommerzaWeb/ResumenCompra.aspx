<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResumenCompra.aspx.cs" Inherits="CommerzaWeb.ResumenCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-4" style="max-width: 700px;">

        <h2 class="mb-4 text-center">Resumen de compra</h2>

        <!-- GRID: productos del carrito -->
        <asp:GridView ID="gvResumen" runat="server" CssClass="table"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                <asp:BoundField HeaderText="Precio" DataField="Producto.Precio"
                    DataFormatString="{0:C}" />
                <asp:BoundField HeaderText="Cant." DataField="Cantidad" />
                <asp:BoundField HeaderText="Subtotal" DataField="Subtotal"
                    DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

        <h4 class="text-end">Total:
            <asp:Label ID="lblTotal" runat="server" /></h4>
        <hr />

        <!-- Datos de envío -->
        <h5>Datos de entrega</h5>
        <asp:TextBox ID="txtTel" runat="server" CssClass="form-control mb-2"
            Placeholder="Teléfono" />
        <asp:TextBox ID="txtDir" runat="server" CssClass="form-control mb-2"
            Placeholder="Dirección" />
        <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control mb-4"
            Placeholder="Altura" />

        <!-- Forma de pago -->
        <h5>Forma de pago</h5>
        <asp:RadioButtonList ID="rbPago" runat="server" CssClass="mb-4">
            <asp:ListItem Text="Mercado Pago" Value="MP" Selected="True" />
            <asp:ListItem Text="Pago al retirar" Value="RET" />
        </asp:RadioButtonList>

        <!-- Botón -->
        <asp:Button ID="btnConfirmar" runat="server"
            Text="Confirmar compra"
            CssClass="btn btn-success w-100"
            OnClick="btnConfirmar_Click1" />

        <!-- Mensaje final -->
        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-3" />
    </div>

</asp:Content>
