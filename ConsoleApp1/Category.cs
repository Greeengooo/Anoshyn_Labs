using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public class Category : EntityBase
	{
		private string _name;
		private string _description;
		private string _colour;

		public Category(string name, string description, string colour)
        {
			this._name = name;
			this._description = description;
			this._colour = colour;
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

		public string Colour
		{
			get
			{
				return _colour;
			}
			set
			{
				_colour = value;
			}
		}

		public override bool Validate()
		{
			var result = true;

			if (String.IsNullOrWhiteSpace(Name))
				result = false;

			return result;
		}
	}
}
