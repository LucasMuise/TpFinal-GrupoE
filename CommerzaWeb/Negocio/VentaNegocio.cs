using System.Collections.Generic;
using CommerzaWeb.Datos;
using CommerzaWeb.Dominio;

namespace CommerzaWeb.Negocio
{
    public class VentaNegocio
    {
        public void Registrar(int clienteId, List<CarritoItem> items)
        {
            foreach (var it in items)
            {
                var d = new AccesoDatos();
                d.setearProcedimiento("usp_RegistrarVenta");
                d.setearParametro("@ClienteId", clienteId);
                d.setearParametro("@ProductoId", it.Producto.Id);
                d.setearParametro("@Cantidad", it.Cantidad);
                d.setearParametro("@Precio", it.Producto.Precio);
                d.ejecutarAccion();
                d.cerrarConexion();
            }
        }
    }
}
