using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using Pisa.Model;

namespace Pisa.DB
{
	public class DBManager
	{
		readonly List<string> INIT_CATEGORIES = new List<string>() { "점심", "간식", "기타" };
		readonly List<string> INIT_PAYMENTS = new List<string>() { "카드", "현금", "통장", "핸드폰" };


		CategoryDataContext _categoryDataContext;
		PaymentDataContext _paymentDataContext;
		PisaDataContext _pisaDataContext;


		public ObservableCollection<PisaModel> Items;
		public ObservableCollection<CategoryModel> Categories;
		public ObservableCollection<PaymentModel> Payments;


		public void SaveAllItems()
		{
			if (_paymentDataContext != null)
			{
				_paymentDataContext.SubmitChanges();
			}
			else
			{
				Debug.Assert(false);
			}

			if (_categoryDataContext != null)
			{
				_categoryDataContext.SubmitChanges();
			}
			else
			{
				Debug.Assert(false);
			}

			if (_pisaDataContext != null)
			{
				_pisaDataContext.SubmitChanges();
			}
			else
			{
				Debug.Assert(false);
			}
		}








		private void _Init()
		{
			_categoryDataContext = new CategoryDataContext();
			_paymentDataContext = new PaymentDataContext();
			_pisaDataContext = new PisaDataContext();


			bool isFirstTimeToCreateCategory = false;
			if (_categoryDataContext.DatabaseExists() == false)
			{
				_categoryDataContext.CreateDatabase();
				isFirstTimeToCreateCategory = true;
			}

			bool isFirstTimeToCreatePayment = false;
			if (_paymentDataContext.DatabaseExists() == false)
			{
				_paymentDataContext.CreateDatabase();
				isFirstTimeToCreatePayment = true;
			}

			if (_pisaDataContext.DatabaseExists() == false)
			{
				_pisaDataContext.CreateDatabase();
			}


			_InitCategories(isFirstTimeToCreateCategory);
			_InitPayments(isFirstTimeToCreatePayment);
			
		}

		public void LoadAllItems()
		{
			Items = new ObservableCollection<PisaModel>();


			foreach (var pisaInfo in _pisaDataContext.Items)
			{
				CategoryModel category = Categories.FirstOrDefault(c => c.ID == pisaInfo.Category);
				PaymentModel payment = Payments.FirstOrDefault(c => c.ID == pisaInfo.PaymentType);
				PisaModel pisaModel = new PisaModel()
				{
					Date = DateTime.Parse(pisaInfo.Date),
					Category = category,
					ImagePath = pisaInfo.ImagePath,
					Message = pisaInfo.Message,
					Payment = payment,
					Price = pisaInfo.Price
				};

				pisaModel.PropertyChanged += pisaModel_PropertyChanged;
				Items.Add(pisaModel);
			}


			Items.CollectionChanged += Items_CollectionChanged;
		}


		void pisaModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Date":
					{

					}
					break;
				default:
					break;
			}
		}

		void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					{
						foreach (PisaModel addedModel in e.NewItems)
						{
							if (addedModel != null)
							{
								addedModel.PropertyChanged += pisaModel_PropertyChanged;
								_pisaDataContext.Items.InsertOnSubmit(_GetPisaTable(addedModel));
							}
							else
							{
								Debug.Assert(false);
							}
						}
					}
					break;
				case NotifyCollectionChangedAction.Remove:
					{
						foreach (PisaModel removedModel in e.OldItems)
						{
							if (removedModel != null)
							{
								removedModel.PropertyChanged -= pisaModel_PropertyChanged;
								_pisaDataContext.Items.DeleteOnSubmit(_GetPisaTable(removedModel));
							}
							else
							{
								Debug.Assert(false);
							}
						}
					}
					break;
				case NotifyCollectionChangedAction.Move:
				case NotifyCollectionChangedAction.Replace:
				case NotifyCollectionChangedAction.Reset:
				default:
					{
						Debug.Assert(false);
					}
					break;
			}
		}

		void _InitCategories(bool isFirtstTime)
		{
			Categories = new ObservableCollection<CategoryModel>();
			if (_categoryDataContext != null)
			{
				if (isFirtstTime == true)
				{
					foreach (string initItem in INIT_CATEGORIES)
					{
						_categoryDataContext.Items.InsertOnSubmit(new CategoryTable()
						{
							Name = initItem
						});
					}

					_categoryDataContext.SubmitChanges();
				}

				foreach (var categoryInfo in _categoryDataContext.Items)
				{
					Categories.Add(_GetCategoryModel(categoryInfo));
				}
			}
			else
			{
				Debug.Assert(false);
			}
		}


		void _InitPayments(bool isFirstTime)
		{
			Payments = new ObservableCollection<PaymentModel>();
			if (_pisaDataContext != null)
			{
				if (isFirstTime == true)
				{
					foreach (string initItem in INIT_PAYMENTS)
					{
						_paymentDataContext.Items.InsertOnSubmit(new PaymentTable()
							{
								Name = initItem
							});
					}
					_paymentDataContext.SubmitChanges();
				}

				foreach (var paymentInfo in _paymentDataContext.Items)
				{
					Payments.Add(_GetPaymentModel(paymentInfo));
				}
			}
			else
			{
				Debug.Assert(false);
			}
		}


		PaymentModel _GetPaymentModel(PaymentTable paymentInfo)
		{
			return new PaymentModel()
				{
					ID = paymentInfo.ID,
					Name = paymentInfo.Name
				};
		}

		CategoryModel _GetCategoryModel(CategoryTable categoryInfo)
		{
			return new CategoryModel()
			{
				ID = categoryInfo.ID,
				Name = categoryInfo.Name
			};
		}


		PisaModel _GetPisaModel(PisaTable item)
		{
			CategoryModel category = Categories.FirstOrDefault(c => c.ID == item.Category);
			PaymentModel payment = Payments.FirstOrDefault(c => c.ID == item.PaymentType);

			Debug.Assert(category != null);
			Debug.Assert(payment != null);



			return new PisaModel()
			{
				Category = category,
				Date = DateTime.Parse(item.Date),
				ImagePath = item.ImagePath,
				Message = item.Message,
				Payment = payment,
				Price = item.Price
			};
		}

		PisaTable _GetPisaTable(PisaModel model)
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

		internal void DeleteAllItems()
		{
			_pisaDataContext.Items.DeleteAllOnSubmit(_pisaDataContext.Items);
			_pisaDataContext.SubmitChanges();
		}
	}
}

