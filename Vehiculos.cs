using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class Vehiculos
    {
        public TipoVehiculo Vehiculo;//enum que vehiculo es 
        public float pesoMaxDeCarga; //camioneta=1200-15kg de la rampa- furgoneta=3500-15kg de la rampa- furgon= 4900 (kg)
        public float volumenDeCarga;//camioneta=5.4937-0.02 de la rampa- furgoneta=17-0.02 de la rampa- furgon=18 (m3)
        public float consumoNafta;//camioneta=6.1- furgoneta=6.9- furgon=8.9(l/100km)
        public float tanqueNafta;// camioneta =50litros- furgoneta= 90litros- furgon=90 litros 
        public float danio = 0; // se incrementa con los viajes
        public float kmPorViaje; //se los pasamos de func distancia
        public int cantViajes; // cantidad de viajes que se hicieron, ya que si es una camioneta puede hacer hasta 4 viajes por día
        public Vehiculos(TipoVehiculo vehiculo, float pesoMaxDeCarga, float volumenDeCarga, float consumoNafta, float tanqueNafta, float danio, float kmPorViaje, int cantViajes)
        {
            Vehiculo = vehiculo;
            this.pesoMaxDeCarga = pesoMaxDeCarga;
            this.volumenDeCarga = volumenDeCarga;
            this.consumoNafta = consumoNafta;
            this.tanqueNafta = tanqueNafta;
            this.danio = danio;
            this.kmPorViaje = kmPorViaje;
            this.cantViajes = cantViajes;
        }
        ~Vehiculos() { }
    }
}
