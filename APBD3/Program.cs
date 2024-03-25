using APBD3.Models;
using APBD3.Models.Base;

public class Program
{
    public static Dictionary<string, double> mapaProduktow = new Dictionary<string, double>();
    
    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("C:\\Users\\orozl\\APBD\\APBD3\\APBD3\\Products.txt");

        foreach (string line in lines)
        {
            string[] l = line.Split(" ");
            mapaProduktow.Add(l[0], Double.Parse(l[1]));
        }
            
        
        KonteinerPlyn cont = new KonteinerPlyn(100, 100, 100, 100, "hazard");
        
        cont.Zaladowac(40);
        cont.Zaladowac(15);
        Console.WriteLine(cont.MasaLadunku);
        Console.WriteLine(cont.NumerSeryjny);
        KonteinerPlyn cont2 = new KonteinerPlyn(100, 100, 100, 100, "normal");
        Console.WriteLine(cont2.NumerSeryjny);

        KonteinerChlodniczy contCh3 = new KonteinerChlodniczy(100, 100, 100, 100, 20);
        contCh3.SetProdukt("Chocolate");
        Console.WriteLine(contCh3);

        List<Konteiner> lista = new List<Konteiner>();
        lista.Add(cont);
        lista.Add(cont2);
        lista.Add(contCh3);
        
        Kontenierowiec kontenierowiec = new Kontenierowiec(50, 5, 400);
        Kontenierowiec kontenierowiec2 = new Kontenierowiec(50, 5, 400);
        Console.WriteLine(kontenierowiec.WagaKontenerow);
        kontenierowiec.AddContainer(cont);
        
        kontenierowiec.AddContainers(lista);
        
        kontenierowiec.DeleteContainer("KON-L-2");
        KonteinerChlodniczy contCh2 = new KonteinerChlodniczy(100, 100, 100, 100, 20);
        
        kontenierowiec.ChangeContainers("KON-L-0", contCh2);
        kontenierowiec.ShipContainerToAnotherContainerShip("KON-L-1", kontenierowiec2);

        List<Konteiner> returned = kontenierowiec2.Containers;
        foreach (Konteiner kont in returned)
        {
            Console.WriteLine(kont + "   aaa");
        }
        
        Console.WriteLine(cont2);
        
    }
}