<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recuperar.aspx.cs" Inherits="CommerzaWeb.Recuperar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-4" style="max-width: 420px;">
        <h2 class="text-center mb-4">Recuperar contraseña</h2>


        <div class="mb-3">
            <label class="form-label">Ingresa tu correo electronico</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />

            <!-- otra validacion para que este lleno  -->
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtEmail"
                Text="Tienes que agregar un correo"
                ErrorMessage="El correo es obligatorio"
                CssClass="text-danger" Display="Dynamic" />

            <!-- formato de correo @ -->
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression=".+@.+\..+"
                ErrorMessage="Formato de correo inválido"
                CssClass="text-danger" Display="Dynamic" />
        </div>

        <!-- Otro mensaje de resumen de error, ver si saco -->
        <asp:ValidationSummary runat="server"
            CssClass="text-danger mb-3"
            HeaderText="Por favor corrige:" />


        <asp:Button ID="btnEnviar" runat="server"
            Text="Enviar"
            CssClass="btn btn-primary w-100"
            OnClick="btnEnviar_Click" />

        <br />

        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-3" />
    </div>

</asp:Content>
