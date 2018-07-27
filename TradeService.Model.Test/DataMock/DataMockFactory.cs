using System;
using System.Collections.Generic;
using TradeService.Model.Market;
using TradeService.Model.DataModel;

namespace TradeService.Model.Test.DataMock
{
	public static class DataMockFactory
	{
		public static List<GoodMock> Goods { get; }
		public static List<BasketMock> Baskets { get; }
		public static List<DiscountMock> Discounts { get; }

		static DataMockFactory()
		{
			Goods = GereateGoods();
			Baskets = GereateBaskets();
			Discounts = GereateDiscounts();
		}

		private static List<GoodMock> GereateGoods()
		{
			var result = new List<GoodMock>();
			result.Add(new GoodMock(
				id: Guid.NewGuid(),
				name: "Bread",
				cost: 30.50m,
				type: GoodType.Food
			));
			result.Add(new GoodMock(
				id: Guid.NewGuid(),
				name: "Milk",
				cost: 40.80m,
				type: GoodType.Food
			));
			result.Add(new GoodMock(
				id: Guid.NewGuid(),
				name: "Honey",
				cost: 160m,
				type: GoodType.Food
			));
			result.Add(new GoodMock(
				id: Guid.NewGuid(),
				name: "Wiper blades",
				cost: 530m,
				type: GoodType.Auto
			));
			return result;
		}

		public static BasketMock NewBasket()
		{
			return new BasketMock(
				id: Guid.NewGuid()
			);
		}

		private static List<BasketMock> GereateBaskets()
		{
			var result = new List<BasketMock>();
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			result.Add(new BasketMock(
				id: Guid.NewGuid()
			));
			return result;
		}

		private static List<DiscountMock> GereateDiscounts()
		{
			var result = new List<DiscountMock>();
			result.Add(new DiscountMock(
				id: Guid.NewGuid(),
				value: 0.20m,
				code: "DriveYourCar",
				type: GoodType.Auto
			));
			result.Add(new DiscountMock(
				id: Guid.NewGuid(),
				value: 0.05m,
				code: "regular customer",
				type: null
			));
			return result;
		}
	}
}