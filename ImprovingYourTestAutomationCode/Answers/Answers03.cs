using ImprovingYourTestAutomationCode.Answers.Users;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Answers
{
    [TestFixture]
    public class Answers03
    {
        [Test]
        public void CheckIfDefaultUserCanAccessLogFiles_shouldBeFalse()
        {
            User user = new User("John Doe", new UserAccount("John Doe"));

            user.PrintInfo();

            Assert.That(user.CanAccessLogFiles(), Is.False);
        }

        [Test]
        public void checkIfAdminUserCanAccessLogFiles_shouldBeTrue()
        {
            User admin = new User("Susan Jones", new AdminAccount("Susan Jones"));

            admin.PrintInfo();

            Assert.That(admin.CanAccessLogFiles(), Is.True);
        }
    }
}
