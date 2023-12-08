using System   ;

// Interface for the type of user that can be created

public interface IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Login();
    public bool Logout();
}

public interface IAdmin : IUser
{
    bool AddUser(IUser user);
    bool RemoveUser(IUser user);
}