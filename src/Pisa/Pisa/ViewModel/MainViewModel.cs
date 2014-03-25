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

		#region ObservableCollection<PaymentModel> Payments
		private ObservableCollection<PaymentModel> _Payments;
		public ObservableCollection<PaymentModel> Payments
		{
			get
			{
				return _Payments;
			}
			set
			{
				_Payments = value;
				RaisePropertyChanged("Payments");
			}
		}
		#endregion ObservableCollection<PaymentModel> Payments

		#region ObservableCollection<CategoryModel> Categories
		private ObservableCollection<CategoryModel> _Categories;
		public ObservableCollection<CategoryModel> Categories
		{
			get
			{
				return _Categories;
			}
			set
			{
				_Categories = value;
				RaisePropertyChanged("Categories");
			}
		}
		#endregion ObservableCollection<CategoryModel> Categories



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
		}

		public void LoadAllItems()
		{
			Items = DBManager.Current.Items;
			Categories = DBManager.Current.Categories;
			Payments = DBManager.Current.Payments;
		}
	}
}