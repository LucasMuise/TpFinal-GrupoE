using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommerzaWeb.Datos;

namespace CommerzaWeb
{
    public partial class Recuperar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;   

            var d = new AccesoDatos();
            d.setearConsuta("SELECT COUNT(*) FROM Usuarios WHERE Email = @mail");
            d.setearParametro("@mail", txtEmail.Text);

            try
            {
                d.ejecutarLectura();
                bool existe = false;
                if (d.Lector.Read())
                    existe = (int)d.Lector[0] > 0;
                d.cerrarConexion();

                if (existe)
                {
                    lblMsg.CssClass = "text-success";
                    lblMsg.Text = "Revisa tu correo, recibirás un link para restablecer la contraseña.";
                }
                else
                {
                    lblMsg.CssClass = "text-danger";
                    lblMsg.Text = "El correo no existe dentro de nuestros clientes.";
                }
            }
            catch (Exception ex)
            {
                d.cerrarConexion();
                lblMsg.CssClass = "text-danger";
                lblMsg.Text = "Ocurrió un error: " + ex.Message;
            }
        }
    }
}