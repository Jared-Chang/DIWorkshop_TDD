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

        [Test]
        public void is_invalid()
        {
            ShouldBeInvalid(DefaultAccountId, "Wrong Password", DefaultOtp);
        }

        [Test]
        public void is_invalid_another_wrong_password()
        {
            ShouldBeInvalid(DefaultAccountId, "Wrong Password 2", DefaultOtp);
        }

        private void ShouldBeInvalid(string accountId, string password, string otp)
        {
            Assert.AreEqual(false, _authenticationService.Verify(accountId, password, otp));
        }

        private void ShouldBeValid(string accountId, string password, string otp)
        {
            Assert.AreEqual(true, _authenticationService.Verify(accountId, password, otp));
        }
    }
}