namespace System.Threading.Channels;

[Serializable]
public class ChannelClosedException : InvalidOperationException
{
	public ChannelClosedException()
		: base("ChannelClosedException_DefaultMessage")
	{
	}

	public ChannelClosedException(Exception? innerException)
		: base("ChannelClosedException_DefaultMessage", innerException)
	{
	}
}
