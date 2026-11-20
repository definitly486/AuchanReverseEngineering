using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/DataSourceLayer", DoNotGenerateAcw = true)]
internal class IDataSourceLayerInvoker : Java.Lang.Object, IDataSourceLayer, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_DataSourceLayer = new XAPeerMembers("com/yandex/mapkit/layers/DataSourceLayer", typeof(IDataSourceLayerInvoker));

	private static Delegate? cb_isActive_IsActive_Z;

	private static Delegate? cb_setActive_SetActive_Z_V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_remove_Remove_V;

	private static Delegate? cb_resetStyles_ResetStyles_V;

	private static Delegate? cb_setDataSourceListener_SetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener__V;

	private static Delegate? cb_setLayerLoadedListener_SetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener__V;

	private static Delegate? cb_setStyle_SetStyle_ILjava_lang_String__Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_DataSourceLayer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_DataSourceLayer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_DataSourceLayer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_DataSourceLayer.ManagedPeerType;

	public unsafe bool Active
	{
		get
		{
			return _members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractBooleanMethod("isActive.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractVoidMethod("setActive.(Z)V", this, ptr);
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IDataSourceLayerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsActiveHandler()
	{
		if ((object)cb_isActive_IsActive_Z == null)
		{
			cb_isActive_IsActive_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsActive));
		}
		return cb_isActive_IsActive_Z;
	}

	private static bool n_IsActive(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Active;
	}

	private static Delegate GetSetActive_ZHandler()
	{
		if ((object)cb_setActive_SetActive_Z_V == null)
		{
			cb_setActive_SetActive_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetActive_Z));
		}
		return cb_setActive_SetActive_Z_V;
	}

	private static void n_SetActive_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Active = p0;
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetClearHandler()
	{
		if ((object)cb_clear_Clear_V == null)
		{
			cb_clear_Clear_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
		}
		return cb_clear_Clear_V;
	}

	private static void n_Clear(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
	}

	public unsafe void Clear()
	{
		_members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetRemoveHandler()
	{
		if ((object)cb_remove_Remove_V == null)
		{
			cb_remove_Remove_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Remove));
		}
		return cb_remove_Remove_V;
	}

	private static void n_Remove(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}

	private static Delegate GetResetStylesHandler()
	{
		if ((object)cb_resetStyles_ResetStyles_V == null)
		{
			cb_resetStyles_ResetStyles_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetStyles));
		}
		return cb_resetStyles_ResetStyles_V;
	}

	private static void n_ResetStyles(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetStyles();
	}

	public unsafe void ResetStyles()
	{
		_members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractVoidMethod("resetStyles.()V", this, null);
	}

	private static Delegate GetSetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener_Handler()
	{
		if ((object)cb_setDataSourceListener_SetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener__V == null)
		{
			cb_setDataSourceListener_SetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener_));
		}
		return cb_setDataSourceListener_SetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener__V;
	}

	private static void n_SetDataSourceListener_Lcom_yandex_mapkit_layers_DataSourceListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IDataSourceLayer? dataSourceLayer = Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDataSourceListener dataSourceListener = Java.Lang.Object.GetObject<IDataSourceListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		dataSourceLayer.SetDataSourceListener(dataSourceListener);
	}

	public unsafe void SetDataSourceListener(IDataSourceListener? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractVoidMethod("setDataSourceListener.(Lcom/yandex/mapkit/layers/DataSourceListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener_Handler()
	{
		if ((object)cb_setLayerLoadedListener_SetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener__V == null)
		{
			cb_setLayerLoadedListener_SetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener_));
		}
		return cb_setLayerLoadedListener_SetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener__V;
	}

	private static void n_SetLayerLoadedListener_Lcom_yandex_mapkit_layers_LayerLoadedListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IDataSourceLayer? dataSourceLayer = Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILayerLoadedListener layerLoadedListener = Java.Lang.Object.GetObject<ILayerLoadedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		dataSourceLayer.SetLayerLoadedListener(layerLoadedListener);
	}

	public unsafe void SetLayerLoadedListener(ILayerLoadedListener? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractVoidMethod("setLayerLoadedListener.(Lcom/yandex/mapkit/layers/LayerLoadedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetStyle_ILjava_lang_String_Handler()
	{
		if ((object)cb_setStyle_SetStyle_ILjava_lang_String__Z == null)
		{
			cb_setStyle_SetStyle_ILjava_lang_String__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_Z(n_SetStyle_ILjava_lang_String_));
		}
		return cb_setStyle_SetStyle_ILjava_lang_String__Z;
	}

	private static bool n_SetStyle_ILjava_lang_String_(nint jnienv, nint native__this, int p0, nint native_p1)
	{
		IDataSourceLayer? dataSourceLayer = Java.Lang.Object.GetObject<IDataSourceLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		return dataSourceLayer.SetStyle(p0, p1);
	}

	public unsafe bool SetStyle(int p0, string p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(num);
			return _members_com_yandex_mapkit_layers_DataSourceLayer.InstanceMethods.InvokeAbstractBooleanMethod("setStyle.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
