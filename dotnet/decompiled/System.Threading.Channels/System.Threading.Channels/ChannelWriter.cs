namespace System.Threading.Channels;

public abstract class ChannelWriter<T>
{
	public virtual bool TryComplete(Exception? error = null)
	{
		return false;
	}

	public abstract bool TryWrite(T item);

	public void Complete(Exception? error = null)
	{
		if (!TryComplete(error))
		{
			throw ChannelUtilities.CreateInvalidCompletionException();
		}
	}
}
