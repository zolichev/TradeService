using System;
using TradeService.Model.Market;

namespace TradeService.Model.Test.DataMock
{
	public class DiscountMock: Discount
	{
		public DiscountMock(Guid id, string code, decimal value, GoodType? type = null) : base(id, code, value, type)
		{
		}
	}
}