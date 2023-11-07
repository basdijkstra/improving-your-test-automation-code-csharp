namespace ImprovingYourTestAutomationCode.Answers.Users
{
    public class AdminAccount : Account
    {
        public string Username { get; }
        public string Password { get; }

        public AdminAccount(string username)
        {
            Username = username;
            Password = GeneratePassword();
        }

        public override bool CanAccessLogFiles()
        {
            return true;
        }
    }
}
