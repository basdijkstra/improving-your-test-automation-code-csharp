using ImprovingYourTestAutomationCode.Models;
using NUnit.Framework;

using static RestAssured.Dsl;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises01 : TestBase
    {
        [TestCase(TestName = "A loan application for $1000 should be approved")]
        public void ApplyFor1000DollarLoan_With100DownPayment_ShouldBeApproved()
        {
            string loanApplication = "{\"LoanAmount\":1000,\"DownPayment\":100,\"FirstName\":\"John\",\"LastName\":\"Doe\"}";

            Given()
                .ContentType("application/json")
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.Result", NHamcrest.Is.EqualTo("Approved"));
        }

        [TestCase(TestName = "A loan application for $2000 should be approved")]
        public void ApplyFor2000DollarLoan_With100DownPayment_ShouldBeApproved()
        {
            string loanApplication = "{\"LoanAmount\":2000,\"DownPayment\":100,\"FirstName\":\"John\",\"LastName\":\"Doe\"}";

            Given()
                .ContentType("application/json")
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.Result", NHamcrest.Is.EqualTo("Approved"));
        }

        [TestCase(TestName = "A loan application for $5000 should be denied")]
        public void ApplyFor5000DollarLoan_With100DownPayment_ShouldBeDenied()
        {
            string loanApplication = "{\"LoanAmount\":5000,\"DownPayment\":100,\"FirstName\":\"John\",\"LastName\":\"Doe\"}";

            Given()
                .ContentType("application/json")
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.Result", NHamcrest.Is.EqualTo("Denied"));
        }
    }
}
