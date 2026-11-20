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

[Register("android/content/Context", DoNotGenerateAcw = true)]
internal class ContextInvoker : Context
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/Context", typeof(ContextInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override Context? ApplicationContext
	{
		[Register("getApplicationContext", "()Landroid/content/Context;", "GetGetApplicationContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override ApplicationInfo? ApplicationInfo
	{
		[Register("getApplicationInfo", "()Landroid/content/pm/ApplicationInfo;", "GetGetApplicationInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ApplicationInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationInfo.()Landroid/content/pm/ApplicationInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override AssetManager? Assets
	{
		[Register("getAssets", "()Landroid/content/res/AssetManager;", "GetGetAssetsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AssetManager>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAssets.()Landroid/content/res/AssetManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override File? CacheDir
	{
		[Register("getCacheDir", "()Ljava/io/File;", "GetGetCacheDirHandler")]
		get
		{
			return Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCacheDir.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override ClassLoader? ClassLoader
	{
		[Register("getClassLoader", "()Ljava/lang/ClassLoader;", "GetGetClassLoaderHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ClassLoader>(_members.InstanceMethods.InvokeAbstractObjectMethod("getClassLoader.()Ljava/lang/ClassLoader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override ContentResolver? ContentResolver
	{
		[Register("getContentResolver", "()Landroid/content/ContentResolver;", "GetGetContentResolverHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ContentResolver>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentResolver.()Landroid/content/ContentResolver;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override File? ExternalCacheDir
	{
		[Register("getExternalCacheDir", "()Ljava/io/File;", "GetGetExternalCacheDirHandler")]
		get
		{
			return Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExternalCacheDir.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override File? FilesDir
	{
		[Register("getFilesDir", "()Ljava/io/File;", "GetGetFilesDirHandler")]
		get
		{
			return Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeAbstractObjectMethod("getFilesDir.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Looper? MainLooper
	{
		[Register("getMainLooper", "()Landroid/os/Looper;", "GetGetMainLooperHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Looper>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMainLooper.()Landroid/os/Looper;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override PackageManager? PackageManager
	{
		[Register("getPackageManager", "()Landroid/content/pm/PackageManager;", "GetGetPackageManagerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PackageManager>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPackageManager.()Landroid/content/pm/PackageManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override string? PackageName
	{
		[Register("getPackageName", "()Ljava/lang/String;", "GetGetPackageNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPackageName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Resources? Resources
	{
		[Register("getResources", "()Landroid/content/res/Resources;", "GetGetResourcesHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Resources>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResources.()Landroid/content/res/Resources;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Resources.Theme? Theme
	{
		[Register("getTheme", "()Landroid/content/res/Resources$Theme;", "GetGetThemeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Resources.Theme>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTheme.()Landroid/content/res/Resources$Theme;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public ContextInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	[Register("deleteSharedPreferences", "(Ljava/lang/String;)Z", "GetDeleteSharedPreferences_Ljava_lang_String_Handler", ApiSince = 24)]
	public unsafe override bool DeleteSharedPreferences(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("deleteSharedPreferences.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getExternalFilesDir", "(Ljava/lang/String;)Ljava/io/File;", "GetGetExternalFilesDir_Ljava_lang_String_Handler")]
	public unsafe override File? GetExternalFilesDir(string? type)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<File>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExternalFilesDir.(Ljava/lang/String;)Ljava/io/File;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getSharedPreferences", "(Ljava/lang/String;I)Landroid/content/SharedPreferences;", "GetGetSharedPreferences_Ljava_lang_String_IHandler")]
	public unsafe override ISharedPreferences? GetSharedPreferences(string? name, FileCreationMode mode)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)mode);
			return Java.Lang.Object.GetObject<ISharedPreferences>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSharedPreferences.(Ljava/lang/String;I)Landroid/content/SharedPreferences;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getSystemService", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGetSystemService_Ljava_lang_String_Handler")]
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
	})] string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSystemService.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Obsolete("This method has an incorrect enumeration type. Use the overload that takes ReceiverFlags instead.")]
	[SupportedOSPlatform("android26.0")]
	[Register("registerReceiver", "(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;I)Landroid/content/Intent;", "GetRegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_IHandler", ApiSince = 26)]
	public unsafe override Intent? RegisterReceiver(BroadcastReceiver? receiver, IntentFilter? filter, ActivityFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(filter?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)flags);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("registerReceiver.(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(receiver);
			GC.KeepAlive(filter);
		}
	}

	[Register("registerReceiver", "(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;", "GetRegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_Handler")]
	public unsafe override Intent? RegisterReceiver(BroadcastReceiver? receiver, IntentFilter? filter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(filter?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("registerReceiver.(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(receiver);
			GC.KeepAlive(filter);
		}
	}

	[Register("sendBroadcast", "(Landroid/content/Intent;)V", "GetSendBroadcast_Landroid_content_Intent_Handler")]
	public unsafe override void SendBroadcast(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("sendBroadcast.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("startActivity", "(Landroid/content/Intent;)V", "GetStartActivity_Landroid_content_Intent_Handler")]
	public unsafe override void StartActivity(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("startActivity.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("unregisterReceiver", "(Landroid/content/BroadcastReceiver;)V", "GetUnregisterReceiver_Landroid_content_BroadcastReceiver_Handler")]
	public unsafe override void UnregisterReceiver(BroadcastReceiver? receiver)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("unregisterReceiver.(Landroid/content/BroadcastReceiver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(receiver);
		}
	}
}
