using System;
namespace Lab01.GUI.WPF
{
    public class User
    {

        public User(Guid guid, string firstname, string lastname, string email, string login)
        {
            Guid = guid;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Login = login;
        }

        public Guid Guid { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
    }
}
