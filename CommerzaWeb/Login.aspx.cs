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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();   

            var datos = new AccesoDatos();
            datos.setearProcedimiento("usp_Usuario_Login");
            datos.setearParametro("@Email", email);
            datos.setearParametro("@Password", pass);   
            datos.ejecutarLectura();

            if (datos.Lector.Read())                    
            {
                int rolId = (int)datos.Lector["RolId"];

                FormsAuthentication.SetAuthCookie(email, false);
                Session["RolId"] = rolId;

               
                string returnUrl = Request.QueryString["ReturnUrl"] ?? "~/Default.aspx";
                Response.Redirect(returnUrl, false);
            }
            else                                       
            {
                lblError.Text = "Correo o contraseña incorrectos.";
            }

            datos.cerrarConexion();   
        }

    }
}