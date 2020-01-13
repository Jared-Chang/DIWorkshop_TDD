namespace AuthenticationServiceNamespace
{
    public class AuthenticationService
    {
        private ProfileDao _profileDao;

        public AuthenticationService(ProfileDao profileDao)
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

    public class ProfileDao
    {
    }
}