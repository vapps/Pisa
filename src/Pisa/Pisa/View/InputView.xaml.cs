using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Practices.ServiceLocation;
using Pisa.DB;
using Pisa.ViewModel;

namespace Pisa.View
{
	public partial class InputView : PhoneApplicationPage
	{
		public InputViewModel ViewModel
		{
			get
			{
				return this.DataContext as InputViewModel;
			}
		}

		public InputView()
		{
			InitializeComponent();
			(this.ApplicationBar.Buttons[0] as ApplicationBarIconButton).Click += AddAppBarButton_Click;
		}

		void AddAppBarButton_Click(object sender, EventArgs e)
		{
			MainViewModel mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
			mainViewModel.AddCommand.Execute(ViewModel.PisaModel);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			DBManager.Current.SaveAllItems();
		}
	}
}