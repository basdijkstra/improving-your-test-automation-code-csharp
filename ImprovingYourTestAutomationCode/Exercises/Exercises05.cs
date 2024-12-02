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

            OrderHandler orderHandler = new OrderHandler();

            bool result = orderHandler.HandleOrder(OrderItem.FC_25, 1);

            Assert.That(result, Is.True);
            Assert.That(orderHandler.GetStockForItem(OrderItem.FC_25), Is.EqualTo(9));
        }

        [Test]
        public void Order101CopiesOfFortnite_ShouldFail()
        {

            OrderHandler orderHandler = new OrderHandler();

            bool result = orderHandler.HandleOrder(OrderItem.FORTNITE, 101);

            Assert.That(result, Is.False);
            Assert.That(orderHandler.GetStockForItem(OrderItem.FORTNITE), Is.EqualTo(100));
        }

        [Test]
        public void AddStockForDOTT_ShouldThrowExpectedException()
        {

            OrderHandler orderHandler = new OrderHandler();

            Assert.Throws<ArgumentException>(() => {
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
        }

        [Test]
        public void OrderMoreThanFiveItemsUsingPayPal_ShouldFail()
        {
            /**
             * Next, can we write a test that verifies that we cannot pay for an order
             * with more than five copies of a game in it using PayPal? Why not?
             * What can we (should we) do to improve our code?
             */
        }

        /**
         * As a final comment, what do you think about the fact you will always need to
         * process a payment when you want to test placing an order, and you will always need to place
         * an order when you want to test processing a payment?
         */
    }
}
