using System;
using System.IO;
using Java.IO;
using Java.Lang;

namespace Android.Runtime;

public class OutputStreamInvoker : Stream
{
	public OutputStream BaseOutputStream { get; private set; }

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public OutputStreamInvoker(OutputStream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		BaseOutputStream = stream;
	}

	public override void Close()
	{
		base.Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing || BaseOutputStream == null)
		{
			return;
		}
		try
		{
			if (BaseOutputStream.PeerReference.IsValid)
			{
				BaseOutputStream.Close();
			}
			BaseOutputStream.Dispose();
		}
		catch (Java.IO.IOException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Dispose"))
		{
			throw new System.IO.IOException(ex.Message, ex);
		}
	}

	public override void Flush()
	{
		try
		{
			BaseOutputStream.Flush();
		}
		catch (Java.IO.IOException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Flush"))
		{
			throw new System.IO.IOException(ex.Message, ex);
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		try
		{
			BaseOutputStream.Write(buffer, offset, count);
		}
		catch (Java.IO.IOException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Write"))
		{
			throw new System.IO.IOException(ex.Message, ex);
		}
	}

	public static Stream? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		return FromNative(handle, transfer);
	}

	internal static Stream? FromNative(nint handle, JniHandleOwnership transfer)
	{
		OutputStream outputStream = Java.Lang.Object.GetObject<OutputStream>(handle, transfer);
		if (outputStream == null)
		{
			return null;
		}
		return new OutputStreamInvoker(outputStream);
	}
}
