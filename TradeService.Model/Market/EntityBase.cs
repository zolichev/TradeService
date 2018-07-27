using System;

namespace TradeService.Model.Market
{
	/// <summary>
	/// Represent common data of entity
	/// </summary>
	public abstract class EntityBase
	{
		/// <summary>
		/// Entity identification number
		/// </summary>
		public Guid Id { get; }

		public EntityBase(Guid id)
		{
			Id = id;
		}
	}
}