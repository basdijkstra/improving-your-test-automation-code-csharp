using Microsoft.Playwright;

namespace ImprovingYourTestAutomationCode.Pages.SauceDemo
{
    public class ProductDetailPage
    {
        private readonly IPage page;

        public ProductDetailPage(IPage page)
        {
            this.page = page;
        }

        public async Task AddProductToCart()
        {
            await this.page.GetByText("Add to cart").ClickAsync();
        }
    }
}
