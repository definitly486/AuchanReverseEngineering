using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Google.Zxing.Common;

[Register("com/google/zxing/common/BitMatrix", DoNotGenerateAcw = true)]
public sealed class BitMatrix : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/BitMatrix", typeof(BitMatrix));

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

	public unsafe int Height
	{
		[Register("getHeight", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
		}
	}

	public unsafe int RowSize
	{
		[Register("getRowSize", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getRowSize.()I", this, null);
		}
	}

	public unsafe int Width
	{
		[Register("getWidth", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getWidth.()I", this, null);
		}
	}

	internal BitMatrix(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe BitMatrix(int dimension)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dimension);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe BitMatrix(int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}

	[Register("clear", "()V", "")]
	public unsafe void Clear()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	[Register("clone", "()Lcom/google/zxing/common/BitMatrix;", "")]
	public new unsafe BitMatrix? Clone()
	{
		return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("clone.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("flip", "()V", "")]
	public unsafe void Flip()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("flip.()V", this, null);
	}

	[Register("flip", "(II)V", "")]
	public unsafe void Flip(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeAbstractVoidMethod("flip.(II)V", this, ptr);
	}

	[Register("get", "(II)Z", "")]
	public unsafe bool Get(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("get.(II)Z", this, ptr);
	}

	[Register("getBottomRightOnBit", "()[I", "")]
	public unsafe int[]? GetBottomRightOnBit()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getBottomRightOnBit.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	[Register("getEnclosingRectangle", "()[I", "")]
	public unsafe int[]? GetEnclosingRectangle()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getEnclosingRectangle.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	[Register("getRow", "(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", "")]
	public unsafe BitArray? GetRow(int y, BitArray? row)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(y);
			ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRow.(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(row);
		}
	}

	[Register("getTopLeftOnBit", "()[I", "")]
	public unsafe int[]? GetTopLeftOnBit()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getTopLeftOnBit.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	[Register("parse", "([[Z)Lcom/google/zxing/common/BitMatrix;", "")]
	public unsafe static BitMatrix? Parse(bool[][]? image)
	{
		nint num = JNIEnv.NewArray(image);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<BitMatrix>(_members.StaticMethods.InvokeObjectMethod("parse.([[Z)Lcom/google/zxing/common/BitMatrix;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (image != null)
			{
				JNIEnv.CopyArray(num, image);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(image);
		}
	}

	[Register("parse", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/google/zxing/common/BitMatrix;", "")]
	public unsafe static BitMatrix? Parse(string? stringRepresentation, string? setString, string? unsetString)
	{
		nint num = JNIEnv.NewString(stringRepresentation);
		nint num2 = JNIEnv.NewString(setString);
		nint num3 = JNIEnv.NewString(unsetString);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			return Java.Lang.Object.GetObject<BitMatrix>(_members.StaticMethods.InvokeObjectMethod("parse.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/google/zxing/common/BitMatrix;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
		}
	}

	[Register("rotate", "(I)V", "")]
	public unsafe void Rotate(int degrees)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(degrees);
		_members.InstanceMethods.InvokeAbstractVoidMethod("rotate.(I)V", this, ptr);
	}

	[Register("rotate180", "()V", "")]
	public unsafe void Rotate180()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("rotate180.()V", this, null);
	}

	[Register("rotate90", "()V", "")]
	public unsafe void Rotate90()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("rotate90.()V", this, null);
	}

	[Register("set", "(II)V", "")]
	public unsafe void Set(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeAbstractVoidMethod("set.(II)V", this, ptr);
	}

	[Register("setRegion", "(IIII)V", "")]
	public unsafe void SetRegion(int left, int top, int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(width);
		ptr[3] = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setRegion.(IIII)V", this, ptr);
	}

	[Register("setRow", "(ILcom/google/zxing/common/BitArray;)V", "")]
	public unsafe void SetRow(int y, BitArray? row)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(y);
			ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRow.(ILcom/google/zxing/common/BitArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(row);
		}
	}

	[Register("toString", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
	public unsafe string? ToString(string? setString, string? unsetString)
	{
		nint num = JNIEnv.NewString(setString);
		nint num2 = JNIEnv.NewString(unsetString);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Obsolete("deprecated")]
	[Register("toString", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
	public unsafe string? ToString(string? setString, string? unsetString, string? lineSeparator)
	{
		nint num = JNIEnv.NewString(setString);
		nint num2 = JNIEnv.NewString(unsetString);
		nint num3 = JNIEnv.NewString(lineSeparator);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
		}
	}

	[Register("unset", "(II)V", "")]
	public unsafe void Unset(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeAbstractVoidMethod("unset.(II)V", this, ptr);
	}

	[Register("xor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
	public unsafe void Xor(BitMatrix? mask)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mask?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("xor.(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mask);
		}
	}
}
