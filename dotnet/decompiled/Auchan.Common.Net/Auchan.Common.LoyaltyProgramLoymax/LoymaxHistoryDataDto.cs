using Auchan.Common.LoyaltyProgram.Dtos;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoymaxHistoryDataDto
{
	[JsonProperty("transactions_types")]
	public HistoryFilter[]? AvailableFilters { get; set; }

	[JsonProperty("items")]
	public TransactionDetailsDto[]? Items { get; set; }
}
