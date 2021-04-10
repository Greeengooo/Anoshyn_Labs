using Lab01.GUI.WPF.Auth;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Lab01.GUI.WPF
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        private SignInViewModel _viewModel;
        public SignIn()
        {
            InitializeComponent();
            _viewModel = new SignInViewModel();
            this.DataContext = _viewModel;
            BSignIn.IsEnabled = false;
            BSignUp.IsEnabled = false;
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbLogin.Text) || String.IsNullOrWhiteSpace(TbPassword.Text))
            {
                MessageBox.Show("Empty Fields");
            }
            else
            {
                var authUser = new AuthUser()
                {
                    Login = TbLogin.Text,
                    Password = TbPassword.Text
                };
                var authService = new AuthService();
                User user = null;
                try
                {
                    user = authService.Auth(authUser);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Sign in failed: {ex.Message}");
                    return;
                }
                MessageBox.Show($"Success for {user.FirstName} {user.LastName}");
            }
        }

        private void TbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbLogin.Text) || String.IsNullOrWhiteSpace(TbPassword.Text))
            {
                BSignIn.IsEnabled = false;
                BSignUp.IsEnabled = false;
            }
            else
            {
                BSignIn.IsEnabled = true;
                BSignUp.IsEnabled = true;
            }
        }

        private void TbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbPassword.Text) || String.IsNullOrWhiteSpace(TbLogin.Text))
            {
                BSignIn.IsEnabled = false;
                BSignUp.IsEnabled = false;
            }
            else
            {
                BSignIn.IsEnabled = true;
                BSignUp.IsEnabled = true;
            }
        }
    }
}
