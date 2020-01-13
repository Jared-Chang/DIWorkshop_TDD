using AuthenticationServiceNamespace;
using NSubstitute;
using NUnit.Framework;

namespace AuthenticationServiceTestNamespace
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        private AuthenticationService _authenticationService;
        private IHash _fakeHash;
        private IProfileDao _fakeProfileDao;
        private const string DefaultAccountId = "Account Id";
        private const string DefaultHashedPassword = "Hashed Password";
        private const string DefaultOtp = "Otp";
        private const string DefaultPassword = "Password";

        [SetUp]
        public void SetUp()
        {
            _fakeProfileDao = Substitute.For<IProfileDao>();
            _fakeHash = Substitute.For<IHash>();
            _authenticationService = new AuthenticationService(_fakeProfileDao, _fakeHash);

            GivenPassword(DefaultAccountId, DefaultPassword);
            GivenHashedPassword(DefaultPassword, DefaultPassword);
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

        [Test]
        public void password_should_hash()
        {
            GivenHashedPassword(DefaultPassword, DefaultHashedPassword);
            GivenPassword(DefaultAccountId, DefaultHashedPassword);

            ShouldBeValid(DefaultAccountId, DefaultPassword, DefaultOtp);
        }

        [Test]
        public void invalid_otp()
        {
            ShouldBeInvalid(DefaultAccountId, DefaultPassword, "Wrong otp");
        }

        private void GivenHashedPassword(string password, string hashedPassword)
        {
            _fakeHash.Compute(password).Returns(hashedPassword);
        }

        private void GivenPassword(string accountId, string password)
        {
            _fakeProfileDao.GetPassword(accountId).Returns(password);
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