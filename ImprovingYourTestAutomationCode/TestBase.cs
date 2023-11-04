using NUnit.Framework;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace ImprovingYourTestAutomationCode
{
    public class TestBase
    {
        private WireMockServer? Server { get; set; }

        [SetUp]
        protected void StartServer()
        {
            this.Server = WireMockServer.Start(9876);

            this.CreateStubFor1000DollarLoan();
            this.CreateStubFor2000DollarLoan();
            this.CreateStubFor5000DollarLoan();
        }

        [TearDown]
        protected void StopServer()
        {
            this.Server?.Stop();
        }

        private void CreateStubFor1000DollarLoan()
        {
            this.Server?.Given(Request.Create().WithPath("/loanApplication").UsingPost()
                .WithBody(new JsonMatcher("{\"LoanAmount\":1000,\"DownPayment\":100,\"FirstName\":\"John\",\"LastName\":\"Doe\"}")))
                .RespondWith(Response.Create()
                .WithStatusCode(201) 
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(new { Result = "Approved" })
                );
        }

        private void CreateStubFor2000DollarLoan()
        {
            this.Server?.Given(Request.Create().WithPath("/loanApplication").UsingPost()
                .WithBody(new JsonMatcher("{\"LoanAmount\":2000,\"DownPayment\":100,\"FirstName\":\"John\",\"LastName\":\"Doe\"}")))
                .RespondWith(Response.Create()
                .WithStatusCode(201)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(new { Result = "Approved" })
                );
        }

        private void CreateStubFor5000DollarLoan()
        {
            this.Server?.Given(Request.Create().WithPath("/loanApplication").UsingPost()
                .WithBody(new JsonMatcher("{\"LoanAmount\":5000,\"DownPayment\":100,\"FirstName\":\"John\",\"LastName\":\"Doe\"}")))
                .RespondWith(Response.Create()
                .WithStatusCode(201)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(new { Result = "Denied" })
                );
        }
    }
}
