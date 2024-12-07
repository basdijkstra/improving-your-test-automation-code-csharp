namespace ImprovingYourTestAutomationCode.Order
{
    public class IdealProcessor : IPaymentProcessor
    {
        public IdealProcessor()
        {
        }

        public bool PayFor(OrderItem orderItem, int quantity)
        {
            return true;
        }
    }
}
