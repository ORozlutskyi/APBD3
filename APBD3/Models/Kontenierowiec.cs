using System.ComponentModel;

namespace APBD3.Models;

public class Kontenierowiec
{
    private List<Container> _containers = new List<Container>();
    private double wagaKontenerow;
    
    public List<Container> Containers
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
    
    
}