namespace APBD3.Models.Base;

public abstract class Container
{
        public double MasaLadunku { get; set; } = 0;
        protected double Height{ get; }
        protected double MasaWlasna{ get; }
        protected double Glebokosc{ get; }
        protected double MaxLadownosc { get; }
        protected static int Number { get; set; } = 0;
        public String NumerSeryjny { get; set; }

        protected Container(double height, double masaWlasna, double glebokosc, double maxLadownosc)
        {
                Height = height;
                MasaWlasna = masaWlasna;
                Glebokosc = glebokosc;
                MaxLadownosc = maxLadownosc;
        }

        public abstract void OproznienieLadunku(double masa);

        public abstract void Zaladowac(double masa);

}