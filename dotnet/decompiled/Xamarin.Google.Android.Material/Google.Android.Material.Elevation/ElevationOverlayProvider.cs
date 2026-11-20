using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Elevation;

[Register("com/google/android/material/elevation/ElevationOverlayProvider", DoNotGenerateAcw = true)]
public class ElevationOverlayProvider : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/elevation/ElevationOverlayProvider", typeof(ElevationOverlayProvider));

	private static Delegate? cb_isThemeElevationOverlayEnabled_IsThemeElevationOverlayEnabled_Z;

	private static Delegate? cb_getThemeElevationOverlayColor_GetThemeElevationOverlayColor_I;

	private static Delegate? cb_getThemeSurfaceColor_GetThemeSurfaceColor_I;

	private static Delegate? cb_calculateOverlayAlpha_CalculateOverlayAlpha_F_I;

	private static Delegate? cb_calculateOverlayAlphaFraction_CalculateOverlayAlphaFraction_F_F;

	private static Delegate? cb_compositeOverlay_CompositeOverlay_IF_I;

	private static Delegate? cb_compositeOverlay_CompositeOverlay_IFLandroid_view_View__I;

	private static Delegate? cb_compositeOverlayIfNeeded_CompositeOverlayIfNeeded_IF_I;

	private static Delegate? cb_compositeOverlayIfNeeded_CompositeOverlayIfNeeded_IFLandroid_view_View__I;

	private static Delegate? cb_compositeOverlayWithThemeSurfaceColorIfNeeded_CompositeOverlayWithThemeSurfaceColorIfNeeded_F_I;

	private static Delegate? cb_compositeOverlayWithThemeSurfaceColorIfNeeded_CompositeOverlayWithThemeSurfaceColorIfNeeded_FLandroid_view_View__I;

	private static Delegate? cb_getParentAbsoluteElevation_GetParentAbsoluteElevation_Landroid_view_View__F;

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

	public unsafe virtual bool IsThemeElevationOverlayEnabled
	{
		[Register("isThemeElevationOverlayEnabled", "()Z", "GetIsThemeElevationOverlayEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isThemeElevationOverlayEnabled.()Z", this, null);
		}
	}

	public unsafe virtual int ThemeElevationOverlayColor
	{
		[Register("getThemeElevationOverlayColor", "()I", "GetGetThemeElevationOverlayColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getThemeElevationOverlayColor.()I", this, null);
		}
	}

	public unsafe virtual int ThemeSurfaceColor
	{
		[Register("getThemeSurfaceColor", "()I", "GetGetThemeSurfaceColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getThemeSurfaceColor.()I", this, null);
		}
	}

	protected ElevationOverlayProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ElevationOverlayProvider(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(ZIIIF)V", "")]
	public unsafe ElevationOverlayProvider(bool elevationOverlayEnabled, int elevationOverlayColor, int elevationOverlayAccentColor, int colorSurface, float displayDensity)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(elevationOverlayEnabled ? ((sbyte)1) : ((sbyte)0));
			ptr[1] = new JniArgumentValue(elevationOverlayColor);
			ptr[2] = new JniArgumentValue(elevationOverlayAccentColor);
			ptr[3] = new JniArgumentValue(colorSurface);
			ptr[4] = new JniArgumentValue(displayDensity);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ZIIIF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ZIIIF)V", this, ptr);
		}
	}

	private static Delegate GetIsThemeElevationOverlayEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsThemeElevationOverlayEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsThemeElevationOverlayEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsThemeElevationOverlayEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetThemeElevationOverlayColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetThemeElevationOverlayColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetThemeElevationOverlayColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThemeElevationOverlayColor;
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

	private static Delegate GetGetThemeSurfaceColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetThemeSurfaceColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetThemeSurfaceColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThemeSurfaceColor;
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

	private static Delegate GetCalculateOverlayAlpha_FHandler()
	{
		return new _JniMarshal_PPF_I(n_CalculateOverlayAlpha_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CalculateOverlayAlpha_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalculateOverlayAlpha(elevation);
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

	[Register("calculateOverlayAlpha", "(F)I", "GetCalculateOverlayAlpha_FHandler")]
	public unsafe virtual int CalculateOverlayAlpha(float elevation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(elevation);
		return _members.InstanceMethods.InvokeVirtualInt32Method("calculateOverlayAlpha.(F)I", this, ptr);
	}

	private static Delegate GetCalculateOverlayAlphaFraction_FHandler()
	{
		return new global::_JniMarshal_PPF_F(n_CalculateOverlayAlphaFraction_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_CalculateOverlayAlphaFraction_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CalculateOverlayAlphaFraction(elevation);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("calculateOverlayAlphaFraction", "(F)F", "GetCalculateOverlayAlphaFraction_FHandler")]
	public unsafe virtual float CalculateOverlayAlphaFraction(float elevation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(elevation);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("calculateOverlayAlphaFraction.(F)F", this, ptr);
	}

	private static Delegate GetCompositeOverlay_IFHandler()
	{
		return new global::_JniMarshal_PPIF_I(n_CompositeOverlay_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompositeOverlay_IF(nint jnienv, nint native__this, int backgroundColor, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompositeOverlay(backgroundColor, elevation);
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

	[Register("compositeOverlay", "(IF)I", "GetCompositeOverlay_IFHandler")]
	public unsafe virtual int CompositeOverlay(int backgroundColor, float elevation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(backgroundColor);
		ptr[1] = new JniArgumentValue(elevation);
		return _members.InstanceMethods.InvokeVirtualInt32Method("compositeOverlay.(IF)I", this, ptr);
	}

	private static Delegate GetCompositeOverlay_IFLandroid_view_View_Handler()
	{
		return new _JniMarshal_PPIFL_I(n_CompositeOverlay_IFLandroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompositeOverlay_IFLandroid_view_View_(nint jnienv, nint native__this, int backgroundColor, float elevation, nint native_overlayView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ElevationOverlayProvider? elevationOverlayProvider = Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View overlayView = Java.Lang.Object.GetObject<View>(native_overlayView, JniHandleOwnership.DoNotTransfer);
			return elevationOverlayProvider.CompositeOverlay(backgroundColor, elevation, overlayView);
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

	[Register("compositeOverlay", "(IFLandroid/view/View;)I", "GetCompositeOverlay_IFLandroid_view_View_Handler")]
	public unsafe virtual int CompositeOverlay(int backgroundColor, float elevation, View overlayView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(backgroundColor);
			ptr[1] = new JniArgumentValue(elevation);
			ptr[2] = new JniArgumentValue(overlayView?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("compositeOverlay.(IFLandroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(overlayView);
		}
	}

	private static Delegate GetCompositeOverlayIfNeeded_IFHandler()
	{
		return new global::_JniMarshal_PPIF_I(n_CompositeOverlayIfNeeded_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompositeOverlayIfNeeded_IF(nint jnienv, nint native__this, int backgroundColor, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompositeOverlayIfNeeded(backgroundColor, elevation);
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

	[Register("compositeOverlayIfNeeded", "(IF)I", "GetCompositeOverlayIfNeeded_IFHandler")]
	public unsafe virtual int CompositeOverlayIfNeeded(int backgroundColor, float elevation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(backgroundColor);
		ptr[1] = new JniArgumentValue(elevation);
		return _members.InstanceMethods.InvokeVirtualInt32Method("compositeOverlayIfNeeded.(IF)I", this, ptr);
	}

	private static Delegate GetCompositeOverlayIfNeeded_IFLandroid_view_View_Handler()
	{
		return new _JniMarshal_PPIFL_I(n_CompositeOverlayIfNeeded_IFLandroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompositeOverlayIfNeeded_IFLandroid_view_View_(nint jnienv, nint native__this, int backgroundColor, float elevation, nint native_overlayView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ElevationOverlayProvider? elevationOverlayProvider = Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View overlayView = Java.Lang.Object.GetObject<View>(native_overlayView, JniHandleOwnership.DoNotTransfer);
			return elevationOverlayProvider.CompositeOverlayIfNeeded(backgroundColor, elevation, overlayView);
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

	[Register("compositeOverlayIfNeeded", "(IFLandroid/view/View;)I", "GetCompositeOverlayIfNeeded_IFLandroid_view_View_Handler")]
	public unsafe virtual int CompositeOverlayIfNeeded(int backgroundColor, float elevation, View overlayView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(backgroundColor);
			ptr[1] = new JniArgumentValue(elevation);
			ptr[2] = new JniArgumentValue(overlayView?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("compositeOverlayIfNeeded.(IFLandroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(overlayView);
		}
	}

	private static Delegate GetCompositeOverlayWithThemeSurfaceColorIfNeeded_FHandler()
	{
		return new _JniMarshal_PPF_I(n_CompositeOverlayWithThemeSurfaceColorIfNeeded_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompositeOverlayWithThemeSurfaceColorIfNeeded_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompositeOverlayWithThemeSurfaceColorIfNeeded(elevation);
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

	[Register("compositeOverlayWithThemeSurfaceColorIfNeeded", "(F)I", "GetCompositeOverlayWithThemeSurfaceColorIfNeeded_FHandler")]
	public unsafe virtual int CompositeOverlayWithThemeSurfaceColorIfNeeded(float elevation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(elevation);
		return _members.InstanceMethods.InvokeVirtualInt32Method("compositeOverlayWithThemeSurfaceColorIfNeeded.(F)I", this, ptr);
	}

	private static Delegate GetCompositeOverlayWithThemeSurfaceColorIfNeeded_FLandroid_view_View_Handler()
	{
		return new _JniMarshal_PPFL_I(n_CompositeOverlayWithThemeSurfaceColorIfNeeded_FLandroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompositeOverlayWithThemeSurfaceColorIfNeeded_FLandroid_view_View_(nint jnienv, nint native__this, float elevation, nint native_overlayView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ElevationOverlayProvider? elevationOverlayProvider = Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View overlayView = Java.Lang.Object.GetObject<View>(native_overlayView, JniHandleOwnership.DoNotTransfer);
			return elevationOverlayProvider.CompositeOverlayWithThemeSurfaceColorIfNeeded(elevation, overlayView);
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

	[Register("compositeOverlayWithThemeSurfaceColorIfNeeded", "(FLandroid/view/View;)I", "GetCompositeOverlayWithThemeSurfaceColorIfNeeded_FLandroid_view_View_Handler")]
	public unsafe virtual int CompositeOverlayWithThemeSurfaceColorIfNeeded(float elevation, View overlayView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(elevation);
			ptr[1] = new JniArgumentValue(overlayView?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("compositeOverlayWithThemeSurfaceColorIfNeeded.(FLandroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(overlayView);
		}
	}

	private static Delegate GetGetParentAbsoluteElevation_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_F(n_GetParentAbsoluteElevation_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetParentAbsoluteElevation_Landroid_view_View_(nint jnienv, nint native__this, nint native_overlayView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			ElevationOverlayProvider? elevationOverlayProvider = Java.Lang.Object.GetObject<ElevationOverlayProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View overlayView = Java.Lang.Object.GetObject<View>(native_overlayView, JniHandleOwnership.DoNotTransfer);
			return elevationOverlayProvider.GetParentAbsoluteElevation(overlayView);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getParentAbsoluteElevation", "(Landroid/view/View;)F", "GetGetParentAbsoluteElevation_Landroid_view_View_Handler")]
	public unsafe virtual float GetParentAbsoluteElevation(View overlayView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(overlayView?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getParentAbsoluteElevation.(Landroid/view/View;)F", this, ptr);
		}
		finally
		{
			GC.KeepAlive(overlayView);
		}
	}
}
