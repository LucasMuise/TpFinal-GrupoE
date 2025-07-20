using CommerzaWeb.Dominio;
using CommerzaWeb.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommerzaWeb
{
    public partial class Administrar : System.Web.UI.Page
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
            btnAgregar.Visible = IsAdmin;
        }
        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            gvProductos.DataSource = negocio.listarConSp();
            gvProductos.DataBind();
        }
        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            cargarProductos();
            gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("About.aspx?id=" + id);
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