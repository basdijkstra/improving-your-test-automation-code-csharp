using Microsoft.AspNetCore.Razor.TagHelpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ImprovingYourTestAutomationCode.Exercises.Pages
{
    public class ShoppingCartPage
    {
        private readonly IWebDriver driver;

        private readonly By buttonGoToCheckout = By.Id("checkout");
        
        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToCheckout()
        {
            Click(buttonGoToCheckout);
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
