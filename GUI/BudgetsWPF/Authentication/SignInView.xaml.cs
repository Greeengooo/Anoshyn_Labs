﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace Anoshyn.Wallets.GUI.WPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
        public SignInView()
        {
            InitializeComponent();
        }

        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((SignInViewModel)DataContext).Password = TbPassword.Password;
        }
    }
}
