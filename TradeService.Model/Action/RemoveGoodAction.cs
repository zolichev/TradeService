using TradeService.Model.Market;

namespace TradeService.Model.Action
{
	/// <summary>
	/// Removing good form basket
	/// </summary>
	public class RemoveGoodAction :ActionBase
	{
		private readonly Basket _basket;
		private readonly Good _good;

		public RemoveGoodAction(Basket basket, Good good)
		{
			_basket = basket;
			_good = good;
		}

		/// <summary>
		/// Adding good to basket
		/// </summary>
		public override void Apply()
		{
			_basket.Goods.Remove(_good);
		}

		/// <summary>
		/// Reverse adding
		/// </summary>
		public override void Regain()
		{
			_basket.Goods.Add(_good);
		}
	}
}