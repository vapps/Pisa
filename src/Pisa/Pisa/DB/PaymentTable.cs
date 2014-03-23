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
	public class PaymentDataContext : DataContext
	{
		public PaymentDataContext() :
			base("Data Source = 'isoStore:/Payment.sdf'")
		{

		}

		public Table<PaymentTable> Items;
	}

	[Table]
	public class PaymentTable : INotifyPropertyChanged, INotifyPropertyChanging
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

		#region string Name
		private string _Name;
		[Column]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				OnPropertyChanging("Name");
				_Name = value;
				OnPropertyChanged("Name");
			}
		}
		#endregion int ID

		#region INotifyPropertyChanged
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
