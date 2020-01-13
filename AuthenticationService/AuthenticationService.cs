namespace AuthenticationServiceNamespace
{
    public class AuthenticationService
    {
        private readonly IProfileDao _profileDao;
        private readonly IHash _sha256Adapter;

        public AuthenticationService(IProfileDao profileDao, IHash sha256Adapter)
        {
            _profileDao = profileDao;
            _sha256Adapter = sha256Adapter;
        }

        public bool Verify(string accountId, string password, string otp)
        {
            var passwordFromDb = _profileDao.GetPassword(accountId);
            var hashedPassword = _sha256Adapter.Compute(password);

            return passwordFromDb == hashedPassword;
        }
    }
}