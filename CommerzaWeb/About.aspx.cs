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
        protected bool IsAdmin
        {
            get { return (int?)Session["RolId"] == 1; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsAdmin)
            {

                Response.Redirect("Default.aspx");
            }
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
                        TxtImagen.Enabled = true;
                    }
                    else
                    {
                        btnEliminar.Enabled = false;
                        TxtImagen.Enabled = false;
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

                // Validar nombre
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblErrorNombre.Text = "El nombre del producto es obligatorio.";
                    return;
                }
                //validar precio
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                {
                    lblErrorPrecio.Text = "Ingrese un precio válido.";
                    return;
                }
                ///validar stock
                if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
                {
                    lblErrorStock.Text = "Campo obligatorio, ingrese valor válido";
                    return;
                }


                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDesc.Text;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCat.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Stock = int.Parse(txtStock.Text);
                ImagenNegocio neg = new ImagenNegocio();
                Imagen img = new Imagen();
                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSp(nuevo);
                    if (!string.IsNullOrWhiteSpace(TxtImagen.Text))
                    {
                        img.IdProducto = nuevo.Id;
                        img.Url = TxtImagen.Text.Trim();
                        neg.agregarImagen(img);
                    }
                }
                else
                {

                    negocio.agregarConSp(nuevo);

                }
                Response.Redirect("Administrar.aspx", false);
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
                Response.Redirect("Administrar.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void TxtImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = TxtImagen.Text;
        }
    }
}