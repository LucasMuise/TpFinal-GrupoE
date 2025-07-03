<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriasMarcas.aspx.cs" Inherits="CommerzaWeb.CategoriasMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  
                <asp:Label ID="lblCategorias" CssClass="form-label" runat="server" Text="CATEGORIAS:"></asp:Label>
       
                <asp:DropDownList ID="ddlCat" CssClass="form-select" runat="server"></asp:DropDownList>
  
                <asp:Label ID="lblMarcas" CssClass="form-label" runat="server" Text="MARCAS:"></asp:Label>
        
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
   

       

</asp:Content>
