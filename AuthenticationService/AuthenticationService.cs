namespace AuthenticationServiceNamespace
{
    public class AuthenticationService
    {
        private ProfileDao _profileDao;

        public AuthenticationService()
        {
            _profileDao = new ProfileDao();
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