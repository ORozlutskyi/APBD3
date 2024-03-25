namespace APBD3.Models.Base;

public abstract class Konteiner
{
        protected double masaLadunku;

        public double MasaLadunku
        {
                get
                {
                        return masaLadunku;
                }
                set
                {
                        masaLadunku = value;
                }
        }

        protected double _height;
        public double Height
        {
                get
                {
                        return _height;
                }
                set
                {
                        _height = value;
                }
        }

        protected double masaWlasna;
        public double MasaWlasna
        {
                get
                {
                        return masaWlasna;
                }
                set
                {
                        masaWlasna = value;
                }
        }
        protected double Glebokosc{ get; }
        protected double MaxLadownosc { get; }
        protected static int Number { get; set; } = 0;
        public String NumerSeryjny { get; set; }

        protected Konteiner(double height, double masaWlasna, double glebokosc, double maxLadownosc)
        {
                Height = height;
                MasaWlasna = masaWlasna;
                Glebokosc = glebokosc;
                MaxLadownosc = maxLadownosc;
        }

        public abstract void OproznienieLadunku(double masa);

        public abstract void Zaladowac(double masa);

        public override string ToString()
        {
                return masaLadunku + ", " + masaWlasna + ", " + _height + ", " + Glebokosc + ", " +
                       NumerSeryjny;
        }
}