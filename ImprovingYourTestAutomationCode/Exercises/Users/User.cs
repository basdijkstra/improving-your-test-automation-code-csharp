using System;

namespace ImprovingYourTestAutomationCode.Exercises.Users
{
    public class User
    {
        public string Name { get; }
        public Account Account { get; }

        public User(string name)
        {
            Name = name;
            Account = new Account(name, GeneratePassword(), AccountType.Default);
        }

        private string GeneratePassword()
        {
            return Guid.NewGuid().ToString();
        }

        public void PrintInfo()
        {
            Console.WriteLine($"User name: {this.Name}, account type: {this.Account.AccountType}");
        }

        public bool CanAccessLogFiles()
        {
            return this.Account.AccountType.Equals(AccountType.Admin);
        }
    }
}
