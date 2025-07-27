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
                
                var user = new CommerzaWeb.Dominio.Usuario
                {
                    Id = (int)datos.Lector["Id"],
                    Email = datos.Lector["Email"].ToString(),
                    Password = datos.Lector["Password"].ToString(),
                    RolId = (int)datos.Lector["RolId"],

                    Telefono = datos.Lector["Telefono"].ToString(),
                    Localidad = datos.Lector["Localidad"].ToString(),
                    Direccion = datos.Lector["Direccion"].ToString(),
                    DireccionAltura = datos.Lector["DireccionAltura"].ToString()
                };

                
                Session["Usuario"] = user;          
                Session["RolId"] = user.RolId;    

               
                FormsAuthentication.SetAuthCookie(user.Email, false);

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