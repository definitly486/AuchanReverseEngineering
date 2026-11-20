using System.Runtime.CompilerServices;

namespace System.Net.Quic;

public readonly struct QuicStreamCapacityChangedArgs
{
	[CompilerGenerated]
	private readonly int _003CUnidirectionalIncrement_003Ek__BackingField;

	public int BidirectionalIncrement { get; init; }

	public int UnidirectionalIncrement
	{
		[CompilerGenerated]
		init
		{
			_003CUnidirectionalIncrement_003Ek__BackingField = value;
		}
	}
}
