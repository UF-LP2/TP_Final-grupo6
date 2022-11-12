using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace tp_final
{
    internal class Clientes
    {
        public string nombre;
        public string apellido;
        public string DNI;
        public string Direccion;
        public float distancia_a_Liniers;
        public Barrio Barrio;
        public Distancia Barrioaux;
        public Clientes(string nombre, string apellido, string dNI, string direccion, float distancia_a_Liniers, Barrio barrio, Distancia barrioaux)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            DNI = dNI;
            Direccion = direccion;
            this.distancia_a_Liniers = distancia_a_Liniers;
            Barrio = barrio;
            Barrioaux = barrioaux;
        }
        ~Clientes() { }
    }
}
