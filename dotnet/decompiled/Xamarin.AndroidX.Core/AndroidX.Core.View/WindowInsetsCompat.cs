using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.Graphics;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/WindowInsetsCompat", DoNotGenerateAcw = true)]
public class WindowInsetsCompat : Java.Lang.Object
{
	[Register("androidx/core/view/WindowInsetsCompat$Type", DoNotGenerateAcw = true)]
	public sealed class Type : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsCompat$Type", typeof(Type));

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		internal Type(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("captionBar", "()I", "")]
		public unsafe static int CaptionBar()
		{
			return _members.StaticMethods.InvokeInt32Method("captionBar.()I", null);
		}

		[Register("displayCutout", "()I", "")]
		public unsafe static int DisplayCutout()
		{
			return _members.StaticMethods.InvokeInt32Method("displayCutout.()I", null);
		}

		[Register("ime", "()I", "")]
		public unsafe static int Ime()
		{
			return _members.StaticMethods.InvokeInt32Method("ime.()I", null);
		}

		[Register("mandatorySystemGestures", "()I", "")]
		public unsafe static int MandatorySystemGestures()
		{
			return _members.StaticMethods.InvokeInt32Method("mandatorySystemGestures.()I", null);
		}

		[Register("navigationBars", "()I", "")]
		public unsafe static int NavigationBars()
		{
			return _members.StaticMethods.InvokeInt32Method("navigationBars.()I", null);
		}

		[Register("statusBars", "()I", "")]
		public unsafe static int StatusBars()
		{
			return _members.StaticMethods.InvokeInt32Method("statusBars.()I", null);
		}

		[Register("systemBars", "()I", "")]
		public unsafe static int SystemBars()
		{
			return _members.StaticMethods.InvokeInt32Method("systemBars.()I", null);
		}

		[Register("systemGestures", "()I", "")]
		public unsafe static int SystemGestures()
		{
			return _members.StaticMethods.InvokeInt32Method("systemGestures.()I", null);
		}

		[Register("systemOverlays", "()I", "")]
		public unsafe static int SystemOverlays()
		{
			return _members.StaticMethods.InvokeInt32Method("systemOverlays.()I", null);
		}

