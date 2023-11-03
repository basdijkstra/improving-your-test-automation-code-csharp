using ImprovingYourTestAutomationCode.Models;
using NUnit.Framework;

using static RestAssured.Dsl;

namespace ImprovingYourTestAutomationCode.Answers
{
    [TestFixture]
    public class Answers01 : TestBase
    {
        [TestCase(1000, "Approved", TestName = "A loan application for $1000 should be approved")]
        [TestCase(2000, "Approved", TestName = "A loan application for $2000 should be approved")]
        [TestCase(5000, "Denied", TestName = "A loan application for $5000 should be denied")]
        public void ApplyForLoan_With100DownPayment_ShouldBe(int loanAmount, string expectedResult)
        {
            var loanApplication = new LoanApplication()
            {
                LoanAmount = loanAmount,
                DownPayment = 100,
                FirstName = "John",
                LastName = "Doe"
            };

            Given()
                .ContentType("application/json")
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.Result", NHamcrest.Is.EqualTo(expectedResult));
        }
    }
}
