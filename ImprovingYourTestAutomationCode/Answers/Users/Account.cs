namespace ImprovingYourTestAutomationCode.Answers.Users
{
    public abstract class Account
    {
        public abstract bool CanAccessLogFiles();

        protected string GeneratePassword()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
