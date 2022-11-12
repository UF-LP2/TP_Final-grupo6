namespace tp_final
{
    static class Constantes
    {
        public const int CostoEnvioCamioneta = 50;
        public const int CostoEnvioFurgoneta = 50;
        public const int CostoEnvioFurgon = 50;
    }
    public enum TipoPedido
    {
        express = 1, normal = 3, diferido = 4
    }
    public enum TipoVehiculo
    {
        camioneta, furgoneta, furgon
    }
    public enum TipoLineaPedido
    {
        Electrodomesticos, LineaBlanca, Electronicos, Televisores
    }
    public enum TipoArticulo
    {
        heladera, lavarropa, cocina, calefon, termotanque, secarropa, microondas, freezer, licuadora, exprimidor,
        rallador, cafetera, molinillo, computadora, impresora, televisor, celular
    }
    public enum Barrio
    {
        Liniers = 0, Mataderos = 2, ParqueAvellaneda = 2, VillaLuro = 1, VelezSarfield = 1, Floresta = 1, MonteCastro = 1, Versalles = 3, VillaReal = 3, VillaDevoto = 3, VillaDelParque = 1, VillaSantaRita = 1,
        VillaGralMitre = 1, LaPaternal = 1, VillaCrespo = 1, Chacarita = 1, Agronomia = 1, ParqueChas = 1, VillaUrtuzar = 1, VillaPueyrredon = 3, VillaUrquiza = 3, Coghlan = 3, Saavedra = 3, Nuñez = 3, Belgrano = 1, Colegiales = 1,
        Palermo = 1, Recoleta = 1, Almagro = 1, Caballito = 1, ParqueChacabuco = 1, Flores = 1, VillaLugano = 2, VillaRiachuelo = 2, VillaSoldati = 2, NuevaPompeya = 2, Boedo = 1, Barracas = 2, ParquePatricios = 2, LaBoca = 2,
        Constitucion = 1, SanTelmo = 1, PuertoMadero = 1, SanNicolas = 1, Montserrat = 1, Balvanera = 1, SanCristobal, Retiro = 1, SanIsidro = 3, LaMatanza = 3, TresDeFebrero = 3, VicenteLopez = 3, Ituzaingo = 3,
        SanMartin = 3, Hurlingham = 3, Moron = 3, LomasDeZamora = 1, Lanus = 2, Avellaneda = 2
    } // le asignamos 1, 2 o 3 dependiendo del recorrido al que pertenezca 
    public enum Distancia
    {
        Liniers, Mataderos, ParqueAvellaneda, VillaLuro, VelezSarfield, Floresta, MonteCastro, Versalles, VillaReal, VillaDevoto, VillaDelParque, VillaSantaRita,
        VillaGralMitre, LaPaternal, VillaCrespo, Chacarita, Agronomia, ParqueChas, VillaUrtuzar, VillaPueyrredon, VillaUrquiza, Coghlan, Saavedra, Nuñez, Belgrano, Colegiales,
        Palermo, Recoleta, Almagro, Caballito, ParqueChacabuco, Flores, VillaLugano, VillaRiachuelo, VillaSoldati, NuevaPompeya, Boedo, Barracas, ParquePatricios, LaBoca,
        Constitucion, SanTelmo, PuertoMadero, SanNicolas, Montserrat, Balvanera, SanCristobal, Retiro, SanIsidro, LaMatanza, TresDeFebrero, VicenteLopez, Ituzaingo,
        SanMartin, Hurlingham, Moron, LomasDeZamora, Lanus, Avellaneda
    }
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

    }
}

