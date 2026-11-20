using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Scanflow.Datacapture.Model;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace Com.Scanflow.Datacapture.Barcode;

[Register("com/scanflow/datacapture/barcode/SFBarcodeReader", DoNotGenerateAcw = true)]
public abstract class SFBarcodeReader : Java.Lang.Object
{
	[Register("com/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback", "", "Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker")]
	public interface IOnBarcodeScanResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onBatchScanResultSuccess", "(Ljava/util/ArrayList;)V", "GetOnBatchScanResultSuccess_Ljava_util_ArrayList_Handler:Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.BarcodeCapture.Maui.Android")]
		void OnBatchScanResultSuccess(IList<ScanResultSuccess> result);

		[Register("onOneOfManyCodeResult", "(Ljava/util/HashSet;)V", "GetOnOneOfManyCodeResult_Ljava_util_HashSet_Handler:Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.BarcodeCapture.Maui.Android")]
		void OnOneOfManyCodeResult(HashSet results);

		[Register("onOneofManyCodeRemoved", "(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", "GetOnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_Handler:Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.BarcodeCapture.Maui.Android")]
		void OnOneofManyCodeRemoved(OneOFManyCodesScanResults result);

		[Register("onOneofManyCodeSelected", "(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", "GetOnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_Handler:Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.BarcodeCapture.Maui.Android")]
		void OnOneofManyCodeSelected(OneOFManyCodesScanResults result);

		[Register("onScanBarcodeDetection", "(Z)V", "GetOnScanBarcodeDetection_ZHandler:Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.BarcodeCapture.Maui.Android")]
		void OnScanBarcodeDetection(bool isDetected);

		[Register("onScanResultFailure", "(Ljava/lang/String;)V", "GetOnScanResultFailure_Ljava_lang_String_Handler:Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.BarcodeCapture.Maui.Android")]
		void OnScanResultFailure(string error);

