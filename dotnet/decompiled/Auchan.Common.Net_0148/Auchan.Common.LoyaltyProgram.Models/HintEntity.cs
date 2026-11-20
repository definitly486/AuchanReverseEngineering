using Auchan.Common.Common;

namespace Auchan.Common.LoyaltyProgram.Models;

public class HintEntity
{
	public AttributedText? Text { get; set; }

	public bool IsLast { get; set; }

	public int Index { get; set; }
}
