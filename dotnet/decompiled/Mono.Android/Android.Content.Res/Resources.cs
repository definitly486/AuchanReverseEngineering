using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Content.Res;

[Register("android/content/res/Resources", DoNotGenerateAcw = true)]
public class Resources : Java.Lang.Object
{
	[Register("android/content/res/Resources$NotFoundException", DoNotGenerateAcw = true)]
	public class NotFoundException : RuntimeException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/res/Resources$NotFoundException", typeof(NotFoundException));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected NotFoundException(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NotFoundException()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe NotFoundException(string? name)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("android/content/res/Resources$Theme", DoNotGenerateAcw = true)]
	public sealed class Theme : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/res/Resources$Theme", typeof(Theme));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Theme(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/res/Resources", typeof(Resources));

	private static Delegate? cb_getConfiguration_GetConfiguration_Landroid_content_res_Configuration_;

	private static Delegate? cb_getDisplayMetrics_GetDisplayMetrics_Landroid_util_DisplayMetrics_;

	private static Delegate? cb_getColor_GetColor_ILandroid_content_res_Resources_Theme__I;

	private static Delegate? cb_getDimension_GetDimension_I_F;

	private static Delegate? cb_getDimensionPixelSize_GetDimensionPixelSize_I_I;

	private static Delegate? cb_getIdentifier_GetIdentifier_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String__I;

	private static Delegate? cb_getResourceEntryName_GetResourceEntryName_I_Ljava_lang_String_;

	private static Delegate? cb_getResourceName_GetResourceName_I_Ljava_lang_String_;

	private static Delegate? cb_updateConfiguration_UpdateConfiguration_Landroid_content_res_Configuration_Landroid_util_DisplayMetrics__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual Configuration? Configuration
	{
		[Register("getConfiguration", "()Landroid/content/res/Configuration;", "GetGetConfigurationHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Configuration>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConfiguration.()Landroid/content/res/Configuration;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual DisplayMetrics? DisplayMetrics
	{
		[Register("getDisplayMetrics", "()Landroid/util/DisplayMetrics;", "GetGetDisplayMetricsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DisplayMetrics>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDisplayMetrics.()Landroid/util/DisplayMetrics;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static Resources? System
	{
		[Register("getSystem", "()Landroid/content/res/Resources;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Resources>(_members.StaticMethods.InvokeObjectMethod("getSystem.()Landroid/content/res/Resources;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Resources(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetConfigurationHandler()
	{
		return new _JniMarshal_PP_L(n_GetConfiguration);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConfiguration(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Configuration);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetDisplayMetricsHandler()
	{
		return new _JniMarshal_PP_L(n_GetDisplayMetrics);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDisplayMetrics(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayMetrics);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetGetColor_ILandroid_content_res_Resources_Theme_Handler()
	{
		return new _JniMarshal_PPIL_I(n_GetColor_ILandroid_content_res_Resources_Theme_);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColor_ILandroid_content_res_Resources_Theme_(nint jnienv, nint native__this, int id, nint native_theme)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Resources? resources = Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Theme theme = Java.Lang.Object.GetObject<Theme>(native_theme, JniHandleOwnership.DoNotTransfer);
			return resources.GetColor(id, theme).ToArgb();
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android23.0")]
	[Register("getColor", "(ILandroid/content/res/Resources$Theme;)I", "GetGetColor_ILandroid_content_res_Resources_Theme_Handler", ApiSince = 23)]
	public unsafe virtual Color GetColor(int id, Theme? theme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(theme?.Handle ?? IntPtr.Zero);
			return new Color(_members.InstanceMethods.InvokeVirtualInt32Method("getColor.(ILandroid/content/res/Resources$Theme;)I", this, ptr));
		}
		finally
		{
			GC.KeepAlive(theme);
		}
	}

	private static Delegate GetGetDimension_IHandler()
	{
		return new _JniMarshal_PPI_F(n_GetDimension_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetDimension_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDimension(id);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getDimension", "(I)F", "GetGetDimension_IHandler")]
	public unsafe virtual float GetDimension(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getDimension.(I)F", this, ptr);
	}

	private static Delegate GetGetDimensionPixelSize_IHandler()
	{
		return new _JniMarshal_PPI_I(n_GetDimensionPixelSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDimensionPixelSize_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDimensionPixelSize(id);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getDimensionPixelSize", "(I)I", "GetGetDimensionPixelSize_IHandler")]
	public unsafe virtual int GetDimensionPixelSize(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getDimensionPixelSize.(I)I", this, ptr);
	}

	private static Delegate GetGetIdentifier_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLL_I(n_GetIdentifier_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIdentifier_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name, nint native_defType, nint native_defPackage)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Resources? resources = Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string defType = JNIEnv.GetString(native_defType, JniHandleOwnership.DoNotTransfer);
			string defPackage = JNIEnv.GetString(native_defPackage, JniHandleOwnership.DoNotTransfer);
			return resources.GetIdentifier(name, defType, defPackage);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getIdentifier", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I", "GetGetIdentifier_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual int GetIdentifier(string? name, string? defType, string? defPackage)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(defType);
		nint num3 = JNIEnv.NewString(defPackage);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIdentifier.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
		}
	}

	private static Delegate GetGetResourceEntryName_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetResourceEntryName_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResourceEntryName_I(nint jnienv, nint native__this, int resid)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetResourceEntryName(resid));
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getResourceEntryName", "(I)Ljava/lang/String;", "GetGetResourceEntryName_IHandler")]
	public unsafe virtual string? GetResourceEntryName(int resid)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resid);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getResourceEntryName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetResourceName_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetResourceName_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResourceName_I(nint jnienv, nint native__this, int resid)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetResourceName(resid));
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getResourceName", "(I)Ljava/lang/String;", "GetGetResourceName_IHandler")]
	public unsafe virtual string? GetResourceName(int resid)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resid);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getResourceName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[ObsoletedOSPlatform("android25.0")]
	private static Delegate GetUpdateConfiguration_Landroid_content_res_Configuration_Landroid_util_DisplayMetrics_Handler()
	{
		return new _JniMarshal_PPLL_V(n_UpdateConfiguration_Landroid_content_res_Configuration_Landroid_util_DisplayMetrics_);
	}

	[ObsoletedOSPlatform("android25.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateConfiguration_Landroid_content_res_Configuration_Landroid_util_DisplayMetrics_(nint jnienv, nint native__this, nint native_config, nint native_metrics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Resources? resources = Java.Lang.Object.GetObject<Resources>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Configuration config = Java.Lang.Object.GetObject<Configuration>(native_config, JniHandleOwnership.DoNotTransfer);
			DisplayMetrics metrics = Java.Lang.Object.GetObject<DisplayMetrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			resources.UpdateConfiguration(config, metrics);
		}
		catch (global::System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[ObsoletedOSPlatform("android25.0")]
	[Register("updateConfiguration", "(Landroid/content/res/Configuration;Landroid/util/DisplayMetrics;)V", "GetUpdateConfiguration_Landroid_content_res_Configuration_Landroid_util_DisplayMetrics_Handler")]
	public unsafe virtual void UpdateConfiguration(Configuration? config, DisplayMetrics? metrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateConfiguration.(Landroid/content/res/Configuration;Landroid/util/DisplayMetrics;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(config);
			GC.KeepAlive(metrics);
		}
	}
}
