using System;
using System.Linq;
using TradeService.Model.DataModel;
using TradeService.Model.Market;

namespace TradeService.Model.Facade
{
	/// <summary>
	/// Simple facade methods for market entities
	/// </summary>
	/// <remarks>For using in REST service</remarks>
	public static class MarketFacade
	{
		public static Good AddGood(Guid id, string name, decimal cost, GoodType type)
		{
			var item = new Good(id, name, cost, type);
			SimpleDataModel.Instance.Goods.Add(item);
			return item;
		}

		public static Good GetGood(Guid id)
		{
			return SimpleDataModel.Instance.Goods.FirstOrDefault(i => i.Id == id);
		}

		public static Basket AddBasket(Guid id)
		{
			var item = new Basket(id);
			SimpleDataModel.Instance.Baskets.Add(item);
			return item;
		}

		public static Basket GetBasket(Guid id)
		{
			return SimpleDataModel.Instance.Baskets.FirstOrDefault(i => i.Id == id);
		}

		public static Discount AddDiscount(Guid id, string code, decimal value, GoodType? type)
		{
			var item = new Discount(id, code, value, type);
			SimpleDataModel.Instance.Discounts.Add(item);
			return item;
		}

		public static Discount GetDiscount(Guid id)
		{
			return SimpleDataModel.Instance.Discounts.FirstOrDefault(i => i.Id == id);
		}

		public static Discount GetDiscount(string code)
		{
			return SimpleDataModel.Instance.Discounts.FirstOrDefault(i => i.Code.Trim().ToLower() == code.Trim().ToLower());
		}
	}
}