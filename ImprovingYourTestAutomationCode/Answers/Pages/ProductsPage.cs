using OpenQA.Selenium;

namespace ImprovingYourTestAutomationCode.Answers.Pages
{
    public class ProductsPage : BasePage
    {
        private readonly By buttonAddBackpackToCart = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By buttonGoToShoppingCart = By.XPath("//a[@class='shopping_cart_link']");

        public ProductsPage(IWebDriver driver) : base(driver)
        {
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
    }
}
