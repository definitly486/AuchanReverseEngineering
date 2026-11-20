using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Views.Animations;

[Register("android/view/animation/Animation", DoNotGenerateAcw = true)]
public abstract class Animation : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/animation/Animation", typeof(Animation));

	private static Delegate? cb_setDuration_SetDuration_J_V;

	private static Delegate? cb_setFillAfter_SetFillAfter_Z_V;

	private static Delegate? cb_setRepeatCount_SetRepeatCount_I_V;

	private static Delegate? cb_setRepeatMode_SetRepeatMode_I_V;

	private static Delegate? cb_setStartOffset_SetStartOffset_J_V;

	private static Delegate? cb_setStartTime_SetStartTime_J_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual long Duration
	{
		[Register("setDuration", "(J)V", "GetSetDuration_JHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDuration.(J)V", this, ptr);
		}
	}

	public unsafe virtual bool FillAfter
	{
		[Register("setFillAfter", "(Z)V", "GetSetFillAfter_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFillAfter.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int RepeatCount
	{
		[Register("setRepeatCount", "(I)V", "GetSetRepeatCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRepeatCount.(I)V", this, ptr);
		}
	}

	public unsafe virtual RepeatMode RepeatMode
	{
		[Register("setRepeatMode", "(I)V", "GetSetRepeatMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRepeatMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual long StartOffset
	{
		[Register("setStartOffset", "(J)V", "GetSetStartOffset_JHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartOffset.(J)V", this, ptr);
		}
	}

	public unsafe virtual long StartTime
	{
		[Register("setStartTime", "(J)V", "GetSetStartTime_JHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartTime.(J)V", this, ptr);
		}
	}

	protected Animation(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe Animation(Context? context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetSetDuration_JHandler()
	{
		return new _JniMarshal_PPJ_V(n_SetDuration_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDuration_J(nint jnienv, nint native__this, long durationMillis)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration = durationMillis;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetFillAfter_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetFillAfter_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFillAfter_Z(nint jnienv, nint native__this, sbyte native_fillAfter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Animation? animation = Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool fillAfter = native_fillAfter != 0;
			animation.FillAfter = fillAfter;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetRepeatCount_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetRepeatCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRepeatCount_I(nint jnienv, nint native__this, int repeatCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatCount = repeatCount;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetRepeatMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetRepeatMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRepeatMode_I(nint jnienv, nint native__this, int native_repeatMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatMode = (RepeatMode)native_repeatMode;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetStartOffset_JHandler()
	{
		return new _JniMarshal_PPJ_V(n_SetStartOffset_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartOffset_J(nint jnienv, nint native__this, long startOffset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartOffset = startOffset;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetStartTime_JHandler()
	{
		return new _JniMarshal_PPJ_V(n_SetStartTime_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartTime_J(nint jnienv, nint native__this, long startTimeMillis)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartTime = startTimeMillis;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
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
