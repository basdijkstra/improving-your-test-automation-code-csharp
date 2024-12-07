namespace ImprovingYourTestAutomationCode.Order
{
    public interface IStockManager
    {
        void AddStockForItem(OrderItem orderItem, int quantity);
        int GetStockForItem(OrderItem orderItem);
        bool RemoveFromStock(OrderItem orderItem, int quantity);
    }
}