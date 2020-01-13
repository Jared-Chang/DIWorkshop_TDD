namespace AuthenticationServiceNamespace
{
    public interface IHash
    {
        string Compute(string password);
    }
}