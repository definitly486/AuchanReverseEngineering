using System;
using System.IO;
using Java.IO;

namespace Android.Runtime;

[Register("mono/android/runtime/OutputStreamAdapter")]
public class OutputStreamAdapter : OutputStream
{
	public Stream BaseStream { get; private set; }

	public OutputStreamAdapter(Stream stream)
		: base(JNIEnv.StartCreateInstance("mono/android/runtime/OutputStreamAdapter", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		BaseStream = stream;
	}

	public override void Close()
	{
		BaseStream.Close();
	}

	public override void Flush()
	{
		BaseStream.Flush();
	}

	public override void Write(byte[] buffer)
	{
		BaseStream.Write(buffer, 0, (buffer != null) ? buffer.Length : 0);
	}

	public override void Write(byte[] buffer, int offset, int length)
	{
		BaseStream.Write(buffer, offset, length);
	}

	public override void Write(int oneByte)
	{
		BaseStream.WriteByte((byte)oneByte);
	}

	public static nint ToLocalJniHandle(Stream? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is OutputStreamInvoker outputStreamInvoker)
		{
			return JNIEnv.ToLocalJniHandle(outputStreamInvoker.BaseOutputStream);
		}
		return JNIEnv.ToLocalJniHandle(new OutputStreamAdapter(value));
	}
}
