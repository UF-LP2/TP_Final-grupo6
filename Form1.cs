using csvfiles;
using System.Windows.Forms;

namespace tp_final
{
    public partial class Form1 : Form
    {
        Cocimundo cocimundo;

        Vehiculos furgon;
        Vehiculos furgoneta;
        Vehiculos camioneta;

        List<Vehiculos> ListaDeVehiculos;
        Articulos heladera;
        Articulos lavarropa;
        Articulos cocina;
        Articulos calefon;
        Articulos termotanque;
        Articulos secarropas;
        Articulos microondas;
        Articulos freezer;
        Articulos licuadora;
        Articulos exprimidor;
        Articulos rallador;
        Articulos cafetera;
        Articulos molinillo;
        Articulos computadora;
        Articulos impresora;
        Articulos televisor;
        Articulos celular;

        List<Articulos> ListaArticulos1;
        List<Articulos> ListaArticulos2;
        List<Articulos> ListaArticulos3;
        List<Articulos> ListaArticulos4;
        List<Articulos> ListaArticulos5;
        List<Articulos> Listadeposito;

        Clientes cliente1;
        Clientes cliente2;
        Clientes cliente3;
        Clientes cliente4;
        Clientes cliente5;
        Clientes cliente6;

        Pedidos Pedido1;
        Pedidos Pedido2;
        Pedidos Pedido3;
        Pedidos Pedido4;
        Pedidos Pedido5;
        Pedidos deposito;

        List<Pedidos> ListaPedidos;
        List<Pedidos> ListaRecorrido1;
        List<Pedidos> ListaRecorrido2;
        List<Pedidos> ListaRecorrido3;
        List<Pedidos> ListaSobrantes;

