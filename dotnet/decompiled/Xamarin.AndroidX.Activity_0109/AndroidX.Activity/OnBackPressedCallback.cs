using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity;

[Register("androidx/activity/OnBackPressedCallback", DoNotGenerateAcw = true)]
public abstract class OnBackPressedCallback : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/OnBackPressedCallback", typeof(OnBackPressedCallback));

	private static Delegate? cb_handleOnBackCancelled_HandleOnBackCancelled_V;

	private static Delegate? cb_handleOnBackPressed_HandleOnBackPressed_V;

	private static Delegate? cb_handleOnBackProgressed_HandleOnBackProgressed_Landroidx_activity_BackEventCompat__V;

	private static Delegate? cb_handleOnBackStarted_HandleOnBackStarted_Landroidx_activity_BackEventCompat__V;

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

	public unsafe bool Enabled
	{
		[Register("isEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isEnabled.()Z", this, null);
		}
		[Register("setEnabled", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setEnabled.(Z)V", this, ptr);
		}
	}

	protected OnBackPressedCallback(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Z)V", "")]
	public unsafe OnBackPressedCallback(bool enabled)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Z)V", this, ptr);
		}
	}

	private static Delegate GetHandleOnBackCancelledHandler()
	{
		return new global::_JniMarshal_PP_V(n_HandleOnBackCancelled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_HandleOnBackCancelled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<OnBackPressedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandleOnBackCancelled();
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

	[Register("handleOnBackCancelled", "()V", "GetHandleOnBackCancelledHandler")]
	public unsafe virtual void HandleOnBackCancelled()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("handleOnBackCancelled.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_HandleOnBackPressed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<OnBackPressedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandleOnBackPressed();
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

	[Register("handleOnBackPressed", "()V", "GetHandleOnBackPressedHandler")]
	public abstract void HandleOnBackPressed();

	private static Delegate GetHandleOnBackProgressed_Landroidx_activity_BackEventCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_HandleOnBackProgressed_Landroidx_activity_BackEventCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_HandleOnBackProgressed_Landroidx_activity_BackEventCompat_(nint jnienv, nint native__this, nint native_backEvent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			OnBackPressedCallback? onBackPressedCallback = Java.Lang.Object.GetObject<OnBackPressedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BackEventCompat backEvent = Java.Lang.Object.GetObject<BackEventCompat>(native_backEvent, JniHandleOwnership.DoNotTransfer);
			onBackPressedCallback.HandleOnBackProgressed(backEvent);
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

	[Register("handleOnBackProgressed", "(Landroidx/activity/BackEventCompat;)V", "GetHandleOnBackProgressed_Landroidx_activity_BackEventCompat_Handler")]
	public unsafe virtual void HandleOnBackProgressed(BackEventCompat backEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backEvent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("handleOnBackProgressed.(Landroidx/activity/BackEventCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(backEvent);
		}
	}

	private static Delegate GetHandleOnBackStarted_Landroidx_activity_BackEventCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_HandleOnBackStarted_Landroidx_activity_BackEventCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_HandleOnBackStarted_Landroidx_activity_BackEventCompat_(nint jnienv, nint native__this, nint native_backEvent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			OnBackPressedCallback? onBackPressedCallback = Java.Lang.Object.GetObject<OnBackPressedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BackEventCompat backEvent = Java.Lang.Object.GetObject<BackEventCompat>(native_backEvent, JniHandleOwnership.DoNotTransfer);
			onBackPressedCallback.HandleOnBackStarted(backEvent);
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

	[Register("handleOnBackStarted", "(Landroidx/activity/BackEventCompat;)V", "GetHandleOnBackStarted_Landroidx_activity_BackEventCompat_Handler")]
	public unsafe virtual void HandleOnBackStarted(BackEventCompat backEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backEvent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("handleOnBackStarted.(Landroidx/activity/BackEventCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(backEvent);
		}
	}

	[Register("remove", "()V", "")]
	public unsafe void Remove()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("remove.()V", this, null);
	}

	[UnmanagedCallersOnly]
	private static void n_HandleOnBackPressed_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_HandleOnBackPressed(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
