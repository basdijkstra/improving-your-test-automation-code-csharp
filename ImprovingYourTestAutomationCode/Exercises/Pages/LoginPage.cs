using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ImprovingYourTestAutomationCode.Exercises.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        private readonly string pageUrl = "https://www.saucedemo.com/";

        private readonly By textfieldUsername = By.Id("user-name");
        private readonly By textfieldPassword = By.Id("password");
        private readonly By buttonLogin = By.Id("login-button");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            Open(pageUrl);
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(textfieldUsername, username);
            SendKeys(textfieldPassword, password);
            Click(buttonLogin);
        }
        private void Open(string url)
        {
            this.driver.Navigate().GoToUrl(url);
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
    }
}
