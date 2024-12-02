using Microsoft.Playwright;

namespace ImprovingYourTestAutomationCode.Pages.ParaBank
{
    public class AccountsOverviewPage
    {
        private readonly IPage page;

        public AccountsOverviewPage(IPage page)
        {
            this.page = page;
        }

        public async Task SelectMenuItem(string menuItemName)
        {
            await this.page.GetByRole(AriaRole.Link, new() { Name = menuItemName }).ClickAsync();
        }
    }
}
