namespace CafeApp.Domain;

public class Tables
{
    private Tables() { }
    public int Id { get; private set; }
    public int SeatsNumber { get; private set; }
    public int Number { get; private set; }

    #region Factory
    public static Tables Create(int seatsNumber, int number)
    {
        if (seatsNumber <= 0)
            throw new InvalidOperationException("Table should have valid number of seats");
        if (number <= 0) 
            throw new InvalidOperationException("Numbe should be positive");

        var table = new Tables 
        { 
            Id = default,
            SeatsNumber = seatsNumber,
            Number = number
        };
        return table;
    }
    #endregion
}
