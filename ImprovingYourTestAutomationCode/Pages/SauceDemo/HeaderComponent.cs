using Microsoft.Playwright;

namespace ImprovingYourTestAutomationCode.Pages.SauceDemo
{
    public class HeaderComponent
    {
        private readonly IPage page;

        public HeaderComponent(IPage page)
        {
            this.page = page;
        }

        public async Task GotoShoppingCart()
        {
            await this.page.Locator("[data-test=shopping-cart-link]").ClickAsync();
        }
    }
}
