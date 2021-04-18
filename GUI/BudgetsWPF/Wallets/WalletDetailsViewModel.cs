using Anoshyn.Wallets.Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;

namespace Anoshyn.Wallets.GUI.WPF.Wallets
{
    public class WalletDetailsViewModel : BindableBase
    {
        private Wallet _wallet;

        public string Name
        {
            get
            {
                return _wallet.Name;
            }
            set
            {
                _wallet.Name = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public decimal Balance
        {
            get
            {
                return _wallet.Balance;
            }
            set
            {
                _wallet.Balance = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName
        {
            get
            {
                return $"{_wallet.Name} (${_wallet.Balance})";
            }
        }

        public DelegateCommand DeleteWalletCommand { get; }

        public WalletDetailsViewModel(Wallet wallet)
        {
            _wallet = wallet;
            DeleteWalletCommand = new DelegateCommand(DeleteWallet);
        }

        private void DeleteWallet()
        {
          
        }
    }
}
