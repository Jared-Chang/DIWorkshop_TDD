using AuthenticationServiceNamespace;
using NUnit.Framework;

namespace AuthenticationServiceTestNamespace
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        private AuthenticationService _authenticationService;
        private const string DefaultAccountId = "Account Id";
        private const string DefaultOtp = "Otp";
        private const string DefaultPassword = "Password";

        [SetUp]
        public void SetUp()
        {
            _authenticationService = new AuthenticationService();
        }

        [Test]
        public void is_valid()
        {
            ShouldBeValid(DefaultAccountId, DefaultPassword, DefaultOtp);
        }

        private void ShouldBeValid(string accountId, string password, string otp)
        {
            Assert.AreEqual(true, _authenticationService.Verify(accountId, password, otp));
        }
    }
}