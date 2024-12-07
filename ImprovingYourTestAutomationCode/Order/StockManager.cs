namespace ImprovingYourTestAutomationCode.Order
{
    public class StockManager : IStockManager
    {
        private Dictionary<OrderItem, int> stock;

        public StockManager(Dictionary<OrderItem, int> stock)
        {
            this.stock = stock;
        }

        public bool RemoveFromStock(OrderItem orderItem, int quantity)
        {
            bool knownItem = this.stock.TryGetValue(orderItem, out int value);

            if (!knownItem)
            {
                return false;
            }

            if (value == 0)
            {
                return false;
            }

            if (quantity > value)
            {
                return false;
            }

            this.stock[orderItem] = value - quantity;
            return true;
        }

        public void AddStockForItem(OrderItem orderItem, int quantity)
        {
            bool knownItem = this.stock.TryGetValue(orderItem, out int value);

            if (!knownItem)
            {
                throw new ArgumentException("Item does not exist");
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }

            this.stock[orderItem] = value + quantity;
        }

        public int GetStockForItem(OrderItem orderItem)
        {
            bool knownItem = this.stock.TryGetValue(orderItem, out int value);

            return knownItem ? value : 0;
        }
    }
}
