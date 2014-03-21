using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Pisa.DB;
using Pisa.Model;

namespace Pisa.ViewModel
{

	public class MainViewModel : ViewModelBase
	{
		#region ObservableCollection<PisaModel> Items
		private ObservableCollection<PisaModel> _items;
		public ObservableCollection<PisaModel> Items
		{
			get
			{
				return _items;
			}
			set
			{
				if (_items != value)
				{
					_items = value;
					RaisePropertyChanged("Items");
				}
			}
		}
		#endregion ObservableCollection<PisaModel> Items



		public RelayCommand<PisaModel> AddCommand { get; set; }
		public RelayCommand LoadAllCommand { get; set; }


		public MainViewModel()
		{
			if (IsInDesignMode)
			{
				// Code runs in Blend --> create design time data.
			}
			else
			{
				CreateCommand();
				LoadAllItems();
			}
		}

		private void CreateCommand()
		{
			AddCommand = new RelayCommand<PisaModel>(AddPisa);
			LoadAllCommand = new RelayCommand(LoadAllItems);
		}

		public void AddPisa(PisaModel model)
		{
			Items.Add(model);
			DBManager.Current.AddPisaModel(model);
		}

		public void LoadAllItems()
		{
			Items = new ObservableCollection<PisaModel>(DBManager.Current.GetAllItems());
		}
	}
}