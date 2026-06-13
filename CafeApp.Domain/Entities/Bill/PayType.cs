namespace CafeApp.Domain;

public class PayType
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum PayTypeEnum
{
    Cash = 1,
    CreditCard = 2,
    MobilePayment = 3
}