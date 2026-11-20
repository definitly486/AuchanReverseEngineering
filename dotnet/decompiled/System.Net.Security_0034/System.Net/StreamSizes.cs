namespace System.Net;

internal struct StreamSizes
{
	public int Header { get; }

	public int Trailer { get; }

	public int MaximumMessage { get; private set; }

	public static StreamSizes Default => new StreamSizes
	{
		MaximumMessage = 32768
	};
}
