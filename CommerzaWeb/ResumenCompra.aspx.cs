using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommerzaWeb.Dominio;
using CommerzaWeb.Negocio;

namespace CommerzaWeb
{
    public partial class ResumenCompra : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var carrito = new CarritoNegocio().ObtenerTodo();
                if (carrito.Count == 0)
                {
                    Response.Redirect("~/Carrito.aspx");
                    return;
                }

                gvResumen.DataSource = carrito;
                gvResumen.DataBind();
                lblTotal.Text = carrito.Sum(i => i.Subtotal).ToString("C");

                // → Si guardaste al usuario en sesión:
                var user = Session["Usuario"] as Usuario;
                if (user != null)
                {
                    txtTel.Text = user.Telefono;
                    txtDir.Text = user.Direccion;
                    txtAltura.Text = user.DireccionAltura;
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            var items = new CarritoNegocio().ObtenerTodo();
            if (items.Count == 0)
            {
                lblMsg.Text = "El carrito está vacío.";
                lblMsg.CssClass = "text-danger d-block mt-3";
                return;
            }

            // Registro venta
            var user = (Usuario)Session["Usuario"];   
            new VentaNegocio().Registrar(user.Id, items);

            // Para vaciar carrito
            new CarritoNegocio().Vaciar();

            //  Mensaje + redirección
            lblMsg.CssClass = "text-success d-block mt-3";
            lblMsg.Text = "Compra confirmada! Gracias por tu pedido.";

            ScriptManager.RegisterStartupScript(this, GetType(), "redir",
                "setTimeout(function(){ window.location='Default.aspx'; }, 3000);", true);
        }

        protected void btnConfirmar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/ResumenCompra.aspx");
        }
    }
}