namespace ImprovingYourTestAutomationCode.Order
{
    public class OrderHandler
    {
        private readonly StockManager stockManager;
        private readonly IPaymentProcessor paymentProcessor;

        public OrderHandler(StockManager stockManager, IPaymentProcessor paymentProcessor)
        {
            this.stockManager = stockManager;
            this.paymentProcessor = paymentProcessor;
        }

        public bool HandleRemoveFromStock(OrderItem orderItem, int quantity)
        {
            return this.stockManager.RemoveFromStock(orderItem, quantity);
        }

        public bool HandleOrderPayment(OrderItem orderItem, int quantity)
        {
            return this.paymentProcessor.PayFor(orderItem, quantity);
        }

        public int GetStockForItem(OrderItem item)
        {
            return this.stockManager.GetStockForItem(item);
        }

        public void AddStockForItem(OrderItem orderItem, int quantity)
        {
            this.stockManager.AddStockForItem(orderItem, quantity);
        }
    }
}
