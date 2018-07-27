using TradeService.Model.Market;

namespace TradeService.Model.Action
{
	/// <summary>
	/// Implement discount to basket
	/// </summary>
	public class ImplementDiscountAction :ActionBase
	{
		private readonly Basket _basket;
		private readonly Discount _discount;
		private readonly Discount _oldDiscount;

		public ImplementDiscountAction(Basket basket, Discount discount)
		{
			_basket = basket;
			_oldDiscount = _basket.Discount;
			_discount = discount;
		}

		/// <summary>
		/// Adding good to basket
		/// </summary>
		public override void Apply()
		{
			_basket.Discount = _discount;
		}

		/// <summary>
		/// Reverse adding
		/// </summary>
		public override void Regain()
		{
			_basket.Discount = _oldDiscount;
		}
	}
}