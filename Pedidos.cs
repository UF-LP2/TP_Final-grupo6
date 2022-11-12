using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class Pedidos
    {
        public int ID; // identificador del pedido, se genera automaticamente de forma random
        public TipoPedido Pedido;// express normal o diferido
        public Clientes cliente; // puntero al cliente que ordeno ese pedido
        public List<Articulos> ListaDeArticulos; // es una Lista de tipo articulos !!// vamos a tener una funciòn que nos  retorne el volumen total del pedido, porque tiene que entregarse todo en una misma tirada-->volumenTotal()
                                                 // va a tener una funcion que devuelve el peso total de todos los articulos de ese pedido--> PesoTotal();
        public bool enviado; // se setea en true si fue enviado, sino se pone en false
        public int CostoEnvio; //se setea dependiendo de que vehiculo lo lleve
        public float beneficio;// volumen/peso
        public int x;//coordenadas para poder imprimir el grafo
        public int y;
        public Pedidos(int iD, TipoPedido pedido, Clientes cliente, List<Articulos> listaDeArticulos, bool enviado, int costoEnvio, float beneficio)
        {
            ID = iD;
            Pedido = pedido;
            this.cliente = cliente;
            ListaDeArticulos = listaDeArticulos;
            this.enviado = false;
            CostoEnvio = costoEnvio;
            this.beneficio = 0;
        }
        ~Pedidos() { }
    }
}
