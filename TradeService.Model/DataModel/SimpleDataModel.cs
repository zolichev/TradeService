using System;
using System.Collections.Generic;
using TradeService.Model.Market;

namespace TradeService.Model.DataModel
{
	/// <summary>
	/// Represent a simple sample of a data access layer
	/// </summary>
	public class SimpleDataModel
	{
		public List<Good> Goods { get; }
		public List<Basket> Baskets { get; }
		public List<Discount> Discounts { get; }

		private static SimpleDataModel _instance;
		private static readonly object SyncRoot = new Object();

		private SimpleDataModel()
		{
			Goods = new List<Good>();
			Baskets = new List<Basket>();
			Discounts = new List<Discount>();
		}

		/// <summary>
		/// Only one instance of entity available for using
		/// </summary>
		public static SimpleDataModel Instance
		{
			get
			{
				if (_instance == null)
					lock (SyncRoot)
						if (_instance == null)
							_instance = new SimpleDataModel();
				return _instance;
			}
		}

	}
}