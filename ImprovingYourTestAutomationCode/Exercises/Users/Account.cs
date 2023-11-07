namespace ImprovingYourTestAutomationCode.Exercises.Users
{
    public class Account
    {
        public string Username { get; }
        public string Password { get; }
        public AccountType AccountType { get; }

        public Account(string username, string password, AccountType accountType)
        {
            Username = username;
            Password = password;
            AccountType = accountType;
        }
    }
}
