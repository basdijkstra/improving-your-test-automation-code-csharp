using ImprovingYourTestAutomationCode.Models;
using NUnit.Framework;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using static RestAssured.Dsl;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises04
    {
        private WireMockServer? wireMockServer;

        [OneTimeSetUp]
        public void StartMockServer()
        {
            this.wireMockServer = WireMockServer.Start(9876);
            SetupMockResponses();
        }

        [TestCase("1000", "100", "Approved", TestName = "A 1000 dollar loan should be approved")]
        [TestCase("10000", "100", "Denied", TestName = "A 10000 dollar loan should be denied")]
        [TestCase("5000", "500", "Approved", TestName = "A 5000 dollar loan should be approved")]

        public void ApplyFor1000DollarLoan_with100DownPayment_shouldBeApproved
            (string loanAmount, string downPayment, string expectedResult)
        {
            var loanRequest = new LoanRequest
            {
                LoanAmount = loanAmount,
                DownPayment = downPayment,
                FirstName = "John",
                LastName = "Doe",
            };

            Given()
                .Body(loanRequest)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.result", NHamcrest.Is.EqualTo(expectedResult));
        }

        [OneTimeTearDown]
        public void StopMockServer()
        {
            this.wireMockServer?.Stop();
        }

        private void SetupMockResponses()
        {
            var approvedResponse = new
            {
                result = "Approved"
            };

            var deniedResponse = new
            {
                result = "Denied"
            };

            this.wireMockServer?.Given(Request.Create().WithPath("/loanApplication").UsingPost()
                .WithBody(new JmesPathMatcher("loanAmount == '1000'")))
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(approvedResponse)
                .WithStatusCode(201));

            this.wireMockServer?.Given(Request.Create().WithPath("/loanApplication").UsingPost()
                .WithBody(new JmesPathMatcher("loanAmount == '10000'")))
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(deniedResponse)
                .WithStatusCode(201));

            this.wireMockServer?.Given(Request.Create().WithPath("/loanApplication").UsingPost()
                .WithBody(new JmesPathMatcher("loanAmount == '5000'")))
                .RespondWith(Response.Create()
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(approvedResponse)
                .WithStatusCode(201));
        }
    }
}
