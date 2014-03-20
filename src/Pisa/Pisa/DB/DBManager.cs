using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisa.DB
{
	public class DBManager
	{
		#region Current
		private DBManager _current;
		public DBManager Current
		{
			get
			{
				if (_current == null)
					_current = new DBManager();

				return _current;
			}
		}
		DBManager()
		{
			_Init();
		}
		#endregion Current

		CategoryDataContext _categoryDataContext;
		PaymentDataContext _paymentDataContext;
		PisaDataContext _pisaDataContext;

		Dictionary<int, string> _categoryDic;
		Dictionary<int, string> _paymentDic;



		private void _Init()
		{
			_categoryDataContext = new CategoryDataContext();
			_paymentDataContext = new PaymentDataContext();
			_pisaDataContext = new PisaDataContext();

			if (_categoryDataContext.DatabaseExists() == false)
			{
				_categoryDataContext.CreateDatabase();
			}

			if (_paymentDataContext.DatabaseExists() == false)
			{
				_paymentDataContext.CreateDatabase();
			}

			if (_pisaDataContext.DatabaseExists() == false)
			{
				_pisaDataContext.CreateDatabase();
			}


			_InitCategoryDic();
			_InitPaymentDic();


		}

		private void _InitPaymentDic()
		{
			_paymentDic = new Dictionary<int, string>();
			if (_pisaDataContext != null)
			{
				foreach (var paymentInfo in _paymentDataContext.Items)
				{
					if (_paymentDic.ContainsKey(paymentInfo.ID) == false)
					{
						_paymentDic.Add(paymentInfo.ID, paymentInfo.Name);
					}
					else
					{
						Debug.Assert(false);
					}
				}
			}
			else
			{
				Debug.Assert(false);
			}
		}

		private void _InitCategoryDic()
		{
			_categoryDic = new Dictionary<int, string>();
			if (_categoryDataContext != null)
			{
				foreach (var categoryInfo in _categoryDataContext.Items)
				{
					if (_categoryDic.ContainsKey(categoryInfo.ID) == false)
					{
						_categoryDic.Add(categoryInfo.ID, categoryInfo.Name);
					}
					else
					{
						Debug.Assert(false);
					}
				}
			}
			else
			{
				Debug.Assert(false);
			}
		}
	}
}
