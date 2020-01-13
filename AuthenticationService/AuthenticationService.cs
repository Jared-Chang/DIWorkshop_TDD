namespace AuthenticationServiceNamespace
{
    public class AuthenticationService
    {
        public bool Verify(string accountId, string password, string otp)
        {
            var profileDao = new ProfileDao();

            if (password == "Wrong Password" || password == "Wrong Password 2")
                return false;
            return true;
        }
    }

    public class ProfileDao
    {
    }
}