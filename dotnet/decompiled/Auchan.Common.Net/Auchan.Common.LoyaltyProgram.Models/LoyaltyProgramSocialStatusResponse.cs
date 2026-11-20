using System.Collections.Generic;

namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyProgramSocialStatusResponse
{
	public IEnumerable<LoyaltyProgramSocialStatusSegment> Segments { get; }

	public bool IsEmployee { get; }

	public bool IsSocial { get; }

	public LoyaltyProgramSocialStatusResponse(IEnumerable<LoyaltyProgramSocialStatusSegment> segments, bool isEmployee, bool isSocial)
	{
		Segments = segments;
		IsEmployee = isEmployee;
		IsSocial = isSocial;
	}
}
