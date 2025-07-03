using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommerzaWeb.Negocio;

namespace CommerzaWeb
{
    public partial class _Default : Page
    {
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

        //evento del boton accion "✍"
        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("About.aspx?id="+ id);
        }
    }
}