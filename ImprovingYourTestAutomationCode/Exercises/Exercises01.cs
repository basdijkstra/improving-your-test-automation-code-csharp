using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises01 : PageTest
    {
        [Test]
        public async Task OrderABackpack()
        {
            await Page.GotoAsync("https://www.saucedemo.com");

            await Page.GetByPlaceholder("Username").FillAsync("standard_user");
            await Page.GetByPlaceholder("Password").FillAsync("secret_sauce");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await Page.GetByText("Sauce Labs Backpack").ClickAsync();
            await Page.GetByText("Add to cart").ClickAsync();

            await Page.Locator("[data-test=shopping-cart-link]").ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Checkout" })).ToBeVisibleAsync();
        }
    }
}
