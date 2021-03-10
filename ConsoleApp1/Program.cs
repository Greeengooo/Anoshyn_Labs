using System;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		//Main test class
		static void Main(string[] args)
		{
			User user1 = new User();
			User user2 = new User();
			user1.FirstName = "John";
			user1.LastName = "Doe";
			Console.WriteLine(user1.ToString());

			Wallet w1 = new Wallet();
			w1.Currency = CurrencyType.Hrivna;

			Transaction tr1 = new Transaction(1, 27, CurrencyType.Hrivna, "Test", DateTime.Now);
			Transaction tr2 = new Transaction(2, 5, CurrencyType.Dollar, "Test", DateTime.Now);

			var user = new User(1, "John", "Doe", "hello@world.com");
			user.Wallet = new Wallet();
			user.Wallet.Currency = CurrencyType.Dollar;
			user.Wallet.AddTransaction(tr1);
			user.Wallet.AddTransaction(tr2);
			

			Console.WriteLine(user.Wallet.GetMonthIncome());

			foreach (Wallet w in user1.Wallets)
            {
				Console.WriteLine(w);
            }
		}
	}
}
