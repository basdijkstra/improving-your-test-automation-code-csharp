using OpenQA.Selenium;

namespace ImprovingYourTestAutomationCode.Answers.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private readonly By buttonGoToCheckout = By.Id("checkout");

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToCheckout()
        {
            Click(buttonGoToCheckout);
        }
    }
}
