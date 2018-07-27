using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradeService.Model.Facade;
using TradeService.Model.Test.DataMock;

namespace TradeService.Model.Test.Facade
{
	[TestClass()]
	public class ActionFacadeTests
	{
		[TestMethod()]
		public void AddGoodToBasketTest()
		{
			var originG = DataMockFactory.Goods[0];
			MarketFacade.AddGood(originG.Id, originG.Name, originG.Cost, originG.Type);
			var originB = DataMockFactory.NewBasket();
			MarketFacade.AddBasket(originB.Id);

			ActionFacade.AddGoodToBasket(originB.Id, originG.Id);

			var goal = MarketFacade.GetBasket(originB.Id);
			Assert.AreEqual(originG.Id, goal?.Goods.LastOrDefault()?.Id);
		}

		[TestMethod()]
		public void RemoveGoodFromBasketTest()
		{
			var originG = DataMockFactory.Goods[0];
			MarketFacade.AddGood(originG.Id, originG.Name, originG.Cost, originG.Type);
			var originB = DataMockFactory.NewBasket();
			MarketFacade.AddBasket(originB.Id);

			ActionFacade.AddGoodToBasket(originB.Id, originG.Id);
			ActionFacade.RemoveGoodFromBasket(originB.Id, originG.Id);

			var goal = MarketFacade.GetBasket(originB.Id);
			Assert.AreNotEqual(originG.Id, goal?.Goods.LastOrDefault()?.Id);
		}

		[TestMethod()]
		public void ImplementDiscountToBasketTest()
		{
			var originB = DataMockFactory.NewBasket();
			MarketFacade.AddBasket(originB.Id);
			var originD = DataMockFactory.Discounts[0];
			MarketFacade.AddDiscount(originD.Id, originD.Code, originD.Value, originD?.Type);
			var originBasketTotal = 0m;
			foreach (var originG in DataMockFactory.Goods)
			{
				MarketFacade.AddGood(originG.Id, originG.Name, originG.Cost, originG.Type);
				ActionFacade.AddGoodToBasket(originB.Id, originG.Id);
				if (originD.Type.HasValue)
				{
					if (originD.Type == originG.Type)
						originBasketTotal += originG.Cost * originD.CostMultiplier;
					else
						originBasketTotal += originG.Cost;
				}
				else
					originBasketTotal += originG.Cost * originD.CostMultiplier;
			}

			ActionFacade.ImplementDiscountToBasket(originB.Id, originD.Id);
			var goal = MarketFacade.GetBasket(originB.Id);

			Assert.AreEqual(originBasketTotal, goal?.TotalCost);
		}

		[TestMethod()]
		public void UndoTest()
		{
			var originB = DataMockFactory.NewBasket();
			MarketFacade.AddBasket(originB.Id);
			var originD = DataMockFactory.Discounts[0];
			MarketFacade.AddDiscount(originD.Id, originD.Code, originD.Value, originD?.Type);
			var originGoodsCount = 0;
			foreach (var originG in DataMockFactory.Goods)
			{
				MarketFacade.AddGood(originG.Id, originG.Name, originG.Cost, originG.Type);
				ActionFacade.AddGoodToBasket(originB.Id, originG.Id);
				originGoodsCount++;
			}

			ActionFacade.Undo();
			originGoodsCount--;
			var goal = MarketFacade.GetBasket(originB.Id);

			Assert.AreEqual(originGoodsCount, goal?.Goods.Count);
		}

		[TestMethod()]
		public void RedoTest()
		{
			var originB = DataMockFactory.NewBasket();
			MarketFacade.AddBasket(originB.Id);
			var originD = DataMockFactory.Discounts[0];
			MarketFacade.AddDiscount(originD.Id, originD.Code, originD.Value, originD?.Type);
			var originGoodsCount = 0;
			foreach (var originG in DataMockFactory.Goods)
			{
				MarketFacade.AddGood(originG.Id, originG.Name, originG.Cost, originG.Type);
				ActionFacade.AddGoodToBasket(originB.Id, originG.Id);
				originGoodsCount++;
			}

			ActionFacade.Undo();
			originGoodsCount--;
			ActionFacade.Undo();
			originGoodsCount--;
			ActionFacade.Redo();
			originGoodsCount++;
			var goal = MarketFacade.GetBasket(originB.Id);

			Assert.AreEqual(originGoodsCount, goal?.Goods.Count);
		}
	}
}