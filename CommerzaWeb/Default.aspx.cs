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
        protected bool IsAdmin
        {
            get { return (int?)Session["RolId"] == 1; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProductos();
            }
        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            gvProductos.DataSource = negocio.listarConSp();
            gvProductos.DataBind();
        }

        //evento del boton accion 
        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("About.aspx?id="+ id);
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddCart")
            {
                int idProd = Convert.ToInt32(e.CommandArgument);

               
                var prodNeg = new ProductoNegocio();
                Producto prod = prodNeg.traerPorId(idProd);

               
                var carritoNeg = new CarritoNegocio();
                carritoNeg.Agregar(prod);

               
            }
        }
    }
}