using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pisa.Model;

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


		public List<PisaModel> Items;



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

			Items = new List<PisaModel>();

			foreach (var pisaInfo in _pisaDataContext.Items)
			{
				Items.Add(new PisaModel()
					{
						Date = DateTime.Parse(pisaInfo.Date),
						Category = new CategoryModel()
						{
							ID = pisaInfo.Category,
							Name = _categoryDic[pisaInfo.Category]
						},
						ImagePath = pisaInfo.ImagePath,
						Message = pisaInfo.Message,
						Payment = new PaymentModel()
						{
							ID = pisaInfo.PaymentType,
							Name = _paymentDic[pisaInfo.PaymentType]
						},
						Price = pisaInfo.Price
					});
			}
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


		public void AddPisaModel(PisaModel model)
		{
		}
	}
}
