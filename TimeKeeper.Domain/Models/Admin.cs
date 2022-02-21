namespace TimeKeeper.Domain.Models;

public class Admin
{
    public Admin(ushort id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }

    public ushort Id { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
}
