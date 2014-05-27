using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Pisa
{
	public enum PisaStyle
	{
		None = 0,
		Red = 1,
		Blue = 2,
		Yellow = 3
	}
	public class StyleManager
	{


		private static StyleManager _current;
		public static StyleManager Current
		{
			get
			{
				if (_current == null)
				{
					_current = new StyleManager();
				}
				return _current;
			}
		}

		internal void ChangedColor(PisaStyle style)
		{
			App.Current.Resources.MergedDictionaries.Clear();
			ResourceDictionary resourceDic = new ResourceDictionary();


			switch (style)
			{
				case PisaStyle.None:
					break;
				case PisaStyle.Red:
					resourceDic.Source = new Uri("/Assets/Styles/RedStyle.xaml", UriKind.RelativeOrAbsolute);
					break;
				case PisaStyle.Blue:
					resourceDic.Source = new Uri("/Assets/Styles/BlueStyle.xaml", UriKind.RelativeOrAbsolute);
					break;
				case PisaStyle.Yellow:
					resourceDic.Source = new Uri("/Assets/Styles/YellowStyle.xaml", UriKind.RelativeOrAbsolute);
					break;
				default:
					break;
			}


			App.Current.Resources.MergedDictionaries.Add(resourceDic);
		}
	}
}
