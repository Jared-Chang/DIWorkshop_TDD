using AuthenticationServiceNamespace;
using NUnit.Framework;

namespace AuthenticationServiceTestNamespace
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        [Test]
        public void is_valid()
        {
            var authenticationService = new AuthenticationService();

            Assert.AreEqual(true, authenticationService.Verify("Account Id", "Password", "Otp"));
        }
    }
}