using Anoshyn.Wallets.GUI.WPF.Authentication;
using Anoshyn.Wallets.GUI.WPF.Navigation;
using Anoshyn.Wallets.GUI.WPF.Wallets;
namespace Anoshyn.Wallets.GUI.WPF
{
    public class MainViewModel : NavigationBase<MainNavigatableTypes>
    {
        public MainViewModel()
        {
            Navigate(MainNavigatableTypes.Auth);
        }
        
        protected override INavigatable<MainNavigatableTypes> CreateViewModel(MainNavigatableTypes type)
        {
            if (type == MainNavigatableTypes.Auth)
            {
                return new AuthViewModel(() => Navigate(MainNavigatableTypes.Wallets));
            }
            else
            {
                return new WalletsViewModel();
            }
        }
    }
}
