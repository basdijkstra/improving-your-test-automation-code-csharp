namespace ImprovingYourTestAutomationCode.Order
{
    public class PaymentProcessor
    {
        private readonly PaymentProcessorType paymentProcessorType;

        public PaymentProcessor(PaymentProcessorType paymentProcessorType)
        {
            this.paymentProcessorType = paymentProcessorType;
        }

        public bool PayFor(OrderItem orderItem, int quantity)
        {
            // With Stripe or iDeal, you can pay for every order
            if (
                this.paymentProcessorType.Equals(PaymentProcessorType.STRIPE) ||
                this.paymentProcessorType.Equals(PaymentProcessorType.STRIPE)
                )
            {
                return true;
            }

            // With PayPal, you can only pay for small orders
            return quantity <= 5;
        }
    }
}
