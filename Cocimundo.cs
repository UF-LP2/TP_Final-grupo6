using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class Cocimundo
    {
        public string nombre;
        public Pedidos deposito;
        public List<Vehiculos> ListaVehiculos = new List<Vehiculos>(3);
        public List<Pedidos> ListaPedidos = new List<Pedidos>();
        public List<Pedidos> ListaSobrantes = new List<Pedidos>();
        // las siguientes listas estan inicialmente vacias
        public List<Pedidos> ListaDeRecorrido1 = new List<Pedidos>();
        public List<Pedidos> ListaDeRecorrido2 = new List<Pedidos>();
        public List<Pedidos> ListaDeRecorrido3 = new List<Pedidos>();
        public Cocimundo(string nombre, Pedidos deposito, List<Vehiculos> listaVehiculos, List<Pedidos> listaPedidos, List<Pedidos> listaDeRecorrido1, List<Pedidos> listaDeRecorrido2, List<Pedidos> listaDeRecorrido3, List<Pedidos> listaSobrantes)
        {
            this.nombre = nombre;
            this.deposito = deposito;
            ListaVehiculos = listaVehiculos;
            ListaPedidos = listaPedidos;
            ListaDeRecorrido1 = listaDeRecorrido1;
            ListaDeRecorrido2 = listaDeRecorrido2;
            ListaDeRecorrido3 = listaDeRecorrido3;
            ListaSobrantes = listaSobrantes;
        }
        ~Cocimundo() { }
        //RUTEO
        public void AsignarRecorrido()
        {
            int j = 0;
            while (j < ListaPedidos.Count)
            {
                if (ListaPedidos[j].cliente.Direccion == "1" || ListaPedidos[j].cliente.Direccion == "0")
                //la direccion pertenece al recorrido 1  o es de Liniers
                {
                    ListaDeRecorrido1.Add(ListaPedidos[j]);//guardo ese pedido en mi sublista del recorrido 1

                }
                else if (ListaPedidos[j].cliente.Direccion == "2")
                //la direccion pertenece al recorrido 2
                {
                   ListaDeRecorrido2.Add(ListaPedidos[j]);//guardo ese pedido en mi sublista del recorrido 2
                }
                else
                //la direccion pertenece al recorrido 3
                {
                   ListaDeRecorrido3.Add(ListaPedidos[j]);//guardo ese pedido en mi sublista del recorrido 3
                }
                j++;
            }

        }
        public void AsignarDistanciaLiniers(List<Pedidos> ListaPedidos)
        {
            for (int i = 0; i < ListaPedidos.Count; i++)
            {
                ListaPedidos[i].cliente.distancia_a_Liniers = DistanciaALiniers(ListaPedidos[i].cliente.Barrioaux);
            }
        }
        public List<Pedidos> Ruteo_Por_Recorrido(List<Pedidos> ListaDePedidos, Vehiculos vehiculo, List<Pedidos> ListaSobrantes)
        {
            int ContadorNafta = 0;
            Pedidos auxiliar; // una variable auxiliar del tipo pedido
            List<Pedidos> ListaAux = new List<Pedidos>();
           // ListaAux[1]=null;
            ListaAux.Add(deposito); //Deposito seria la direccion del donde está el deposito el primero en la lista del ruteo será Liniers que es de donde partimos, no sumamos distancia
            ListaAux.Add(Distancias(ListaAux[0], ListaDePedidos, vehiculo));//la ciudad que este mas cerca al deposito la visito primero 
            vehiculo.kmPorViaje = ListaAux[1].cliente.distancia_a_Liniers; // agregamos los km que hay a la ciudad más cercana
            for (int i = 2; i < ListaAux.Count; i++)
            {
                auxiliar = Distancias(ListaAux[ListaAux.Count], ListaDePedidos, vehiculo);
                if (auxiliar == ListaAux[i - 1]) // significa que no puedo entregar mas pedidos porque no me alcanza la nafta
                {
                    ContadorNafta++; // lo usamos para tener una condición a la hora de copiarnos la lista y eso, porque si ponemos el for directamente lo hara sin importar si la nafta me alcanzo o no
                    break; // entonces dejo de recorrer la lista 
                }
                else
                {
                    ListaAux.Add(auxiliar); // lo guardo en mi lista de pedidos, ya que la nafta me alcanza 
                }
            }
            if (ContadorNafta == 1)//significa que no me alcanzo la nafta por ende me guardo los pedidos que siguen en la lista en una auxiliar, para hacerlos en otra instancia
            {
                for (int k = 0; k < ListaSobrantes.Count; k++)
                {
                    for (int j = k; j < ListaDePedidos.Count; j++)
                    {
                        ListaSobrantes[k] = ListaDePedidos[j];
                        return ListaAux; // retorno la lista del ruteo, y me guardo en mi listasobrantes los pedidos que no he podido entregar
                    }
                }
            }
            // es la lista final del ruteo, la cual  esta ordenada de forma tal de ahorrar en el consumo de nafta
            return ListaAux;
        }
        public Pedidos Distancias(Pedidos Pedido, List<Pedidos> ListaPedidos, Vehiculos vehiculo)
        {
            int ContadorNafta = 0;
            Clientes cliente = new Clientes("a", "b", "0", "0", 0, 0, 0);
            List<Articulos> art = new List<Articulos>() { };
            Pedidos ProxPedido=new Pedidos(0,0,cliente,art,false,0,0); //es un elemento auxiliar del tipo pedido
            if (ListaPedidos.Count == 1)// significa que llegue al ultimo pedido de mi recorrido
            {
                ProxPedido = ListaPedidos[0]; // es el único elemento por ende es el primero de mi lista
                double distancia_mas_Cercano = Math.Sqrt(Math.Pow(Pedido.cliente.distancia_a_Liniers, 2) + Math.Pow(ProxPedido.cliente.distancia_a_Liniers, 2)); // vuelvo a calcular la distancia entre mi nodo actual y el elegido como mi proximo pedido
                vehiculo.kmPorViaje += (float)distancia_mas_Cercano;
                if (!VerificarNafta(vehiculo)) // si la nafta de mi vehículo no me alcanza
                {
                    ContadorNafta++;
                    vehiculo.kmPorViaje = vehiculo.kmPorViaje - (float)distancia_mas_Cercano; // retrocedo al momento previo de añadir ese pedido a mi recorrido
                    ProxPedido = Pedido; // retorno el anterior a él
                    return ProxPedido;
                }
                else
                {
                    ListaPedidos.RemoveAt(ProxPedido.ID);//la borramos porque ya pertenece a la ruta de entrega, y pasara a ser mi nuevo nodo de actual
                    return ProxPedido;
                }
            }
            for (int i = 0; i < ListaPedidos.Count(); i++) // recorro la lista de los pedidos que me quedan por hacer
            {

                if (i == 0)
                {
                    ProxPedido = ListaPedidos[i];
                }
                double distancia = Math.Sqrt(Math.Pow(Pedido.cliente.distancia_a_Liniers, 2) + Math.Pow(ListaPedidos[i].cliente.distancia_a_Liniers, 2)); //calculamos la distancia entre mi nodo  actual y los destinos que me quedan por recorrer
                double distancia_ProxPedido = Math.Sqrt(Math.Pow(ProxPedido.cliente.distancia_a_Liniers, 2) + Math.Pow(ListaPedidos[i].cliente.distancia_a_Liniers, 2));
                if (distancia < distancia_ProxPedido)// el de menor distancia pasará a ocupar el lugar de ProxPedido, al terminar de recorrer la lista tendre mi proximo pedido al que debo ir
                {
                    ProxPedido = ListaPedidos[i];

                }//guardo la ciudad a menor distancia de mi ultima ciudad visitada
            }
            double distancia_del_mas_cercano = Math.Sqrt(Math.Pow(Pedido.cliente.distancia_a_Liniers, 2) + Math.Pow(ProxPedido.cliente.distancia_a_Liniers, 2)); // vuelvo a calcular la distancia entre mi nodo actual y el elegido como mi proximo pedido
            vehiculo.kmPorViaje = vehiculo.kmPorViaje + (float)distancia_del_mas_cercano; //sumo los km que tengo que hacer para ir hasta ese próximo pedido
            if (!VerificarNafta(vehiculo))// si la nafta de mi vehículo no me alcanza
            {
                ContadorNafta++;
                vehiculo.kmPorViaje -= (float)distancia_del_mas_cercano; // retrocedo al momento previo de añadir ese pedido a mi recorrido
                ProxPedido = Pedido; // devuelvo el anterior a él
                return ProxPedido;
            }
            else
            {
                // el tamanio de la lista y sus componentes, van siendo modificados en cada iteracion de la función distancia llamada en ruteo
                ListaPedidos.Remove(ProxPedido);//la borramos porque ya pertenece a la ruta de entrega, y pasara a ser mi nuevo nodo de actual
                return ProxPedido; //devuelvo el proximo a ir
            }
        }
        public bool VerificarNafta(Vehiculos vehiculo) // vehiculo es un elemento del tipo vehiculo
        {
            float kilometros = (vehiculo.consumoNafta * vehiculo.tanqueNafta) / 100;//los kilometros que puedo recorrer con un tanque de nafta
            if (vehiculo.kmPorViaje <= kilometros * 2)//lo multiplico x2 para tener en cuenta la vuelta
            {
                return true; // si me alcanzan los litros  de nafta para hacer los km de ese recorrido

            }
            else
            {
                return false;
            }
        }
        //ListaPedidosRecorrido es una lista de elementos del tipo pedido, cocimundo es un elemento del tipo Cocimundo
        public int LineaBlanca(List<Pedidos> ListaPedidos) // retorna la cantidad de pedidos que son de linea blanca en un recorrido
        {
            int contador = 0;
            for (int i = 0; i < ListaPedidos.Count; i++)
            {
                for (int j = 0; j < ListaPedidos[i].ListaDeArticulos.Count; j++)
                {
                    if (ListaPedidos[i].ListaDeArticulos[j].CategoriaPedido == TipoLineaPedido.LineaBlanca)
                    {
                        contador++;
                    }
                }
            }
            return contador;
        }
        public void AsignarVehiculoARecorrido(int cont1, int cont2, int cont3) // funcion que compara los contadores de linea blanca
        {
            if (cont1 > cont3 && cont1 > cont2)
            {
                ListaVehiculos[0].Vehiculo = TipoVehiculo.furgon;
                if (cont2 < cont3)
                {
                   ListaVehiculos[1].Vehiculo = TipoVehiculo.camioneta;
                   ListaVehiculos[2].Vehiculo = TipoVehiculo.furgoneta;
                }
                else
                {
                   ListaVehiculos[1].Vehiculo = TipoVehiculo.furgoneta;
                   ListaVehiculos[2].Vehiculo = TipoVehiculo.camioneta;
                }
            }

            if (cont2 > cont3 && cont2 > cont1)
            {
               ListaVehiculos[1].Vehiculo = TipoVehiculo.furgon;
                if (cont1 < cont3)
                {
                   ListaVehiculos[0].Vehiculo = TipoVehiculo.camioneta;
                   ListaVehiculos[2].Vehiculo = TipoVehiculo.furgoneta;
                }
                else if (cont1 > cont3)
                {
                   ListaVehiculos[2].Vehiculo = TipoVehiculo.camioneta;
                   ListaVehiculos[0].Vehiculo = TipoVehiculo.furgoneta;
                }

            }
            if (cont3 > cont2 && cont3 > cont1)
            {
                ListaVehiculos[1].Vehiculo = TipoVehiculo.furgon;
                if (cont1 < cont2)
                {
                    ListaVehiculos[0].Vehiculo = TipoVehiculo.camioneta;
                    ListaVehiculos[1].Vehiculo = TipoVehiculo.furgoneta;
                }
                else
                {
                    ListaVehiculos[1].Vehiculo = TipoVehiculo.camioneta;
                    ListaVehiculos[0].Vehiculo = TipoVehiculo.furgoneta;
                }
            }

        }
        public void AsignarCostoEnvio(List<Pedidos> ListaPedidos, Vehiculos vehiculo)
        {
            if (vehiculo.Vehiculo == TipoVehiculo.camioneta)
            {
                for (int i = 0; i < ListaPedidos.Count(); i++)
                {
                    ListaPedidos[i].CostoEnvio = Constantes.CostoEnvioCamioneta;
                }

            }
            if (vehiculo.Vehiculo == TipoVehiculo.furgoneta)
            {
                for (int i = 0; i < ListaPedidos.Count; i++)
                {
                    ListaPedidos[i].CostoEnvio = Constantes.CostoEnvioFurgoneta;
                }

            }
            else // el envio se hara en el furgón
            {
                for (int i = 0; i < ListaPedidos.Count; i++)
                {
                    ListaPedidos[i].CostoEnvio = Constantes.CostoEnvioFurgon;
                }
            }
        }
        public int DistanciaALiniers(Distancia barrios)
        {
            int d = 0;
            switch (barrios)
            {
                case Distancia.Chacarita:
                    d = 23; break;
                case Distancia.LaBoca:
                    d = 25; break;
                case Distancia.PuertoMadero:
                    d = 18; break;
                case Distancia.Flores:
                    d = 17; break;
                case Distancia.Caballito:
                    d = 15; break;
                case Distancia.Retiro:
                    d = 27; break;
                case Distancia.Palermo:
                    d = 14; break;
                case Distancia.Belgrano:
                    d = 20; break;
                case Distancia.VillaUrquiza:
                    d = 13; break;
                case Distancia.VillaDevoto:
                    d = 12; break;
                case Distancia.VillaLugano:
                    d = 10; break;
                case Distancia.ParqueAvellaneda:
                    d = 9; break;
                case Distancia.VelezSarfield:
                    d = 8; break;
                case Distancia.MonteCastro:
                    d = 7; break;
                case Distancia.Mataderos:
                    d = 4; break;
                case Distancia.VillaLuro:
                    d = 2; break;
                case Distancia.Versalles:
                    d = 3; break;
                case Distancia.Avellaneda:
                    d = 21; break;
                case Distancia.Lanus:
                    d = 19; break;
                case Distancia.LomasDeZamora:
                    d = 18; break;
                case Distancia.LaMatanza:
                    d = 5; break;
                case Distancia.VicenteLopez:
                    d = 17; break;
                case Distancia.SanMartin:
                    d = 11; break;
                case Distancia.TresDeFebrero:
                    d = 6; break;
                case Distancia.Liniers:
                    d = 0; break;
                case Distancia.Floresta:
                    d = 5; break;
                case Distancia.VillaReal:
                    d = 5; break;
                case Distancia.VillaDelParque:
                    d = 9; break;
                case Distancia.VillaSantaRita:
                    d = 7; break;
                case Distancia.VillaGralMitre:
                    d = 8; break;
                case Distancia.LaPaternal:
                    d = 13; break;
                case Distancia.VillaCrespo:
                    d = 12; break;
                case Distancia.Agronomia:
                    d = 10; break;
                case Distancia.ParqueChas:
                    d = 12; break;
                case Distancia.VillaUrtuzar:
                    d = 18; break;
                case Distancia.VillaPueyrredon:
                    d = 10; break;
                case Distancia.Coghlan:
                    d = 16; break;
                case Distancia.Saavedra:
                    d = 14; break;
                case Distancia.Nuñez:
                    d = 18; break;
                case Distancia.Colegiales:
                    d = 19; break;
                case Distancia.Recoleta:
                    d = 27; break;
                case Distancia.Almagro:
                    d = 15; break;
                case Distancia.ParqueChacabuco:
                    d = 12; break;
                case Distancia.VillaRiachuelo:
                    d = 10; break;
                case Distancia.VillaSoldati:
                    d = 10; break;
                case Distancia.NuevaPompeya:
                    d = 11; break;
                case Distancia.Boedo:
                    d = 13; break;
                case Distancia.Barracas:
                    d = 19; break;
                case Distancia.ParquePatricios:
                    d = 17; break;
                case Distancia.Constitucion:
                    d = 17; break;
                case Distancia.SanTelmo:
                    d = 17; break;
                case Distancia.SanNicolas:
                    d = 19; break;
                case Distancia.Montserrat:
                    d = 17; break;
                case Distancia.Balvanera:
                    d = 17; break;
                case Distancia.SanCristobal:
                    d = 14; break;
                case Distancia.SanIsidro:
                    d = 27; break;
                case Distancia.Ituzaingo:
                    d = 19; break;
                case Distancia.Hurlingham:
                    d = 14; break;
                case Distancia.Moron:
                    d = 14; break;
            }
            return d;
        }
        public void AsignarCoordenadas(List<Pedidos> PedidosACargar)
        {
            Distancia barrio;
            for (int i = 0; i < PedidosACargar.Count; i++)
            {
                barrio = PedidosACargar[i].cliente.Barrioaux;
                switch (barrio)
                {
                    case Distancia.Chacarita:
                        PedidosACargar[i].x = 15;
                        PedidosACargar[i].y = 16;
                        break;
                    case Distancia.LaBoca:
                        PedidosACargar[i].x = 21;
                        PedidosACargar[i].y = 23;
                        break;
                    case Distancia.PuertoMadero:
                        PedidosACargar[i].x = 17;
                        PedidosACargar[i].y = 23;
                        break;
                    case Distancia.Flores:
                        PedidosACargar[i].x = 21;
                        PedidosACargar[i].y = 16;
                        break;
                    case Distancia.Caballito:
                        PedidosACargar[i].x = 18;
                        PedidosACargar[i].y = 17;
                        break;
                    case Distancia.Retiro:
                        PedidosACargar[i].x = 15;
                        PedidosACargar[i].y = 22;
                        break;
                    case Distancia.Palermo:
                        PedidosACargar[i].x = 14;
                        PedidosACargar[i].y = 18;
                        break;
                    case Distancia.Belgrano:
                        PedidosACargar[i].x = 12;
                        PedidosACargar[i].y = 16;
                        break;
                    case Distancia.VillaUrquiza:
                        PedidosACargar[i].x = 13;
                        PedidosACargar[i].y = 14;
                        break;
                    case Distancia.VillaDevoto:
                        PedidosACargar[i].x = 17;
                        PedidosACargar[i].y = 12;
                        break;
                    case Distancia.VillaLugano:
                        PedidosACargar[i].x = 25;
                        PedidosACargar[i].y = 15;
                        break;
                    case Distancia.ParqueAvellaneda:
                        PedidosACargar[i].x = 22;
                        PedidosACargar[i].y = 15;
                        break;
                    case Distancia.VelezSarfield:
                        PedidosACargar[i].x = 20;
                        PedidosACargar[i].y = 14;
                        break;
                    case Distancia.MonteCastro:
                        PedidosACargar[i].x = 19;
                        PedidosACargar[i].y = 13;
                        break;
                    case Distancia.Mataderos:
                        PedidosACargar[i].x = 23;
                        PedidosACargar[i].y = 13;
                        break;
                    case Distancia.VillaLuro:
                        PedidosACargar[i].x = 21;
                        PedidosACargar[i].y = 13;
                        break;
                    case Distancia.Versalles:
                        PedidosACargar[i].x = 20;
                        PedidosACargar[i].y = 12;
                        break;
                    case Distancia.Avellaneda:
                        PedidosACargar[i].x = 24;
                        PedidosACargar[i].y = 23;
                        break;
                    case Distancia.Lanus:
                        PedidosACargar[i].x = 29;
                        PedidosACargar[i].y = 20;
                        break;
                    case Distancia.LomasDeZamora:
                        PedidosACargar[i].x = 31;
                        PedidosACargar[i].y = 17;
                        break;
                    case Distancia.LaMatanza:
                        PedidosACargar[i].x = 28;
                        PedidosACargar[i].y = 5;
                        break;
                    case Distancia.VicenteLopez:
                        PedidosACargar[i].x = 8;
                        PedidosACargar[i].y = 15;
                        break;
                    case Distancia.SanMartin:
                        PedidosACargar[i].x = 14;
                        PedidosACargar[i].y = 11;
                        break;
                    case Distancia.TresDeFebrero:
                        PedidosACargar[i].x = 18;
                        PedidosACargar[i].y = 9;
                        break;
                    case Distancia.Liniers:
                        PedidosACargar[i].x = 22;
                        PedidosACargar[i].y = 12;
                        break;
                    case Distancia.Floresta:
                        PedidosACargar[i].x = 19;
                        PedidosACargar[i].y = 14;
                        break;
                    case Distancia.VillaReal:
                        PedidosACargar[i].x = 19;
                        PedidosACargar[i].y = 12;
                        break;
                    case Distancia.VillaDelParque:
                        PedidosACargar[i].x = 16;
                        PedidosACargar[i].y = 14;
                        break;
                    case Distancia.VillaSantaRita:
                        PedidosACargar[i].x = 18;
                        PedidosACargar[i].y = 14;
                        break;
                    case Distancia.VillaGralMitre:
                        PedidosACargar[i].x = 18;
                        PedidosACargar[i].y = 15;
                        break;
                    case Distancia.LaPaternal:
                        PedidosACargar[i].x = 16;
                        PedidosACargar[i].y = 15;
                        break;
                    case Distancia.VillaCrespo:
                        PedidosACargar[i].x = 16;
                        PedidosACargar[i].y = 17;
                        break;
                    case Distancia.Agronomia:
                        PedidosACargar[i].x = 16;
                        PedidosACargar[i].y = 14;
                        break;
                    case Distancia.ParqueChas:
                        PedidosACargar[i].x = 15;
                        PedidosACargar[i].y = 15;
                        break;
                    case Distancia.VillaUrtuzar:
                        PedidosACargar[i].x = 14;
                        PedidosACargar[i].y = 16;
                        break;
                    case Distancia.VillaPueyrredon:
                        PedidosACargar[i].x = 14;
                        PedidosACargar[i].y = 13;
                        break;
                    case Distancia.Coghlan:
                        PedidosACargar[i].x = 12;
                        PedidosACargar[i].y = 15;
                        break;
                    case Distancia.Saavedra:
                        PedidosACargar[i].x = 11;
                        PedidosACargar[i].y = 14;
                        break;
                    case Distancia.Nuñez:
                        PedidosACargar[i].x = 10;
                        PedidosACargar[i].y = 16;
                        break;
                    case Distancia.Colegiales:
                        PedidosACargar[i].x = 14;
                        PedidosACargar[i].y = 16;
                        break;
                    case Distancia.Recoleta:
                        PedidosACargar[i].x = 16;
                        PedidosACargar[i].y = 20;
                        break;
                    case Distancia.Almagro:
                        PedidosACargar[i].x = 17;
                        PedidosACargar[i].y = 19;
                        break;
                    case Distancia.ParqueChacabuco:
                        PedidosACargar[i].x = 21;
                        PedidosACargar[i].y = 18;
                        break;
                    case Distancia.VillaRiachuelo:
                        PedidosACargar[i].x = 27;
                        PedidosACargar[i].y = 16;
                        break;
                    case Distancia.VillaSoldati:
                        PedidosACargar[i].x = 24;
                        PedidosACargar[i].y = 17;
                        break;
                    case Distancia.NuevaPompeya:
                        PedidosACargar[i].x = 22;
                        PedidosACargar[i].y = 19;
                        break;
                    case Distancia.Boedo:
                        PedidosACargar[i].x = 20;
                        PedidosACargar[i].y = 19;
                        break;
                    case Distancia.Barracas:
                        PedidosACargar[i].x = 22;
                        PedidosACargar[i].y = 21;
                        break;
                    case Distancia.ParquePatricios:
                        PedidosACargar[i].x = 21;
                        PedidosACargar[i].y = 20;
                        break;
                    case Distancia.Constitucion:
                        PedidosACargar[i].x = 19;
                        PedidosACargar[i].y = 21;
                        break;
                    case Distancia.SanTelmo:
                        PedidosACargar[i].x = 19;
                        PedidosACargar[i].y = 22;
                        break;
                    case Distancia.SanNicolas:
                        PedidosACargar[i].x = 17;
                        PedidosACargar[i].y = 21;
                        break;
                    case Distancia.Montserrat:
                        PedidosACargar[i].x = 18;
                        PedidosACargar[i].y = 21;
                        break;
                    case Distancia.Balvanera:
                        PedidosACargar[i].x = 18;
                        PedidosACargar[i].y = 20;
                        break;
                    case Distancia.SanCristobal:
                        PedidosACargar[i].x = 19;
                        PedidosACargar[i].y = 20;
                        break;
                    case Distancia.SanIsidro:
                        PedidosACargar[i].x = 1;
                        PedidosACargar[i].y = 11;
                        break;
                    case Distancia.Ituzaingo:
                        PedidosACargar[i].x = 23;
                        PedidosACargar[i].y = 1;
                        break;
                    case Distancia.Hurlingham:
                        PedidosACargar[i].x = 15;
                        PedidosACargar[i].y = 4;
                        break;
                    case Distancia.Moron:
                        PedidosACargar[i].x = 23;
                        PedidosACargar[i].y = 5;
                        break;

                }
            }
        }

        //ALMACENAMIENTO
        public float VolumenPedidos(Pedidos Pedido)
        {
            float vol = 0;
            for (int j = 0; j < Pedido.ListaDeArticulos.Count; j++)
            {
                vol = Pedido.ListaDeArticulos[j].ancho * Pedido.ListaDeArticulos[j].largo * Pedido.ListaDeArticulos[j].alto;
            }

            return vol; //retorno el volumen de este pedido
        }
        public float PesoPedidos(Pedidos Pedido)
        {
            float peso = 0;

            for (int j = 0; j < Pedido.ListaDeArticulos.Count; j++)
            {
                peso += Pedido.ListaDeArticulos[j].Peso;
            }

            return peso; //retorno el peso de este pedido
        }
        public int[] Beneficio(List<Pedidos> ListaPedidos)
        {
            int[] beneficios = new int[ListaPedidos.Count];
            for (int i = 0; i < ListaPedidos.Count; i++)
            {
                if (ListaPedidos[i].Pedido == TipoPedido.express)
                {
                    beneficios[i] = (int)VolumenPedidos(ListaPedidos[i]) / (int)PesoPedidos(ListaPedidos[i]) + 100; //mayor prioridad, le sumo 100
                }
                else if (ListaPedidos[i].Pedido == TipoPedido.normal)
                {
                    beneficios[i] = (int)VolumenPedidos(ListaPedidos[i]) / (int)PesoPedidos(ListaPedidos[i]) + 50;//pedidos normales tienen prioridad media
                }
                else
                {
                    beneficios[i] = (int)VolumenPedidos(ListaPedidos[i]) / (int)PesoPedidos(ListaPedidos[i]);//pedidos diferidos < prioridad
                }
            }
            return beneficios;
        }
        public void ElementosACargar(List<Pedidos> ListaPedidos, Vehiculos vehiculo, List<Pedidos> ListaSobrantes, List<Pedidos> PedidosACargar)
        {
            int i, j;
            int[] beneficios = Beneficio(ListaPedidos);
            float contpeso = 0;

            int[,] matriz = new int[ListaPedidos.Count + 1, (int)vehiculo.volumenDeCarga + 1]; //creamos la matriz

            //matriz[i][j] nos da el maximo valor i de pedidos que se pueden cargar con capacidad de volumen j

            //inicializamos matriz[0][j] =0 para todo 0≤j≤V

            for (j = 0; j <= vehiculo.volumenDeCarga; j++)

            {
                matriz[0, j] = 0;
            }
            //inicializamos matriz[i][0] para 0≤i≤N. No puedo agregar mas pedidos si no tengo lugar

            for (i = 0; i <= ListaPedidos.Count; i++)

            { matriz[i, 0] = 0; }


            //llenamos la matriz de forma ascendente

            for (i = 1; i < ListaPedidos.Count; i++)
            {
                for (j = 0; j <= vehiculo.volumenDeCarga; j++)
                {
                    //verificamos si el peso del articulo i es menor o igual a la capacidad del volumen, lo tomo como máximo una vez incluyendo el articulo actual y otra vez sin incluirlo (me fijo cuando tengo max beneficio)

                    if (VolumenPedidos(ListaPedidos[i - 1]) <= j && contpeso + PesoPedidos(ListaPedidos[i - 1]) <= vehiculo.pesoMaxDeCarga)
                    {
                        contpeso += PesoPedidos(ListaPedidos[i - 1]);
                        matriz[i, j] = Math.Max(beneficios[i - 1] + matriz[i - 1, j - (int)VolumenPedidos(ListaPedidos[i - 1])], matriz[i - 1, j]);

                    }
                    else //no se puede incluir el elemento actual
                    {
                        matriz[i, j] = matriz[i - 1, j];
                    }
                }
            }
            for (i = ListaPedidos.Count; i < 0; i--)
            {
                for (j = (int)vehiculo.volumenDeCarga; j < 0; j--)
                {
                    if (matriz[i, j] == matriz[i - 1, j])
                    {
                        ListaSobrantes.Add(ListaPedidos[i]);
                    }
                    else
                    {
                        PedidosACargar.Add(ListaPedidos[i]);
                        ListaPedidos.RemoveAt(i);
                    }
                }
            }
            //una vez cargados los pedidos que ENTRAN en el camion, los ordenamos por orden de cercania entre nodos

        }

        /*public void VerificarPeso(List<Pedidos> PedidosACargar, Vehiculos vehiculo, List<Pedidos> ListaSobrantes)
        {
            List<Pedidos> ListaAux;

            float peso = 0;
            int i = 0;
            while (peso <= vehiculo.pesoMaxDeCarga)
            {
                peso += PesoPedidos(PedidosACargar[i]);
                i++;
            }
            for (int k = i; k < PedidosACargar.Count; k++)
            {
                ListaSobrantes.Add(PedidosACargar[k]);
                PedidosACargar.Remove(PedidosACargar[k]);
            }//guardo los pedidos que no entran en la lista de pedidos que se mandan en el siguiente viaje y los que entran los paso a la lista a cargar

        }*/
        public void IniciarReparto(List<Pedidos> PedidosACargar, Vehiculos vehiculo)
        {
            for (int i = 0; i < PedidosACargar.Count; i++)
            {
                PedidosACargar[i].enviado = true; //modificamos el estado de entrega
                vehiculo.cantViajes++;
            }
        }
        public void FinDelDia(Vehiculos vehiculo)
        {
            vehiculo.danio += (float)0.1;
            //le incrementamos el daño respecto de la depreciacion anual del vehiculo
        }
    }
}