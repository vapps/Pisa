using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Pisa.DB;
using Pisa.Model;

namespace Pisa.ViewModel
{

	public class MainViewModel : ViewModelBase
	{
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
			
		}

		public void LoadAllItems()
		{
			ServiceLocator.Current.GetInstance<DBManager>().LoadAllItems();
		}
	}
}