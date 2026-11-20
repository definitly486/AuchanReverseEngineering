using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content.PM;

[Register("android/content/pm/PackageManager", DoNotGenerateAcw = true)]
internal class PackageManagerInvoker : PackageManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/PackageManager", typeof(PackageManagerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public PackageManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getApplicationInfo", "(Ljava/lang/String;I)Landroid/content/pm/ApplicationInfo;", "GetGetApplicationInfo_Ljava_lang_String_IHandler")]
	public unsafe override ApplicationInfo GetApplicationInfo(string packageName, PackageInfoFlags flags)
	{
		nint num = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)flags);
			return Java.Lang.Object.GetObject<ApplicationInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationInfo.(Ljava/lang/String;I)Landroid/content/pm/ApplicationInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[ObsoletedOSPlatform("android30.0")]
	[Register("getInstallerPackageName", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetInstallerPackageName_Ljava_lang_String_Handler")]
	public unsafe override string? GetInstallerPackageName(string packageName)
	{
		nint num = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getInstallerPackageName.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getLaunchIntentForPackage", "(Ljava/lang/String;)Landroid/content/Intent;", "GetGetLaunchIntentForPackage_Ljava_lang_String_Handler")]
	public unsafe override Intent? GetLaunchIntentForPackage(string packageName)
	{
		nint num = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLaunchIntentForPackage.(Ljava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getPackageInfo", "(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;", "GetGetPackageInfo_Ljava_lang_String_IHandler")]
	public unsafe override PackageInfo? GetPackageInfo(string packageName, PackageInfoFlags flags)
	{
		nint num = JNIEnv.NewString(packageName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)flags);
			return Java.Lang.Object.GetObject<PackageInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPackageInfo.(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("queryIntentActivities", "(Landroid/content/Intent;I)Ljava/util/List;", "GetQueryIntentActivities_Landroid_content_Intent_IHandler")]
	public unsafe override IList<ResolveInfo> QueryIntentActivities(Intent intent, PackageInfoFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			return JavaList<ResolveInfo>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("queryIntentActivities.(Landroid/content/Intent;I)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("setComponentEnabledSetting", "(Landroid/content/ComponentName;II)V", "GetSetComponentEnabledSetting_Landroid_content_ComponentName_IIHandler")]
	[RequiresPermission("android.permission.CHANGE_COMPONENT_ENABLED_STATE")]
	public unsafe override void SetComponentEnabledSetting(ComponentName componentName, ComponentEnabledState newState, ComponentEnableOption flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)newState);
			ptr[2] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setComponentEnabledSetting.(Landroid/content/ComponentName;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(componentName);
		}
	}
}
