namespace ImprovingYourTestAutomationCode.Order
{
    public class OrderHandler
    {
        private readonly StockManager stockManager;
        private readonly PaymentProcessor paymentProcessor;

        public OrderHandler()
        {
            this.stockManager = new StockManager();
            this.paymentProcessor = new PaymentProcessor(PaymentProcessorType.IDEAL);
        }

        public bool HandleOrder(OrderItem orderItem, int quantity)
        {
            if (this.stockManager.RemoveFromStock(orderItem, quantity))
            {
                return this.paymentProcessor.PayFor(orderItem, quantity);
            }

            return false;
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
