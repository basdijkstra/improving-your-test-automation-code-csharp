using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ImprovingYourTestAutomationCode.Exercises.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;

        private readonly By buttonAddBackpackToCart = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By buttonGoToShoppingCart = By.XPath("//a[@class='shopping_cart_link']");

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ProductsPage AddBackPackToCart()
        {
            Click(buttonAddBackpackToCart);
            return this;
        }

        public void GoToShoppingCart()
        {
            Click(buttonGoToShoppingCart);
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
    }
}
