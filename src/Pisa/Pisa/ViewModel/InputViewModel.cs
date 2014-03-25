﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
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

		public InputViewModel()
		{
			MainViewModel mainViewMode = ServiceLocator.Current.GetInstance<MainViewModel>();
			PisaModel = new PisaModel()
			{
				Date = DateTime.Now,
				Category = mainViewMode.Categories[0],
				Payment = mainViewMode.Payments[0]
			};
		}
	}
}