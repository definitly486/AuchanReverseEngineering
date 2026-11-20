using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/StartupParamsCallback", "", "IO.Appmetrica.Analytics.IStartupParamsCallbackInvoker")]
public interface IStartupParamsCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("io/appmetrica/analytics/StartupParamsCallback$Reason", DoNotGenerateAcw = true)]
	public sealed class Reason : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/StartupParamsCallback$Reason", typeof(Reason));

		[Register("INVALID_RESPONSE")]
		public static Reason? InvalidResponse
		{
			get
			{
				return Java.Lang.Object.GetObject<Reason>(_members.StaticFields.GetObjectValue("INVALID_RESPONSE.Lio/appmetrica/analytics/StartupParamsCallback$Reason;").Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.StaticFields.SetValue("INVALID_RESPONSE.Lio/appmetrica/analytics/StartupParamsCallback$Reason;", new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("NETWORK")]
		public static Reason? Network
		{
			get
			{
				return Java.Lang.Object.GetObject<Reason>(_members.StaticFields.GetObjectValue("NETWORK.Lio/appmetrica/analytics/StartupParamsCallback$Reason;").Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.StaticFields.SetValue("NETWORK.Lio/appmetrica/analytics/StartupParamsCallback$Reason;", new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("UNKNOWN")]
		public static Reason? Unknown
		{
			get
			{
				return Java.Lang.Object.GetObject<Reason>(_members.StaticFields.GetObjectValue("UNKNOWN.Lio/appmetrica/analytics/StartupParamsCallback$Reason;").Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.StaticFields.SetValue("UNKNOWN.Lio/appmetrica/analytics/StartupParamsCallback$Reason;", new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("value")]
		public string Value
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("value.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("value.Ljava/lang/String;", this, new JniObjectReference(num));
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

		internal Reason(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe Reason(string value)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("io/appmetrica/analytics/StartupParamsCallback$Result", DoNotGenerateAcw = true)]
	public sealed class Result : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/StartupParamsCallback$Result", typeof(Result));

		[Register("deviceId")]
		public string? DeviceId
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("deviceId.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("deviceId.Ljava/lang/String;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("deviceIdHash")]
		public string? DeviceIdHash
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("deviceIdHash.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("deviceIdHash.Ljava/lang/String;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("parameters")]
		public IDictionary Parameters
		{
			get
			{
				return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("parameters.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JavaDictionary.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("parameters.Ljava/util/Map;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("uuid")]
		public string? Uuid
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("uuid.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("uuid.Ljava/lang/String;", this, new JniObjectReference(num));
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

		internal Result(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/Map;)V", "")]
		public unsafe Result(IDictionary<string, StartupParamsItem> parameters)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JavaDictionary<string, StartupParamsItem>.ToLocalJniHandle(parameters);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Map;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parameters);
			}
		}

		[Register("parameterForKey", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string? ParameterForKey(string key)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parameterForKey.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("onReceive", "(Lio/appmetrica/analytics/StartupParamsCallback$Result;)V", "GetOnReceive_Lio_appmetrica_analytics_StartupParamsCallback_Result_Handler:IO.Appmetrica.Analytics.IStartupParamsCallbackInvoker, Appmetrica.Android")]
	void OnReceive(Result? p0);

	[Register("onRequestError", "(Lio/appmetrica/analytics/StartupParamsCallback$Reason;Lio/appmetrica/analytics/StartupParamsCallback$Result;)V", "GetOnRequestError_Lio_appmetrica_analytics_StartupParamsCallback_Reason_Lio_appmetrica_analytics_StartupParamsCallback_Result_Handler:IO.Appmetrica.Analytics.IStartupParamsCallbackInvoker, Appmetrica.Android")]
	void OnRequestError(Reason p0, Result? p1);
}
