namespace AuthenticationServiceNamespace
{
    public class AuthenticationService
    {
        public bool Verify(string accountId, string password, string otp)
        {
            if (password == "Wrong Password")
                return false;
            return true;
        }
    }
}