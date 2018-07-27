using System;
using TradeService.Model.Market;

namespace TradeService.Model.Test.DataMock
{
	public class GoodMock: Good
	{
		public GoodMock(Guid id, string name, decimal cost, GoodType type) : base(id, name, cost, type)
		{
		}
	}
}