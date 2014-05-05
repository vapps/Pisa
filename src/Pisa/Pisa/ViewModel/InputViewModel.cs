using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Pisa.DB;
using Pisa.Model;

namespace Pisa.ViewModel
{
	public class InputViewModel : ViewModelBase
	{
		#region PisaModel PisaModel
		private PisaModel _pisaModel;
		public PisaModel PisaModel
		{
			get
			{
				return _pisaModel;
			}
			set
			{
				_pisaModel = value;
				RaisePropertyChanged("PisaModel");
			}
		}
		#endregion PisaModel PisaModel


		public void InitPisaModel()
		{
			PisaModel = new PisaModel()
			{
				Date = DateTime.Now,

				Category = ServiceLocator.Current.GetInstance<DBManager>().Categories[0],
				Payment = ServiceLocator.Current.GetInstance<DBManager>().Payments[0]
			};
		}
	}
}
