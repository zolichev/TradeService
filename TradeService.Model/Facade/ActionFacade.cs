using System;
using TradeService.Model.Action;

namespace TradeService.Model.Facade
{
	/// <summary>
	/// Simple facade methods for actions
	/// </summary>
	/// <remarks>For using in REST service</remarks>
	public static class ActionFacade
	{
		/// <summary>
		/// Adding good to basket
		/// </summary>
		/// <param name="basketId">Id of basket entity</param>
		/// <param name="goodId">Id of good entity</param>
		public static void AddGoodToBasket(Guid basketId, Guid goodId)
		{
			var basket = MarketFacade.GetBasket(basketId);
			var good = MarketFacade.GetGood(goodId);
			var act = new AddGoodAction(basket, good);
			Actions.Instance.RunAction(act);
		}

		/// <summary>
		/// Removing good form basket
		/// </summary>
		/// <param name="basketId">Id of basket entity</param>
		/// <param name="goodId">Id of good entity</param>
		public static void RemoveGoodFromBasket(Guid basketId, Guid goodId)
		{
			var basket = MarketFacade.GetBasket(basketId);
			var good = MarketFacade.GetGood(goodId);
			var act = new RemoveGoodAction(basket, good);
			Actions.Instance.RunAction(act);
		}

		/// <summary>
		/// Implement discount to basket
		/// </summary>
		/// <param name="basketId">Id of basket entity</param>
		/// <param name="discountId">Id of discount entity</param>
		public static void ImplementDiscountToBasket(Guid basketId, Guid discountId)
		{
			var basket = MarketFacade.GetBasket(basketId);
			var discount = MarketFacade.GetDiscount(discountId);
			var act = new ImplementDiscountAction(basket, discount);
			Actions.Instance.RunAction(act);
		}

		/// <summary>
		/// Undone last action
		/// </summary>
		/// <returns>Can do Undo again</returns>
		public static bool Undo()
		{
			Actions.Instance.Undo();
			return Actions.Instance.IsCanUndo;
		}

		/// <summary>
		/// Redo last action
		/// </summary>
		/// <returns>Can do Redo again</returns>
		public static bool Redo()
		{
			Actions.Instance.Redo();
			return Actions.Instance.IsCanRedo;
		}
	}
}