using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ImprovingYourTestAutomationCode.Answers.Pages
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void Open(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        protected void SendKeys(By by, string valueToType)
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

        protected void Click(By by)
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


        protected string GetElementText(By by)
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
