namespace CoffeeShop.BusinessEntity.Enums
{
    public enum OrderState : byte
    {
        New,
        Paid,
        Committed,
        Ready,
        Finished,
        Cancelled
    }
}
