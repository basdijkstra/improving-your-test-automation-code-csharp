namespace ImprovingYourTestAutomationCode.Models
{
    internal class LoanApplication
    {
        public int LoanAmount { get; set; }
        public int DownPayment { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
