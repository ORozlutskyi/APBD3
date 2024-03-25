using APBD3.Models.Base;

namespace APBD3.Models;

public class ContainerChlodniczy : Container, IHazardNotifier
{
    private double Tempreture;
    private string Produkt = "";
    
    public ContainerChlodniczy(double height, double masaWlasna, double glebokosc, double maxLadownosc, double tempreture) : base(height, masaWlasna, glebokosc, maxLadownosc)
    {
        Tempreture = tempreture;
    }

    public void SetProdukt(string produkt)
    {
        if (Produkt != "" && Tempreture > main.mapaProduktow[Produkt])
        {
            Produkt = produkt;
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
}