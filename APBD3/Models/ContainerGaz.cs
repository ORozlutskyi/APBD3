using APBD3.Models.Base;

namespace APBD3.Models;

public class ContainerGaz : Container, IHazardNotifier
{
    public double Cisnienie { get; set; }
    
    public ContainerGaz(double height, double masaWlasna, double glebokosc, double maxLadownosc, double cisnienie) : base(height, masaWlasna, glebokosc, maxLadownosc)
    {
        Cisnienie = cisnienie;
    }

    public override void OproznienieLadunku(double masa)
    {
        MasaLadunku -= masa;
        if (MasaLadunku < MaxLadownosc * 0.05)
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
        throw new NotImplementedException();
    }
}