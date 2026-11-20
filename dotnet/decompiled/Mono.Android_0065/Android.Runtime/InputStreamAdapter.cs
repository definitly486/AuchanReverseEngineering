using System;
using System.IO;
using Java.IO;

namespace Android.Runtime;

[Register("mono/android/runtime/InputStreamAdapter")]
public sealed class InputStreamAdapter : InputStream
{
	public Stream BaseStream { get; private set; }

	public InputStreamAdapter(Stream stream)
		: base(JNIEnv.StartCreateInstance("mono/android/runtime/InputStreamAdapter", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		BaseStream = stream;
	}

	public override void Close()
	{
		BaseStream.Close();
	}

	public override int Read()
	{
		return BaseStream.ReadByte();
	}

	public override int Read(byte[] bytes)
	{
		return Read(bytes, 0, bytes.Length);
	}

	public override int Read(byte[] bytes, int offset, int length)
	{
		int num = BaseStream.Read(bytes, offset, length);
		if (num == 0)
		{
			return -1;
		}
		return num;
	}

	public static nint ToLocalJniHandle(Stream? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is InputStreamInvoker inputStreamInvoker)
		{
			return JNIEnv.ToLocalJniHandle(inputStreamInvoker.BaseInputStream);
		}
		return JNIEnv.ToLocalJniHandle(new InputStreamAdapter(value));
	}
}
