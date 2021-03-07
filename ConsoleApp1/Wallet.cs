using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public enum CurrencyType
	{
		Hrivna = 1,
		Dollar = 2,
		Euro = 3
	}

	public class Wallet : EntityBase
	{
		private int _ownerId;
		private string _name;
		private string _description;
		private decimal _balance;
		private List<Transaction> transactions;
		private CurrencyType _currency;

		public Wallet()
		{
			transactions = new List<Transaction>();
		}
		public Wallet(int owner, string name, CurrencyType currency, string description, decimal balance) : this()
		{
			transactions = new List<Transaction>();
			this._ownerId = owner;
			this._name = name;
			this._currency = currency;
			this._description = description;
			this._balance = balance;
		}

		public int Owner
		{
			get
			{
				return _ownerId;
			}
			set
			{
				_ownerId = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public CurrencyType Currency
		{
			get
			{
				return _currency;
			}
			set
			{
				_currency = value;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_name = value;
			}
		}

		public decimal Balance
		{
			get
			{
				return _balance;
			}
			set
			{
				_balance = value;
			}
		}

		public void AddTransaction(Transaction transaction)
		{
			if (!transactions.Contains(transaction))
			{
				transactions.Add(transaction);
				_balance += transaction.Sum;
			}
		}

		private int GetTransactionIndex(int id)
		{
			int index = transactions.FindIndex(a => a.Id == id);
			return index;
		}

		public void DeleteTransaction(int id)
		{
			int trans_index = GetTransactionIndex(id);
			if (transactions.Contains(transactions[trans_index]))
			{
				transactions.RemoveAt(trans_index);
			}
		}

		public void EditTransaction(int id, Transaction transaction)
		{
			int index = transactions.FindIndex(a => a.Id == id);
			transactions[index] = transaction;
		}

		public Transaction DeleteTransaction(Transaction transaction)
		{
			Transaction res = transaction;
			foreach (Transaction trans in transactions)
			{
				if (transaction.Id == trans.Id)
				{
					res = trans;
				}
			}
			return res;
		}

		public decimal GetCurrentBalance()
		{
			return _balance;
		}

		public void ShowTransactions()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(transactions[i]);
			}
		}

		public void ShowTransactions(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				Console.WriteLine(transactions[i]);
			}
		}

		public override bool Validate()
		{
			var result = true;

			if (String.IsNullOrWhiteSpace(Name))
				result = false;

			return result;
		}

		public override string ToString()
		{
			return Name + '\n' + Currency + '\n' + Balance;
		}
	}
}