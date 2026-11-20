using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content.PM;

[Register("android/content/pm/PackageManager", DoNotGenerateAcw = true)]
public abstract class PackageManager : Java.Lang.Object
{
	[SupportedOSPlatform("android33.0")]
	[Register("android/content/pm/PackageManager$ComponentEnabledSetting", DoNotGenerateAcw = true, ApiSince = 33)]
	public sealed class ComponentEnabledSetting : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/PackageManager$ComponentEnabledSetting", typeof(ComponentEnabledSetting));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ComponentEnabledSetting(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[SupportedOSPlatform("android33.0")]
		[Register(".ctor", "(Landroid/content/ComponentName;II)V", "", ApiSince = 33)]
		public unsafe ComponentEnabledSetting(ComponentName componentName, int newState, int flags)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newState);
				ptr[2] = new JniArgumentValue(flags);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/ComponentName;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/ComponentName;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(componentName);
			}
		}

		[SupportedOSPlatform("android33.0")]
		[Register("describeContents", "()I", "", ApiSince = 33)]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[SupportedOSPlatform("android33.0")]
		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "", ApiSince = 33)]
		public unsafe void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/PackageManager", typeof(PackageManager));

	private static Delegate? cb_getApplicationInfo_GetApplicationInfo_Ljava_lang_String_I_Landroid_content_pm_ApplicationInfo_;

	private static Delegate? cb_getInstallerPackageName_GetInstallerPackageName_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getInstallSourceInfo_GetInstallSourceInfo_Ljava_lang_String__Landroid_content_pm_InstallSourceInfo_;

	private static Delegate? cb_getLaunchIntentForPackage_GetLaunchIntentForPackage_Ljava_lang_String__Landroid_content_Intent_;

	private static Delegate? cb_getPackageInfo_GetPackageInfo_Ljava_lang_String_I_Landroid_content_pm_PackageInfo_;

	private static Delegate? cb_queryIntentActivities_QueryIntentActivities_Landroid_content_Intent_I_Ljava_util_List_;

	private static Delegate? cb_setComponentEnabledSetting_SetComponentEnabledSetting_Landroid_content_ComponentName_II_V;

	private static Delegate? cb_setComponentEnabledSettings_SetComponentEnabledSettings_Ljava_util_List__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PackageManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetApplicationInfo_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_GetApplicationInfo_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetApplicationInfo_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_packageName, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string packageName = JNIEnv.GetString(native_packageName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(packageManager.GetApplicationInfo(packageName, (PackageInfoFlags)native_flags));
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

	[Register("getApplicationInfo", "(Ljava/lang/String;I)Landroid/content/pm/ApplicationInfo;", "GetGetApplicationInfo_Ljava_lang_String_IHandler")]
	public abstract ApplicationInfo GetApplicationInfo(string packageName, PackageInfoFlags flags);

	[ObsoletedOSPlatform("android30.0")]
	private static Delegate GetGetInstallerPackageName_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetInstallerPackageName_Ljava_lang_String_);
	}

	[ObsoletedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInstallerPackageName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_packageName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string packageName = JNIEnv.GetString(native_packageName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(packageManager.GetInstallerPackageName(packageName));
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

	[ObsoletedOSPlatform("android30.0")]
	[Register("getInstallerPackageName", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetInstallerPackageName_Ljava_lang_String_Handler")]
	public abstract string? GetInstallerPackageName(string packageName);

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetInstallSourceInfo_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetInstallSourceInfo_Ljava_lang_String_);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInstallSourceInfo_Ljava_lang_String_(nint jnienv, nint native__this, nint native_packageName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string packageName = JNIEnv.GetString(native_packageName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(packageManager.GetInstallSourceInfo(packageName));
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

	[SupportedOSPlatform("android30.0")]
	[Register("getInstallSourceInfo", "(Ljava/lang/String;)Landroid/content/pm/InstallSourceInfo;", "GetGetInstallSourceInfo_Ljava_lang_String_Handler", ApiSince = 30)]
	public unsafe virtual InstallSourceInfo GetInstallSourceInfo(string packageName)
	{
		nint num = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<InstallSourceInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInstallSourceInfo.(Ljava/lang/String;)Landroid/content/pm/InstallSourceInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetLaunchIntentForPackage_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetLaunchIntentForPackage_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLaunchIntentForPackage_Ljava_lang_String_(nint jnienv, nint native__this, nint native_packageName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string packageName = JNIEnv.GetString(native_packageName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(packageManager.GetLaunchIntentForPackage(packageName));
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

	[Register("getLaunchIntentForPackage", "(Ljava/lang/String;)Landroid/content/Intent;", "GetGetLaunchIntentForPackage_Ljava_lang_String_Handler")]
	public abstract Intent? GetLaunchIntentForPackage(string packageName);

	private static Delegate GetGetPackageInfo_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_GetPackageInfo_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPackageInfo_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_packageName, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string packageName = JNIEnv.GetString(native_packageName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(packageManager.GetPackageInfo(packageName, (PackageInfoFlags)native_flags));
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

	[Register("getPackageInfo", "(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;", "GetGetPackageInfo_Ljava_lang_String_IHandler")]
	public abstract PackageInfo? GetPackageInfo(string packageName, PackageInfoFlags flags);

	private static Delegate GetQueryIntentActivities_Landroid_content_Intent_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_QueryIntentActivities_Landroid_content_Intent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_QueryIntentActivities_Landroid_content_Intent_I(nint jnienv, nint native__this, nint native_intent, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JavaList<ResolveInfo>.ToLocalJniHandle(packageManager.QueryIntentActivities(intent, (PackageInfoFlags)native_flags));
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

	[Register("queryIntentActivities", "(Landroid/content/Intent;I)Ljava/util/List;", "GetQueryIntentActivities_Landroid_content_Intent_IHandler")]
	public abstract IList<ResolveInfo> QueryIntentActivities(Intent intent, PackageInfoFlags flags);

	private static Delegate GetSetComponentEnabledSetting_Landroid_content_ComponentName_IIHandler()
	{
		return new _JniMarshal_PPLII_V(n_SetComponentEnabledSetting_Landroid_content_ComponentName_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetComponentEnabledSetting_Landroid_content_ComponentName_II(nint jnienv, nint native__this, nint native_componentName, int native_newState, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			packageManager.SetComponentEnabledSetting(componentName, (ComponentEnabledState)native_newState, (ComponentEnableOption)native_flags);
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

	[Register("setComponentEnabledSetting", "(Landroid/content/ComponentName;II)V", "GetSetComponentEnabledSetting_Landroid_content_ComponentName_IIHandler")]
	[RequiresPermission("android.permission.CHANGE_COMPONENT_ENABLED_STATE")]
	public abstract void SetComponentEnabledSetting(ComponentName componentName, ComponentEnabledState newState, ComponentEnableOption flags);

	[SupportedOSPlatform("android33.0")]
	private static Delegate GetSetComponentEnabledSettings_Ljava_util_List_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetComponentEnabledSettings_Ljava_util_List_);
	}

	[SupportedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetComponentEnabledSettings_Ljava_util_List_(nint jnienv, nint native__this, nint native_settings)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PackageManager? packageManager = Java.Lang.Object.GetObject<PackageManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<ComponentEnabledSetting> componentEnabledSettings = JavaList<ComponentEnabledSetting>.FromJniHandle(native_settings, JniHandleOwnership.DoNotTransfer);
			packageManager.SetComponentEnabledSettings(componentEnabledSettings);
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

	[SupportedOSPlatform("android33.0")]
	[Register("setComponentEnabledSettings", "(Ljava/util/List;)V", "GetSetComponentEnabledSettings_Ljava_util_List_Handler", ApiSince = 33)]
	[RequiresPermission("android.permission.CHANGE_COMPONENT_ENABLED_STATE")]
	public unsafe virtual void SetComponentEnabledSettings(IList<ComponentEnabledSetting> settings)
	{
		nint num = JavaList<ComponentEnabledSetting>.ToLocalJniHandle(settings);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setComponentEnabledSettings.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(settings);
		}
	}
}
