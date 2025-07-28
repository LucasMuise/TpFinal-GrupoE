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
                    <asp:TextBox runat="server" placeholder="Nombre.." ID="txtNombre" CssClass="form-control" />
                    <asp:Label ID="lblErrorNombre" runat="server" ForeColor="Red" />
                </div>
                <div class="mb-3">
                    <label for="txtDesc" class="form-label">Descripcion: </label>
                    <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control" />
                </div>



                <div class="mb-3">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio:"></asp:Label>
                    <asp:TextBox ID="txtPrecio" placeholder="ejemplo:1500" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lblErrorPrecio" runat="server" ForeColor="Red" />
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
                    <asp:TextBox ID="txtStock" TextMode="Number" PlaceHolder="Ingrese un número entero válido" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lblErrorStock" runat="server" ForeColor="Red" />
                </div>

                <div class="mb-3">
                    <label for="txtImagen" class="form-label">ImagenUrl: </label>
                    <asp:TextBox runat="server" Placeholder="agregar Url..." AutoPostBack="true" OnTextChanged="TxtImagen_TextChanged" ID="TxtImagen" CssClass="form-control" />
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" 
                        runat="server" ID="imgArticulo" Width="60%" />
                </div>


            </div>

        </div>
    </main>
</asp:Content>
