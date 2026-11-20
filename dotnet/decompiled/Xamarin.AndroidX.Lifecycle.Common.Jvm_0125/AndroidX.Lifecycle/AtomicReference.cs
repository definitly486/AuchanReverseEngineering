using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/lifecycle/AtomicReference", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "V" })]
public sealed class AtomicReference : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/AtomicReference", typeof(AtomicReference));

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

	internal AtomicReference(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/Object;)V", "")]
	public unsafe AtomicReference(Java.Lang.Object? initialValue)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.ToLocalJniHandle(initialValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(initialValue);
		}
	}

	[Register("compareAndSet", "(Ljava/lang/Object;Ljava/lang/Object;)Z", "")]
	public unsafe bool CompareAndSet(Java.Lang.Object? expectedValue, Java.Lang.Object? newValue)
	{
		nint num = JNIEnv.ToLocalJniHandle(expectedValue);
		nint num2 = JNIEnv.ToLocalJniHandle(newValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("compareAndSet.(Ljava/lang/Object;Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(expectedValue);
			GC.KeepAlive(newValue);
		}
	}

	[Register("get", "()Ljava/lang/Object;", "")]
	public unsafe Java.Lang.Object? Get()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