		[Register("tappableElement", "()I", "")]
		public unsafe static int TappableElement()
		{
			return _members.StaticMethods.InvokeInt32Method("tappableElement.()I", null);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsCompat", typeof(WindowInsetsCompat));

	private static Delegate? cb_getDisplayCutout_GetDisplayCutout_Landroidx_core_view_DisplayCutoutCompat_;

	private static Delegate? cb_hasInsets_HasInsets_Z;

	private static Delegate? cb_hasStableInsets_HasStableInsets_Z;

	private static Delegate? cb_hasSystemWindowInsets_HasSystemWindowInsets_Z;

	private static Delegate? cb_isConsumed_IsConsumed_Z;

	private static Delegate? cb_isRound_IsRound_Z;

	private static Delegate? cb_getMandatorySystemGestureInsets_GetMandatorySystemGestureInsets_Landroidx_core_graphics_Insets_;

	private static Delegate? cb_getStableInsetBottom_GetStableInsetBottom_I;

	private static Delegate? cb_getStableInsetLeft_GetStableInsetLeft_I;

	private static Delegate? cb_getStableInsetRight_GetStableInsetRight_I;

	private static Delegate? cb_getStableInsetTop_GetStableInsetTop_I;

	private static Delegate? cb_getStableInsets_GetStableInsets_Landroidx_core_graphics_Insets_;

	private static Delegate? cb_getSystemGestureInsets_GetSystemGestureInsets_Landroidx_core_graphics_Insets_;

	private static Delegate? cb_getSystemWindowInsetBottom_GetSystemWindowInsetBottom_I;

	private static Delegate? cb_getSystemWindowInsetLeft_GetSystemWindowInsetLeft_I;

	private static Delegate? cb_getSystemWindowInsetRight_GetSystemWindowInsetRight_I;

	private static Delegate? cb_getSystemWindowInsetTop_GetSystemWindowInsetTop_I;

	private static Delegate? cb_getSystemWindowInsets_GetSystemWindowInsets_Landroidx_core_graphics_Insets_;

	private static Delegate? cb_getTappableElementInsets_GetTappableElementInsets_Landroidx_core_graphics_Insets_;

	private static Delegate? cb_consumeDisplayCutout_ConsumeDisplayCutout_Landroidx_core_view_WindowInsetsCompat_;

	private static Delegate? cb_consumeStableInsets_ConsumeStableInsets_Landroidx_core_view_WindowInsetsCompat_;

	private static Delegate? cb_consumeSystemWindowInsets_ConsumeSystemWindowInsets_Landroidx_core_view_WindowInsetsCompat_;

	private static Delegate? cb_getInsets_GetInsets_I_Landroidx_core_graphics_Insets_;

	private static Delegate? cb_getInsetsIgnoringVisibility_GetInsetsIgnoringVisibility_I_Landroidx_core_graphics_Insets_;

	private static Delegate? cb_inset_Inset_Landroidx_core_graphics_Insets__Landroidx_core_view_WindowInsetsCompat_;

	private static Delegate? cb_inset_Inset_IIII_Landroidx_core_view_WindowInsetsCompat_;

	private static Delegate? cb_isVisible_IsVisible_I_Z;

	private static Delegate? cb_replaceSystemWindowInsets_ReplaceSystemWindowInsets_Landroid_graphics_Rect__Landroidx_core_view_WindowInsetsCompat_;

	private static Delegate? cb_replaceSystemWindowInsets_ReplaceSystemWindowInsets_IIII_Landroidx_core_view_WindowInsetsCompat_;

	private static Delegate? cb_toWindowInsets_ToWindowInsets_Landroid_view_WindowInsets_;

	[Register("CONSUMED")]
	public static WindowInsetsCompat? Consumed => Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.StaticFields.GetObjectValue("CONSUMED.Landroidx/core/view/WindowInsetsCompat;").Handle, JniHandleOwnership.TransferLocalRef);

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual DisplayCutoutCompat? DisplayCutout
	{
		[Register("getDisplayCutout", "()Landroidx/core/view/DisplayCutoutCompat;", "GetGetDisplayCutoutHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DisplayCutoutCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDisplayCutout.()Landroidx/core/view/DisplayCutoutCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool HasInsets
	{
		[Register("hasInsets", "()Z", "GetHasInsetsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasInsets.()Z", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual bool HasStableInsets
	{
		[Register("hasStableInsets", "()Z", "GetHasStableInsetsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasStableInsets.()Z", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual bool HasSystemWindowInsets
	{
		[Register("hasSystemWindowInsets", "()Z", "GetHasSystemWindowInsetsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasSystemWindowInsets.()Z", this, null);
		}
	}

	public unsafe virtual bool IsConsumed
	{
		[Register("isConsumed", "()Z", "GetIsConsumedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConsumed.()Z", this, null);
		}
	}

	public unsafe virtual bool IsRound
	{
		[Register("isRound", "()Z", "GetIsRoundHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRound.()Z", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual AndroidX.Core.Graphics.Insets? MandatorySystemGestureInsets
	{
		[Register("getMandatorySystemGestureInsets", "()Landroidx/core/graphics/Insets;", "GetGetMandatorySystemGestureInsetsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMandatorySystemGestureInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int StableInsetBottom
	{
		[Register("getStableInsetBottom", "()I", "GetGetStableInsetBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStableInsetBottom.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int StableInsetLeft
	{
		[Register("getStableInsetLeft", "()I", "GetGetStableInsetLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStableInsetLeft.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int StableInsetRight
	{
		[Register("getStableInsetRight", "()I", "GetGetStableInsetRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStableInsetRight.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int StableInsetTop
	{
		[Register("getStableInsetTop", "()I", "GetGetStableInsetTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStableInsetTop.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual AndroidX.Core.Graphics.Insets? StableInsets
	{
		[Register("getStableInsets", "()Landroidx/core/graphics/Insets;", "GetGetStableInsetsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStableInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual AndroidX.Core.Graphics.Insets? SystemGestureInsets
	{
		[Register("getSystemGestureInsets", "()Landroidx/core/graphics/Insets;", "GetGetSystemGestureInsetsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSystemGestureInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int SystemWindowInsetBottom
	{
		[Register("getSystemWindowInsetBottom", "()I", "GetGetSystemWindowInsetBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSystemWindowInsetBottom.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int SystemWindowInsetLeft
	{
		[Register("getSystemWindowInsetLeft", "()I", "GetGetSystemWindowInsetLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSystemWindowInsetLeft.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int SystemWindowInsetRight
	{
		[Register("getSystemWindowInsetRight", "()I", "GetGetSystemWindowInsetRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSystemWindowInsetRight.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int SystemWindowInsetTop
	{
		[Register("getSystemWindowInsetTop", "()I", "GetGetSystemWindowInsetTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSystemWindowInsetTop.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual AndroidX.Core.Graphics.Insets? SystemWindowInsets
	{
		[Register("getSystemWindowInsets", "()Landroidx/core/graphics/Insets;", "GetGetSystemWindowInsetsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSystemWindowInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual AndroidX.Core.Graphics.Insets? TappableElementInsets
	{
		[Register("getTappableElementInsets", "()Landroidx/core/graphics/Insets;", "GetGetTappableElementInsetsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTappableElementInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected WindowInsetsCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/core/view/WindowInsetsCompat;)V", "")]
	public unsafe WindowInsetsCompat(WindowInsetsCompat? src)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/core/view/WindowInsetsCompat;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/core/view/WindowInsetsCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(src);
		}
	}

	private static Delegate GetGetDisplayCutoutHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDisplayCutout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDisplayCutout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayCutout);
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

	private static Delegate GetHasInsetsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasInsets);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasInsets ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete]
	private static Delegate GetHasStableInsetsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasStableInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasStableInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasStableInsets ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete]
	private static Delegate GetHasSystemWindowInsetsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasSystemWindowInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasSystemWindowInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasSystemWindowInsets ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsConsumedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsConsumed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsConsumed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConsumed ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsRoundHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRound);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRound(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRound ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete]
	private static Delegate GetGetMandatorySystemGestureInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMandatorySystemGestureInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMandatorySystemGestureInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MandatorySystemGestureInsets);
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

	[Obsolete]
	private static Delegate GetGetStableInsetBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStableInsetBottom);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStableInsetBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StableInsetBottom;
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

	[Obsolete]
	private static Delegate GetGetStableInsetLeftHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStableInsetLeft);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStableInsetLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StableInsetLeft;
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

	[Obsolete]
	private static Delegate GetGetStableInsetRightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStableInsetRight);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStableInsetRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StableInsetRight;
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

	[Obsolete]
	private static Delegate GetGetStableInsetTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStableInsetTop);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStableInsetTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StableInsetTop;
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

	[Obsolete]
	private static Delegate GetGetStableInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStableInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStableInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StableInsets);
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

	[Obsolete]
	private static Delegate GetGetSystemGestureInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSystemGestureInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSystemGestureInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemGestureInsets);
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

	[Obsolete]
	private static Delegate GetGetSystemWindowInsetBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSystemWindowInsetBottom);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSystemWindowInsetBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemWindowInsetBottom;
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

	[Obsolete]
	private static Delegate GetGetSystemWindowInsetLeftHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSystemWindowInsetLeft);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSystemWindowInsetLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemWindowInsetLeft;
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

	[Obsolete]
	private static Delegate GetGetSystemWindowInsetRightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSystemWindowInsetRight);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSystemWindowInsetRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemWindowInsetRight;
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

	[Obsolete]
	private static Delegate GetGetSystemWindowInsetTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSystemWindowInsetTop);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSystemWindowInsetTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemWindowInsetTop;
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

	[Obsolete]
	private static Delegate GetGetSystemWindowInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSystemWindowInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSystemWindowInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemWindowInsets);
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

	[Obsolete]
	private static Delegate GetGetTappableElementInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTappableElementInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTappableElementInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TappableElementInsets);
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

	[Obsolete]
	private static Delegate GetConsumeDisplayCutoutHandler()
	{
		return new global::_JniMarshal_PP_L(n_ConsumeDisplayCutout);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ConsumeDisplayCutout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConsumeDisplayCutout());
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

	[Obsolete("deprecated")]
	[Register("consumeDisplayCutout", "()Landroidx/core/view/WindowInsetsCompat;", "GetConsumeDisplayCutoutHandler")]
	public unsafe virtual WindowInsetsCompat? ConsumeDisplayCutout()
	{
		return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("consumeDisplayCutout.()Landroidx/core/view/WindowInsetsCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetConsumeStableInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_ConsumeStableInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ConsumeStableInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConsumeStableInsets());
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

	[Obsolete("deprecated")]
	[Register("consumeStableInsets", "()Landroidx/core/view/WindowInsetsCompat;", "GetConsumeStableInsetsHandler")]
	public unsafe virtual WindowInsetsCompat? ConsumeStableInsets()
	{
		return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("consumeStableInsets.()Landroidx/core/view/WindowInsetsCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetConsumeSystemWindowInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_ConsumeSystemWindowInsets);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ConsumeSystemWindowInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConsumeSystemWindowInsets());
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

	[Obsolete("deprecated")]
	[Register("consumeSystemWindowInsets", "()Landroidx/core/view/WindowInsetsCompat;", "GetConsumeSystemWindowInsetsHandler")]
	public unsafe virtual WindowInsetsCompat? ConsumeSystemWindowInsets()
	{
		return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("consumeSystemWindowInsets.()Landroidx/core/view/WindowInsetsCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetInsets_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetInsets_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInsets_I(nint jnienv, nint native__this, int typeMask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInsets(typeMask));
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

	[Register("getInsets", "(I)Landroidx/core/graphics/Insets;", "GetGetInsets_IHandler")]
	public unsafe virtual AndroidX.Core.Graphics.Insets? GetInsets(int typeMask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(typeMask);
		return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInsets.(I)Landroidx/core/graphics/Insets;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetInsetsIgnoringVisibility_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetInsetsIgnoringVisibility_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInsetsIgnoringVisibility_I(nint jnienv, nint native__this, int typeMask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInsetsIgnoringVisibility(typeMask));
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

	[Register("getInsetsIgnoringVisibility", "(I)Landroidx/core/graphics/Insets;", "GetGetInsetsIgnoringVisibility_IHandler")]
	public unsafe virtual AndroidX.Core.Graphics.Insets? GetInsetsIgnoringVisibility(int typeMask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(typeMask);
		return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInsetsIgnoringVisibility.(I)Landroidx/core/graphics/Insets;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetInset_Landroidx_core_graphics_Insets_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Inset_Landroidx_core_graphics_Insets_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Inset_Landroidx_core_graphics_Insets_(nint jnienv, nint native__this, nint native_insets)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WindowInsetsCompat? windowInsetsCompat = Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.Core.Graphics.Insets insets = Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(native_insets, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(windowInsetsCompat.Inset(insets));
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

	[Register("inset", "(Landroidx/core/graphics/Insets;)Landroidx/core/view/WindowInsetsCompat;", "GetInset_Landroidx_core_graphics_Insets_Handler")]
	public unsafe virtual WindowInsetsCompat? Inset(AndroidX.Core.Graphics.Insets? insets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("inset.(Landroidx/core/graphics/Insets;)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(insets);
		}
	}

	private static Delegate GetInset_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_L(n_Inset_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Inset_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Inset(left, top, right, bottom));
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

	[Register("inset", "(IIII)Landroidx/core/view/WindowInsetsCompat;", "GetInset_IIIIHandler")]
	public unsafe virtual WindowInsetsCompat? Inset(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("inset.(IIII)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIsVisible_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_IsVisible_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsVisible_I(nint jnienv, nint native__this, int typeMask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVisible(typeMask) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isVisible", "(I)Z", "GetIsVisible_IHandler")]
	public unsafe virtual bool IsVisible(int typeMask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(typeMask);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isVisible.(I)Z", this, ptr);
	}

	[Obsolete]
	private static Delegate GetReplaceSystemWindowInsets_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_ReplaceSystemWindowInsets_Landroid_graphics_Rect_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ReplaceSystemWindowInsets_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_systemWindowInsets)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WindowInsetsCompat? windowInsetsCompat = Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect systemWindowInsets = Java.Lang.Object.GetObject<Rect>(native_systemWindowInsets, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(windowInsetsCompat.ReplaceSystemWindowInsets(systemWindowInsets));
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

	[Obsolete("deprecated")]
	[Register("replaceSystemWindowInsets", "(Landroid/graphics/Rect;)Landroidx/core/view/WindowInsetsCompat;", "GetReplaceSystemWindowInsets_Landroid_graphics_Rect_Handler")]
	public unsafe virtual WindowInsetsCompat? ReplaceSystemWindowInsets(Rect? systemWindowInsets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(systemWindowInsets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("replaceSystemWindowInsets.(Landroid/graphics/Rect;)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(systemWindowInsets);
		}
	}

	[Obsolete]
	private static Delegate GetReplaceSystemWindowInsets_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_L(n_ReplaceSystemWindowInsets_IIII);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ReplaceSystemWindowInsets_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReplaceSystemWindowInsets(left, top, right, bottom));
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

	[Obsolete("deprecated")]
	[Register("replaceSystemWindowInsets", "(IIII)Landroidx/core/view/WindowInsetsCompat;", "GetReplaceSystemWindowInsets_IIIIHandler")]
	public unsafe virtual WindowInsetsCompat? ReplaceSystemWindowInsets(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("replaceSystemWindowInsets.(IIII)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetToWindowInsetsHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToWindowInsets);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToWindowInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WindowInsetsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToWindowInsets());
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

	[Register("toWindowInsets", "()Landroid/view/WindowInsets;", "GetToWindowInsetsHandler")]
	public unsafe virtual WindowInsets? ToWindowInsets()
	{
		return Java.Lang.Object.GetObject<WindowInsets>(_members.InstanceMethods.InvokeVirtualObjectMethod("toWindowInsets.()Landroid/view/WindowInsets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toWindowInsetsCompat", "(Landroid/view/WindowInsets;)Landroidx/core/view/WindowInsetsCompat;", "")]
	public unsafe static WindowInsetsCompat? ToWindowInsetsCompat(WindowInsets? insets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.StaticMethods.InvokeObjectMethod("toWindowInsetsCompat.(Landroid/view/WindowInsets;)Landroidx/core/view/WindowInsetsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(insets);
		}
	}

	[Register("toWindowInsetsCompat", "(Landroid/view/WindowInsets;Landroid/view/View;)Landroidx/core/view/WindowInsetsCompat;", "")]
	public unsafe static WindowInsetsCompat? ToWindowInsetsCompat(WindowInsets? insets, Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.StaticMethods.InvokeObjectMethod("toWindowInsetsCompat.(Landroid/view/WindowInsets;Landroid/view/View;)Landroidx/core/view/WindowInsetsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(insets);
			GC.KeepAlive(view);
		}
	}
}
