using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anoshyn.Wallets.Models.Wallets;


namespace AV.ProgrammingWithCSharp.Budgets.Services
{
    public class WalletService
    {
        private static List<Wallet> Users = new List<Wallet>()
        {
            new Wallet() {Name = "Wallet1", Balance = 57.06m},
            new Wallet() {Name = "Wallet2", Balance = 157.06m},
            new Wallet() {Name = "Wallet3", Balance = 257.06m},
            new Wallet() {Name = "Wallet4", Balance = 357.06m},
            new Wallet() {Name = "Wallet5", Balance = 457.06m}
        };

        public List<Wallet> GetWallets()
        {
            return Users.ToList();
        }
    }
}
