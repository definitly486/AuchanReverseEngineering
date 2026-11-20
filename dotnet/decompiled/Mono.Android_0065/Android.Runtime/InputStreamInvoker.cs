using System;
using System.IO;
using Java.IO;
using Java.Lang;
using Java.Nio.Channels;

namespace Android.Runtime;

public class InputStreamInvoker : Stream
{
	public InputStream BaseInputStream { get; private set; }

	protected FileChannel? BaseFileChannel { get; private set; }

	public override bool CanRead => true;

	public override bool CanSeek => BaseFileChannel != null;

	public override bool CanWrite => false;

	public override long Length
	{
		get
		{
			if (BaseFileChannel != null)
			{
				return BaseFileChannel.Size();
			}
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			if (BaseFileChannel != null)
			{
				return BaseFileChannel.Position();
			}
			throw new NotSupportedException();
		}
		set
		{
			if (BaseFileChannel != null)
			{
				BaseFileChannel.Position(value);
				return;
			}
			throw new NotSupportedException();
		}
	}

	public InputStreamInvoker(InputStream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		BaseInputStream = stream;
		if (stream is FileInputStream fileInputStream)
		{
			BaseFileChannel = fileInputStream.Channel;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing || BaseInputStream == null)
		{
			return;
		}
		try
		{
			BaseFileChannel = null;
			if (BaseInputStream.PeerReference.IsValid)
			{
				BaseInputStream.Close();
			}
			BaseInputStream.Dispose();
		}
		catch (Java.IO.IOException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Dispose"))
		{
			throw new System.IO.IOException(ex.Message, ex);
		}
	}

	public override void Close()
	{
		base.Close();
	}

	public override void Flush()
	{
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num;
		try
		{
			num = BaseInputStream.Read(buffer, offset, count);
		}
		catch (Java.IO.IOException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Read"))
		{
			throw new System.IO.IOException(ex.Message, ex);
		}
		if (num == -1)
		{
			return 0;
		}
		return num;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (BaseFileChannel == null)
		{
			throw new NotSupportedException();
		}
		switch (origin)
		{
		case SeekOrigin.Begin:
			BaseFileChannel.Position(offset);
			break;
		case SeekOrigin.Current:
			BaseFileChannel.Position(BaseFileChannel.Position() + offset);
			break;
		case SeekOrigin.End:
			BaseFileChannel.Position(BaseFileChannel.Size() + offset);
			break;
		}
		return BaseFileChannel.Position();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public static Stream? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		InputStream inputStream = Java.Lang.Object.GetObject<InputStream>(handle, transfer);
		if (inputStream == null)
		{
			return null;
		}
		return new InputStreamInvoker(inputStream);
	}
}
