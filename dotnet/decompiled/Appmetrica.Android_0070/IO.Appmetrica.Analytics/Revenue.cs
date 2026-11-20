using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/Revenue", DoNotGenerateAcw = true)]
public class Revenue : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/Revenue$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/Revenue$Builder", typeof(Builder));

		private static Delegate? cb_build_Build_Lio_appmetrica_analytics_Revenue_;

		private static Delegate? cb_withPayload_WithPayload_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_;

		private static Delegate? cb_withProductID_WithProductID_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_;

		private static Delegate? cb_withQuantity_WithQuantity_Ljava_lang_Integer__Lio_appmetrica_analytics_Revenue_Builder_;

		private static Delegate? cb_withReceipt_WithReceipt_Lio_appmetrica_analytics_Revenue_Receipt__Lio_appmetrica_analytics_Revenue_Builder_;

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
			if ((object)cb_build_Build_Lio_appmetrica_analytics_Revenue_ == null)
			{
				cb_build_Build_Lio_appmetrica_analytics_Revenue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build_Build_Lio_appmetrica_analytics_Revenue_;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lio/appmetrica/analytics/Revenue;", "GetBuildHandler")]
		public unsafe virtual Revenue Build()
		{
			return Java.Lang.Object.GetObject<Revenue>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/Revenue;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithPayload_Ljava_lang_String_Handler()
		{
			if ((object)cb_withPayload_WithPayload_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_ == null)
			{
				cb_withPayload_WithPayload_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithPayload_Ljava_lang_String_));
			}
			return cb_withPayload_WithPayload_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_;
		}

		private static nint n_WithPayload_Ljava_lang_String_(nint jnienv, nint native__this, nint native_payload)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string payload = JNIEnv.GetString(native_payload, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithPayload(payload));
		}

		[Register("withPayload", "(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Builder;", "GetWithPayload_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithPayload(string? payload)
		{
			nint num = JNIEnv.NewString(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withPayload.(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithProductID_Ljava_lang_String_Handler()
		{
			if ((object)cb_withProductID_WithProductID_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_ == null)
			{
				cb_withProductID_WithProductID_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithProductID_Ljava_lang_String_));
			}
			return cb_withProductID_WithProductID_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Builder_;
		}

		private static nint n_WithProductID_Ljava_lang_String_(nint jnienv, nint native__this, nint native_productID)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string productID = JNIEnv.GetString(native_productID, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithProductID(productID));
		}

		[Register("withProductID", "(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Builder;", "GetWithProductID_Ljava_lang_String_Handler")]
		public unsafe virtual Builder WithProductID(string? productID)
		{
			nint num = JNIEnv.NewString(productID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withProductID.(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetWithQuantity_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_withQuantity_WithQuantity_Ljava_lang_Integer__Lio_appmetrica_analytics_Revenue_Builder_ == null)
			{
				cb_withQuantity_WithQuantity_Ljava_lang_Integer__Lio_appmetrica_analytics_Revenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithQuantity_Ljava_lang_Integer_));
			}
			return cb_withQuantity_WithQuantity_Ljava_lang_Integer__Lio_appmetrica_analytics_Revenue_Builder_;
		}

		private static nint n_WithQuantity_Ljava_lang_Integer_(nint jnienv, nint native__this, nint native_quantity)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer quantity = Java.Lang.Object.GetObject<Integer>(native_quantity, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithQuantity(quantity));
		}

		[Register("withQuantity", "(Ljava/lang/Integer;)Lio/appmetrica/analytics/Revenue$Builder;", "GetWithQuantity_Ljava_lang_Integer_Handler")]
		public unsafe virtual Builder WithQuantity(Integer? quantity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(quantity?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withQuantity.(Ljava/lang/Integer;)Lio/appmetrica/analytics/Revenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(quantity);
			}
		}

		private static Delegate GetWithReceipt_Lio_appmetrica_analytics_Revenue_Receipt_Handler()
		{
			if ((object)cb_withReceipt_WithReceipt_Lio_appmetrica_analytics_Revenue_Receipt__Lio_appmetrica_analytics_Revenue_Builder_ == null)
			{
				cb_withReceipt_WithReceipt_Lio_appmetrica_analytics_Revenue_Receipt__Lio_appmetrica_analytics_Revenue_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithReceipt_Lio_appmetrica_analytics_Revenue_Receipt_));
			}
			return cb_withReceipt_WithReceipt_Lio_appmetrica_analytics_Revenue_Receipt__Lio_appmetrica_analytics_Revenue_Builder_;
		}

		private static nint n_WithReceipt_Lio_appmetrica_analytics_Revenue_Receipt_(nint jnienv, nint native__this, nint native_receipt)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Receipt receipt = Java.Lang.Object.GetObject<Receipt>(native_receipt, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.WithReceipt(receipt));
		}

		[Register("withReceipt", "(Lio/appmetrica/analytics/Revenue$Receipt;)Lio/appmetrica/analytics/Revenue$Builder;", "GetWithReceipt_Lio_appmetrica_analytics_Revenue_Receipt_Handler")]
		public unsafe virtual Builder WithReceipt(Receipt? receipt)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(receipt?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withReceipt.(Lio/appmetrica/analytics/Revenue$Receipt;)Lio/appmetrica/analytics/Revenue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(receipt);
			}
		}
	}

	[Register("io/appmetrica/analytics/Revenue$Receipt", DoNotGenerateAcw = true)]
	public class Receipt : Java.Lang.Object
	{
		[Register("io/appmetrica/analytics/Revenue$Receipt$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/Revenue$Receipt$Builder", typeof(Builder));

			private static Delegate? cb_build_Build_Lio_appmetrica_analytics_Revenue_Receipt_;

			private static Delegate? cb_withData_WithData_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_;

			private static Delegate? cb_withSignature_WithSignature_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_;

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
				if ((object)cb_build_Build_Lio_appmetrica_analytics_Revenue_Receipt_ == null)
				{
					cb_build_Build_Lio_appmetrica_analytics_Revenue_Receipt_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
				}
				return cb_build_Build_Lio_appmetrica_analytics_Revenue_Receipt_;
			}

			private static nint n_Build(nint jnienv, nint native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lio/appmetrica/analytics/Revenue$Receipt;", "GetBuildHandler")]
			public unsafe virtual Receipt Build()
			{
				return Java.Lang.Object.GetObject<Receipt>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lio/appmetrica/analytics/Revenue$Receipt;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetWithData_Ljava_lang_String_Handler()
			{
				if ((object)cb_withData_WithData_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_ == null)
				{
					cb_withData_WithData_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithData_Ljava_lang_String_));
				}
				return cb_withData_WithData_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_;
			}

			private static nint n_WithData_Ljava_lang_String_(nint jnienv, nint native__this, nint native_data)
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string data = JNIEnv.GetString(native_data, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.WithData(data));
			}

			[Register("withData", "(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Receipt$Builder;", "GetWithData_Ljava_lang_String_Handler")]
			public unsafe virtual Builder WithData(string? data)
			{
				nint num = JNIEnv.NewString(data);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withData.(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Receipt$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}

			private static Delegate GetWithSignature_Ljava_lang_String_Handler()
			{
				if ((object)cb_withSignature_WithSignature_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_ == null)
				{
					cb_withSignature_WithSignature_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithSignature_Ljava_lang_String_));
				}
				return cb_withSignature_WithSignature_Ljava_lang_String__Lio_appmetrica_analytics_Revenue_Receipt_Builder_;
			}

			private static nint n_WithSignature_Ljava_lang_String_(nint jnienv, nint native__this, nint native_signature)
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string signature = JNIEnv.GetString(native_signature, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.WithSignature(signature));
			}

			[Register("withSignature", "(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Receipt$Builder;", "GetWithSignature_Ljava_lang_String_Handler")]
			public unsafe virtual Builder WithSignature(string? signature)
			{
				nint num = JNIEnv.NewString(signature);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withSignature.(Ljava/lang/String;)Lio/appmetrica/analytics/Revenue$Receipt$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/Revenue$Receipt", typeof(Receipt));

		[Register("data")]
		public string? Data
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("data.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("data.Ljava/lang/String;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("signature")]
		public string? Signature
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("signature.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("signature.Ljava/lang/String;", this, new JniObjectReference(num));
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

		protected Receipt(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newBuilder", "()Lio/appmetrica/analytics/Revenue$Receipt$Builder;", "")]
		public unsafe static Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lio/appmetrica/analytics/Revenue$Receipt$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/Revenue", typeof(Revenue));

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
	public string? Payload
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("payload.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("payload.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("priceMicros")]
	public long PriceMicros
	{
		get
		{
			return _members.InstanceFields.GetInt64Value("priceMicros.J", this);
		}
		set
		{
			_members.InstanceFields.SetValue("priceMicros.J", this, value);
		}
	}

	[Register("productID")]
	public string? ProductID
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("productID.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("productID.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("quantity")]
	public Integer? Quantity
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("quantity.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("quantity.Ljava/lang/Integer;", this, new JniObjectReference(num));
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

	protected Revenue(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("newBuilder", "(JLjava/util/Currency;)Lio/appmetrica/analytics/Revenue$Builder;", "")]
	public unsafe static Builder NewBuilder(long priceMicros, Currency currency)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(priceMicros);
			ptr[1] = new JniArgumentValue(currency?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(JLjava/util/Currency;)Lio/appmetrica/analytics/Revenue$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(currency);
		}
	}
}
