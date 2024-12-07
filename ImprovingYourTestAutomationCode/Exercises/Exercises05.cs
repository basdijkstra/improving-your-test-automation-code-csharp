using ImprovingYourTestAutomationCode.Order;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises05
    {
        [Test]
        public void Order1CopyOfFC25_ShouldLeave9CopiesRemaining()
        {
            var stock = new Dictionary<OrderItem, int>()
            {
                { OrderItem.FC_25, 10 },
            };

            OrderHandler orderHandler = new OrderHandler(new StockManager(stock), new StripeProcessor());

            bool result = orderHandler.HandleRemoveFromStock(OrderItem.FC_25, 1);

            Assert.That(result, Is.True);
            Assert.That(orderHandler.GetStockForItem(OrderItem.FC_25), Is.EqualTo(9));
        }

        [Test]
        public void Order101CopiesOfFortnite_ShouldFail()
        {
            var stock = new Dictionary<OrderItem, int>()
            {
                { OrderItem.FORTNITE, 100 },
            };

            OrderHandler orderHandler = new OrderHandler(new StockManager(stock), new StripeProcessor());

            bool result = orderHandler.HandleRemoveFromStock(OrderItem.FORTNITE, 101);

            Assert.That(result, Is.False);
            Assert.That(orderHandler.GetStockForItem(OrderItem.FORTNITE), Is.EqualTo(100));
        }

        [Test]
        public void AddStockForDOTT_ShouldThrowExpectedException()
        {
            var stock = new Dictionary<OrderItem, int>()
            {
                { OrderItem.FC_25, 10 },
            };

            OrderHandler orderHandler = new OrderHandler(new StockManager(stock), new StripeProcessor());

            Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.AddStockForItem(OrderItem.DAY_OF_THE_TENTACLE, 10);
            });
        }

        [Test]
        public void OrderOutOfStockItem_ShouldFail()
        {
            /**
             * So, can we write a test that verifies the behaviour of our OrderHandler
             * when the stock for an item is equal to 0? If so, how? And is this the most
             * efficient way to test this? If not, what do we need to improve?
             */

            var stock = new Dictionary<OrderItem, int>()
            {
                { OrderItem.FC_25, 0 },
            };

            OrderHandler orderHandler = new OrderHandler(new StockManager(stock), new StripeProcessor());

            bool result = orderHandler.HandleRemoveFromStock(OrderItem.FC_25, 1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void OrderMoreThanFiveItemsUsingPayPal_ShouldFail()
        {
            /**
             * Next, can we write a test that verifies that we cannot pay for an order
             * with more than five copies of a game in it using PayPal? Why not?
             * What can we (should we) do to improve our code?
             */

            var paymentProcessor = new PayPalProcessor();

            Assert.That(paymentProcessor.PayFor(OrderItem.DAY_OF_THE_TENTACLE, 6), Is.False);
        }

        /**
         * As a final comment, what do you think about the fact you will always need to
         * process a payment when you want to test placing an order, and you will always need to place
         * an order when you want to test processing a payment?
         */
    }
}
