using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisa.Model
{
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

		#region int Price
		private int _Price;
		public int Price
		{
			get
			{
				return _Price;
			}
			set
			{
				_Price = value;
				OnPropertyChanged("Price");
			}
		}
		#endregion int Price

		#region CategoryModel Category
		private CategoryModel _Category;
		public CategoryModel Category
		{
			get
			{
				return _Category;
			}
			set
			{
				_Category = value;
				OnPropertyChanged("Category");
			}
		}
		#endregion CategoryModel Category

		#region PaymentModel Payment
		private PaymentModel _Payment;
		public PaymentModel Payment
		{
			get
			{
				return _Payment;
			}
			set
			{
				_Payment = value;
				OnPropertyChanged("Payment");
			}
		}
		#endregion PaymentModel Payment

		#region string Message
		private string _Message;
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
				OnPropertyChanged("Message");
			}
		}
		#endregion string Message

		#region string ImagePath
		private string _ImagePath;
		public string ImagePath
		{
			get
			{
				return _ImagePath;
			}
			set
			{
				_ImagePath = value;
				OnPropertyChanged("ImagePath");
			}
		}
		#endregion string ImagePath

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
