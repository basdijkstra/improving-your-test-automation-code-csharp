namespace ImprovingYourTestAutomationCode.Order
{
    public class StripeProcessor : IPaymentProcessor
    {
        public StripeProcessor()
        {
        }

        public bool PayFor(OrderItem orderItem, int quantity)
        {
            return true;
        }
    }
}
