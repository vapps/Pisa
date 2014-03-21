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
		private static DBManager _current;
		public static DBManager Current
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
			_pisaDataContext.Items.InsertOnSubmit(_GetPisaTable(model));
		}

		public List<PisaModel> GetAllItems()
		{
			List<PisaModel> result = new List<PisaModel>();

			foreach (var item in _pisaDataContext.Items)
			{
				result.Add(_GetPisaModel(item));
			}

			return result;
		}

		private PisaModel _GetPisaModel(PisaTable item)
		{
			return new PisaModel()
			{
				Category = new CategoryModel()
				{
					ID = item.Category,
					Name = _categoryDic[item.Category]
				},
				Date = DateTime.Parse(item.Date),
				ImagePath = item.ImagePath,
				Message = item.Message,
				Payment = new PaymentModel()
				{
					ID = item.PaymentType,
					Name = _paymentDic[item.PaymentType]
				},
				Price = item.Price
			};
		}

		private PisaTable _GetPisaTable(PisaModel model)
		{
			return new PisaTable()
			{
				Category = model.Category.ID,
				Date = model.Date.ToString(),
				ImagePath = model.ImagePath,
				Message = model.Message,
				PaymentType = model.Payment.ID,
				Price = model.Price
			};
		}
	}
}
