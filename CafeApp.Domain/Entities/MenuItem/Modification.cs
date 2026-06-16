namespace CafeApp.Domain;

public class Modification
{
    private Modification() { }
    public int Id { get; private  set; }
    public string Name { get; private set; }
    public decimal AdditionalCost { get; private set; }

    public static Modification Create(string name, decimal additionalCost)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException();
        if (additionalCost < 0)
            throw new InvalidOperationException();
        return new Modification
        {
            Name = name,
            AdditionalCost = additionalCost
        };
    }
}
