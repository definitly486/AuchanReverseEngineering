using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Style;

[Register("android/text/style/ClickableSpan", DoNotGenerateAcw = true)]
public abstract class ClickableSpan : CharacterStyle, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/ClickableSpan", typeof(ClickableSpan));

	private static Delegate? cb_onClick_OnClick_Landroid_view_View__V;

	private static Delegate? cb_updateDrawState_UpdateDrawState_Landroid_text_TextPaint__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ClickableSpan(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe ClickableSpan()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnClick_Landroid_view_View_(nint jnienv, nint native__this, nint native_widget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ClickableSpan? clickableSpan = Java.Lang.Object.GetObject<ClickableSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View widget = Java.Lang.Object.GetObject<View>(native_widget, JniHandleOwnership.DoNotTransfer);
			clickableSpan.OnClick(widget);
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

	public abstract void OnClick(View widget);

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDrawState_Landroid_text_TextPaint_(nint jnienv, nint native__this, nint native_ds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ClickableSpan? clickableSpan = Java.Lang.Object.GetObject<ClickableSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextPaint tp = Java.Lang.Object.GetObject<TextPaint>(native_ds, JniHandleOwnership.DoNotTransfer);
			clickableSpan.UpdateDrawState(tp);
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

	public unsafe override void UpdateDrawState(TextPaint ds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateDrawState.(Landroid/text/TextPaint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ds);
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

	[UnmanagedCallersOnly]
	private static void n_OnClick_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_widget)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnClick_Landroid_view_View_(jnienv, native__this, native_widget);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_UpdateDrawState_Landroid_text_TextPaint__mm_wrapper(nint jnienv, nint native__this, nint native_ds)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_UpdateDrawState_Landroid_text_TextPaint_(jnienv, native__this, native_ds);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
