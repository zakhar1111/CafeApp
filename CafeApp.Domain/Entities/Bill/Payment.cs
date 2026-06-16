namespace CafeApp.Domain;

public class Payment
{ 
    public int Id { get; set; }


    public int BillId { get; set; } //FK
    public int CustomerId { get; set; } //FK
    

    public decimal Amount { get; set; }
    public DateTime PaymentTime { get; set; }



    public PayTypeEnum PayType { get; set; }
    public PayStatusEnum PayStatus { get; set; }
}
