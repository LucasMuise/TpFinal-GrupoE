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
    public partial class CategoriasMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                List<Categoria> lista = negocio.listar();
                ddlCat.DataSource = lista;
                ddlCat.DataValueField = "Id";
                ddlCat.DataTextField = "Desc";
                ddlCat.DataBind();


                MarcaNegocio negocioM = new MarcaNegocio();
                List<Marca> listaM = negocioM.listar();

                ddlMarca.DataSource = listaM;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Desc";
                ddlMarca.DataBind();

            }

        }

        protected void btnCat_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevo = new Categoria();
                CategoriaNegocio negocio = new CategoriaNegocio();


                nuevo.Desc = txtCategoria.Text;
                negocio.agregarCat(nuevo);

                Response.Redirect("CategoriasMarcas.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnMarca_Click(object sender, EventArgs e)
        {
            try
            {
                Marca nuevo = new Marca();
                MarcaNegocio negocio = new MarcaNegocio();
                nuevo.Desc = txtMarca.Text;
                negocio.agregarMarca(nuevo);
                Response.Redirect("CategoriasMarcas.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {



        }

        protected void eliminarMarca_Click(object sender, EventArgs e)
        {

        }
    }
}