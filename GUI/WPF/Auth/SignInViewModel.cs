using Prism.Commands;
using System;

namespace Lab01.GUI.WPF.Auth
{
    public class SignInViewModel
    {
        private AuthUser _authUser = new AuthUser();
        public string Login
        {
            get 
            {
                return _authUser.Login;
            }
            set 
            {
                _authUser.Login = value;
            }
        }

        public string Password
        {
            get
            {
                return _authUser.Password;
            }
            set
            {
                _authUser.Password = value;
            }
        }

        public DelegateCommand SignInCommand { get; }

        public SignInViewModel()
        { 
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnabled)
        }

        private void SignIn()
        {
            throw new NotImplementedException();
        }

        private bool IsSignInEnabled()
        {
            throw new NotImplementedException();
        }
    }
}
