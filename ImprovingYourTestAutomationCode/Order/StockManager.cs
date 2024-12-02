namespace ImprovingYourTestAutomationCode.Order
{
    public class StockManager
    {
        private Dictionary<OrderItem, int> stock;

        public StockManager()
        {
            stock = new Dictionary<OrderItem, int>()
            {
                { OrderItem.FC_25, 10 },
                { OrderItem.FORTNITE, 100 },
                { OrderItem.SUPER_MARIO_BROS_3, 5 }
            };
        }

        public bool RemoveFromStock(OrderItem orderItem, int quantity)
        {
            bool knownItem = stock.TryGetValue(orderItem, out int value);

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

            stock[orderItem] = value - quantity;
            return true;
        }

        public void AddStockForItem(OrderItem orderItem, int quantity)
        {
            bool knownItem = stock.TryGetValue(orderItem, out int value);

            if (!knownItem)
            {
                throw new ArgumentException("Item does not exist");
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }

            stock[orderItem] = value + quantity;
        }

        public int GetStockForItem(OrderItem orderItem)
        {
            bool knownItem = stock.TryGetValue(orderItem, out int value);

            return knownItem ? value : 0;
        }
    }
}
