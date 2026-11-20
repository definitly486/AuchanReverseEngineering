using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Indoor;

[Register("com/yandex/mapkit/indoor/IndoorPlan", DoNotGenerateAcw = true)]
internal class IIndoorPlanInvoker : Java.Lang.Object, IIndoorPlan, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_indoor_IndoorPlan = new XAPeerMembers("com/yandex/mapkit/indoor/IndoorPlan", typeof(IIndoorPlanInvoker));

	private static Delegate? cb_getActiveLevelId_GetActiveLevelId_Ljava_lang_String_;

	private static Delegate? cb_setActiveLevelId_SetActiveLevelId_Ljava_lang_String__V;

	private static Delegate? cb_getLevels_GetLevels_Ljava_util_List_;

	private static nint java_class_ref => _members_com_yandex_mapkit_indoor_IndoorPlan.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_indoor_IndoorPlan;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_indoor_IndoorPlan.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_indoor_IndoorPlan.ManagedPeerType;

	public unsafe string ActiveLevelId
	{
		get
		{
			return JNIEnv.GetString(_members_com_yandex_mapkit_indoor_IndoorPlan.InstanceMethods.InvokeAbstractObjectMethod("getActiveLevelId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_yandex_mapkit_indoor_IndoorPlan.InstanceMethods.InvokeAbstractVoidMethod("setActiveLevelId.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe IList<IndoorLevel> Levels => JavaList<IndoorLevel>.FromJniHandle(_members_com_yandex_mapkit_indoor_IndoorPlan.InstanceMethods.InvokeAbstractObjectMethod("getLevels.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IIndoorPlanInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetActiveLevelIdHandler()
	{
		if ((object)cb_getActiveLevelId_GetActiveLevelId_Ljava_lang_String_ == null)
		{
			cb_getActiveLevelId_GetActiveLevelId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetActiveLevelId));
		}
		return cb_getActiveLevelId_GetActiveLevelId_Ljava_lang_String_;
	}

	private static nint n_GetActiveLevelId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IIndoorPlan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActiveLevelId);
	}

	private static Delegate GetSetActiveLevelId_Ljava_lang_String_Handler()
	{
		if ((object)cb_setActiveLevelId_SetActiveLevelId_Ljava_lang_String__V == null)
		{
			cb_setActiveLevelId_SetActiveLevelId_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetActiveLevelId_Ljava_lang_String_));
		}
		return cb_setActiveLevelId_SetActiveLevelId_Ljava_lang_String__V;
	}

	private static void n_SetActiveLevelId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IIndoorPlan? indoorPlan = Java.Lang.Object.GetObject<IIndoorPlan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string activeLevelId = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		indoorPlan.ActiveLevelId = activeLevelId;
	}

	private static Delegate GetGetLevelsHandler()
	{
		if ((object)cb_getLevels_GetLevels_Ljava_util_List_ == null)
		{
			cb_getLevels_GetLevels_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLevels));
		}
		return cb_getLevels_GetLevels_Ljava_util_List_;
	}

	private static nint n_GetLevels(nint jnienv, nint native__this)
	{
		return JavaList<IndoorLevel>.ToLocalJniHandle(Java.Lang.Object.GetObject<IIndoorPlan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Levels);
	}
}
