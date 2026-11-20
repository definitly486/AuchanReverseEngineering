using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Style;

[Register("android/text/style/ReplacementSpan", DoNotGenerateAcw = true)]
public abstract class ReplacementSpan : MetricAffectingSpan
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/ReplacementSpan", typeof(ReplacementSpan));

	private static Delegate? cb_updateDrawState_UpdateDrawState_Landroid_text_TextPaint__V;

	private static Delegate? cb_updateMeasureState_UpdateMeasureState_Landroid_text_TextPaint__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ReplacementSpan(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetUpdateDrawState_Landroid_text_TextPaint_Handler()
	{
		return new _JniMarshal_PPL_V(n_UpdateDrawState_Landroid_text_TextPaint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDrawState_Landroid_text_TextPaint_(nint jnienv, nint native__this, nint native_ds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ReplacementSpan? replacementSpan = Java.Lang.Object.GetObject<ReplacementSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextPaint tp = Java.Lang.Object.GetObject<TextPaint>(native_ds, JniHandleOwnership.DoNotTransfer);
			replacementSpan.UpdateDrawState(tp);
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

	public unsafe override void UpdateDrawState(TextPaint? ds)
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

	private static Delegate GetUpdateMeasureState_Landroid_text_TextPaint_Handler()
	{
		return new _JniMarshal_PPL_V(n_UpdateMeasureState_Landroid_text_TextPaint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateMeasureState_Landroid_text_TextPaint_(nint jnienv, nint native__this, nint native_p)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ReplacementSpan? replacementSpan = Java.Lang.Object.GetObject<ReplacementSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextPaint textPaint = Java.Lang.Object.GetObject<TextPaint>(native_p, JniHandleOwnership.DoNotTransfer);
			replacementSpan.UpdateMeasureState(textPaint);
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

	public unsafe override void UpdateMeasureState(TextPaint? p)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateMeasureState.(Landroid/text/TextPaint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p);
		}
	}
}
