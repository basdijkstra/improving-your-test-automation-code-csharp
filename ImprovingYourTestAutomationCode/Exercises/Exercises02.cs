using ImprovingYourTestAutomationCode.Pages.SauceDemo;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises02 : PageTest
    {
        [Test]
        public async Task OrderABackpack()
        {
            await Page.GotoAsync("https://www.saucedemo.com");

            var loginPage = new LoginPage(Page);
            await loginPage.Open();
            await loginPage.LoginAs("standard_user", "secret_sauce");

            await new ProductsOverviewPage(Page)
                .SelectProduct("Sauce Labs Backpack");

            var productDetailPage = new ProductDetailPage(Page);
            await productDetailPage.AddProductToCart();
            await productDetailPage.GotoShoppingCart();

            await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Checkout" })).ToBeVisibleAsync();
        }
    }
}
