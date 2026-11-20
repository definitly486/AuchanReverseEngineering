namespace System.Threading.Channels;

public static class Channel
{
	public static Channel<T> CreateUnbounded<T>(UnboundedChannelOptions options)
	{
		ArgumentNullException.ThrowIfNull(options, "options");
		if (options.SingleReader)
		{
			return new SingleConsumerUnboundedChannel<T>(!options.AllowSynchronousContinuations);
		}
		return new UnboundedChannel<T>(!options.AllowSynchronousContinuations);
	}
}
public abstract class Channel<T> : Channel<T, T>
{
}
public abstract class Channel<TWrite, TRead>
{
	public ChannelReader<TRead> Reader { get; protected set; }

	public ChannelWriter<TWrite> Writer { get; protected set; }

	public static implicit operator ChannelReader<TRead>(Channel<TWrite, TRead> channel)
	{
		return channel.Reader;
	}

	public static implicit operator ChannelWriter<TWrite>(Channel<TWrite, TRead> channel)
	{
		return channel.Writer;
	}
}
