using OpenQA.Selenium;

namespace ImprovingYourTestAutomationCode.Answers.Pages
{
    public class CheckoutPage : BasePage
    {
        private readonly By textfieldFirstName = By.Id("first-name");
        private readonly By textfieldLastName = By.Id("last-name");
        private readonly By textfieldPostalCode = By.Id("postal-code");
        private readonly By buttonContinueToOverview = By.Id("continue");
        private readonly By buttonConfirmOrder = By.Id("finish");
        private readonly By textlabelConfirmation = By.XPath("//h2");

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
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
    }
}
