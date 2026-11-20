using System.Collections.Generic;

namespace Auchan.Common.Ecom.Cart;

public class CashbackLimitNotifiedModel
{
	public List<string> LimitNotifiedGimaIds { get; set; }

	public CashbackLimitNotifiedModel(List<string> limitNotifiedGimaIds)
	{
		LimitNotifiedGimaIds = limitNotifiedGimaIds;
	}
}
