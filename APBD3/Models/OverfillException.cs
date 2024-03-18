namespace APBD3.Models;

public class OverfillException : Exception
{
    public OverfillException(String message)
        : base(message)
    {
    }
}