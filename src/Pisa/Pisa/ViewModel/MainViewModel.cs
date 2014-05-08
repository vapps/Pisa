using System;
using System.Collections;
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
		public RelayCommand AddCommand { get; set; }
		public RelayCommand LoadAllCommand { get; set; }

		public PisaModel CurrentModel { get; set; }

		public ObservableCollection<CategoryModel> Categories
		{
			get
			{
				return ServiceLocator.Current.GetInstance<DBManager>().Categories;
			}
		}

		public ObservableCollection<PaymentModel> Payments
		{
			get
			{
				return ServiceLocator.Current.GetInstance<DBManager>().Payments;
			}
		}

		public ObservableCollection<PisaModel> Items
		{
			get
			{
				return ServiceLocator.Current.GetInstance<DBManager>().Items;
			}
		}





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
				_InitCurrentModel();
			}
		}

		private void CreateCommand()
		{
			AddCommand = new RelayCommand(AddPisa);
			LoadAllCommand = new RelayCommand(LoadAllItems);
		}




		public void AddPisa()
		{
			//TODO : 5이렇게 카피하는 형식은 위험함
			PisaModel addedItem = new PisaModel()
			{
				Category = CurrentModel.Category,
				Date = CurrentModel.Date,
				ImagePath = CurrentModel.ImagePath,
				Message = CurrentModel.Message,
				Payment = CurrentModel.Payment,
				Price = CurrentModel.Price
			};

			ServiceLocator.Current.GetInstance<DBManager>().Items.Add(addedItem);
			_InitCurrentModel();
		}

		private void _InitCurrentModel()
		{
			if (CurrentModel == null)
			{
				CurrentModel = new PisaModel();
			}


			CurrentModel.Date = DateTime.Now;
			CurrentModel.Category = this.Categories[0];
			CurrentModel.Payment = this.Payments[0];
			CurrentModel.Price = string.Empty;
			CurrentModel.Message = string.Empty;
		}

		public void LoadAllItems()
		{
			ServiceLocator.Current.GetInstance<DBManager>().LoadAllItems();
		}
	}
}