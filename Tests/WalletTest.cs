using ConsoleApp1;
using System;
using Xunit;

namespace Lab01.Tests
{
    public class WalletTest
    {

        [Fact]
        public void TestWalletFields()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            user.Wallet = new Wallet("myWallet", CurrencyType.Dollar, "text");
            Transaction tr1 = new Transaction(1, 25000.234, CurrencyType.Dollar, "Test", DateTime.Now);
            Transaction tr2 = new Transaction(2, 25000.234, CurrencyType.Dollar, "Test", DateTime.Now);
            user.Wallet.AddTransaction(tr1);
            user.Wallet.AddTransaction(tr2);

            var expected_name = "myWallet";
            var expected_currency = CurrencyType.Dollar;
            var expected_description = "text";

            //Act
            var actual_name = user.Wallet.Name;
            var actual_currency = user.Wallet.Currency;
            var actual_description = user.Wallet.Description;

            //Assert
            Assert.Equal(expected_name, actual_name);
            Assert.Equal(expected_currency, actual_currency);
            Assert.Equal(expected_description, actual_description);
        }

        [Fact]
        public void TestName()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            user.Wallet.Name = "Wallet1";
            var expected_name = "Wallet1";

            //Act
            var actual_name = user.Wallet.Name;
   
            //Assert
            Assert.Equal(expected_name, actual_name);
        }

        [Fact]
        public void TestOwner()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            var expected_owner = user;

            //Act
            var actual_owner = user.Wallet.Owner;

            //Assert
            Assert.Equal(expected_owner, actual_owner);
        }

        [Fact]
        public void TestCurrency()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            user.Wallet.Currency = CurrencyType.Dollar;
            var expected_currency = CurrencyType.Dollar;

            //Act
            var actual_currency = user.Wallet.Currency;

            //Assert
            Assert.Equal(expected_currency, actual_currency);
        }

        [Fact]
        public void TestTransaction()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            user.Wallet.Currency = CurrencyType.Dollar;
            Transaction tr1 = new Transaction(1, 25000.234, CurrencyType.Hrivna, "Test", DateTime.Now);
            user.Wallet.AddTransaction(tr1);
            var expected_transaction = tr1;

            //Act
            var actual_transaction = user.Wallet.GetTransaction(tr1);

            //Assert
            Assert.Equal(expected_transaction, actual_transaction);
        }

        [Fact]
        public void TestSharedWalletOwner()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            var user1 = new User(1, "Dave", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            user.Wallet.Currency = CurrencyType.Dollar;
            user.ShareWallet(user.Wallet, user1);
            var expected_owner = user;
            
            //Act
            var actual_owner = user1.Wallets[0].Owner;

            //Assert
            Assert.Equal(expected_owner, actual_owner);
        }


        [Fact]
        public void TestSharedWalletEditTransaction()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            var user1 = new User(2, "Dave", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            user.Wallet.Currency = CurrencyType.Dollar;
            Transaction tr1 = new Transaction(1, 25000.234, CurrencyType.Hrivna, "Test", DateTime.Now);
            Transaction tr2 = new Transaction(2, 25000.234, CurrencyType.Hrivna, "Test", DateTime.Now);
            user.Wallet.AddTransaction(tr1);
            user.Wallet.AddTransaction(tr2);
            user.ShareWallet(user.Wallet, user1);
            user1.Wallets[0].EditTransaction(tr1.Id, tr2);
            var expected_transaction = tr1;

            //Act
            var actual_transaction = user1.Wallets[0].GetTransaction(tr1);

            //Assert
            Assert.Equal(expected_transaction, actual_transaction);
        }

        [Fact]
        public void TestSharedWalletDeleteTransaction()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            var user1 = new User(2, "Dave", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            user.Wallet.Currency = CurrencyType.Dollar;
            Transaction tr1 = new Transaction(1, 25000.234, CurrencyType.Hrivna, "Test", DateTime.Now);
            Transaction tr2 = new Transaction(2, 25000.234, CurrencyType.Hrivna, "Test", DateTime.Now);
            user.Wallet.AddTransaction(tr1);
            user.Wallet.AddTransaction(tr2);
            user.ShareWallet(user.Wallet, user1);
            user1.Wallets[0].DeleteTransaction(tr1.Id);
            var expected_transaction = tr1;

            //Act
            var actual_transaction = user1.Wallets[0].GetTransaction(tr1);

            //Assert
            Assert.Equal(expected_transaction, actual_transaction);
        }

        [Fact]
        public void TestGetMonthIncome()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            user.Wallet = new Wallet("myWallet", CurrencyType.Dollar, "text");
            Transaction tr1 = new Transaction(1, 25000, CurrencyType.Dollar, "Test", DateTime.Now);
            Transaction tr2 = new Transaction(2, 25000, CurrencyType.Dollar, "Test", DateTime.Now);
            user.Wallet.AddTransaction(tr1);
            user.Wallet.AddTransaction(tr2);
            var expected_income = 50000;

            //Act
            var actual_income = user.Wallet.GetMonthIncome();
    
            //Assert
            Assert.Equal(expected_income, actual_income);
        
        }

        [Fact]
        public void TestIncomeCurrency()
        {
            //Arrange
            var user = new User(1, "John", "Doe", "hello@world.com");
            user.Wallet = new Wallet();
            user.Wallet.Currency = CurrencyType.Dollar;
            Transaction tr1 = new Transaction(1, 27, CurrencyType.Hrivna, "Test", DateTime.Now);
            Transaction tr2 = new Transaction(2, 5, CurrencyType.Dollar, "Test", DateTime.Now);
            user.Wallet.AddTransaction(tr1);
            user.Wallet.AddTransaction(tr2);
            var expected_sum = 6;

            //Act
            int actual_sum = (int)user.Wallet.GetMonthIncome();

            //Assert
            Assert.Equal(expected_sum, actual_sum);
        }
    }
}
