namespace ImprovingYourTestAutomationCode.Order
{
    public interface IPaymentProcessor
    {
        bool PayFor(OrderItem orderItem, int quantity);
    }
}