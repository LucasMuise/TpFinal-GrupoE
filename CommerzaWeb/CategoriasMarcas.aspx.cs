using CommerzaWeb.Dominio;
using CommerzaWeb.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace CommerzaWeb
{
    public partial class CategoriasMarcas : Page
    {
        private readonly CategoriaNegocio catNeg = new CategoriaNegocio();
        private readonly MarcaNegocio marNeg = new MarcaNegocio();

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
            ddlCat.DataSource = catNeg.listar();
            ddlCat.DataValueField = "Id";
            ddlCat.DataTextField = "Desc";
            ddlCat.DataBind();
        }

        private void cargarMarcas()
        {
            ddlMarca.DataSource = marNeg.listar();
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataTextField = "Desc";
            ddlMarca.DataBind();
        }

        
        private void Mensaje(string texto, bool ok = true)
        {
            lblMensaje.Text = texto;
            lblMensaje.CssClass = ok ? "text-success" : "text-danger";
        }

        //AGREGAR CATEGORÍA 
        protected void btnCat_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;                    

            string nombre = txtCategoria.Text.Trim();

            bool duplicado = catNeg.listar().Any(c => c.Desc.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (duplicado)
            {
                Mensaje("La categoria ya existe", false);
                return;
            }

            catNeg.agregarCat(new Categoria { Desc = nombre });
            Mensaje("Categoría agregada exitosamente");
            cargarCategorias();
            txtCategoria.Text = string.Empty;
        }

        //ELIMINAR CATEGORÍA 
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddlCat.SelectedValue == "") return;

            int id = int.Parse(ddlCat.SelectedValue);
            catNeg.elminarCat(id);

            Mensaje("Categoría eliminada");
            cargarCategorias();
        }

        //AGREGAR MARCA 
        protected void btnMarca_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string nombre = txtMarca.Text.Trim();

            bool duplicado = marNeg.listar()
                                   .Any(m => m.Desc.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (duplicado)
            {
                Mensaje("La marca ya existe", false);
                return;
            }

            marNeg.agregarMarca(new Marca { Desc = nombre });
            Mensaje("Marca agregada exitosamente");
            cargarMarcas();
            txtMarca.Text = string.Empty;
        }

        //ELIMINAR MARCA 
        protected void eliminarMarca_Click(object sender, EventArgs e)
        {
            if (ddlMarca.SelectedValue == "") return;

            int id = int.Parse(ddlMarca.SelectedValue);
            marNeg.elminarMarca(id);

            Mensaje("Marca eliminada");
            cargarMarcas();
        }
    }
}
