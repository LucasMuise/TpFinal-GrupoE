<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriasMarcas.aspx.cs" Inherits="CommerzaWeb.CategoriasMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
            <div class="col-5">
                <asp:Label ID="lblCategorias" CssClass="form-label" runat="server" Text="CATEGORIAS:"></asp:Label>

                <asp:DropDownList ID="ddlCat" CssClass="form-select" runat="server"></asp:DropDownList>
                
                <asp:TextBox ID="txtCategoria" CssClass="form-control" runat="server"></asp:TextBox>
              
                <asp:Button ID="btnCat" CssClass="btn btn-secondary" OnClick="btnCat_Click" runat="server" Text="Agregar Categoria" />

                <asp:Button ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />
            </div>
            <div class="col-5">
                <asp:Label ID="lblMarcas" CssClass="form-label" runat="server" Text="MARCAS:"></asp:Label>
              
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
              
                <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox>
               
                <asp:Button ID="btnMarca" CssClass="btn btn-secondary" OnClick="btnMarca_Click" runat="server" Text="Agregar Marca" />
                <asp:Button ID="eliminarMarca" cssClass="btn btn-danger" onClick="eliminarMarca_Click" runat="server" Text="Eliminar" />
            </div>

           
        </div>

  
       
  
        
   

       

</asp:Content>
