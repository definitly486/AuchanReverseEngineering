using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/DeferredDeeplinkParametersListener", "", "IO.Appmetrica.Analytics.IDeferredDeeplinkParametersListenerInvoker")]
public interface IDeferredDeeplinkParametersListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("io/appmetrica/analytics/DeferredDeeplinkParametersListener$Error", DoNotGenerateAcw = true)]
	public sealed class Error : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/DeferredDeeplinkParametersListener$Error", typeof(Error));

		[Register("NOT_A_FIRST_LAUNCH")]
		public static Error? NotAFirstLaunch => Java.Lang.Object.GetObject<Error>(_members.StaticFields.GetObjectValue("NOT_A_FIRST_LAUNCH.Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NO_REFERRER")]
		public static Error? NoReferrer => Java.Lang.Object.GetObject<Error>(_members.StaticFields.GetObjectValue("NO_REFERRER.Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PARSE_ERROR")]
		public static Error? ParseError => Java.Lang.Object.GetObject<Error>(_members.StaticFields.GetObjectValue("PARSE_ERROR.Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static Error? Unknown => Java.Lang.Object.GetObject<Error>(_members.StaticFields.GetObjectValue("UNKNOWN.Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string? Description
		{
			[Register("getDescription", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Error(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;", "")]
		public unsafe static Error? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Error>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;", "")]
		public unsafe static Error[]? Values()
		{
			return (Error[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Error));
		}
	}

	[Register("onError", "(Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;Ljava/lang/String;)V", "GetOnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String_Handler:IO.Appmetrica.Analytics.IDeferredDeeplinkParametersListenerInvoker, Appmetrica.Android")]
	void OnError(Error p0, string p1);

	[Register("onParametersLoaded", "(Ljava/util/Map;)V", "GetOnParametersLoaded_Ljava_util_Map_Handler:IO.Appmetrica.Analytics.IDeferredDeeplinkParametersListenerInvoker, Appmetrica.Android")]
	void OnParametersLoaded(IDictionary<string, string> p0);
}
