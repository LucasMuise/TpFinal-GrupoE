<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CommerzaWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-4" style="max-width: 420px;">
        <h2 class="text-center mb-4">Crear cuenta</h2>

        <!-- Email -->
        <div class="mb-3">
            <label class="form-label">Correo</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />

            <!-- valido que sea obligatorio -->
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="El correo es obligatorio"
                CssClass="text-danger" Display="Dynamic" />

            <!-- valido que tenga @ y formato correcto-->
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="Formato de correo inválido"
                CssClass="text-danger" Display="Dynamic" />
        </div>


        <!-- Password -->
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control" />
            <asp:RequiredFieldValidator ControlToValidate="txtPass" runat="server"
                ErrorMessage="Falta crear una contraseña" CssClass="text-danger" Display="Dynamic" />
        </div>


        <!-- Teléfono -->
        <div class="mb-3">
            <label class="form-label">Teléfono</label>
            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" />

            
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtTel"
                ErrorMessage="El teléfono es obligatorio"
                CssClass="text-danger" Display="Dynamic" />

            <!-- valido solo numeros -->
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtTel"
                ValidationExpression="^\d{7,15}$"
                ErrorMessage="Sólo dígitos (7‑15)"
                CssClass="text-danger" Display="Dynamic" />
        </div>

        <!-- Localidad -->
        <div class="mb-3">
            <label class="form-label">Localidad</label>
            <asp:TextBox ID="txtLoc" runat="server" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtLoc"
                ErrorMessage="La localidad es obligatoria"
                CssClass="text-danger" Display="Dynamic" />
        </div>

        <!-- Dirección -->
        <div class="mb-3">
            <label class="form-label">Dirección</label>
            <asp:TextBox ID="txtDir" runat="server" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtDir"
                ErrorMessage="La dirección es obligatoria"
                CssClass="text-danger" Display="Dynamic" />
        </div>

        <!-- Altura -->
        <div class="mb-4">
            <label class="form-label">Altura</label>
            <asp:TextBox ID="txtAlt" runat="server" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtAlt"
                ErrorMessage="La altura es obligatoria"
                CssClass="text-danger" Display="Dynamic" />

            <!-- otra vez valido numeros -->
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtAlt"
                ValidationExpression="^\d+$"
                ErrorMessage="Sólo números"
                CssClass="text-danger" Display="Dynamic" />
        </div>

        <asp:ValidationSummary ID="vs" runat="server"
            CssClass="text-danger mb-3"
            DisplayMode="BulletList"
            HeaderText="Por favor corrige:" />

        <!-- Botón y label -->
        <asp:Button ID="btnReg" runat="server" Text="Registrarme"
            CssClass="btn btn-primary w-100"
            OnClick="btnReg_Click" />
        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-3" />
    </div>

</asp:Content>
