using ImprovingYourTestAutomationCode.Exercises.Users;
using NUnit.Framework;

namespace ImprovingYourTestAutomationCode.Exercises
{
    [TestFixture]
    public class Exercises03
    {
        [Test]
        public void CheckIfDefaultUserCanAccessLogFiles_ShouldBeFalse()
        {
            User user = new User("John Doe");

            user.PrintInfo();

            Assert.That(user.CanAccessLogFiles(), Is.False);
        }

        [Test]
        public void CheckIfAdminUserCanAccessLogFiles_ShouldBeTrue()
        {
            /// Eeerrmmm..
        }
    }
}
