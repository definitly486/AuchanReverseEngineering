using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Core.Content;

[Register("androidx/core/content/ContextCompat", DoNotGenerateAcw = true)]
public class ContextCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/ContextCompat", typeof(ContextCompat));

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

	protected ContextCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	protected unsafe ContextCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("checkSelfPermission", "(Landroid/content/Context;Ljava/lang/String;)I", "")]
	public unsafe static Permission CheckSelfPermission(Context? context, string? permission)
	{
		nint num = JNIEnv.NewString(permission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return (Permission)_members.StaticMethods.InvokeInt32Method("checkSelfPermission.(Landroid/content/Context;Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("createAttributionContext", "(Landroid/content/Context;Ljava/lang/String;)Landroid/content/Context;", "")]
	public unsafe static Context? CreateAttributionContext(Context? context, string? attributionTag)
	{
		nint num = JNIEnv.NewString(attributionTag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Context>(_members.StaticMethods.InvokeObjectMethod("createAttributionContext.(Landroid/content/Context;Ljava/lang/String;)Landroid/content/Context;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("createDeviceProtectedStorageContext", "(Landroid/content/Context;)Landroid/content/Context;", "")]
	public unsafe static Context? CreateDeviceProtectedStorageContext(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Context>(_members.StaticMethods.InvokeObjectMethod("createDeviceProtectedStorageContext.(Landroid/content/Context;)Landroid/content/Context;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getAttributionTag", "(Landroid/content/Context;)Ljava/lang/String;", "")]
	public unsafe static string? GetAttributionTag(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getAttributionTag.(Landroid/content/Context;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getCodeCacheDir", "(Landroid/content/Context;)Ljava/io/File;", "")]
	public unsafe static File? GetCodeCacheDir(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<File>(_members.StaticMethods.InvokeObjectMethod("getCodeCacheDir.(Landroid/content/Context;)Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getColor", "(Landroid/content/Context;I)I", "")]
	public unsafe static int GetColor(Context? context, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return _members.StaticMethods.InvokeInt32Method("getColor.(Landroid/content/Context;I)I", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getColorStateList", "(Landroid/content/Context;I)Landroid/content/res/ColorStateList;", "")]
	public unsafe static ColorStateList? GetColorStateList(Context? context, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<ColorStateList>(_members.StaticMethods.InvokeObjectMethod("getColorStateList.(Landroid/content/Context;I)Landroid/content/res/ColorStateList;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getContextForLanguage", "(Landroid/content/Context;)Landroid/content/Context;", "")]
	public unsafe static Context? GetContextForLanguage(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Context>(_members.StaticMethods.InvokeObjectMethod("getContextForLanguage.(Landroid/content/Context;)Landroid/content/Context;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getDataDir", "(Landroid/content/Context;)Ljava/io/File;", "")]
	public unsafe static File? GetDataDir(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<File>(_members.StaticMethods.InvokeObjectMethod("getDataDir.(Landroid/content/Context;)Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getDisplayOrDefault", "(Landroid/content/Context;)Landroid/view/Display;", "")]
	public unsafe static Display? GetDisplayOrDefault(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Display>(_members.StaticMethods.InvokeObjectMethod("getDisplayOrDefault.(Landroid/content/Context;)Landroid/view/Display;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getDrawable", "(Landroid/content/Context;I)Landroid/graphics/drawable/Drawable;", "")]
	public unsafe static Drawable? GetDrawable(Context? context, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Drawable>(_members.StaticMethods.InvokeObjectMethod("getDrawable.(Landroid/content/Context;I)Landroid/graphics/drawable/Drawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Obsolete("deprecated")]
	[Register("getExternalCacheDirs", "(Landroid/content/Context;)[Ljava/io/File;", "")]
	public unsafe static File[]? GetExternalCacheDirs(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return (File[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("getExternalCacheDirs.(Landroid/content/Context;)[Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(File));
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Obsolete("deprecated")]
	[Register("getExternalFilesDirs", "(Landroid/content/Context;Ljava/lang/String;)[Ljava/io/File;", "")]
	public unsafe static File[]? GetExternalFilesDirs(Context? context, string? type)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return (File[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("getExternalFilesDirs.(Landroid/content/Context;Ljava/lang/String;)[Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(File));
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("getMainExecutor", "(Landroid/content/Context;)Ljava/util/concurrent/Executor;", "")]
	public unsafe static IExecutor? GetMainExecutor(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IExecutor>(_members.StaticMethods.InvokeObjectMethod("getMainExecutor.(Landroid/content/Context;)Ljava/util/concurrent/Executor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getNoBackupFilesDir", "(Landroid/content/Context;)Ljava/io/File;", "")]
	public unsafe static File? GetNoBackupFilesDir(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<File>(_members.StaticMethods.InvokeObjectMethod("getNoBackupFilesDir.(Landroid/content/Context;)Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Obsolete("deprecated")]
	[Register("getObbDirs", "(Landroid/content/Context;)[Ljava/io/File;", "")]
	public unsafe static File[]? GetObbDirs(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return (File[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("getObbDirs.(Landroid/content/Context;)[Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(File));
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getString", "(Landroid/content/Context;I)Ljava/lang/String;", "")]
	public unsafe static string? GetString(Context? context, int resId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resId);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getString.(Landroid/content/Context;I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getSystemService", "(Landroid/content/Context;Ljava/lang/Class;)Ljava/lang/Object;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static Java.Lang.Object? GetSystemService(Context? context, Class? serviceClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(serviceClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("getSystemService.(Landroid/content/Context;Ljava/lang/Class;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(serviceClass);
		}
	}

	[Register("getSystemServiceName", "(Landroid/content/Context;Ljava/lang/Class;)Ljava/lang/String;", "")]
	public unsafe static string? GetSystemServiceName(Context? context, Class? serviceClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(serviceClass?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getSystemServiceName.(Landroid/content/Context;Ljava/lang/Class;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(serviceClass);
		}
	}

	[Register("isDeviceProtectedStorage", "(Landroid/content/Context;)Z", "")]
	public unsafe static bool IsDeviceProtectedStorage(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isDeviceProtectedStorage.(Landroid/content/Context;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("registerReceiver", "(Landroid/content/Context;Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;I)Landroid/content/Intent;", "")]
	public unsafe static Intent? RegisterReceiver(Context? context, BroadcastReceiver? receiver, IntentFilter? filter, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(filter?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(flags);
			return Java.Lang.Object.GetObject<Intent>(_members.StaticMethods.InvokeObjectMethod("registerReceiver.(Landroid/content/Context;Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;I)Landroid/content/Intent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(receiver);
			GC.KeepAlive(filter);
		}
	}

	[Register("registerReceiver", "(Landroid/content/Context;Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;Ljava/lang/String;Landroid/os/Handler;I)Landroid/content/Intent;", "")]
	public unsafe static Intent? RegisterReceiver(Context? context, BroadcastReceiver? receiver, IntentFilter? filter, string? broadcastPermission, Handler? scheduler, int flags)
	{
		nint num = JNIEnv.NewString(broadcastPermission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(filter?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			ptr[4] = new JniArgumentValue(scheduler?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(flags);
			return Java.Lang.Object.GetObject<Intent>(_members.StaticMethods.InvokeObjectMethod("registerReceiver.(Landroid/content/Context;Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;Ljava/lang/String;Landroid/os/Handler;I)Landroid/content/Intent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(receiver);
			GC.KeepAlive(filter);
			GC.KeepAlive(scheduler);
		}
	}

	[Register("startActivities", "(Landroid/content/Context;[Landroid/content/Intent;)Z", "")]
	public unsafe static bool StartActivities(Context? context, Intent[]? intents)
	{
		nint num = JNIEnv.NewArray(intents);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeBooleanMethod("startActivities.(Landroid/content/Context;[Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			if (intents != null)
			{
				JNIEnv.CopyArray(num, intents);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(context);
			GC.KeepAlive(intents);
		}
	}

	[Register("startActivities", "(Landroid/content/Context;[Landroid/content/Intent;Landroid/os/Bundle;)Z", "")]
	public unsafe static bool StartActivities(Context? context, Intent[]? intents, Bundle? options)
	{
		nint num = JNIEnv.NewArray(intents);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("startActivities.(Landroid/content/Context;[Landroid/content/Intent;Landroid/os/Bundle;)Z", ptr);
		}
		finally
		{
			if (intents != null)
			{
				JNIEnv.CopyArray(num, intents);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(context);
			GC.KeepAlive(intents);
			GC.KeepAlive(options);
		}
	}

	[Obsolete("deprecated")]
	[Register("startActivity", "(Landroid/content/Context;Landroid/content/Intent;Landroid/os/Bundle;)V", "")]
	public unsafe static void StartActivity(Context? context, Intent? intent, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("startActivity.(Landroid/content/Context;Landroid/content/Intent;Landroid/os/Bundle;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	[Register("startForegroundService", "(Landroid/content/Context;Landroid/content/Intent;)V", "")]
	public unsafe static void StartForegroundService(Context? context, Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("startForegroundService.(Landroid/content/Context;Landroid/content/Intent;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(intent);
		}
	}
}
