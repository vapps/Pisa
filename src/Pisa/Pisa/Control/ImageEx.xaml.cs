using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Pisa.Control
{
	public partial class ImageEx : UserControl
	{
		#region SourceStr
		[Category("ImageEx")]
		public string SourceStr
		{
			get { return (string)GetValue(SourceStrProperty); }
			set { SetValue(SourceStrProperty, value); }
		}

		public static readonly DependencyProperty SourceStrProperty =
					DependencyProperty.Register(
						  "SourceStr",
						  typeof(string),
						  typeof(ImageEx),
						  new PropertyMetadata(OnSourceStrPropertyChanged));

		private static void OnSourceStrPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ImageEx _ImageEx = d as ImageEx;
			if (_ImageEx != null)
			{
				_ImageEx.SetSourceStr((string)e.NewValue);
			}
		}
		private void SetSourceStr(string sourceStr)
		{
			if (imageCache.ContainsKey(sourceStr) == true)
			{
				SourceImage.Source = imageCache[sourceStr];
			}
			else
			{
				using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (isf.FileExists(sourceStr) == false)
					{
						SourceImage.Source = null;
					}
					else
					{
						BitmapImage source = new BitmapImage();
						using (IsolatedStorageFileStream isfStream = new IsolatedStorageFileStream(sourceStr, System.IO.FileMode.Open, isf))
						{
							source.SetSource(isfStream);
						}
						imageCache.Add(sourceStr, source);
						SourceImage.Source = source;
					}
				}
			}
		}
		#endregion SourceStr

		Dictionary<string, BitmapImage> imageCache = new Dictionary<string, BitmapImage>();

		public ImageEx()
		{
			InitializeComponent();
		}
	}
}
