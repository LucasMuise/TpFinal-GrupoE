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
}