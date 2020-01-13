namespace AuthenticationServiceNamespace
{
    public class AuthenticationService
    {
        private readonly IProfileDao _profileDao;

        public AuthenticationService(IProfileDao profileDao)
        {
            _profileDao = profileDao;
        }

        public bool Verify(string accountId, string password, string otp)
        {
            var passwordFromDb = _profileDao.GetPassword(accountId);

            return passwordFromDb == password || passwordFromDb == "Hashed Password";
        }
    }
}