using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ImprovingYourTestAutomationCode.Exercises.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;

        private readonly By textfieldFirstName = By.Id("first-name");
        private readonly By textfieldLastName = By.Id("last-name");
        private readonly By textfieldPostalCode = By.Id("postal-code");
        private readonly By buttonContinueToOverview = By.Id("continue");
        private readonly By buttonConfirmOrder = By.Id("finish");
        private readonly By textlabelConfirmation = By.XPath("//h2");

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CompleteOrderFor(string firstName, string lastName, string postalCode)
        {
            SendKeys(textfieldFirstName, firstName);
            SendKeys(textfieldLastName, lastName);
            SendKeys(textfieldPostalCode, postalCode);
            Click(buttonContinueToOverview);
            Click(buttonConfirmOrder);
        }

        public string GetOrderConfirmationText()
        {
            return GetElementText(textlabelConfirmation);
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
