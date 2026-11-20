using System.Runtime.CompilerServices;

namespace System.Threading.Channels;

public abstract class ChannelOptions
{
	[CompilerGenerated]
	private bool _003CSingleWriter_003Ek__BackingField;

	public bool SingleWriter
	{
		[CompilerGenerated]
		set
		{
			_003CSingleWriter_003Ek__BackingField = value;
		}
	}

	public bool SingleReader { get; set; }

	public bool AllowSynchronousContinuations { get; }
}
