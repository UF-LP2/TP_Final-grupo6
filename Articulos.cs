using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class Articulos
    {
        public TipoLineaPedido CategoriaPedido;
        public TipoArticulo TipoDeArticulo;//enum con todos los articulos
        public float Peso; // peso en kg del producto teniendo en cuenta su envoltorio TipoLineaPedido CategoriaPedido; // si pertenece a linea blanca, etc
        public float largo; //Volumen es un enum donde definimos los volumenes d cada articulo
        public float ancho;
        public float alto;
        public Articulos(TipoLineaPedido categoriaPedido, TipoArticulo tipoDeArticulo, float peso, float largo, float ancho, float alto)
        {
            CategoriaPedido = categoriaPedido;
            TipoDeArticulo = tipoDeArticulo;
            Peso = peso;
            this.largo = largo;
            this.ancho = ancho;
            this.alto = alto;
        }
        ~Articulos() { }
    }
}
