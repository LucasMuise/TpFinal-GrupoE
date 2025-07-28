using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommerzaWeb.Negocio;
using CommerzaWeb.Dominio;

namespace CommerzaWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                cargarProductos();
        }

        private void cargarProductos()
        {
            var negocio = new ProductoNegocio();
          
            Session.Add("listaProductos", negocio.listarConSp());
            repProductos.DataSource = Session["listaProductos"]; 
            repProductos.DataBind();
        }

        protected void repProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int idProd = Convert.ToInt32(e.CommandArgument);
            var prodNeg = new ProductoNegocio();

            if (e.CommandName == "Agregar")
            {
                var carrito = new CarritoNegocio();
                carrito.Agregar(prodNeg.traerPorId(idProd));

                ScriptManager.RegisterStartupScript(this, GetType(), "productoAgregado",
    "var toast = new bootstrap.Toast(document.getElementById('toastAgregado')); toast.show();", true);

            }
            else if (e.CommandName == "VerFotos")
            {
                var producto = prodNeg.traerPorId(idProd);

                if (producto.Imagenes != null && producto.Imagenes.Count > 0)
                {
                    Session["ImagenesModal"] = producto.Imagenes;
                    Session["IndexImagen"] = 0;

                    string script = $@"
                        document.getElementById('MainContent_imgModal').src = '{producto.Imagenes[0].Url}';
                        var modal = new bootstrap.Modal(document.getElementById('fotosModal'));
                        modal.show();";

                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", script, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sinImagenes", "alert('Este producto no tiene imágenes.');", true);
                }
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (Session["ImagenesModal"] is List<Imagen> imagenes && Session["IndexImagen"] is int index)
            {
                index = (index - 1 + imagenes.Count) % imagenes.Count;
                Session["IndexImagen"] = index;
                imgModal.ImageUrl = imagenes[index].Url;

                // Reabrir modal tras el postback parcial
                string script = "mostrarModal();";
                ScriptManager.RegisterStartupScript(this, GetType(), "abrirModal", script, true);

            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Session["ImagenesModal"] is List<Imagen> imagenes && Session["IndexImagen"] is int index)
            {
                index = (index + 1) % imagenes.Count;
                Session["IndexImagen"] = index;
                imgModal.ImageUrl = imagenes[index].Url;

                // Reabrir modal tras el postback parcial
                string script = "mostrarModal();";
                ScriptManager.RegisterStartupScript(this, GetType(), "abrirModal", script, true);

            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> lista = (List<Producto>)Session["listaProductos"];
            List<Producto> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            repProductos.DataSource = listaFiltrada;
            repProductos.DataBind();
        }
    }
}