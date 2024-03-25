using System.ComponentModel;
using APBD3.Models.Base;

namespace APBD3.Models;

public class Kontenierowiec
{
    private List<Konteiner> _containers = new List<Konteiner>();
    private double wagaKontenerow = 0;
    public double WagaKontenerow
    {
        get
        {
            return wagaKontenerow;
        }
        set
        {
            wagaKontenerow = value;
        }
    }
    
    public List<Konteiner> Containers
    {
        get
        {
            return _containers;
        }
        set
        {
            _containers = value;
        }
    }

    private double maxPredkosc;
    public double MaxPredkosc
    {
        get
        {
            return maxPredkosc;
        }
        set
        {
            maxPredkosc = value;
        }
    }

    private int maxIloscKontenerow;

    public int MaxIloscKontenerow
    {
        get
        {
            return maxIloscKontenerow;
        }
        set
        {
            maxIloscKontenerow = value;
        }
    }

    private double maxWaga;
    public double MaxWaga
    {
        get
        {
            return maxWaga;
        }
        set
        {
            maxWaga = value;
        }
    }

    public Kontenierowiec(double maxPredkosc, int maxIloscKontenerow, double maxWaga)
    {
        this.maxPredkosc = maxPredkosc;
        this.maxIloscKontenerow = maxIloscKontenerow;
        this.maxWaga = maxWaga;
    }

    public void AddContainer(Konteiner cont)
    {
        wagaKontenerow += cont.MasaLadunku + cont.MasaWlasna;
        if (wagaKontenerow > maxWaga)
        {
            Console.WriteLine("Nie możesz dodać tego konteneru, waga jest za duża");
            wagaKontenerow -= cont.MasaLadunku + cont.MasaWlasna;
        }
        else
        {
            _containers.Add(cont);
        }
    }

    public void AddContainers(List<Konteiner> conts)
    {
        foreach (Konteiner kont in conts)
        {
            AddContainer(kont);
        }
    }
    
    public void DeleteContainer(string numerSeryjny)
    {
        foreach (Konteiner kont in _containers)
        {
            if (kont.NumerSeryjny == numerSeryjny) _containers.Remove(kont);
        }
    }

    public void ChangeContainers(string numerSeryjny, Konteiner kont)
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].NumerSeryjny == numerSeryjny)
            {
                if (wagaKontenerow + kont.MasaWlasna + kont.MasaLadunku > maxWaga)
                {
                    Console.WriteLine("Nie możesz zamienić, waga podanego kontenera jest zbyt duża");
                }
                else
                {
                    _containers.Remove(_containers[i]);
                    _containers.Insert(i, kont);
                }
            }
        }
    }

    public void ShipContainerToAnotherContainerShip(string numerSeryjny, Kontenierowiec kont)
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].NumerSeryjny == numerSeryjny)
            {
                kont.AddContainer(_containers[i]);
                _containers.Remove(_containers[i]);
            }
        }
    }
}