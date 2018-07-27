using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeService.Model.Market
{
	/// <summary>
	/// Represent data of Basket entity
	/// </summary>
	public class Basket: EntityBase
	{
		public Basket(Guid id) : base(id)
		{
			Goods = new List<Good>();
		}

		/// <summary>
		/// Goods in Basket
		/// </summary>
		public List<Good> Goods { get;}

		/// <summary>
		/// Total cost of all goods in Basket
		/// </summary>
		public decimal TotalCost => GetDiscountedCost();

		private decimal GetDiscountedCost()
		{
			if (Discount == null) return Goods.Sum(good => good.Cost);
			if (!Discount.Type.HasValue) return Goods.Sum(good => good.Cost) * Discount.CostMultiplier;
			return Goods.Sum(good => good.Type == Discount.Type ? good.Cost * Discount.CostMultiplier : good.Cost);
		}

		/// <summary>
		/// Discount applied to basked
		/// </summary>
		public Discount Discount { get; set; }
	}
}