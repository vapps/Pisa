using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisa.Model
{
	public class CategoryModel : INotifyPropertyChanged
	{
		#region int ID
		private int _ID;
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
				OnPropertyChanged("ID");
			}
		}
		#endregion int ID

		#region string Name
		private string _Name;
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
				OnPropertyChanged("Name");
			}
		}
		#endregion string Name

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
