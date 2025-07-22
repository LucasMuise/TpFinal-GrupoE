using CommerzaWeb.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace CommerzaWeb.Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }
        private string _imagenPrincipal;
        private List<Imagen> _imagenes;

        public string ImagenPrincipal
        {
            get
            {
                // Si las imágenes ya están cargadas y hay alguna, usar la primera
                if (_imagenes != null && _imagenes.Count > 0)
                {
                    _imagenPrincipal = _imagenes.First().Url;
                }
                if (_imagenPrincipal == null && Id > 0)
                {
                    // Si no hay imágenes cargadas, traer de BD
                    _imagenPrincipal = ImagenNegocio.TraerImagenPrincipalDeProducto(Id);
                }
                return _imagenPrincipal;
            }
        }

        public List<Imagen> Imagenes
        {
            get
            {
                if (_imagenes == null && Id > 0)
                {
                    _imagenes = ImagenNegocio.ListarImagenesDeProducto(Id);
                }
                return _imagenes;
            }
        }
    }
}