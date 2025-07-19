using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommerzaWeb.Datos;

namespace CommerzaWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
                Response.Redirect("~/Default.aspx");

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var d = new AccesoDatos();
            d.setearProcedimiento("usp_Usuario_Registrar");
            d.setearParametro("@Email", txtEmail.Text);
            d.setearParametro("@Password", txtPass.Text);
            d.setearParametro("@Telefono", txtTel.Text);
            d.setearParametro("@Localidad", txtLoc.Text);
            d.setearParametro("@Direccion", txtDir.Text);
            d.setearParametro("@Altura", txtAlt.Text);

            try
            {
                d.ejecutarAccion();
                lblMsg.CssClass = "text-success";
                lblMsg.Text = "¡Cuenta creada exitosamente!"; 
                limpiar();
                FormsAuthentication.SetAuthCookie(txtEmail.Text, false);
                // Redirigo a la pagina de inicio
                ScriptManager.RegisterStartupScript(
                    this,                      
                    GetType(),
                    "redirCliente",
                    "setTimeout(function(){ window.location='Default.aspx'; }, 2000);",
                    true);
            }
            catch (System.Data.SqlClient.SqlException ex) when (ex.Number == 2627) // que no se use el mismo mail
            {
                lblMsg.CssClass = "text-danger";
                lblMsg.Text = "Ese correo ya existe.";
            }
            finally { d.cerrarConexion(); }
        }

        private void limpiar()
        {
            txtEmail.Text = txtPass.Text = txtTel.Text =
            txtLoc.Text = txtDir.Text = txtAlt.Text = "";
        }
    }
}