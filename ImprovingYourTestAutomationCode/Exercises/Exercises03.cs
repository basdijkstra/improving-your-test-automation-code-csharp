using GraphQL.Validation.Rules;
using ImprovingYourTestAutomationCode.Pages.ParaBank;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises03 : PageTest
    {
        [TestCase("1000", "100", "Approved", TestName = "A 1000 dollar loan should be approved")]
        [TestCase("10000", "100", "Denied", TestName = "A 10000 dollar loan should be denied")]
        [TestCase("5000", "500", "Approved", TestName = "A 5000 dollar loan should be approved")]
        public async Task SubmitALoanApplicationRequest
            (string loanAmount, string downPayment, string expectedResult)
        {
            var loginPage = new LoginPage(Page);
            await loginPage.Open();
            await loginPage.LoginAs("john", "demo");

            await new AccountsOverviewPage(Page)
                .SelectMenuItem("Request Loan");

            await new RequestLoanPage(Page)
                .SubmitLoanApplicationFor(loanAmount, downPayment, "12345");

            await Expect(Page.Locator("#loanStatus")).ToBeVisibleAsync();
            await Expect(Page.Locator("#loanStatus")).ToHaveTextAsync(expectedResult);
        }
    }
}
