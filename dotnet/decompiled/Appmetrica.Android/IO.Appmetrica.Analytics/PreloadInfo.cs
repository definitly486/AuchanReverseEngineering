using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/PreloadInfo", DoNotGenerateAcw = true)]
public class PreloadInfo : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/PreloadInfo$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/PreloadInfo$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_PreloadInfo_;

		private static Delegate? cb_setAdditionalParams_SetAdditionalParams_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_PreloadInfo_Builder_;

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

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetBuildHandler()
		{
			if ((object)cb_build_Build_Lio_appmetrica_analytics_PreloadInfo_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_PreloadInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_PreloadInfo_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/PreloadInfo;", "GetBuildHandler")]
		public unsafe virtual PreloadInfo? Build()
		{
			return Java.Lang.Object.GetObject<PreloadInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/PreloadInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetAdditionalParams_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_setAdditionalParams_SetAdditionalParams_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_PreloadInfo_Builder_ == null)
			{
				cb_setAdditionalParams_SetAdditionalParams_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_PreloadInfo_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_SetAdditionalParams_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_setAdditionalParams_SetAdditionalParams_Ljava_lang_String_Ljava_lang_String__Lio_appmetrica_analytics_PreloadInfo_Builder_;
		}

		private static nint n_SetAdditionalParams_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_value)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetAdditionalParams(key, value));
		}

		[Register("setAdditionalParams", "(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/PreloadInfo$Builder;", "GetSetAdditionalParams_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? SetAdditionalParams(string? key, string? value)
		{
			nint num = JNIEnv.NewString(key);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAdditionalParams.(Ljava/lang/String;Ljava/lang/String;)Lio/appmetrica/analytics/PreloadInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/PreloadInfo", typeof(PreloadInfo));

	private static Delegate? cb_getAdditionalParams_GetAdditionalParams_Ljava_util_Map_;

	private static Delegate? cb_getTrackingId_GetTrackingId_Ljava_lang_String_;

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

	public unsafe virtual IDictionary<string, string>? AdditionalParams
	{
		[Register("getAdditionalParams", "()Ljava/util/Map;", "GetGetAdditionalParamsHandler")]
		get
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAdditionalParams.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? TrackingId
	{
		[Register("getTrackingId", "()Ljava/lang/String;", "GetGetTrackingIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTrackingId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected PreloadInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetAdditionalParamsHandler()
	{
		if ((object)cb_getAdditionalParams_GetAdditionalParams_Ljava_util_Map_ == null)
		{
			cb_getAdditionalParams_GetAdditionalParams_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAdditionalParams));
		}
		return cb_getAdditionalParams_GetAdditionalParams_Ljava_util_Map_;
	}

	private static nint n_GetAdditionalParams(nint jnienv, nint native__this)
	{
		return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<PreloadInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AdditionalParams);
	}

	private static Delegate GetGetTrackingIdHandler()
	{
		if ((object)cb_getTrackingId_GetTrackingId_Ljava_lang_String_ == null)
		{
			cb_getTrackingId_GetTrackingId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTrackingId));
		}
		return cb_getTrackingId_GetTrackingId_Ljava_lang_String_;
	}

	private static nint n_GetTrackingId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<PreloadInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackingId);
	}

	[Register("newBuilder", "(Ljava/lang/String;)Lio/appmetrica/analytics/PreloadInfo$Builder;", "")]
	public unsafe static Builder? NewBuilder(string? trackingId)
	{
		nint num = JNIEnv.NewString(trackingId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(Ljava/lang/String;)Lio/appmetrica/analytics/PreloadInfo$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
