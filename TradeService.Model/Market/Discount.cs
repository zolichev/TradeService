using System;

namespace TradeService.Model.Market
{
	/// <summary>
	/// Represent data of Discount entity
	/// </summary>
	public class Discount : EntityBase
	{
		public Discount(Guid id, string code, decimal value, GoodType? type = null) : base(id)
		{
			Value = value;
			Code = code;
			Type = type;
		}

		/// <summary>
		/// Discount code
		/// </summary>
		public string Code { get; }

		private decimal _value;

		/// <summary>
		/// Discount value
		/// </summary>
		public decimal Value
		{
			get => _value;
			set => _value = (0 <= value && value <= 1) ? value : 0;
		}

		/// <summary>
		/// Helpfull value for calculating new cost of goods
		/// </summary>
		public decimal CostMultiplier => 1 - Value;

		/// <summary>
		/// Type will be defined if discount implements to one good type or null for all basket
		/// </summary>
		public GoodType? Type { get; set; }
	}
}