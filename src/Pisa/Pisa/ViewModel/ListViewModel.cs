using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using Pisa.DB;
using Pisa.Model;

namespace Pisa.ViewModel
{
	public class ListViewModel : ViewModelBase
	{
		#region ObservableCollection<PisaModel> Items
		private ObservableCollection<PisaModel> _Items;
		public ObservableCollection<PisaModel> Items
		{
			get
			{
				return _Items;
			}
			set
			{
				_Items = value;
				RaisePropertyChanged("Items");
			}
		}
		#endregion ObservableCollection<PisaModel> Items

		public ListViewModel()
		{
			Items = ServiceLocator.Current.GetInstance<DBManager>().Items;
		}
	}
}
