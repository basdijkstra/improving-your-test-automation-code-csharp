using Microsoft.Playwright;

namespace ImprovingYourTestAutomationCode.Pages.SauceDemo
{
    public class ProductsOverviewPage
    {
        private readonly IPage page;

        public ProductsOverviewPage(IPage page)
        {
            this.page = page;
        }

        public async Task SelectProduct(string productName)
        {
            await this.page.GetByText(productName).ClickAsync();
        }
    }
}
