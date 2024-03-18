using APBD3.Models.Base;

namespace APBD3.Models;

public class ContainerPlyn : Container, IHazardNotifier
{
    protected string TypLadunku;
    public ContainerPlyn(double height, double masaWlasna, double glebokosc, double maxLadownosc, string typLadunku) : base( height, masaWlasna, glebokosc, maxLadownosc)
    {
        TypLadunku = typLadunku;
        NumerSeryjny = "KON-L-" + Number;
        Number++;
    }

    public override void OproznienieLadunku()
    {
        MasaLadunku = 0;
    }

    public override void Zaladowac(double masa)
    {
        try
        {
            double NewMasa = MasaLadunku += masa;
            if ((NewMasa > (MaxLadownosc / 2)) && TypLadunku == "hazard")
            {
                HazardDetected();
            } else if (NewMasa > (MaxLadownosc * 0.9))
            {
                HazardDetected();
            } else if (NewMasa > MaxLadownosc)
            {
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
        Console.WriteLine("i huj");
    }
}