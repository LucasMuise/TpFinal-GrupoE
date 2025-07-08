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
    public partial class Carrito : System.Web.UI.Page
    {
        private readonly CarritoNegocio carritoNeg = new CarritoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            // tiene que estar logeado el usuario para ver el carrito
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=Carrito.aspx");
                return;
            }

            if (!IsPostBack)
                CargarCarrito();
        }

        private void CargarCarrito()
        {
            List<CarritoItem> lista = carritoNeg.ObtenerTodo();

            gvCarrito.DataSource = lista;
            gvCarrito.DataBind();

            lblTotal.Text = carritoNeg.Total().ToString("C");

            // Habilita el botón solo si hay algo en la lista 
            btnComprar.Enabled = lista.Count > 0;
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Viene de la columna 🗑 
            if (e.CommandName == "DelCart")
            {
                int idProd = Convert.ToInt32(e.CommandArgument);
                carritoNeg.Eliminar(idProd);  
                CargarCarrito();               
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            // guardo la venta
            carritoNeg.Vaciar();
            CargarCarrito();
            lblMensaje.Text = "¡Gracias por tu compra (simulada)!";
        }
    }
}