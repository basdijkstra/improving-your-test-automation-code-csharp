using ImprovingYourTestAutomationCode.Pages.ParaBank;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises03 : PageTest
    {
        [Test]
        public async Task SubmitALoanApplicationRequest()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.Open();
            await loginPage.LoginAs("john", "demo");

            await new AccountsOverviewPage(Page)
                .SelectMenuItem("Request Loan");

            await new RequestLoanPage(Page)
                .SubmitLoanApplicationFor("1000", "100", "12345");

            await Expect(Page.Locator("#loanStatus")).ToBeVisibleAsync();
            await Expect(Page.Locator("#loanStatus")).ToHaveTextAsync("Approved");
        }

        [Test]
        public async Task SubmitAnotherLoanApplicationRequest()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.Open();
            await loginPage.LoginAs("john", "demo");

            await new AccountsOverviewPage(Page)
                .SelectMenuItem("Request Loan");

            await new RequestLoanPage(Page)
                .SubmitLoanApplicationFor("10000", "100", "12345");

            await Expect(Page.Locator("#loanStatus")).ToBeVisibleAsync();
            await Expect(Page.Locator("#loanStatus")).ToHaveTextAsync("Denied");
        }

        [Test]
        public async Task SubmitYetAnotherLoanApplicationRequest()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.Open();
            await loginPage.LoginAs("john", "demo");

            await new AccountsOverviewPage(Page)
                .SelectMenuItem("Request Loan");

            await new RequestLoanPage(Page)
                .SubmitLoanApplicationFor("5000", "500", "12345");

            await Expect(Page.Locator("#loanStatus")).ToBeVisibleAsync();
            await Expect(Page.Locator("#loanStatus")).ToHaveTextAsync("Approved");
        }
    }
}
