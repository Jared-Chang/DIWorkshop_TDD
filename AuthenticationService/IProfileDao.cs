namespace AuthenticationServiceNamespace
{
    public interface IProfileDao
    {
        string GetPassword(string accountId);
    }
}