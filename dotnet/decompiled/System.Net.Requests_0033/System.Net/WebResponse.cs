using System.IO;
using System.Runtime.Serialization;

namespace System.Net;

public abstract class WebResponse : MarshalByRefObject, ISerializable, IDisposable
{
	public virtual bool IsFromCache => false;

	public virtual WebHeaderCollection Headers
	{
		get
		{
			throw System.NotImplemented.ByDesignWithMessage("net_PropertyNotImplementedException");
		}
	}

	[Obsolete("Serialization has been deprecated for WebResponse.")]
	void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	[Obsolete("Serialization has been deprecated for WebResponse.")]
	protected virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	public virtual void Close()
	{
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			try
			{
				Close();
			}
			catch
			{
			}
		}
	}

	public virtual Stream GetResponseStream()
	{
		throw System.NotImplemented.ByDesignWithMessage("net_MethodNotImplementedException");
	}
}
