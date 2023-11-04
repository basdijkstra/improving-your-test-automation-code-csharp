using ImprovingYourTestAutomationCode.Answers.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ImprovingYourTestAutomationCode.Answers
{
    [TestFixture]
    public class Answers02
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();

            new LoginPage(this.driver)
                .LoginAs("standard_user", "secret_sauce");
        }

        [Test]
        public void AddBackpackToShoppingCart_CheckoutOrder_ShouldBeSuccessful()
        {
            new ProductsPage(this.driver)
                .AddBackPackToCart()
                .GoToShoppingCart();

            new ShoppingCartPage(this.driver)
                .GoToCheckout();

            var checkoutPage = new CheckoutPage(this.driver);

            checkoutPage
                .CompleteOrderFor("John", "Doe", "90210");

            Assert.That(checkoutPage.GetOrderConfirmationText(), Is.EqualTo("Thank you for your order!"));
        }

        [TearDown]
        public void StopBrowser()
        {
            this.driver.Quit();
        }
    }
}
