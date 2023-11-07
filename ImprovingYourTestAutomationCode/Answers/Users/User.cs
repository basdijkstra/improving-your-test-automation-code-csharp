namespace ImprovingYourTestAutomationCode.Answers.Users
{
    public class User
    {
        public string Name { get; private set; }
        public Account Account { get; private set; }

        public User(string name, Account account)
        {
            Name = name;
            Account = account;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"User name: {this.Name}, account type: {this.Account.GetType().Name}");
        }

        public bool CanAccessLogFiles()
        {
            return this.Account.CanAccessLogFiles();
        }
    }
}
