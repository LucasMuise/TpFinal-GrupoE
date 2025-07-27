<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CommerzaWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <asp:UpdatePanel ID="UpdatePanelProductos" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="container py-4">
                    <div class="row row-cols-1 row-cols-md-3 g-4">
                        <asp:Repeater ID="repProductos" runat="server" OnItemCommand="repProductos_ItemCommand">
                            <ItemTemplate>
                                <div class="col">
                                    <div class="card h-100">
                                        <img src='<%# Eval("ImagenPrincipal") %>'
                                            class="card-img-top"
                                            style="max-height: 200px; width: 100%; object-fit: contain;"
                                            alt="Imagen del producto" />
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                            <p class="card-text fw-bold">$<%# Eval("Precio", "{0:N2}") %></p>
                                            <asp:Button ID="btnVerFotos" runat="server" Text="Ver Fotos"
                                                CommandName="VerFotos" CommandArgument='<%# Eval("Id") %>'
                                                CssClass="btn btn-dark btn-sm" />
                                            <asp:Button runat="server" CssClass="btn btn-primary"
                                                CommandName="Agregar" CommandArgument='<%# Eval("Id") %>' Text="Agregar" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="repProductos" EventName="ItemCommand" />
                <asp:AsyncPostBackTrigger ControlID="btnAnterior" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSiguiente" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>


        <!-- Modal -->

        <div class="modal fade" id="fotosModal" tabindex="-1" role="dialog" aria-labelledby="fotosModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">

                    <asp:UpdatePanel ID="UpdatePanelModalContent" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-body text-center">
                                <asp:Image ID="imgModal" runat="server" CssClass="img-fluid" />
                            </div>
                            <div class="modal-footer justify-content-center">
                                <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-outline-primary" Text="⟨ Anterior" OnClick="btnAnterior_Click" />
                                <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-outline-primary" Text="Siguiente ⟩" OnClick="btnSiguiente_Click" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAnterior" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnSiguiente" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>

        <div class="toast-container position-fixed bottom-0 end-0 p-3">
            <div class="toast align-items-center text-bg-success border-0" role="alert" aria-live="assertive" aria-atomic="true" id="toastAgregado">
                <div class="d-flex">
                    <div class="toast-body">
                        Producto agregado al carrito.
                    </div>
                    <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Cerrar"></button>
                </div>
            </div>
        </div>


    </main>

    <script>
        var fotosModalInstance = null;

        function initModal() {
            if (!fotosModalInstance) {
                fotosModalInstance = new bootstrap.Modal(document.getElementById('fotosModal'));
            }
        }

        function mostrarModal() {
            if (!fotosModalInstance) {
                initModal();
            }
            fotosModalInstance.show();
        }

        // Inicializar el modal al cargar la página
        Sys.Application.add_load(function () {
            initModal();
        });
    </script>

</asp:Content>
