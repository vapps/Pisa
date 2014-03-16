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
