<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CommerzaWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">



        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtId" class="form-label">Id</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre: </label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtDesc" class="form-label">Descripcion: </label>
                    <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtImagen" class="form-label">ImagenUrl: </label>
                    <asp:TextBox runat="server" ID="TxtImage" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio:"></asp:Label>
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />

                    <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                </div>
            </div>
            <div class="col-6">

                <div class="mb-3">
                    <label for="ddlCat" class="form-label">Categoria: </label>
                    <asp:DropDownList ID="ddlCat" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlMarca" class="form-label">Marca:</label>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>


                <div class="mb-3">
                    <asp:Label ID="lblStock" runat="server" Text="Stock:"></asp:Label>
                    <asp:TextBox ID="txtStock" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblAdmin" CssClass="form-label" runat="server" Text="Categorias y Marcas"></asp:Label>

                    <a href="CategoriasMarcas.aspx" class="btn btn-primary">Administrar</a>
                </div>


            </div>

        </div>
    </main>
</asp:Content>
