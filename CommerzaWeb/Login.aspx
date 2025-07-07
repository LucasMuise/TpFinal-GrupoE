<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master"
         AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CommerzaWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:420px;">
        <asp:Panel runat="server" CssClass="card p-4 shadow-sm">
            <h3 class="text-center mb-4">Iniciar sesión</h3>

            <asp:Label runat="server" AssociatedControlID="txtEmail" Text="Correo" />
            <asp:TextBox ID="txtEmail" runat="server"
                         CssClass="form-control mb-3" TextMode="Email" />

            <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Contraseña" />
            <asp:TextBox ID="txtPassword" runat="server"
                         CssClass="form-control mb-3" TextMode="Password" />

            <asp:Label ID="lblError" runat="server" ForeColor="Red" />

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                        CssClass="btn btn-primary w-100 mt-3"
                        OnClick="btnLogin_Click" />
        </asp:Panel>
    </div>
</asp:Content>
