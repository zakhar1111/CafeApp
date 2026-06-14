namespace CafeApp.Domain;

// trade-off - Look-up table need only If status values are managed by administrators  
//public class PayType
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
public enum PayTypeEnum
{
    Cash = 1,
    CreditCard = 2,
    MobilePayment = 3
}