using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Google.Zxing.Common;

[Register("com/google/zxing/common/BitArray", DoNotGenerateAcw = true)]
public sealed class BitArray : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/BitArray", typeof(BitArray));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe int Size
	{
		[Register("getSize", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSize.()I", this, null);
		}
	}

	public unsafe int SizeInBytes
	{
		[Register("getSizeInBytes", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSizeInBytes.()I", this, null);
		}
	}

	internal BitArray(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BitArray()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe BitArray(int size)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(size);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	[Register("appendBit", "(Z)V", "")]
	public unsafe void AppendBit(bool bit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(bit);
		_members.InstanceMethods.InvokeAbstractVoidMethod("appendBit.(Z)V", this, ptr);
	}

	[Register("appendBitArray", "(Lcom/google/zxing/common/BitArray;)V", "")]
	public unsafe void AppendBitArray(BitArray? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("appendBitArray.(Lcom/google/zxing/common/BitArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	[Register("appendBits", "(II)V", "")]
	public unsafe void AppendBits(int value, int numBits)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(value);
		ptr[1] = new JniArgumentValue(numBits);
		_members.InstanceMethods.InvokeAbstractVoidMethod("appendBits.(II)V", this, ptr);
	}

	[Register("clear", "()V", "")]
	public unsafe void Clear()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	[Register("clone", "()Lcom/google/zxing/common/BitArray;", "")]
	public new unsafe BitArray? Clone()
	{
		return Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("clone.()Lcom/google/zxing/common/BitArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("flip", "(I)V", "")]
	public unsafe void Flip(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		_members.InstanceMethods.InvokeAbstractVoidMethod("flip.(I)V", this, ptr);
	}

	[Register("get", "(I)Z", "")]
	public unsafe bool Get(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("get.(I)Z", this, ptr);
	}

	[Register("getBitArray", "()[I", "")]
	public unsafe int[]? GetBitArray()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getBitArray.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	[Register("getNextSet", "(I)I", "")]
	public unsafe int GetNextSet(int from)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(from);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getNextSet.(I)I", this, ptr);
	}

	[Register("getNextUnset", "(I)I", "")]
	public unsafe int GetNextUnset(int from)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(from);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getNextUnset.(I)I", this, ptr);
	}

	[Register("isRange", "(IIZ)Z", "")]
	public unsafe bool IsRange(int start, int end, bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		ptr[2] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRange.(IIZ)Z", this, ptr);
	}

	[Register("reverse", "()V", "")]
	public unsafe void Reverse()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("reverse.()V", this, null);
	}

	[Register("set", "(I)V", "")]
	public unsafe void Set(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		_members.InstanceMethods.InvokeAbstractVoidMethod("set.(I)V", this, ptr);
	}

	[Register("setBulk", "(II)V", "")]
	public unsafe void SetBulk(int i, int newBits)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(i);
		ptr[1] = new JniArgumentValue(newBits);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setBulk.(II)V", this, ptr);
	}

	[Register("setRange", "(II)V", "")]
	public unsafe void SetRange(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setRange.(II)V", this, ptr);
	}

	[Register("toBytes", "(I[BII)V", "")]
	public unsafe void ToBytes(int bitOffset, byte[]? array, int offset, int numBytes)
	{
		nint num = JNIEnv.NewArray(array);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(bitOffset);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			ptr[3] = new JniArgumentValue(numBytes);
			_members.InstanceMethods.InvokeAbstractVoidMethod("toBytes.(I[BII)V", this, ptr);
		}
		finally
		{
			if (array != null)
			{
				JNIEnv.CopyArray(num, array);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(array);
		}
	}

	[Register("xor", "(Lcom/google/zxing/common/BitArray;)V", "")]
	public unsafe void Xor(BitArray? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("xor.(Lcom/google/zxing/common/BitArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}
}
