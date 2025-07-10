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

                cargarCategorias();

                cargarMarcas();
            }

        }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> lista = negocio.listar();
            ddlCat.DataSource = lista;
            ddlCat.DataValueField = "Id";
            ddlCat.DataTextField = "Desc";
            ddlCat.DataBind();

        }

        private void cargarMarcas()
        {
            MarcaNegocio negocioM = new MarcaNegocio();
            List<Marca> listaM = negocioM.listar();

            ddlMarca.DataSource = listaM;
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataTextField = "Desc";
            ddlMarca.DataBind();


        }
        protected void btnCat_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevo = new Categoria();
                CategoriaNegocio negocio = new CategoriaNegocio();


                nuevo.Desc = txtCategoria.Text;
                negocio.agregarCat(nuevo);

                cargarCategorias();
                txtCategoria.Text = string.Empty;
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
                cargarMarcas();
                txtMarca.Text = string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                int id = int.Parse(ddlCat.SelectedValue);
                negocio.elminarCat(id);
                cargarCategorias();

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        protected void eliminarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                int id = int.Parse(ddlMarca.SelectedValue);
                negocio.elminarMarca(id);
                cargarMarcas();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}