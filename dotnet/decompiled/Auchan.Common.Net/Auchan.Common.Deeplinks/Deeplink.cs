namespace Auchan.Common.Deeplinks;

public class Deeplink
{
	public DeeplinkType type { get; }

	public string id { get; }

	public Deeplink(DeeplinkType type, string id)
	{
		this.type = type;
		this.id = id;
	}
}
