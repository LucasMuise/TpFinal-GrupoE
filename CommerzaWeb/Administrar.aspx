<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="CommerzaWeb.Administrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>BIENVENIDO</h1>

    <hr />


    <asp:GridView class="mb-4" ID="gvProductos" runat="server" OnPageIndexChanging="gvProductos_PageIndexChanging" CssClass="table"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        OnSelectedIndexChanged="gvProductos_SelectedIndexChanged"
        OnRowCommand="gvProductos_RowCommand"
        AllowPaging="true"
        PageSize="2">

        <Columns>
            <%-- <asp:BoundField HeaderText="Id" DataField="Id" />--%>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <%--    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />--%>
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />


            <asp:TemplateField HeaderText="Carrito">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkAdd" runat="server"
                        CssClass="btn btn-sm btn-success"
                        Text="+" CommandName="AddCart"
                        CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server"
                        CssClass="btn btn-link p-0"
                        CommandName="Select" Text="✍"
                        Visible='<%# IsAdmin %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <a
        id="btnAgregar"
        runat="server"
        href="About.aspx"
        class="btn btn-primary">Agregar
    </a>




    <div class="mb-4">
        <h2>Administrar marcas y categorias
        </h2>
        <a href="CategoriasMarcas.aspx" class="btn btn-primary">Administrar</a>
    </div>
</asp:Content>
