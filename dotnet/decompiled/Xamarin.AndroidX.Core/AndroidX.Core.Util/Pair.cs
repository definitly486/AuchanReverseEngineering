using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Util;

[Register("androidx/core/util/Pair", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "F", "S" })]
public class Pair : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/util/Pair", typeof(Pair));

	[Register("first")]
	public Java.Lang.Object? First
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceFields.GetObjectValue("first.Ljava/lang/Object;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("first.Ljava/lang/Object;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("second")]
	public Java.Lang.Object? Second
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceFields.GetObjectValue("second.Ljava/lang/Object;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("second.Ljava/lang/Object;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	protected Pair(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/Object;Ljava/lang/Object;)V", "")]
	public unsafe Pair(Java.Lang.Object? first, Java.Lang.Object? second)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.ToLocalJniHandle(first);
		nint num2 = JNIEnv.ToLocalJniHandle(second);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(first);
			GC.KeepAlive(second);
		}
	}

	[Register("create", "(Ljava/lang/Object;Ljava/lang/Object;)Landroidx/core/util/Pair;", "")]
	[JavaTypeParameters(new string[] { "A", "B" })]
	public unsafe static Pair? Create(Java.Lang.Object? a, Java.Lang.Object? b)
	{
		nint num = JNIEnv.ToLocalJniHandle(a);
		nint num2 = JNIEnv.ToLocalJniHandle(b);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Pair>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/Object;Ljava/lang/Object;)Landroidx/core/util/Pair;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}
}
