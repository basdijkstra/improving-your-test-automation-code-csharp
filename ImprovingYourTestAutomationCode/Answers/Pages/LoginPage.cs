using OpenQA.Selenium;

namespace ImprovingYourTestAutomationCode.Answers.Pages
{
    public class LoginPage : BasePage
    {
        private readonly string pageUrl = "https://www.saucedemo.com/";

        private readonly By textfieldUsername = By.Id("user-name");
        private readonly By textfieldPassword = By.Id("password");
        private readonly By buttonLogin = By.Id("login-button");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Open(pageUrl);
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(textfieldUsername, username);
            SendKeys(textfieldPassword, password);
            Click(buttonLogin);
        }
    }
}
