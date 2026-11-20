using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Scanflow.Datacapture.Model;

[Register("com/scanflow/datacapture/model/OneOFManyCodesScanResults", DoNotGenerateAcw = true)]
public sealed class OneOFManyCodesScanResults : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/model/OneOFManyCodesScanResults", typeof(OneOFManyCodesScanResults));

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

	public unsafe string DecodedFormat
	{
		[Register("getDecodedFormat", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDecodedFormat.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string DecodedValue
	{
		[Register("getDecodedValue", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDecodedValue.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal OneOFManyCodesScanResults(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe OneOFManyCodesScanResults(string p0, string p1)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(p0);
		nint num2 = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register("component1", "()Ljava/lang/String;", "")]
	public unsafe string Component1()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component2", "()Ljava/lang/String;", "")]
	public unsafe string Component2()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("copy", "(Ljava/lang/String;Ljava/lang/String;)Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;", "")]
	public unsafe OneOFManyCodesScanResults Copy(string decodedValue, string decodedFormat)
	{
		nint num = JNIEnv.NewString(decodedValue);
		nint num2 = JNIEnv.NewString(decodedFormat);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<OneOFManyCodesScanResults>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Ljava/lang/String;)Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}
