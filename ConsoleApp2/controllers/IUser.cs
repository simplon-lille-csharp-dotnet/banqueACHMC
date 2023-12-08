using System;

// Interface for the type of user that can be created
public interface IUser
{
    string Username { get; set; }
    string Password { get; set; }
    bool Login();
    bool Logout();
}


public interface IAdmin : IUser
{
    bool AddUser(IUser user);
    bool RemoveUser(IUser user);
}