using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/BaseMapObjectCollection", DoNotGenerateAcw = true)]
internal class IBaseMapObjectCollectionInvoker : Java.Lang.Object, IBaseMapObjectCollection, IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_BaseMapObjectCollection = new XAPeerMembers("com/yandex/mapkit/map/BaseMapObjectCollection", typeof(IBaseMapObjectCollectionInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObject = new XAPeerMembers("com/yandex/mapkit/map/MapObject", typeof(IBaseMapObjectCollectionInvoker));

	private static Delegate? cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V;

	private static Delegate? cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;

	private static Delegate? cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V;

	private static Delegate? cb_isDraggable_IsDraggable_Z;

	private static Delegate? cb_setDraggable_SetDraggable_Z_V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_;

	private static Delegate? cb_getUserData_GetUserData_Ljava_lang_Object_;

	private static Delegate? cb_setUserData_SetUserData_Ljava_lang_Object__V;

	private static Delegate? cb_isVisible_IsVisible_Z;

	private static Delegate? cb_setVisible_SetVisible_Z_V;

	private static Delegate? cb_getZIndex_GetZIndex_F;

	private static Delegate? cb_setZIndex_SetZIndex_F_V;

	private static Delegate? cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;

	private static Delegate? cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;

	private static Delegate? cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V;

	private static Delegate? cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_BaseMapObjectCollection.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_BaseMapObjectCollection;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_BaseMapObjectCollection.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_BaseMapObjectCollection.ManagedPeerType;

	public unsafe bool Draggable
	{
		get
		{
			return _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractBooleanMethod("isDraggable.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setDraggable.(Z)V", this, ptr);
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe IBaseMapObjectCollection Parent => Java.Lang.Object.GetObject<IBaseMapObjectCollection>(_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractObjectMethod("getParent.()Lcom/yandex/mapkit/map/BaseMapObjectCollection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Java.Lang.Object? UserData
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractObjectMethod("getUserData.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setUserData.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool Visible
	{
		get
		{
			return _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
		}
	}

	public unsafe float ZIndex
	{
		get
		{
			return _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
		}
	}

	public IBaseMapObjectCollectionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_Handler()
	{
		if ((object)cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V == null)
		{
			cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_));
		}
		return cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;
	}

	private static void n_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectCollectionListener p = Java.Lang.Object.GetObject<IMapObjectCollectionListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.AddListener(p);
	}

	public unsafe void AddListener(IMapObjectCollectionListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("addListener.(Lcom/yandex/mapkit/map/MapObjectCollectionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
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
		Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
	}

	public unsafe void Clear()
	{
		_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetRemove_Lcom_yandex_mapkit_map_MapObject_Handler()
	{
		if ((object)cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V == null)
		{
			cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Remove_Lcom_yandex_mapkit_map_MapObject_));
		}
		return cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V;
	}

	private static void n_Remove_Lcom_yandex_mapkit_map_MapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.Remove(p);
	}

	public unsafe void Remove(IMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("remove.(Lcom/yandex/mapkit/map/MapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_Handler()
	{
		if ((object)cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V == null)
		{
			cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_));
		}
		return cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;
	}

	private static void n_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectCollectionListener p = Java.Lang.Object.GetObject<IMapObjectCollectionListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.RemoveListener(p);
	}

	public unsafe void RemoveListener(IMapObjectCollectionListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("removeListener.(Lcom/yandex/mapkit/map/MapObjectCollectionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetTraverse_Lcom_yandex_mapkit_map_MapObjectVisitor_Handler()
	{
		if ((object)cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V == null)
		{
			cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor_));
		}
		return cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V;
	}

	private static void n_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectVisitor p = Java.Lang.Object.GetObject<IMapObjectVisitor>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.Traverse(p);
	}

	public unsafe void Traverse(IMapObjectVisitor p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("traverse.(Lcom/yandex/mapkit/map/MapObjectVisitor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetIsDraggableHandler()
	{
		if ((object)cb_isDraggable_IsDraggable_Z == null)
		{
			cb_isDraggable_IsDraggable_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDraggable));
		}
		return cb_isDraggable_IsDraggable_Z;
	}

	private static bool n_IsDraggable(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable;
	}

	private static Delegate GetSetDraggable_ZHandler()
	{
		if ((object)cb_setDraggable_SetDraggable_Z_V == null)
		{
			cb_setDraggable_SetDraggable_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetDraggable_Z));
		}
		return cb_setDraggable_SetDraggable_Z_V;
	}

	private static void n_SetDraggable_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable = p0;
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
		return Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetParentHandler()
	{
		if ((object)cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_ == null)
		{
			cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetParent));
		}
		return cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_;
	}

	private static nint n_GetParent(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
	}

	private static Delegate GetGetUserDataHandler()
	{
		if ((object)cb_getUserData_GetUserData_Ljava_lang_Object_ == null)
		{
			cb_getUserData_GetUserData_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUserData));
		}
		return cb_getUserData_GetUserData_Ljava_lang_Object_;
	}

	private static nint n_GetUserData(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserData);
	}

	private static Delegate GetSetUserData_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setUserData_SetUserData_Ljava_lang_Object__V == null)
		{
			cb_setUserData_SetUserData_Ljava_lang_Object__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetUserData_Ljava_lang_Object_));
		}
		return cb_setUserData_SetUserData_Ljava_lang_Object__V;
	}

	private static void n_SetUserData_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object userData = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.UserData = userData;
	}

	private static Delegate GetIsVisibleHandler()
	{
		if ((object)cb_isVisible_IsVisible_Z == null)
		{
			cb_isVisible_IsVisible_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsVisible));
		}
		return cb_isVisible_IsVisible_Z;
	}

	private static bool n_IsVisible(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible;
	}

	private static Delegate GetSetVisible_ZHandler()
	{
		if ((object)cb_setVisible_SetVisible_Z_V == null)
		{
			cb_setVisible_SetVisible_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetVisible_Z));
		}
		return cb_setVisible_SetVisible_Z_V;
	}

	private static void n_SetVisible_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible = p0;
	}

	private static Delegate GetGetZIndexHandler()
	{
		if ((object)cb_getZIndex_GetZIndex_F == null)
		{
			cb_getZIndex_GetZIndex_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetZIndex));
		}
		return cb_getZIndex_GetZIndex_F;
	}

	private static float n_GetZIndex(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex;
	}

	private static Delegate GetSetZIndex_FHandler()
	{
		if ((object)cb_setZIndex_SetZIndex_F_V == null)
		{
			cb_setZIndex_SetZIndex_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetZIndex_F));
		}
		return cb_setZIndex_SetZIndex_F_V;
	}

	private static void n_SetZIndex_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex = p0;
	}

	private static Delegate GetAddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_Handler()
	{
		if ((object)cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V == null)
		{
			cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_));
		}
		return cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;
	}

	private static void n_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.AddTapListener(p);
	}

	public unsafe void AddTapListener(IMapObjectTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("addTapListener.(Lcom/yandex/mapkit/map/MapObjectTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_Handler()
	{
		if ((object)cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V == null)
		{
			cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_));
		}
		return cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;
	}

	private static void n_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.RemoveTapListener(p);
	}

	public unsafe void RemoveTapListener(IMapObjectTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("removeTapListener.(Lcom/yandex/mapkit/map/MapObjectTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener_Handler()
	{
		if ((object)cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V == null)
		{
			cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener_));
		}
		return cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V;
	}

	private static void n_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectDragListener dragListener = Java.Lang.Object.GetObject<IMapObjectDragListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.SetDragListener(dragListener);
	}

	public unsafe void SetDragListener(IMapObjectDragListener? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setDragListener.(Lcom/yandex/mapkit/map/MapObjectDragListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZLL_V(n_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, bool p0, nint native_p1, nint native_p2)
	{
		IBaseMapObjectCollection? baseMapObjectCollection = Java.Lang.Object.GetObject<IBaseMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Animation p1 = Java.Lang.Object.GetObject<Animation>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p2 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		baseMapObjectCollection.SetVisible(p0, p1, p2);
	}

	public unsafe void SetVisible(bool p0, Animation p1, ICallback? p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(ZLcom/yandex/mapkit/Animation;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}
}
