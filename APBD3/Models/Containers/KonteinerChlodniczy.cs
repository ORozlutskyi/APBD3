using APBD3.Models.Base;

namespace APBD3.Models;

public class KonteinerChlodniczy : Konteiner, IHazardNotifier
{
    private double Tempreture;
    private string Produkt = "";
    
    public KonteinerChlodniczy(double height, double masaWlasna, double glebokosc, double maxLadownosc, double tempreture) : base(height, masaWlasna, glebokosc, maxLadownosc)
    {
        Tempreture = tempreture;
        NumerSeryjny = "KON-L-" + Number;
        Number++;
    }

    public void SetProdukt(string produkt)
    {
        if (Produkt == "" && Tempreture > Program.mapaProduktow[produkt])
        {
            Produkt = produkt;
        }
        else
        {
            Console.WriteLine("Zbyt wysoka temp lub produkt już jest ustalony");
        }
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
            if (NewMasa > MaxLadownosc)
            {
                MasaLadunku -= masa;
                throw new OverfillException("Nie mozna wiecej");
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        };
    }

    public void HazardDetected()
    {
        Console.WriteLine("No, you are dalbayod, Numer seryjny kontenera: "+ NumerSeryjny);
    }

    public override string ToString()
    {
        return base.ToString() + ", " + Tempreture + ", " + Produkt;
    }
}