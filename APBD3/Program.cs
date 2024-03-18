using APBD3.Models;
using APBD3.Models.Base;

public class main
{
    public static void Main(string[] args)
    {
        ContainerPlyn cont = new ContainerPlyn(100, 100, 100, 100, "hazard");
        
        cont.Zaladowac(40);
        cont.Zaladowac(5);
        Console.WriteLine(cont.MasaLadunku);
        Console.WriteLine(cont.NumerSeryjny);
        ContainerPlyn cont2 = new ContainerPlyn(100, 100, 100, 100, "normal");
        Console.WriteLine(cont2.NumerSeryjny);
    }
}