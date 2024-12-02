using Microsoft.Playwright;

namespace ImprovingYourTestAutomationCode.Pages.SauceDemo
{
    public class BasePage
    {
        private readonly IPage page;

        public BasePage(IPage page)
        {
            this.page = page;
        }

        public async Task GotoShoppingCart()
        {
            await this.page.Locator("[data-test=shopping-cart-link]").ClickAsync();
        }
    }
}
