using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Math;
using Java.Util;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/AdRevenue", DoNotGenerateAcw = true)]
public class AdRevenue : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/AdRevenue$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/AdRevenue$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_AdRevenue_;

		private static Delegate? cb_withAdNetwork_WithAdNetwork_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;

		private static Delegate? cb_withAdPlacementId_WithAdPlacementId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;

		private static Delegate? cb_withAdPlacementName_WithAdPlacementName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;

		private static Delegate? cb_withAdType_WithAdType_Lio_appmetrica_analytics_AdType__Lio_appmetrica_analytics_AdRevenue_Builder_;

		private static Delegate? cb_withAdUnitId_WithAdUnitId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;

		private static Delegate? cb_withAdUnitName_WithAdUnitName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;

		private static Delegate? cb_withPayload_WithPayload_Ljava_util_Map__Lio_appmetrica_analytics_AdRevenue_Builder_;

		private static Delegate? cb_withPrecision_WithPrecision_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;

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
			if ((object)cb_build_Build_Lio_appmetrica_analytics_AdRevenue_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_AdRevenue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_AdRevenue_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/AdRevenue;", "GetBuildHandler")]
		public unsafe virtual AdRevenue? Build()
		{
			return Java.Lang.Object.GetObject<AdRevenue>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/AdRevenue;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithAdNetwork_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAdNetwork_WithAdNetwork_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withAdNetwork_WithAdNetwork_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithAdNetwork_Ljava_lang_String_));
			}
			return cb_withAdNetwork_WithAdNetwork_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithAdNetwork_Ljava_lang_String_(nint jnienv, nint native__this, nint native_adNetwork)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string adNetwork = JNIEnv.GetString(native_adNetwork, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdNetwork(adNetwork));
		}

		[Register("withAdNetwork", "(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithAdNetwork_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? WithAdNetwork(string? adNetwork)
		{
			nint num = JNIEnv.NewString(adNetwork);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdNetwork.(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithAdPlacementId_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAdPlacementId_WithAdPlacementId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withAdPlacementId_WithAdPlacementId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithAdPlacementId_Ljava_lang_String_));
			}
			return cb_withAdPlacementId_WithAdPlacementId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithAdPlacementId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_adPlacementId)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string adPlacementId = JNIEnv.GetString(native_adPlacementId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdPlacementId(adPlacementId));
		}

		[Register("withAdPlacementId", "(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithAdPlacementId_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? WithAdPlacementId(string? adPlacementId)
		{
			nint num = JNIEnv.NewString(adPlacementId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdPlacementId.(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithAdPlacementName_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAdPlacementName_WithAdPlacementName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withAdPlacementName_WithAdPlacementName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithAdPlacementName_Ljava_lang_String_));
			}
			return cb_withAdPlacementName_WithAdPlacementName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithAdPlacementName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_adPlacementName)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string adPlacementName = JNIEnv.GetString(native_adPlacementName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdPlacementName(adPlacementName));
		}

		[Register("withAdPlacementName", "(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithAdPlacementName_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? WithAdPlacementName(string? adPlacementName)
		{
			nint num = JNIEnv.NewString(adPlacementName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdPlacementName.(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithAdType_Lio_appmetrica_analytics_AdType_Handler()
		{
			if ((object)cb_withAdType_WithAdType_Lio_appmetrica_analytics_AdType__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withAdType_WithAdType_Lio_appmetrica_analytics_AdType__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithAdType_Lio_appmetrica_analytics_AdType_));
			}
			return cb_withAdType_WithAdType_Lio_appmetrica_analytics_AdType__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithAdType_Lio_appmetrica_analytics_AdType_(nint jnienv, nint native__this, nint native_adType)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AdType adType = Java.Lang.Object.GetObject<AdType>(native_adType, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdType(adType));
		}

		[Register("withAdType", "(Lio/appmetrica/analytics/AdType;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithAdType_Lio_appmetrica_analytics_AdType_Handler")]
		public unsafe virtual Builder? WithAdType(AdType? adType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(adType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdType.(Lio/appmetrica/analytics/AdType;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(adType);
			}
		}

		private static Delegate GetWithAdUnitId_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAdUnitId_WithAdUnitId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withAdUnitId_WithAdUnitId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithAdUnitId_Ljava_lang_String_));
			}
			return cb_withAdUnitId_WithAdUnitId_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithAdUnitId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_adUnitId)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string adUnitId = JNIEnv.GetString(native_adUnitId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdUnitId(adUnitId));
		}

		[Register("withAdUnitId", "(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithAdUnitId_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? WithAdUnitId(string? adUnitId)
		{
			nint num = JNIEnv.NewString(adUnitId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdUnitId.(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithAdUnitName_Ljava_lang_String_Handler()
		{
			if ((object)cb_withAdUnitName_WithAdUnitName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withAdUnitName_WithAdUnitName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithAdUnitName_Ljava_lang_String_));
			}
			return cb_withAdUnitName_WithAdUnitName_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithAdUnitName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_adUnitName)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string adUnitName = JNIEnv.GetString(native_adUnitName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithAdUnitName(adUnitName));
		}

		[Register("withAdUnitName", "(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithAdUnitName_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? WithAdUnitName(string? adUnitName)
		{
			nint num = JNIEnv.NewString(adUnitName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAdUnitName.(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithPayload_Ljava_util_Map_Handler()
		{
			if ((object)cb_withPayload_WithPayload_Ljava_util_Map__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withPayload_WithPayload_Ljava_util_Map__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithPayload_Ljava_util_Map_));
			}
			return cb_withPayload_WithPayload_Ljava_util_Map__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithPayload_Ljava_util_Map_(nint jnienv, nint native__this, nint native_payload)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, string> payload = JavaDictionary<string, string>.FromJniHandle(native_payload, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithPayload(payload));
		}

		[Register("withPayload", "(Ljava/util/Map;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithPayload_Ljava_util_Map_Handler")]
		public unsafe virtual Builder? WithPayload(IDictionary<string, string>? payload)
		{
			nint num = JavaDictionary<string, string>.ToLocalJniHandle(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withPayload.(Ljava/util/Map;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(payload);
			}
		}

		private static Delegate GetWithPrecision_Ljava_lang_String_Handler()
		{
			if ((object)cb_withPrecision_WithPrecision_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ == null)
			{
				cb_withPrecision_WithPrecision_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithPrecision_Ljava_lang_String_));
			}
			return cb_withPrecision_WithPrecision_Ljava_lang_String__Lio_appmetrica_analytics_AdRevenue_Builder_;
		}

		private static nint n_WithPrecision_Ljava_lang_String_(nint jnienv, nint native__this, nint native_precision)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string precision = JNIEnv.GetString(native_precision, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithPrecision(precision));
		}

		[Register("withPrecision", "(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", "GetWithPrecision_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? WithPrecision(string? precision)
		{
			nint num = JNIEnv.NewString(precision);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withPrecision.(Ljava/lang/String;)Lio/appmetrica/analytics/AdRevenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/AdRevenue", typeof(AdRevenue));

	[Register("adNetwork")]
	public string? AdNetwork
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("adNetwork.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("adNetwork.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("adPlacementId")]
	public string? AdPlacementId
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("adPlacementId.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("adPlacementId.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("adPlacementName")]
	public string? AdPlacementName
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("adPlacementName.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("adPlacementName.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("AdvRevenue")]
	public BigDecimal AdvRevenue
	{
		get
		{
			return Java.Lang.Object.GetObject<BigDecimal>(_members.InstanceFields.GetObjectValue("AdvRevenue.Ljava/math/BigDecimal;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("AdvRevenue.Ljava/math/BigDecimal;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("adType")]
	public AdType? AdType
	{
		get
		{
			return Java.Lang.Object.GetObject<AdType>(_members.InstanceFields.GetObjectValue("adType.Lio/appmetrica/analytics/AdType;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("adType.Lio/appmetrica/analytics/AdType;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("adUnitId")]
	public string? AdUnitId
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("adUnitId.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("adUnitId.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("adUnitName")]
	public string? AdUnitName
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("adUnitName.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("adUnitName.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("currency")]
	public Currency Currency
	{
		get
		{
			return Java.Lang.Object.GetObject<Currency>(_members.InstanceFields.GetObjectValue("currency.Ljava/util/Currency;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("currency.Ljava/util/Currency;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("payload")]
	public IDictionary? Payload
	{
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("payload.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaDictionary.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("payload.Ljava/util/Map;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("precision")]
	public string? Precision
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("precision.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("precision.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	protected AdRevenue(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("newBuilder", "(DLjava/util/Currency;)Lio/appmetrica/analytics/AdRevenue$Builder;", "")]
	public unsafe static Builder? NewBuilder(double adRevenue, Currency currency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(adRevenue);
			ptr[1] = new JniArgumentValue(currency?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(DLjava/util/Currency;)Lio/appmetrica/analytics/AdRevenue$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(currency);
		}
	}

	[Register("newBuilder", "(Ljava/math/BigDecimal;Ljava/util/Currency;)Lio/appmetrica/analytics/AdRevenue$Builder;", "")]
	public unsafe static Builder? NewBuilder(BigDecimal adRevenue, Currency currency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(adRevenue?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(currency?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(Ljava/math/BigDecimal;Ljava/util/Currency;)Lio/appmetrica/analytics/AdRevenue$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(adRevenue);
			GC.KeepAlive(currency);
		}
	}

	[Register("newBuilder", "(JLjava/util/Currency;)Lio/appmetrica/analytics/AdRevenue$Builder;", "")]
	public unsafe static Builder? NewBuilder(long adRevenueMicros, Currency currency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(adRevenueMicros);
			ptr[1] = new JniArgumentValue(currency?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(JLjava/util/Currency;)Lio/appmetrica/analytics/AdRevenue$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(currency);
		}
	}
}
