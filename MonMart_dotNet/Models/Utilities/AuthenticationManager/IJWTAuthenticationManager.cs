namespace MonMart.Utilities.AuthenticationManager
{
    public interface IJWTAuthenticationManager
    {
        string? Authenticate(string username, string password);
    }
}
