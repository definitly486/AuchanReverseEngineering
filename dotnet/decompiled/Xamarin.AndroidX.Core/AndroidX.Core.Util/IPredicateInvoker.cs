using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Util;

[Register("androidx/core/util/Predicate", DoNotGenerateAcw = true)]
internal class IPredicateInvoker : Java.Lang.Object, IPredicate, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_util_Predicate = new XAPeerMembers("androidx/core/util/Predicate", typeof(IPredicateInvoker));

	private static Delegate? cb_test_Test_Ljava_lang_Object__Z;

	private static nint java_class_ref => _members_androidx_core_util_Predicate.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_util_Predicate;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_util_Predicate.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_util_Predicate.ManagedPeerType;

	public IPredicateInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetTest_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Test_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Test_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_t)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IPredicate? predicate = Java.Lang.Object.GetObject<IPredicate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object t = Java.Lang.Object.GetObject<Java.Lang.Object>(native_t, JniHandleOwnership.DoNotTransfer);
			return predicate.Test(t) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool Test(Java.Lang.Object? t)
	{
		nint num = JNIEnv.ToLocalJniHandle(t);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_androidx_core_util_Predicate.InstanceMethods.InvokeAbstractBooleanMethod("test.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(t);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
