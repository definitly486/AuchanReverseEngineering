using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Comparator", DoNotGenerateAcw = true)]
internal class IComparatorInvoker : Java.Lang.Object, IComparator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_Comparator = new XAPeerMembers("java/util/Comparator", typeof(IComparatorInvoker));

	private static Delegate? cb_compare_Compare_Ljava_lang_Object_Ljava_lang_Object__I;

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_Comparator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_Comparator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_Comparator.ManagedPeerType;

	public IComparatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCompare_Ljava_lang_Object_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPLL_I(n_Compare_Ljava_lang_Object_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Compare_Ljava_lang_Object_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_o1, nint native_o2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o2, JniHandleOwnership.DoNotTransfer);
			return comparator.Compare(o, o2);
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

	public unsafe int Compare(Java.Lang.Object? o1, Java.Lang.Object? o2)
	{
		nint num = JNIEnv.ToLocalJniHandle(o1);
		nint num2 = JNIEnv.ToLocalJniHandle(o2);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members_java_util_Comparator.InstanceMethods.InvokeAbstractInt32Method("compare.(Ljava/lang/Object;Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(o1);
			GC.KeepAlive(o2);
		}
	}

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_B(n_Equals_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Equals_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_obj)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IComparator? comparator = Java.Lang.Object.GetObject<IComparator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return comparator.Equals(obj) ? ((sbyte)1) : ((sbyte)0);
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

	public new unsafe bool Equals(Java.Lang.Object? obj)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			return _members_java_util_Comparator.InstanceMethods.InvokeAbstractBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
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
