using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/ContextWrapper", DoNotGenerateAcw = true)]
public class ContextWrapper : Context
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ContextWrapper", typeof(ContextWrapper));

	private static Delegate? cb_getApplicationContext_GetApplicationContext_Landroid_content_Context_;

	private static Delegate? cb_getApplicationInfo_GetApplicationInfo_Landroid_content_pm_ApplicationInfo_;

	private static Delegate? cb_getAssets_GetAssets_Landroid_content_res_AssetManager_;

	private static Delegate? cb_getCacheDir_GetCacheDir_Ljava_io_File_;

	private static Delegate? cb_getClassLoader_GetClassLoader_Ljava_lang_ClassLoader_;

	private static Delegate? cb_getContentResolver_GetContentResolver_Landroid_content_ContentResolver_;

	private static Delegate? cb_getExternalCacheDir_GetExternalCacheDir_Ljava_io_File_;

	private static Delegate? cb_getFilesDir_GetFilesDir_Ljava_io_File_;

	private static Delegate? cb_getMainLooper_GetMainLooper_Landroid_os_Looper_;

	private static Delegate? cb_getPackageManager_GetPackageManager_Landroid_content_pm_PackageManager_;

	private static Delegate? cb_getPackageName_GetPackageName_Ljava_lang_String_;

	private static Delegate? cb_getResources_GetResources_Landroid_content_res_Resources_;

	private static Delegate? cb_getTheme_GetTheme_Landroid_content_res_Resources_Theme_;

	private static Delegate? cb_deleteSharedPreferences_DeleteSharedPreferences_Ljava_lang_String__Z;

	private static Delegate? cb_getExternalFilesDir_GetExternalFilesDir_Ljava_lang_String__Ljava_io_File_;

	private static Delegate? cb_getSharedPreferences_GetSharedPreferences_Ljava_lang_String_I_Landroid_content_SharedPreferences_;

	private static Delegate? cb_getSystemService_GetSystemService_Ljava_lang_String__Ljava_lang_Object_;

	private static Delegate? cb_registerReceiver_RegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_I_Landroid_content_Intent_;

	private static Delegate? cb_registerReceiver_RegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter__Landroid_content_Intent_;

	private static Delegate? cb_sendBroadcast_SendBroadcast_Landroid_content_Intent__V;

	private static Delegate? cb_startActivity_StartActivity_Landroid_content_Intent__V;

	private static Delegate? cb_unregisterReceiver_UnregisterReceiver_Landroid_content_BroadcastReceiver__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override Context? ApplicationContext => Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplicationContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override ApplicationInfo? ApplicationInfo => Java.Lang.Object.GetObject<ApplicationInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplicationInfo.()Landroid/content/pm/ApplicationInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override AssetManager? Assets => Java.Lang.Object.GetObject<AssetManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAssets.()Landroid/content/res/AssetManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override File? CacheDir => Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCacheDir.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override ClassLoader? ClassLoader => Java.Lang.Object.GetObject<ClassLoader>(_members.InstanceMethods.InvokeVirtualObjectMethod("getClassLoader.()Ljava/lang/ClassLoader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override ContentResolver? ContentResolver => Java.Lang.Object.GetObject<ContentResolver>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentResolver.()Landroid/content/ContentResolver;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override File? ExternalCacheDir => Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExternalCacheDir.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override File? FilesDir => Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFilesDir.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override Looper? MainLooper => Java.Lang.Object.GetObject<Looper>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMainLooper.()Landroid/os/Looper;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override PackageManager? PackageManager => Java.Lang.Object.GetObject<PackageManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPackageManager.()Landroid/content/pm/PackageManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override string? PackageName => JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPackageName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override Resources? Resources => Java.Lang.Object.GetObject<Resources>(_members.InstanceMethods.InvokeVirtualObjectMethod("getResources.()Landroid/content/res/Resources;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override Resources.Theme? Theme => Java.Lang.Object.GetObject<Resources.Theme>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTheme.()Landroid/content/res/Resources$Theme;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	protected ContextWrapper(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetApplicationContextHandler()
	{
		return new _JniMarshal_PP_L(n_GetApplicationContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetApplicationContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplicationContext);
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

	private static Delegate GetGetApplicationInfoHandler()
	{
		return new _JniMarshal_PP_L(n_GetApplicationInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetApplicationInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplicationInfo);
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

	private static Delegate GetGetAssetsHandler()
	{
		return new _JniMarshal_PP_L(n_GetAssets);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAssets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Assets);
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

	private static Delegate GetGetCacheDirHandler()
	{
		return new _JniMarshal_PP_L(n_GetCacheDir);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCacheDir(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CacheDir);
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

	private static Delegate GetGetClassLoaderHandler()
	{
		return new _JniMarshal_PP_L(n_GetClassLoader);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetClassLoader(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClassLoader);
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

	private static Delegate GetGetContentResolverHandler()
	{
		return new _JniMarshal_PP_L(n_GetContentResolver);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentResolver(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentResolver);
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

	private static Delegate GetGetExternalCacheDirHandler()
	{
		return new _JniMarshal_PP_L(n_GetExternalCacheDir);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExternalCacheDir(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExternalCacheDir);
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

	private static Delegate GetGetFilesDirHandler()
	{
		return new _JniMarshal_PP_L(n_GetFilesDir);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFilesDir(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FilesDir);
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

	private static Delegate GetGetMainLooperHandler()
	{
		return new _JniMarshal_PP_L(n_GetMainLooper);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMainLooper(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MainLooper);
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

	private static Delegate GetGetPackageManagerHandler()
	{
		return new _JniMarshal_PP_L(n_GetPackageManager);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPackageManager(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PackageManager);
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

	private static Delegate GetGetPackageNameHandler()
	{
		return new _JniMarshal_PP_L(n_GetPackageName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPackageName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PackageName);
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

	private static Delegate GetGetResourcesHandler()
	{
		return new _JniMarshal_PP_L(n_GetResources);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResources(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resources);
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

	private static Delegate GetGetThemeHandler()
	{
		return new _JniMarshal_PP_L(n_GetTheme);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTheme(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Theme);
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

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetDeleteSharedPreferences_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_B(n_DeleteSharedPreferences_Ljava_lang_String_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DeleteSharedPreferences_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return contextWrapper.DeleteSharedPreferences(name) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android24.0")]
	public unsafe override bool DeleteSharedPreferences(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("deleteSharedPreferences.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetExternalFilesDir_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetExternalFilesDir_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExternalFilesDir_Ljava_lang_String_(nint jnienv, nint native__this, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(contextWrapper.GetExternalFilesDir(type));
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

	public unsafe override File? GetExternalFilesDir(string? type)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExternalFilesDir.(Ljava/lang/String;)Ljava/io/File;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetSharedPreferences_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_GetSharedPreferences_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSharedPreferences_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_name, int native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(contextWrapper.GetSharedPreferences(name, (FileCreationMode)native_mode));
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

	public unsafe override ISharedPreferences? GetSharedPreferences(string? name, FileCreationMode mode)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)mode);
			return Java.Lang.Object.GetObject<ISharedPreferences>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSharedPreferences.(Ljava/lang/String;I)Landroid/content/SharedPreferences;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetSystemService_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetSystemService_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSystemService_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(contextWrapper.GetSystemService(name));
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

	public unsafe override Java.Lang.Object? GetSystemService([StringDef(Type = "Android.Content.Context", Fields = new string[]
	{
		"PowerService", "WindowService", "LayoutInflaterService", "AccountService", "ActivityService", "AlarmService", "NotificationService", "AccessibilityService", "CaptioningService", "KeyguardService",
		"LocationService", "HealthconnectService", "SearchService", "SensorService", "StorageService", "StorageStatsService", "WallpaperService", "VibratorManagerService", "VibratorService", "ConnectivityService",
		"TetheringService", "IpsecService", "VpnManagementService", "NetworkStatsService", "WifiService", "WifiAwareService", "WifiP2pService", "WifiRttRangingService", "NsdService", "AudioService",
		"FingerprintService", "BiometricService", "MediaRouterService", "TelephonyService", "TelephonySubscriptionService", "CarrierConfigService", "EuiccService", "TelecomService", "ClipboardService", "InputMethodService",
		"TextServicesManagerService", "TextClassificationService", "AppwidgetService", "DropboxService", "DevicePolicyService", "UiModeService", "DownloadService", "NfcService", "BluetoothService", "UsbService",
		"LauncherAppsService", "InputService", "DisplayService", "UserService", "RestrictionsService", "AppOpsService", "RoleService", "CameraService", "PrintService", "ConsumerIrService",
		"TvInteractiveAppService", "TvInputService", "UsageStatsService", "MediaSessionService", "MediaCommunicationService", "BatteryService", "JobSchedulerService", "PersistentDataBlockService", "MediaProjectionService", "MidiService",
		"HardwarePropertiesService", "ShortcutService", "SystemHealthService", "CompanionDeviceService", "VirtualDeviceService", "CrossProfileAppsService", "LocaleService", "MediaMetricsService", "DisplayHashService", "CredentialService",
		"DeviceLockService", "GrammaticalInflectionService", "SecurityStateService", "ContactKeysService", "MediaQualityService", "AdvancedProtectionService"
	})][StringDef(Type = "Android.Content.Context", Fields = new string[]
	{
		"PowerService", "WindowService", "LayoutInflaterService", "AccountService", "ActivityService", "AlarmService", "NotificationService", "AccessibilityService", "CaptioningService", "KeyguardService",
		"LocationService", "HealthconnectService", "SearchService", "SensorService", "StorageService", "StorageStatsService", "WallpaperService", "VibratorManagerService", "VibratorService", "ConnectivityService",
		"TetheringService", "IpsecService", "VpnManagementService", "NetworkStatsService", "WifiService", "WifiAwareService", "WifiP2pService", "WifiRttRangingService", "NsdService", "AudioService",
		"FingerprintService", "BiometricService", "MediaRouterService", "TelephonyService", "TelephonySubscriptionService", "CarrierConfigService", "EuiccService", "TelecomService", "ClipboardService", "InputMethodService",
		"TextServicesManagerService", "TextClassificationService", "AppwidgetService", "DropboxService", "DevicePolicyService", "UiModeService", "DownloadService", "NfcService", "BluetoothService", "UsbService",
		"LauncherAppsService", "InputService", "DisplayService", "UserService", "RestrictionsService", "AppOpsService", "RoleService", "CameraService", "PrintService", "ConsumerIrService",
		"TvInteractiveAppService", "TvInputService", "UsageStatsService", "MediaSessionService", "MediaCommunicationService", "BatteryService", "JobSchedulerService", "PersistentDataBlockService", "MediaProjectionService", "MidiService",
		"HardwarePropertiesService", "ShortcutService", "SystemHealthService", "CompanionDeviceService", "VirtualDeviceService", "CrossProfileAppsService", "LocaleService", "MediaMetricsService", "DisplayHashService", "CredentialService",
		"DeviceLockService", "GrammaticalInflectionService", "SecurityStateService", "ContactKeysService", "MediaQualityService", "AdvancedProtectionService"
	})] string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSystemService.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Obsolete]
	[SupportedOSPlatform("android26.0")]
	private static Delegate GetRegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_IHandler()
	{
		return new _JniMarshal_PPLLI_L(n_RegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_I);
	}

	[Obsolete]
	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_I(nint jnienv, nint native__this, nint native_receiver, nint native_filter, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BroadcastReceiver receiver = Java.Lang.Object.GetObject<BroadcastReceiver>(native_receiver, JniHandleOwnership.DoNotTransfer);
			IntentFilter filter = Java.Lang.Object.GetObject<IntentFilter>(native_filter, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(contextWrapper.RegisterReceiver(receiver, filter, (ActivityFlags)native_flags));
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

	[Obsolete("This method has an incorrect enumeration type. Use the overload that takes ReceiverFlags instead.")]
	[SupportedOSPlatform("android26.0")]
	public unsafe override Intent? RegisterReceiver(BroadcastReceiver? receiver, IntentFilter? filter, ActivityFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(filter?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)flags);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("registerReceiver.(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(receiver);
			GC.KeepAlive(filter);
		}
	}

	private static Delegate GetRegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_Handler()
	{
		return new _JniMarshal_PPLL_L(n_RegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_(nint jnienv, nint native__this, nint native_receiver, nint native_filter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BroadcastReceiver receiver = Java.Lang.Object.GetObject<BroadcastReceiver>(native_receiver, JniHandleOwnership.DoNotTransfer);
			IntentFilter filter = Java.Lang.Object.GetObject<IntentFilter>(native_filter, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(contextWrapper.RegisterReceiver(receiver, filter));
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

	public unsafe override Intent? RegisterReceiver(BroadcastReceiver? receiver, IntentFilter? filter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(filter?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("registerReceiver.(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(receiver);
			GC.KeepAlive(filter);
		}
	}

	private static Delegate GetSendBroadcast_Landroid_content_Intent_Handler()
	{
		return new _JniMarshal_PPL_V(n_SendBroadcast_Landroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SendBroadcast_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_intent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			contextWrapper.SendBroadcast(intent);
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

	public unsafe override void SendBroadcast(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("sendBroadcast.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetStartActivity_Landroid_content_Intent_Handler()
	{
		return new _JniMarshal_PPL_V(n_StartActivity_Landroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivity_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_intent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			contextWrapper.StartActivity(intent);
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

	public unsafe override void StartActivity(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivity.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetUnregisterReceiver_Landroid_content_BroadcastReceiver_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterReceiver_Landroid_content_BroadcastReceiver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterReceiver_Landroid_content_BroadcastReceiver_(nint jnienv, nint native__this, nint native_receiver)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ContextWrapper? contextWrapper = Java.Lang.Object.GetObject<ContextWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BroadcastReceiver receiver = Java.Lang.Object.GetObject<BroadcastReceiver>(native_receiver, JniHandleOwnership.DoNotTransfer);
			contextWrapper.UnregisterReceiver(receiver);
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

	public unsafe override void UnregisterReceiver(BroadcastReceiver? receiver)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterReceiver.(Landroid/content/BroadcastReceiver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(receiver);
		}
	}
}
