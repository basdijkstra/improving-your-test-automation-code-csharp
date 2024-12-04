using Newtonsoft.Json;

namespace ImprovingYourTestAutomationCode.Models
{
    public class LoanRequest
    {
        [JsonProperty("loanAmount")]
        public string LoanAmount { get; set; }

        [JsonProperty("downPayment")]
        public string DownPayment { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
