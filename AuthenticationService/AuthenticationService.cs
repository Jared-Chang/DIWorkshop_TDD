namespace AuthenticationServiceNamespace
{
    public class AuthenticationService
    {
        private IProfileDao _profileDao;

        public AuthenticationService(IProfileDao profileDao)
        {
            _profileDao = profileDao;
        }

        public bool Verify(string accountId, string password, string otp)
        {
            if (password == "Wrong Password" || password == "Wrong Password 2")
                return false;
            return true;
        }
    }

    public interface IProfileDao
    {
    }

    public class ProfileDao : IProfileDao
    {
    }
}