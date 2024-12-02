using Microsoft.Playwright;

namespace ImprovingYourTestAutomationCode.Pages.ParaBank
{
    public class LoginPage
    {
        private readonly IPage page;

        public LoginPage(IPage page)
        {
            this.page = page;
        }

        public async Task Open()
        {
            await this.page.GotoAsync("https://parabank.parasoft.com");
        }

        public async Task LoginAs(string username, string password)
        {
            await this.page.Locator("[name=username]").FillAsync(username);
            await this.page.Locator("[name=password]").FillAsync(password);
            await this.page.GetByRole(AriaRole.Button, new() { Name = "Log In" }).ClickAsync();
        }
    }
}
