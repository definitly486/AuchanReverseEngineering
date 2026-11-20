using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Calendar", DoNotGenerateAcw = true)]
public abstract class Calendar : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Calendar", typeof(Calendar));

	private static Delegate? cb_getTimeInMillis_GetTimeInMillis_J;

	private static Delegate? cb_clone_Clone_Ljava_lang_Object_;

	private static Delegate? cb_get_Get_I_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static Calendar Instance
	{
		[Register("getInstance", "()Ljava/util/Calendar;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Calendar>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Ljava/util/Calendar;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual long TimeInMillis
	{
		[Register("getTimeInMillis", "()J", "GetGetTimeInMillisHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getTimeInMillis.()J", this, null);
		}
	}

	protected Calendar(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetTimeInMillisHandler()
	{
		return new _JniMarshal_PP_J(n_GetTimeInMillis);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetTimeInMillis(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<Calendar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TimeInMillis;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetCloneHandler()
	{
		return new _JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Calendar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Ljava/lang/Object;", "GetCloneHandler")]
	public new unsafe virtual Java.Lang.Object Clone()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGet_IHandler()
	{
		return new _JniMarshal_PPI_I(n_Get_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Get_I(nint jnienv, nint native__this, int native_field)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Calendar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get((CalendarField)native_field);
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

	[Register("get", "(I)I", "GetGet_IHandler")]
	public unsafe virtual int Get(CalendarField field)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)field);
		return _members.InstanceMethods.InvokeVirtualInt32Method("get.(I)I", this, ptr);
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
