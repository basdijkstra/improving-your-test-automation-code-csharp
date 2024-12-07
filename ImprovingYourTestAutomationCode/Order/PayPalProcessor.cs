namespace ImprovingYourTestAutomationCode.Order
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public PayPalProcessor()
        {
        }

        public bool PayFor(OrderItem orderItem, int quantity)
        {
            return quantity <= 5;
        }
    }
}
