using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Com.Yandex.Mapkit.Map;
using Com.Yandex.Runtime.View;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Mapview;

[Register("com/yandex/mapkit/mapview/MapView", DoNotGenerateAcw = true)]
public class MapView : RelativeLayout
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/mapview/MapView", typeof(MapView));

	private static Delegate? cb_getGraphicsAPI_GetGraphicsAPI_Lcom_yandex_runtime_view_GraphicsAPIType_;

	private static Delegate? cb_isDebugModeEnabled_IsDebugModeEnabled_Z;

	private static Delegate? cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_;

	private static Delegate? cb_getMapWindow_GetMapWindow_Lcom_yandex_mapkit_map_MapWindow_;

	private static Delegate? cb_getScreenshot_GetScreenshot_Landroid_graphics_Bitmap_;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_setNoninteractive_SetNoninteractive_Z_V;

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

	public unsafe virtual GraphicsAPIType? GraphicsAPI
	{
		[Register("getGraphicsAPI", "()Lcom/yandex/runtime/view/GraphicsAPIType;", "GetGetGraphicsAPIHandler")]
		get
		{
			return Java.Lang.Object.GetObject<GraphicsAPIType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getGraphicsAPI.()Lcom/yandex/runtime/view/GraphicsAPIType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsDebugModeEnabled
	{
		[Register("isDebugModeEnabled", "()Z", "GetIsDebugModeEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDebugModeEnabled.()Z", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual IMap? Map
	{
		[Register("getMap", "()Lcom/yandex/mapkit/map/Map;", "GetGetMapHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMap>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMap.()Lcom/yandex/mapkit/map/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IMapWindow? MapWindow
	{
		[Register("getMapWindow", "()Lcom/yandex/mapkit/map/MapWindow;", "GetGetMapWindowHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMapWindow>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMapWindow.()Lcom/yandex/mapkit/map/MapWindow;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Bitmap? Screenshot
	{
		[Register("getScreenshot", "()Landroid/graphics/Bitmap;", "GetGetScreenshotHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeVirtualObjectMethod("getScreenshot.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected MapView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe MapView(Context? context)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe MapView(Context? context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe MapView(Context? context, IAttributeSet? attrs, int defStyle)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetGetGraphicsAPIHandler()
	{
		if ((object)cb_getGraphicsAPI_GetGraphicsAPI_Lcom_yandex_runtime_view_GraphicsAPIType_ == null)
		{
			cb_getGraphicsAPI_GetGraphicsAPI_Lcom_yandex_runtime_view_GraphicsAPIType_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGraphicsAPI));
		}
		return cb_getGraphicsAPI_GetGraphicsAPI_Lcom_yandex_runtime_view_GraphicsAPIType_;
	}

	private static nint n_GetGraphicsAPI(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GraphicsAPI);
	}

	private static Delegate GetIsDebugModeEnabledHandler()
	{
		if ((object)cb_isDebugModeEnabled_IsDebugModeEnabled_Z == null)
		{
			cb_isDebugModeEnabled_IsDebugModeEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDebugModeEnabled));
		}
		return cb_isDebugModeEnabled_IsDebugModeEnabled_Z;
	}

	private static bool n_IsDebugModeEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDebugModeEnabled;
	}

	[Obsolete]
	private static Delegate GetGetMapHandler()
	{
		if ((object)cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_ == null)
		{
			cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMap));
		}
		return cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_;
	}

	[Obsolete]
	private static nint n_GetMap(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Map);
	}

	private static Delegate GetGetMapWindowHandler()
	{
		if ((object)cb_getMapWindow_GetMapWindow_Lcom_yandex_mapkit_map_MapWindow_ == null)
		{
			cb_getMapWindow_GetMapWindow_Lcom_yandex_mapkit_map_MapWindow_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMapWindow));
		}
		return cb_getMapWindow_GetMapWindow_Lcom_yandex_mapkit_map_MapWindow_;
	}

	private static nint n_GetMapWindow(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MapWindow);
	}

	private static Delegate GetGetScreenshotHandler()
	{
		if ((object)cb_getScreenshot_GetScreenshot_Landroid_graphics_Bitmap_ == null)
		{
			cb_getScreenshot_GetScreenshot_Landroid_graphics_Bitmap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetScreenshot));
		}
		return cb_getScreenshot_GetScreenshot_Landroid_graphics_Bitmap_;
	}

	private static nint n_GetScreenshot(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Screenshot);
	}

	private static Delegate GetOnStartHandler()
	{
		if ((object)cb_onStart_OnStart_V == null)
		{
			cb_onStart_OnStart_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStart));
		}
		return cb_onStart_OnStart_V;
	}

	private static void n_OnStart(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
	}

	[Register("onStart", "()V", "GetOnStartHandler")]
	public unsafe virtual void OnStart()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.()V", this, null);
	}

	private static Delegate GetOnStopHandler()
	{
		if ((object)cb_onStop_OnStop_V == null)
		{
			cb_onStop_OnStop_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStop));
		}
		return cb_onStop_OnStop_V;
	}

	private static void n_OnStop(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
	}

	[Register("onStop", "()V", "GetOnStopHandler")]
	public unsafe virtual void OnStop()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.()V", this, null);
	}

	private static Delegate GetSetNoninteractive_ZHandler()
	{
		if ((object)cb_setNoninteractive_SetNoninteractive_Z_V == null)
		{
			cb_setNoninteractive_SetNoninteractive_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetNoninteractive_Z));
		}
		return cb_setNoninteractive_SetNoninteractive_Z_V;
	}

	private static void n_SetNoninteractive_Z(nint jnienv, nint native__this, bool @is)
	{
		Java.Lang.Object.GetObject<MapView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNoninteractive(@is);
	}

	[Register("setNoninteractive", "(Z)V", "GetSetNoninteractive_ZHandler")]
	public unsafe virtual void SetNoninteractive(bool @is)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(@is);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setNoninteractive.(Z)V", this, ptr);
	}
}
