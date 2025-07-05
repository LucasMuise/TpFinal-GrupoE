using CommerzaWeb.Dominio;
using CommerzaWeb.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CommerzaWeb
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try

            {
                if (!IsPostBack)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    List<Categoria> lista = negocio.listar();
                    MarcaNegocio negocioM = new MarcaNegocio();
                    List<Marca> listaM = negocioM.listar();
                    ddlCat.DataSource = lista;
                    ddlCat.DataValueField = "Id";
                    ddlCat.DataTextField = "Desc";
                    ddlCat.DataBind();

                    ddlMarca.DataSource = listaM;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Desc";
                    ddlMarca.DataBind();
                    if (Request.QueryString["Id"] != null)
                    {
                        btnEliminar.Enabled = true; 
                    }
                    else
                    {
                        btnEliminar.Enabled = false; 
                    }
                
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {

                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto seleccionado = (negocio.traerPorId(int.Parse(id)));

                    Session.Add("prodSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDesc.Text = seleccionado.Descripcion;
                    ddlCat.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtStock.Text = seleccionado.Stock.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto nuevo = new Producto();
                ProductoNegocio negocio = new ProductoNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDesc.Text;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCat.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
               
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Stock = int.Parse(txtStock.Text);
                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSp(nuevo);
                   
                }
                else
                {   
                   
                    negocio.agregarConSp(nuevo);
                   
                }
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                negocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("Default.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}