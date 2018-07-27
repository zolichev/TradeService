using System;

namespace TradeService.Model.Market
{
	/// <summary>
	/// Represent data of Good entity
	/// </summary>
	public class Good : EntityBase
	{
		public Good(Guid id, string name, decimal cost, GoodType type) : base(id)
		{
			Name = name;
			Cost = cost;
			Type = type;
		}

		/// <summary>
		/// Name of Good
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Cost of Good
		/// </summary>
		public decimal Cost { get; set; }

		/// <summary>
		/// Type of Good
		/// </summary>
		public GoodType Type { get; set; }
	}
}