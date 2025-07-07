using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommerzaWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool auth = HttpContext.Current.User.Identity.IsAuthenticated;
            int rol = (int?)Session["RolId"] ?? 0;   // 1 es Administrador es cliente

            liLogin.Visible = !auth;             // mostrar “Ingresar” solo a anónimos
            liLogout.Visible = auth;             // mostrar “Salir” a usuarios logeados
            liAdmin.Visible = auth && rol == 1; // mostrar “Administrar” solo para el user admin
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}