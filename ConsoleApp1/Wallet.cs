using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public enum CurrencyType
	{
		Hrivna = 1,
		Dollar = 2,
	}

	public class Wallet : EntityBase
	{
		private User _owner;
		private string _name;
		private string _description;
		private string _status;
		private double _balance;
		private List<Transaction> transactions_income;
		private List<Transaction> transactions_spendings;
		private CurrencyType _currency;

		public Wallet()
		{
			transactions_income = new List<Transaction>();
			transactions_spendings = new List<Transaction>();
		}
		public Wallet(string name, CurrencyType currency, string description) : this()
		{
			transactions_income = new List<Transaction>();
			this._name = name;
			this._currency = currency;
			this._description = description;
		}

		public User Owner
		{
			get
			{
				return _owner;
			}
            set
            {
				if (_owner == null)
				{
					_owner = value;
				}
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

		public string Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
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

		public double Balance
		{
			get
			{
				return _balance;
			}
		}

		public void AddTransaction(Transaction tr)
		{
			if (!transactions_income.Contains(tr))
			{
				if (_currency == CurrencyType.Hrivna && tr.Currency == CurrencyType.Dollar)
				{
					tr.Sum *= 27.4;
				}
				else if(_currency == CurrencyType.Dollar && tr.Currency == CurrencyType.Hrivna)
				{
					tr.Sum *= 0.038;
				}
				transactions_income.Add(tr);
				_balance += tr.Sum;
			}
		}

		private int GetTransactionIndex(int id)
		{
			int index = transactions_income.FindIndex(a => a.Id == id);
			return index;
		}

		public double GetMonthIncome()
        {
			double total = 0;
			List<Transaction> month_trans = new List<Transaction>(); 

			foreach (Transaction tr in transactions_income)
			{
				if (tr.Date.Month == DateTime.Now.Month)
                {
					month_trans.Add(tr);
                }
			}

			foreach (Transaction tr in month_trans)
			{
				total += tr.Sum;
			}
			return total;
        }

		public double GetMonthSpendings()
		{
			double total = 0;
			List<Transaction> month_trans = new List<Transaction>();

			foreach (Transaction tr in transactions_income)
			{
				if (tr.Date.Month == DateTime.Now.Month)
				{
					month_trans.Add(tr);
				}
			}

			foreach (Transaction tr in month_trans)
			{
				if (tr.Currency == Currency)
				{
					total += tr.Sum;
				}
				else
				{
					if (_currency == CurrencyType.Hrivna && tr.Currency == CurrencyType.Dollar)
						tr.Sum *= 27;
					else
						tr.Sum *= 0.036;
				}

			}
			return total;
		}


		public void DeleteTransaction(int id)
		{
			if (Status == "owner")
			{
				int trans_index = GetTransactionIndex(id);
				if (transactions_income.Contains(transactions_income[trans_index]))
				{
					transactions_income.RemoveAt(trans_index);
				}
			}
		}

		public void EditTransaction(int id, Transaction transaction)
		{
			if (Status == "owner")
			{
				int index = transactions_income.FindIndex(a => a.Id == id);
				transactions_income[index] = transaction;
			}
		}

		public Transaction GetTransaction(Transaction transaction)
		{
			Transaction result = new Transaction();
			foreach (Transaction tr in transactions_income)
			{
				if (tr == transaction)
				{
					result = tr;
				}
			}
			return result;
		}

		public void ShowTransactions()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(transactions_income[i]);
			}
		}

		public void ShowTransactions(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				Console.WriteLine(transactions_income[i]);
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