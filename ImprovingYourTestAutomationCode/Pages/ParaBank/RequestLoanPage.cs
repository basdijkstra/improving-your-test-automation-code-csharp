using Microsoft.Playwright;

namespace ImprovingYourTestAutomationCode.Pages.ParaBank
{
    public class RequestLoanPage
    {
        private readonly IPage page;

        public RequestLoanPage(IPage page)
        {
            this.page = page;
        }

        public async Task SubmitLoanApplicationFor(string amount, string downPayment, string fromAccountId)
        {
            await this.page.Locator("#amount").FillAsync(amount);
            await this.page.Locator("#downPayment").FillAsync(downPayment);
            await this.page.Locator("#fromAccountId").SelectOptionAsync(fromAccountId);
            await this.page.GetByRole(AriaRole.Button, new() { Name = "Apply Now" }).ClickAsync();
        }
    }
}