        public Form1()
        {   
            furgon = new Vehiculos(TipoVehiculo.furgon, 4900,(Single)10.8,(Single)8.9,90,0,0,0);
            furgoneta = new Vehiculos(TipoVehiculo.furgoneta,3485,(Single)16.08, (Single)6.9,90,0,0,0);
            camioneta = new Vehiculos(TipoVehiculo.camioneta, 1185, (Single)5.4935, (Single)6.1, 50, 0, 0, 0);

            ListaDeVehiculos = new List<Vehiculos>();
            ListaDeVehiculos.Add(furgon);
            ListaDeVehiculos.Add(furgoneta);
            ListaDeVehiculos.Add(camioneta);

            heladera = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.heladera, 55, (Single)0.6, 12, 10);
            lavarropa = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.lavarropa, 70,(Single)23,12,6);
            cocina = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.cocina, 35,3,23,3);
            calefon = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.calefon, 10, 8,4,2);
            termotanque = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.termotanque,25, 7,12,4);
            secarropas = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.secarropa, 34, 9,6,13);
            microondas = new Articulos(TipoLineaPedido.Electrodomesticos, TipoArticulo.microondas, 18, 12,4,6);
            freezer = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.freezer, 50, 2,6,3);
            licuadora = new Articulos(TipoLineaPedido.Electrodomesticos, TipoArticulo.licuadora, 3, 1,3,2);
            exprimidor = new Articulos(TipoLineaPedido.Electrodomesticos, TipoArticulo.exprimidor, 3, 1,1,1);
            rallador = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.rallador, 55, 2,1,1);
            cafetera = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.cafetera, 55, 2,2,1);
            molinillo = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.molinillo, 55, 3,2,2);
            computadora = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.computadora, 55, 1,2,1);
            impresora = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.impresora, 55, 2,1,1);
            televisor = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.televisor, 55, 4,1,1);
            celular = new Articulos(TipoLineaPedido.LineaBlanca, TipoArticulo.celular, 55, 1,(Single)0.6,(Single)0.5);

           ListaArticulos1=new List<Articulos>();
           ListaArticulos2 = new List<Articulos>();
           ListaArticulos3 = new List<Articulos>();
           ListaArticulos4 = new List<Articulos>();
           ListaArticulos5 = new List<Articulos>();
           Listadeposito=new List<Articulos>();
            ListaArticulos1.Add(cafetera);
            ListaArticulos2.Add(licuadora);
            ListaArticulos2.Add(freezer);
            ListaArticulos2.Add(molinillo);
            ListaArticulos3.Add(rallador);
            ListaArticulos4.Add(televisor);
            ListaArticulos4.Add(celular);
            ListaArticulos5.Add(televisor);

            cliente1 =new Clientes("pepe","juarez","34567892","Amoedo 1234",0,Barrio.VelezSarfield,Distancia.VelezSarfield);
            cliente2 = new Clientes("maria", "perez", "21342564", "Moreno 654", 0, Barrio.Almagro, Distancia.Almagro);
            cliente3 = new Clientes("pilar", "ruiz", "45665231", "12 de octubre 123", 0, Barrio.Avellaneda, Distancia.Avellaneda);
            cliente4 = new Clientes("Pedro", "Gomez", "21432560", "Belgrano 1014", 0, Barrio.Caballito, Distancia.Caballito);
            cliente5 = new Clientes("Sofia", "Lombardi", "44534218", "Alberdi 560", 0, Barrio.PuertoMadero, Distancia.PuertoMadero);
            cliente6 = new Clientes("deposito", "deposito", "0", "Liniers", 0, Barrio.Liniers, Distancia.Liniers);

           Pedido1 =new Pedidos(12,TipoPedido.express,cliente1,ListaArticulos3,false,0,0);
           Pedido2 = new Pedidos(0134, TipoPedido.normal, cliente2, ListaArticulos4, false, 0, 0);
           Pedido3 = new Pedidos(312, TipoPedido.normal, cliente3, ListaArticulos5, false, 0, 0);
           Pedido4 = new Pedidos(12, TipoPedido.express, cliente5, ListaArticulos2, false, 0, 0);
           Pedido5 = new Pedidos(111, TipoPedido.diferido, cliente4, ListaArticulos1, false, 0, 0);
           deposito = new Pedidos(0, TipoPedido.express, cliente6,Listadeposito, true, 0, 0);

            ListaPedidos = new List<Pedidos>();
            ListaPedidos.Add(Pedido1);
            ListaPedidos.Add(Pedido2);
            ListaPedidos.Add(Pedido3);
            ListaPedidos.Add(Pedido4);
            ListaPedidos.Add(Pedido5);

            ListaRecorrido1 = new List<Pedidos>();
            ListaRecorrido2 = new List<Pedidos>();
            ListaRecorrido3 = new List<Pedidos>();
            ListaSobrantes = new List<Pedidos>();
            cocimundo = new Cocimundo("Cocimundo",deposito,ListaDeVehiculos,ListaPedidos,ListaRecorrido1,ListaRecorrido2,ListaRecorrido3,ListaSobrantes);



            InitializeComponent();
            //var csv_ = new csvfiles._csv();
            //List<Pedidos> Pedidos = csv_.read_csv();
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            cocimundo.AsignarRecorrido();
            int cont1 = 0, cont2 = 0, cont3 = 0;
            cont1 = cocimundo.LineaBlanca(cocimundo.ListaDeRecorrido1);
            cont2 = cocimundo.LineaBlanca(cocimundo.ListaDeRecorrido2);
            cont3 = cocimundo.LineaBlanca(cocimundo.ListaDeRecorrido3);
            cocimundo.AsignarVehiculoARecorrido(cont1, cont2, cont3);

        }

        private void button2_Click(object sender, EventArgs e)
        {   //RECORRIDO 1
            // ANALISIS DE MI RECORRIDO + ALMACENAMIENTO DE PEDIDOS
            cocimundo.AsignarCostoEnvio(cocimundo.ListaDeRecorrido1, cocimundo.ListaVehiculos[0]);
            List<Pedidos> PedidosACargar1 = new List<Pedidos>();
           cocimundo.ElementosACargar(cocimundo.ListaDeRecorrido1, cocimundo.ListaVehiculos[0], cocimundo.ListaSobrantes, PedidosACargar1);
           /*VerificarPeso(PedidosACargar1, cocimundo.ListaVehiculos[0], cocimundo.ListaSobrantes);*/
           List<Pedidos> ListaFinal1 = cocimundo.Ruteo_Por_Recorrido(cocimundo.ListaDeRecorrido1, cocimundo.ListaVehiculos[0], cocimundo.ListaSobrantes);
            // ORGANIZO MI RUTA-> ARMO UNA LISTA CON LOS PEDIDOS EN SU ORDEN DE ENTREGA DEL MÁS CERCANO AL MÁS LEJANO
            cocimundo.IniciarReparto(ListaFinal1, cocimundo.ListaVehiculos[0]);
            //IMPRIMIR MAPA RECORRIDO
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            //papel.DrawEllipse(lapiz, 30,50 , 10, 10);
            for (int i = 1; i < ListaFinal1.Count; i++)
            {
                if (ListaFinal1[i].enviado == true)//el pedido ya fue eliminado pinto la ciudad
                {
                    papel.FillEllipse(brush, ListaFinal1[i].x, ListaFinal1[i].y, 50, 50);
                    papel.DrawLine(lapiz, ListaFinal1[i].x, ListaFinal1[i].y, ListaFinal1[i - 1].x, ListaFinal1[i - 1].y);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //RECORRIDO 2
            //ANALISIS DE MI RECORRIDO + ALMACENAMIENTO DE PEDIDOS
            //siempre seguimos agregando elementos a la lista de sobrantes, es unica, y todos los que no entraron quedan ahi
            //posteriormente si puedo llevarlos en mi camioneta lo haré
            cocimundo.AsignarCostoEnvio(cocimundo.ListaDeRecorrido2, cocimundo.ListaVehiculos[1]);
            List<Pedidos> PedidosACargar2 = new List<Pedidos>();
            cocimundo.ElementosACargar(cocimundo.ListaDeRecorrido2, cocimundo.ListaVehiculos[1], cocimundo.ListaSobrantes, PedidosACargar2);
            List<Pedidos> ListaFinal2 = cocimundo.Ruteo_Por_Recorrido(cocimundo.ListaDeRecorrido2, cocimundo.ListaVehiculos[1], cocimundo.ListaSobrantes);
            //ORGANIZO MI RUTA-> ARMO UNA LISTA CON LOS PEDIDOS EN SU ORDEN DE ENTREGA DEL MÁS CERCANO AL MÁS LEJANO
            //VerificarPeso(PedidosACargar2, cocimundo.ListaVehiculos[1], cocimundo.ListaSobrantes);
            cocimundo.IniciarReparto(ListaFinal2, cocimundo.ListaVehiculos[1]);
            //IMPRIMIR MAPA RECORRIDO
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
            //papel.DrawEllipse(lapiz, 30,50 , 10, 10);
            for (int i = 1; i < ListaFinal2.Count; i++)
            {
                if (ListaFinal2[i].enviado == true)//el pedido ya fue eliminado pinto la ciudad
                {
                    papel.FillEllipse(brush, ListaFinal2[i].x, ListaFinal2[i].y, 50, 50);
                    papel.DrawLine(lapiz, ListaFinal2[i].x, ListaFinal2[i].y, ListaFinal2[i - 1].x, ListaFinal2[i - 1].y);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         //RECORRIDO 3
            // ANALISIS DE MI RECORRIDO + ALMACENAMIENTO DE PEDIDOS
            // siempre seguimos agregando elementos a la lista de sobrantes, es unica, y todos los que no entraron quedan ahi
           // posteriormente si puedo llevarlos en mi camioneta lo haré
           cocimundo.AsignarCostoEnvio(cocimundo.ListaDeRecorrido3, cocimundo.ListaVehiculos[2]);
           List<Pedidos> PedidosACargar3 = new List<Pedidos>();
           cocimundo.ElementosACargar(cocimundo.ListaDeRecorrido3, cocimundo.ListaVehiculos[2], cocimundo.ListaSobrantes, PedidosACargar3);
           List<Pedidos> ListaFinal3 = cocimundo.Ruteo_Por_Recorrido(cocimundo.ListaDeRecorrido3, cocimundo.ListaVehiculos[2], cocimundo.ListaSobrantes);
            // ORGANIZO MI RUTA-> ARMO UNA LISTA CON LOS PEDIDOS EN SU ORDEN DE ENTREGA DEL MÁS CERCANO AL MÁS LEJANO
            // VerificarPeso(PedidosACargar3, cocimundo.ListaVehiculos[2], cocimundo.ListaSobrantes);
            cocimundo.IniciarReparto(ListaFinal3, cocimundo.ListaVehiculos[2]);
            //IMPRIMIR MAPA RECORRIDO
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            //papel.DrawEllipse(lapiz, 30,50 , 10, 10);
            for (int i = 1; i < ListaFinal3.Count; i++)
            {
                if (ListaFinal3[i].enviado == true)//el pedido ya fue eliminado pinto la ciudad
                {
                    papel.FillEllipse(brush, ListaFinal3[i].x, ListaFinal3[i].y, 50, 50);
                    papel.DrawLine(lapiz, ListaFinal3[i].x, ListaFinal3[i].y, ListaFinal3[i - 1].x, ListaFinal3[i - 1].y);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //AL FINALIZAR EL DIA--> los vehículos van a ver recibido un % de daño por el/los recorrido/s hechos, entonces es ahi cuando les sumamos el daño de el/los recorrido/s.
            cocimundo.FinDelDia(cocimundo.ListaVehiculos[0]);
          cocimundo.FinDelDia(cocimundo.ListaVehiculos[1]);
            cocimundo.FinDelDia(cocimundo.ListaVehiculos[2]);
        }
    }
}