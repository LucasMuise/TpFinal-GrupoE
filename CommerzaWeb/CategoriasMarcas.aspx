<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
         AutoEventWireup="true" CodeBehind="CategoriasMarcas.aspx.cs"
         Inherits="CommerzaWeb.CategoriasMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <!--  CATEGORÍAS  -->
        <div class="col-5">

            <asp:Label runat="server" Text="CATEGORÍAS:" CssClass="form-label" />

            <asp:DropDownList ID="ddlCat" runat="server" CssClass="form-select" />

            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" />

            <!-- Valido que el txtBox no quede vacio -->
            <asp:RequiredFieldValidator ID="rfvCat" runat="server"
                ControlToValidate="txtCategoria"
                ErrorMessage="Ingrese una Categoria"
                Display="Dynamic" CssClass="text-danger"
                ValidationGroup="cat" />

            <!-- Agregar categoria -->
            <asp:Button ID="btnCat" runat="server"
                        Text="Agregar categoría"
                        CssClass="btn btn-secondary mt-1"
                        OnClick="btnCat_Click"
                        ValidationGroup="cat" />

            <!-- Eliminar categoria -->
            <asp:Button ID="btnEliminar" runat="server"
                        Text="Eliminar"
                        CssClass="btn btn-danger mt-1"
                        OnClick="btnEliminar_Click"
                        CausesValidation="False" />
        </div>

        <!--  MARCAS  -->
        <div class="col-5">

            <asp:Label runat="server" Text="MARCAS:" CssClass="form-label" />

            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" />

            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />

            <!-- Valido que el txtBox no este vacio -->
            <asp:RequiredFieldValidator ID="rfvMarca" runat="server"
                ControlToValidate="txtMarca"
                ErrorMessage="Ingrese una Marca"
                Display="Dynamic" CssClass="text-danger"
                ValidationGroup="marca" />

            <!-- Agregar marca  -->
            <asp:Button ID="btnMarca" runat="server"
                        Text="Agregar marca"
                        CssClass="btn btn-secondary mt-1"
                        OnClick="btnMarca_Click"
                        ValidationGroup="marca" />

            <!-- Eliminar marca  -->
            <asp:Button ID="eliminarMarca" runat="server"
                        Text="Eliminar"
                        CssClass="btn btn-danger mt-1"
                        OnClick="eliminarMarca_Click"
                        CausesValidation="False" />
        </div>

        <!--  FEEDBACK + VOLVER  -->
        <div class="col-12 mt-3">
            <asp:Label ID="lblMensaje" runat="server" />
            <a href="Administrar.aspx" class="btn btn-primary ms-2">Volver</a>
        </div>

    </div>
</asp:Content>
