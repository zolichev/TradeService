using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradeService.Model.DataModel;
using TradeService.Model.Facade;
using TradeService.Model.Test.DataMock;

namespace TradeService.Model.Test.Facade
{
	[TestClass()]
	public class MarketFacadeTests
	{
		[TestMethod()]
		public void AddGoodTest()
		{
			var origin = DataMockFactory.Goods[0];
			MarketFacade.AddGood(origin.Id, origin.Name, origin.Cost, origin.Type);
			var goal = SimpleDataModel.Instance.Goods.LastOrDefault();
			Assert.AreEqual(origin.Id, goal?.Id);
		}

		[TestMethod()]
		public void GetGoodTest()
		{
			var origin = DataMockFactory.Goods[0];
			MarketFacade.AddGood(origin.Id, origin.Name, origin.Cost, origin.Type);
			var goal = MarketFacade.GetGood(origin.Id);
			Assert.AreEqual(origin.Id, goal?.Id);
		}

		[TestMethod()]
		public void AddBasketTest()
		{
			var origin = DataMockFactory.NewBasket();
			MarketFacade.AddBasket(origin.Id);
			var goal = SimpleDataModel.Instance.Baskets.LastOrDefault();
			Assert.AreEqual(origin.Id, goal?.Id);
		}

		[TestMethod()]
		public void GetBasketTest()
		{
			var origin = DataMockFactory.NewBasket();
			MarketFacade.AddBasket(origin.Id);
			var goal = MarketFacade.GetBasket(origin.Id);
			Assert.AreEqual(origin.Id, goal?.Id);
		}

		[TestMethod()]
		public void AddDiscountTest()
		{
			var origin = DataMockFactory.Discounts[0];
			MarketFacade.AddDiscount(origin.Id, origin.Code, origin.Value, origin?.Type);
			var goal = SimpleDataModel.Instance.Discounts.LastOrDefault();
			Assert.AreEqual(origin.Id, goal?.Id);
		}

		[TestMethod()]
		public void GetDiscountTestId()
		{
			var origin = DataMockFactory.Discounts[0];
			MarketFacade.AddDiscount(origin.Id, origin.Code, origin.Value, origin?.Type);
			var goal = MarketFacade.GetDiscount(origin.Id);
			Assert.AreEqual(origin.Id, goal?.Id);
		}

		[TestMethod()]
		public void GetDiscountTestCode()
		{
			var origin = DataMockFactory.Discounts[0];
			MarketFacade.AddDiscount(origin.Id, origin.Code, origin.Value, origin?.Type);
			var goal = MarketFacade.GetDiscount(origin.Id);
			Assert.AreEqual(origin.Code, goal?.Code);
		}
	}
}