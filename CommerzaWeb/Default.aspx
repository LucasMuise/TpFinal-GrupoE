<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CommerzaWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <%--<section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Bienvenidos a Nuestra WB </h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Getting started</h2>
                <p>
                    ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Get more libraries</h2>
                <p>
                    NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Web Hosting</h2>
                <p>
                    You can easily find a web hosting company that offers the right mix of features and price for your applications.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>--%>
        <%--  <div class="row">
            <h2>Catálogo de Productos</h2>
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" CssClass="table" />
            <columns>
            >
            </columns>

        </div>--%>
        <h1>
            LISTADO PRODUCTOS
        </h1>

        <hr />

        <asp:GridView ID="gvProductos" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" DataKeyNames="id" CssClass="table" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:BoundField HeaderText="Stock" DataField="Stock" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />
            </Columns>


        </asp:GridView>
         <a href="About.aspx" class="btn btn-primary">Agregar</a>
    </main>

</asp:Content>
