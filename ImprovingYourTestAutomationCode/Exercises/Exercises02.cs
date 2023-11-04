using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises02 : TestBase
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [Test]
        public void AddBackpackToShoppingCart_CheckoutOrder_ShouldBeSuccessful()
        {
            // Navigate to the web shop
            this.driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Log in to the web shop
            SendKeys(By.Id("user-name"), "standard_user");
            SendKeys(By.Id("password"), "secret_sauce");
            Click(By.Id("login-button"));

            // Add backpack to cart
            Click(By.Id("add-to-cart-sauce-labs-backpack"));

            // Go to shopping cart
            Click(By.XPath("//a[@class='shopping_cart_link']"));

            // Go to checkout
            Click(By.Id("checkout"));

            // Fill in details
            SendKeys(By.Id("first-name"), "John");
            SendKeys(By.Id("last-name"), "Doe");
            SendKeys(By.Id("postal-code"), "90210");
            Click(By.Id("continue"));

            // Confirm
            Click(By.Id("finish"));

            // Check that checkout has been completed successfully
            Assert.That(GetElementText(By.XPath("//h2")), Is.EqualTo("Thank you for your order!"));
        }

        [TearDown]
        public void StopBrowser()
        {
            this.driver.Quit();
        }

        private void SendKeys(By by, string valueToType)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Clear();
                myElement.SendKeys(valueToType);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {by} not visible and enabled within 10 seconds.");
            }
        }

        private void Click(By by)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Click(): element located by {by} not visible and enabled within 10 seconds.");
            }
        }

        private string GetElementText(By by)
        {
            string returnValue = "";

            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                returnValue = myElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in GetElementText(): element located by {by} not visible and enabled within 10 seconds.");
            }

            return returnValue;
        }
    }
}
