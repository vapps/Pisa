using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Pisa.View.Setting
{
	public partial class StyleView : PhoneApplicationPage
	{
		public StyleView()
		{
			InitializeComponent();
			LinkEvents();
		}

		private void LinkEvents()
		{
			RedButton.Click += RedButton_Click;
			BlueButton.Click += BlueButton_Click;
			YellowButton.Click += YellowButton_Click;
		}

		void YellowButton_Click(object sender, RoutedEventArgs e)
		{
			StyleManager.Current.ChangedColor(PisaStyle.Yellow);
			this.NavigationService.GoBack();
		}

		void BlueButton_Click(object sender, RoutedEventArgs e)
		{
			StyleManager.Current.ChangedColor(PisaStyle.Blue);
			this.NavigationService.GoBack();
		}

		void RedButton_Click(object sender, RoutedEventArgs e)
		{
			StyleManager.Current.ChangedColor(PisaStyle.Red);
			this.NavigationService.GoBack();
		}
	}

	public class StyleViewModel : ViewModelBase
	{

	}
}