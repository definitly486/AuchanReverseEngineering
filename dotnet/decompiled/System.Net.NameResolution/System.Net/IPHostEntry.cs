using System.Runtime.CompilerServices;

namespace System.Net;

public class IPHostEntry
{
	[CompilerGenerated]
	private string[] _003CAliases_003Ek__BackingField;

	public string HostName { get; set; }

	public string[] Aliases
	{
		[CompilerGenerated]
		set
		{
			_003CAliases_003Ek__BackingField = value;
		}
	}

	public IPAddress[] AddressList { get; set; }
}
