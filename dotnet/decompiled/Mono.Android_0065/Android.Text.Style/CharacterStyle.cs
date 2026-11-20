using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Style;

[Register("android/text/style/CharacterStyle", DoNotGenerateAcw = true)]
public abstract class CharacterStyle : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/CharacterStyle", typeof(CharacterStyle));

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

	protected CharacterStyle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDrawState_Landroid_text_TextPaint_(nint jnienv, nint native__this, nint native_tp)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CharacterStyle? characterStyle = Java.Lang.Object.GetObject<CharacterStyle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextPaint tp = Java.Lang.Object.GetObject<TextPaint>(native_tp, JniHandleOwnership.DoNotTransfer);
			characterStyle.UpdateDrawState(tp);
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

	public abstract void UpdateDrawState(TextPaint? tp);

	[UnmanagedCallersOnly]
	private static void n_UpdateDrawState_Landroid_text_TextPaint__mm_wrapper(nint jnienv, nint native__this, nint native_tp)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_UpdateDrawState_Landroid_text_TextPaint_(jnienv, native__this, native_tp);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
