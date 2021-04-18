using System;
using System.Collections.ObjectModel;
using System.Linq;
using Anoshyn.Wallets.GUI.WPF.Navigation;
using AV.ProgrammingWithCSharp.Budgets.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace Anoshyn.Wallets.GUI.WPF.Wallets
{
    public class WalletsViewModel : BindableBase, INavigatable<MainNavigatableTypes>
    {
        private WalletService _service;
        private WalletDetailsViewModel _currentWallet;
        public ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }

        public WalletDetailsViewModel CurrentWallet
        {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand DeleteCommand { get; }
        public DelegateCommand AddCommand { get; }


        public WalletsViewModel()
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
            DeleteCommand = new DelegateCommand(DeleteWallet);
            AddCommand = new DelegateCommand(AddWallet);
        }

        private void DeleteWallet()
        {
            Wallets.Remove(_currentWallet);
        }

        private void AddWallet()
        {
            var wall = new WalletDetailsViewModel(new Models.Wallets.Wallet());
            Wallets.Add(wall);
        }

        public MainNavigatableTypes Type 
        {
            get
            {
                return MainNavigatableTypes.Wallets;
            }
        }
        public void ClearSensitiveData()
        {
            
        }
    }
}
