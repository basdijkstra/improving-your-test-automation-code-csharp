namespace ImprovingYourTestAutomationCode.Answers.Users
{
    public class UserAccount : Account
    {
        public string Username { get; }
        public string Password { get; }

        public UserAccount(string username)
        {
            Username = username;
            Password = GeneratePassword();
        }

        public override bool CanAccessLogFiles()
        {
            return false;
        }
    }
}
