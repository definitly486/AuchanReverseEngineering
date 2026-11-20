using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/TypeDictionary", DoNotGenerateAcw = true)]
internal class ITypeDictionaryInvoker : Java.Lang.Object, ITypeDictionary, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_runtime_TypeDictionary = new XAPeerMembers("com/yandex/runtime/TypeDictionary", typeof(ITypeDictionaryInvoker));

	private static Delegate? cb_getAllItems_GetAllItems_Ljava_util_Map_;

	private static Delegate? cb_getItem_GetItem_Ljava_lang_Class__Ljava_lang_Object_;

	private static nint java_class_ref => _members_com_yandex_runtime_TypeDictionary.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_runtime_TypeDictionary;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_runtime_TypeDictionary.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_runtime_TypeDictionary.ManagedPeerType;

	public unsafe IDictionary? AllItems => JavaDictionary.FromJniHandle(_members_com_yandex_runtime_TypeDictionary.InstanceMethods.InvokeAbstractObjectMethod("getAllItems.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public ITypeDictionaryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetAllItemsHandler()
	{
		if ((object)cb_getAllItems_GetAllItems_Ljava_util_Map_ == null)
		{
			cb_getAllItems_GetAllItems_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAllItems));
		}
		return cb_getAllItems_GetAllItems_Ljava_util_Map_;
	}

	private static nint n_GetAllItems(nint jnienv, nint native__this)
	{
		return JavaDictionary.ToLocalJniHandle(Java.Lang.Object.GetObject<ITypeDictionary>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllItems);
	}

	private static Delegate GetGetItem_Ljava_lang_Class_Handler()
	{
		if ((object)cb_getItem_GetItem_Ljava_lang_Class__Ljava_lang_Object_ == null)
		{
			cb_getItem_GetItem_Ljava_lang_Class__Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetItem_Ljava_lang_Class_));
		}
		return cb_getItem_GetItem_Ljava_lang_Class__Ljava_lang_Object_;
	}

	private static nint n_GetItem_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_p0)
	{
		ITypeDictionary? typeDictionary = Java.Lang.Object.GetObject<ITypeDictionary>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class p = Java.Lang.Object.GetObject<Class>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(typeDictionary.GetItem(p));
	}

	public unsafe Java.Lang.Object? GetItem(Class? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_yandex_runtime_TypeDictionary.InstanceMethods.InvokeAbstractObjectMethod("getItem.(Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
