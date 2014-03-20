using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisa.DB
{
	public class PisaDataContext : DataContext
	{
		public PisaDataContext()
			: base("Data Source = 'isoStore:/Pisa.sdf'")
		{
		}

		public Table<PisaTable> Items;
	}


	[Table]
	public class PisaTable : INotifyPropertyChanged, INotifyPropertyChanging
	{
		#region int ID
		private int _ID;
		[Column(IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				OnPropertyChanging("ID");
				_ID = value;
				OnPropertyChanged("ID");
			}
		}
		#endregion int ID

		#region int Price
		private int _Price;
		[Column]
		public int Price
		{
			get
			{
				return _Price;
			}
			set
			{
				OnPropertyChanging("Price");
				_Price = value;
				OnPropertyChanged("Price");
			}
		}
		#endregion int Price

		#region string Date
		private string _Date;
		[Column]
		public string Date
		{
			get
			{
				return _Date;
			}
			set
			{
				OnPropertyChanging("Date");
				_Date = value;
				OnPropertyChanged("Date");
			}
		}
		#endregion string Date

		#region int PaymentType
		private int _PaymentType;
		[Column]
		public int PaymentType
		{
			get
			{
				return _PaymentType;
			}
			set
			{
				OnPropertyChanging("PaymentType");
				_PaymentType = value;
				OnPropertyChanged("PaymentType");
			}
		}
		#endregion int PaymentType

		#region int Category
		private int _Category;
		[Column]
		public int Category
		{
			get
			{
				return _Category;
			}
			set
			{
				OnPropertyChanging("Category");
				_Category = value;
				OnPropertyChanged("Category");
			}
		}
		#endregion int Category

		#region string Message
		private string _Message;
		[Column]
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				OnPropertyChanging("Message");
				_Message = value;
				OnPropertyChanged("Message");
			}
		}
		#endregion string Message

		#region string ImagePath
		private string _ImagePath;
		[Column]
		public string ImagePath
		{
			get
			{
				return _ImagePath;
			}
			set
			{
				OnPropertyChanging("ImagePath");
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

		#region INotifyPropertyChanging
		public event PropertyChangingEventHandler PropertyChanging;
		protected virtual void OnPropertyChanging(string propertyName)
		{
			PropertyChangingEventHandler handler = PropertyChanging;
			if (handler != null) handler.Invoke(this, new PropertyChangingEventArgs(propertyName));
		}
		#endregion INotifyPropertyChanging
	}


}
