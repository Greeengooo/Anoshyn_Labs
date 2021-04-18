using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.GUI.WPF
{
    public class AuthService
    {
        public User Auth(AuthUser authUser)
        {
            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or Password is NULL");
            return new User(Guid.NewGuid(), "Oleksii", "Anoshyn", "email@gmail.com", "aanoshyn");
        }
    }
}
