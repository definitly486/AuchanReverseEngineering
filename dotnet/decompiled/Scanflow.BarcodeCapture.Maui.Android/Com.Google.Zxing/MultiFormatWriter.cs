using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Google.Zxing.Common;
using Java.Interop;
using Java.Lang;

namespace Com.Google.Zxing;

[Register("com/google/zxing/MultiFormatWriter", DoNotGenerateAcw = true)]
public sealed class MultiFormatWriter : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/MultiFormatWriter", typeof(MultiFormatWriter));

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

	internal MultiFormatWriter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MultiFormatWriter()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
	public unsafe BitMatrix? Encode(string? contents, BarcodeFormat? format, int width, int height)
	{
		nint num = JNIEnv.NewString(contents);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(format);
		}
	}

	[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "")]
	public unsafe BitMatrix? Encode(string? contents, BarcodeFormat? format, int width, int height, IDictionary<EncodeHintType, object>? hints)
	{
		nint num = JNIEnv.NewString(contents);
		nint num2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			ptr[4] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(format);
			GC.KeepAlive(hints);
		}
	}
}