		[Register("onScanResultSuccess", "(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V", "GetOnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess_Handler:Com.Scanflow.Datacapture.Barcode.SFBarcodeReader/IOnBarcodeScanResultCallbackInvoker, Scanflow.BarcodeCapture.Maui.Android")]
		void OnScanResultSuccess(ScanResultSuccess result);
	}

	[Register("com/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback", DoNotGenerateAcw = true)]
	internal class IOnBarcodeScanResultCallbackInvoker : Java.Lang.Object, IOnBarcodeScanResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback = new XAPeerMembers("com/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback", typeof(IOnBarcodeScanResultCallbackInvoker));

		private static Delegate? cb_onBatchScanResultSuccess_OnBatchScanResultSuccess_Ljava_util_ArrayList__V;

		private static Delegate? cb_onOneOfManyCodeResult_OnOneOfManyCodeResult_Ljava_util_HashSet__V;

		private static Delegate? cb_onOneofManyCodeRemoved_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V;

		private static Delegate? cb_onOneofManyCodeSelected_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V;

		private static Delegate? cb_onScanBarcodeDetection_OnScanBarcodeDetection_Z_V;

		private static Delegate? cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;

		private static Delegate? cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess__V;

		private static nint java_class_ref => _members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.ManagedPeerType;

		public IOnBarcodeScanResultCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnBatchScanResultSuccess_Ljava_util_ArrayList_Handler()
		{
			if ((object)cb_onBatchScanResultSuccess_OnBatchScanResultSuccess_Ljava_util_ArrayList__V == null)
			{
				cb_onBatchScanResultSuccess_OnBatchScanResultSuccess_Ljava_util_ArrayList__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnBatchScanResultSuccess_Ljava_util_ArrayList_));
			}
			return cb_onBatchScanResultSuccess_OnBatchScanResultSuccess_Ljava_util_ArrayList__V;
		}

		private static void n_OnBatchScanResultSuccess_Ljava_util_ArrayList_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<ScanResultSuccess> result = JavaList<ScanResultSuccess>.FromJniHandle(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnBatchScanResultSuccess(result);
		}

		public unsafe void OnBatchScanResultSuccess(IList<ScanResultSuccess> result)
		{
			nint num = JavaList<ScanResultSuccess>.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onBatchScanResultSuccess.(Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetOnOneOfManyCodeResult_Ljava_util_HashSet_Handler()
		{
			if ((object)cb_onOneOfManyCodeResult_OnOneOfManyCodeResult_Ljava_util_HashSet__V == null)
			{
				cb_onOneOfManyCodeResult_OnOneOfManyCodeResult_Ljava_util_HashSet__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOneOfManyCodeResult_Ljava_util_HashSet_));
			}
			return cb_onOneOfManyCodeResult_OnOneOfManyCodeResult_Ljava_util_HashSet__V;
		}

		private static void n_OnOneOfManyCodeResult_Ljava_util_HashSet_(nint jnienv, nint native__this, nint native_results)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			HashSet results = Java.Lang.Object.GetObject<HashSet>(native_results, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnOneOfManyCodeResult(results);
		}

		public unsafe void OnOneOfManyCodeResult(HashSet results)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(results?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onOneOfManyCodeResult.(Ljava/util/HashSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(results);
			}
		}

		private static Delegate GetOnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_Handler()
		{
			if ((object)cb_onOneofManyCodeRemoved_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V == null)
			{
				cb_onOneofManyCodeRemoved_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_));
			}
			return cb_onOneofManyCodeRemoved_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V;
		}

		private static void n_OnOneofManyCodeRemoved_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OneOFManyCodesScanResults result = Java.Lang.Object.GetObject<OneOFManyCodesScanResults>(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnOneofManyCodeRemoved(result);
		}

		public unsafe void OnOneofManyCodeRemoved(OneOFManyCodesScanResults result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onOneofManyCodeRemoved.(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetOnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_Handler()
		{
			if ((object)cb_onOneofManyCodeSelected_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V == null)
			{
				cb_onOneofManyCodeSelected_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_));
			}
			return cb_onOneofManyCodeSelected_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults__V;
		}

		private static void n_OnOneofManyCodeSelected_Lcom_scanflow_datacapture_model_OneOFManyCodesScanResults_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OneOFManyCodesScanResults result = Java.Lang.Object.GetObject<OneOFManyCodesScanResults>(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnOneofManyCodeSelected(result);
		}

		public unsafe void OnOneofManyCodeSelected(OneOFManyCodesScanResults result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onOneofManyCodeSelected.(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetOnScanBarcodeDetection_ZHandler()
		{
			if ((object)cb_onScanBarcodeDetection_OnScanBarcodeDetection_Z_V == null)
			{
				cb_onScanBarcodeDetection_OnScanBarcodeDetection_Z_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnScanBarcodeDetection_Z));
			}
			return cb_onScanBarcodeDetection_OnScanBarcodeDetection_Z_V;
		}

		private static void n_OnScanBarcodeDetection_Z(nint jnienv, nint native__this, bool isDetected)
		{
			Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScanBarcodeDetection(isDetected);
		}

		public unsafe void OnScanBarcodeDetection(bool isDetected)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isDetected);
			_members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanBarcodeDetection.(Z)V", this, ptr);
		}

		private static Delegate GetOnScanResultFailure_Ljava_lang_String_Handler()
		{
			if ((object)cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V == null)
			{
				cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultFailure_Ljava_lang_String_));
			}
			return cb_onScanResultFailure_OnScanResultFailure_Ljava_lang_String__V;
		}

		private static void n_OnScanResultFailure_Ljava_lang_String_(nint jnienv, nint native__this, nint native_error)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnScanResultFailure(error);
		}

		public unsafe void OnScanResultFailure(string error)
		{
			nint num = JNIEnv.NewString(error);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultFailure.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetOnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess_Handler()
		{
			if ((object)cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess__V == null)
			{
				cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess_));
			}
			return cb_onScanResultSuccess_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess__V;
		}

		private static void n_OnScanResultSuccess_Lcom_scanflow_datacapture_model_ScanResultSuccess_(nint jnienv, nint native__this, nint native_result)
		{
			IOnBarcodeScanResultCallback? onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ScanResultSuccess result = Java.Lang.Object.GetObject<ScanResultSuccess>(native_result, JniHandleOwnership.DoNotTransfer);
			onBarcodeScanResultCallback.OnScanResultSuccess(result);
		}

		public unsafe void OnScanResultSuccess(ScanResultSuccess result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members_com_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback.InstanceMethods.InvokeAbstractVoidMethod("onScanResultSuccess.(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/barcode/SFBarcodeReader", typeof(SFBarcodeReader));

	private static Delegate? cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_barcode_SFBarcodeReader_;

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

	protected SFBarcodeReader(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SFBarcodeReader()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetSetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback_Handler()
	{
		if ((object)cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_barcode_SFBarcodeReader_ == null)
		{
			cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_barcode_SFBarcodeReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback_));
		}
		return cb_setOnBarcodeScanResultCallback_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback__Lcom_scanflow_datacapture_barcode_SFBarcodeReader_;
	}

	private static nint n_SetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		SFBarcodeReader? sFBarcodeReader = Java.Lang.Object.GetObject<SFBarcodeReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnBarcodeScanResultCallback onBarcodeScanResultCallback = Java.Lang.Object.GetObject<IOnBarcodeScanResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(sFBarcodeReader.SetOnBarcodeScanResultCallback(onBarcodeScanResultCallback));
	}

	[Register("setOnBarcodeScanResultCallback", "(Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;", "GetSetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback_Handler")]
	public abstract SFBarcodeReader SetOnBarcodeScanResultCallback(IOnBarcodeScanResultCallback callback);
}
