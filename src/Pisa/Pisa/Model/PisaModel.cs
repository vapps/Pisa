using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisa.Model
{
	public enum PaymentType
	{
		None = 0,
		Cache = 1,
		Card = 2,
		BankBook = 3
	}

	public enum Category
	{

	}

	public class PisaModel : INotifyPropertyChanged
	{
		#region DateTime Date
		private DateTime _Date;
		public DateTime Date
		{
			get
			{
				return _Date;
			}
			set
			{
				_Date = value;
				OnPropertyChanged("Date");
			}
		}
		#endregion DateTime Date


		#region ▶ INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler == null)
			{
				return;
			}
			handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion INotifyPropertyChanged
	}
}
