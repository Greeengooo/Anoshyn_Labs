using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public class User : EntityBase
	{
        private int _id;
		private string _lastName;
		private string _firstName;
		private string _email;
        private Wallet _wallet;
        private List<Wallet>? _wallets;
        private List<Category>? _categories;



        public User()
        {
            IsNew = true;
            _wallets = new List<Wallet>();
            _categories = new List<Category>();
        }
        public User(int id, string lastName, string firstName, string email) : this()
        {
            this._id = id;
            this._lastName = lastName;
            this._firstName = firstName;
            this._email = email;
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
                HasChanges = true;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                HasChanges = true;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                HasChanges = true;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                HasChanges = true;
            }
        }

        public Wallet Wallet
        {
            get
            {
                return _wallet;
            }
            set
            {
                if (_wallet == null)
                {
                    _wallet = value;
                    _wallet.Owner = this;
                    _wallet.Status = "owner";
                }
            }
        }
        public List<Wallet> Wallets
        {
            get
            {
                return _wallets;
            }
        }

        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public string FullName
        {
            get
            {
                var result = LastName;
                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    if (!String.IsNullOrWhiteSpace(LastName))
                    {
                        result += ", ";
                    }
                    result += FirstName;
                }
                return result;
            }
        }

        public void ShareWallet(Wallet wallet, User user)
        {
            Wallet transfer = wallet;
            transfer.Status = "user";
            user.AddWallet(transfer);
        }

        public void AddWallet(Wallet wallet)
        {
            _wallets.Add(wallet);
        }

        public override bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(LastName))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;

            return result;
        }

        public override string ToString()
        {
            return FullName;
        }
    }

}
