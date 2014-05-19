using System;
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
		public InputView()
		{
			InitializeComponent();
			InitApplicationBarButtons();
		}

		private void InitApplicationBarButtons()
		{
			ApplicationBarIconButton addButton = new ApplicationBarIconButton()
			{
				Text = "[번]추가",
				IconUri = new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.RelativeOrAbsolute)
			};
			addButton.Click += addButton_Click;


			ApplicationBarIconButton listButton = new ApplicationBarIconButton()
			{
				Text = "[번]목록",
				IconUri = new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.RelativeOrAbsolute)
			};
			listButton.Click += listButton_Click;

			ApplicationBarIconButton settingButton = new ApplicationBarIconButton()
			{
				Text = "[번]설정",
				IconUri = new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.RelativeOrAbsolute)
			};
			settingButton.Click += settingButton_Click;

			this.ApplicationBar.Buttons.Add(addButton);
			this.ApplicationBar.Buttons.Add(listButton);
			this.ApplicationBar.Buttons.Add(settingButton);
		}



		void settingButton_Click(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/Pisa;component/View/SettingView.xaml", UriKind.RelativeOrAbsolute));
		}

		void listButton_Click(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/Pisa;component/View/ListView.xaml", UriKind.RelativeOrAbsolute));
		}

		void addButton_Click(object sender, EventArgs e)
		{
			MainViewModel mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
			mainViewModel.CurrentModel.ImagePath = CameraControl.SaveAndGetFilePath();
			mainViewModel.AddCommand.Execute(null);
		}


		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			ServiceLocator.Current.GetInstance<DBManager>().SaveAllItems();
		}

		private void PriceTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			(sender as PhoneTextBox).SelectAll();
		}

		private void MessageTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			(sender as PhoneTextBox).SelectAll();
		}

		private void PriceTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			(sender as PhoneTextBox).GetBindingExpression(PhoneTextBox.TextProperty).UpdateSource();
		}

		private void MessageTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			(sender as PhoneTextBox).GetBindingExpression(PhoneTextBox.TextProperty).UpdateSource();
		}
	}
}