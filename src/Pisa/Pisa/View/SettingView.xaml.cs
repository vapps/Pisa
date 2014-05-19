using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Pisa.View
{
	public partial class SettingView : PhoneApplicationPage
	{
		public SettingView()
		{
			InitializeComponent();
			LinkEvents();
		}

		private void LinkEvents()
		{
			ChangeStyleButton.Click += ChangeStyleButton_Click;
			AlarmSettingButton.Click += AlarmSettingButton_Click;
			PasswordButton.Click += PasswordButton_Click;
			UsePasswordSwitch.Checked += UsePasswordSwitch_Checked;
			UsePasswordSwitch.Unchecked += UsePasswordSwitch_Unchecked;
		}

		void UsePasswordSwitch_Unchecked(object sender, RoutedEventArgs e)
		{
			
		}

		void UsePasswordSwitch_Checked(object sender, RoutedEventArgs e)
		{
			
		}

		void PasswordButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/Pisa;component/View/Setting/PasswordSettingView.xaml", UriKind.RelativeOrAbsolute));
		}

		void AlarmSettingButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/Pisa;component/View/Setting/AlarmSettingView.xaml", UriKind.RelativeOrAbsolute));
		}

		void ChangeStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/Pisa;component/View/Setting/StyleView.xaml", UriKind.RelativeOrAbsolute));
		}
	}
}