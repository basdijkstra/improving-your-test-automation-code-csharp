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

        [Test]
        public void ApplyFor1000DollarLoan_with100DownPayment_shouldBeApproved()
        {
            string requestBody = @"
                {
                    ""loanAmount"": ""1000"",
                    ""downPayment"": ""100"",
                    ""firstName"": ""John"",
                    ""lastName"" : ""Doe""
                }";

            Given()
                .Body(requestBody)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.result", NHamcrest.Is.EqualTo("Approved"));
        }

        [Test]
        public void ApplyFor10000DollarLoan_with100DownPayment_shouldBeDenied()
        {
            string requestBody = @"
                {
                    ""loanAmount"": ""10000"",
                    ""downPayment"": ""100"",
                    ""firstName"": ""John"",
                    ""lastName"" : ""Doe""
                }";

            Given()
                .Body(requestBody)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.result", NHamcrest.Is.EqualTo("Denied"));
        }

        [Test]
        public void ApplyFor5000DollarLoan_with500DownPayment_shouldBeApproved()
        {
            string requestBody = @"
                {
                    ""loanAmount"": ""5000"",
                    ""downPayment"": ""500"",
                    ""firstName"": ""John"",
                    ""lastName"" : ""Doe""
                }";

            Given()
                .Body(requestBody)
                .When()
                .Post("http://localhost:9876/loanApplication")
                .Then()
                .StatusCode(201)
                .Body("$.result", NHamcrest.Is.EqualTo("Approved"));
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
