using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/MapKitFactory", DoNotGenerateAcw = true)]
public sealed class MapKitFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/MapKitFactory", typeof(MapKitFactory));

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

	public unsafe static IMapKit? Instance
	{
		[Register("getInstance", "()Lcom/yandex/mapkit/MapKit;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IMapKit>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/yandex/mapkit/MapKit;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal MapKitFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MapKitFactory()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("initialize", "(Landroid/content/Context;)V", "")]
	public unsafe static void Initialize(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("initialize.(Landroid/content/Context;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("setApiKey", "(Ljava/lang/String;)V", "")]
	public unsafe static void SetApiKey(string apiKey)
	{
		nint num = JNIEnv.NewString(apiKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setApiKey.(Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("setLocale", "(Ljava/lang/String;)V", "")]
	public unsafe static void SetLocale(string? locale)
	{
		nint num = JNIEnv.NewString(locale);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setLocale.(Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("setUserId", "(Ljava/lang/String;)V", "")]
	public unsafe static void SetUserId(string? userId)
	{
		nint num = JNIEnv.NewString(userId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setUserId.(Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
