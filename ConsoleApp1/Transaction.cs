using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	public class Transaction : EntityBase
	{
		private int _id;
		private double _sum;
		private CurrencyType _currency;
		private Category _category;
        private string? _description;
		private DateTime _date;
		private FileInfo attachment;
		public Transaction() {}
		public Transaction(int id, double sum, CurrencyType currency, string description,  DateTime date)
		{
			this._id = id;
			this._sum = sum;
			this._currency = currency;
			this._description = description;
			this._date = date;
		}

		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}


		public double Sum
		{
			get
			{
				return _sum;
			}
			set
			{
				_sum = value;
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

		public Category Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
			}
		}

		public string? Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public DateTime Date
		{
			get
			{
				return _date;
			}
			set
			{
				_date = value;
			}
		}

		public FileInfo Attachment
		{
			get
			{
				return attachment;
			}
			set
			{
				attachment = value;
			}
		}

		public override bool Validate()
		{
			var result = true;

			if (Id == 0)
				result = false;

			return result;
		}
	}
}
