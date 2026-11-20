namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyProgramSocialStatusSegment
{
	public string Code { get; set; }

	public int Id { get; set; }

	public LoyaltyProgramSocialStatusSegment(string code, int id)
	{
		Code = code;
		Id = id;
	}
}
