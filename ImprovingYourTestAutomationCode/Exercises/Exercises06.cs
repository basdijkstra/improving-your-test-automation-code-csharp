using ImprovingYourTestAutomationCode.Order;
using Moq;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises06
    {
        [Test]
        public void UseMockedStockManager()
        {
            /**
             * Now that we can inject a StockManager object when creating the OrderHandler,
             * write a test that:
             * - Creates a mock StockManager
             * - Configures the StockManager to always return 'false' when removeFromStock() is called
             *   for OrderItem.SUPER_MARIO_BROS_3 and quantity 1
             * - Injects the mock StockManager into a new OrderHandler
             * - Places 1 order for OrderItem.SUPER_MARIO_BROS_3, with quantity = 1
             *   (remember, the original stock is 5)
             * - Asserts that this fails (so without having to place 5 actual orders first)
             * - Verifies that exactly one call was made to the mocked StockManager method
             */

            var stockManager = new Mock<IStockManager>();
            stockManager.Setup(m => m.RemoveFromStock(OrderItem.SUPER_MARIO_BROS_3, 1)).Returns(false);

            var orderHandler = new OrderHandler(stockManager.Object, new StripeProcessor());

            bool result = orderHandler.HandleRemoveFromStock(OrderItem.SUPER_MARIO_BROS_3, 1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void UseMockedPaymentProcessor()
        {
            /**
             * Discuss: assuming that the PaymentProcessor class and its implementation is borrowed
             * from another project (developed either internally or externally), should we mock it in
             * our tests? Why? Why not? Try and find arguments for either side.
             */
        }
    }
}
