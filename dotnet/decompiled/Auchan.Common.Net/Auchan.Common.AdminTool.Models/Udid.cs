namespace Auchan.Common.AdminTool.Models;

public class Udid
{
	public string UserId { get; }

	public string Key { get; }

	public Udid(string userId, string key)
	{
		UserId = userId;
		Key = key;
	}
}
