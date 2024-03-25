using APBD3.Models.Base;

namespace APBD3.Models;

public class KonteinerPlyn : Konteiner, IHazardNotifier
{
    protected string TypLadunku;
    public KonteinerPlyn(double height, double masaWlasna, double glebokosc, double maxLadownosc, string typLadunku) : base( height, masaWlasna, glebokosc, maxLadownosc)
    {
        TypLadunku = typLadunku;
        NumerSeryjny = "KON-L-" + Number;
        Number++;
    }

    public override void OproznienieLadunku(double masa)
    {
        MasaLadunku -= masa;
        if (MasaLadunku < 0)
        {
            Console.WriteLine("You can't unfill that much");
            MasaLadunku += masa;
        }
    }

    public override void Zaladowac(double masa)
    {
        try
        {
            double NewMasa = MasaLadunku += masa;
            if (((NewMasa > (MaxLadownosc / 2)) && TypLadunku == "hazard") || NewMasa > (MaxLadownosc * 0.9))
            {
                HazardDetected();
                MasaLadunku -= masa;
            } else if (NewMasa > MaxLadownosc)
            {
                MasaLadunku -= masa;
                throw new OverfillException("Nie mozna wiecej");
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }
    }

    public void HazardDetected()
    {
        Console.WriteLine("Zbyt duża masa, Numer seryjny kontenera: "+ NumerSeryjny);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + TypLadunku;
    }
}