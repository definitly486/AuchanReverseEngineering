using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Graphics;
using Android.Runtime;
using Com.Scanflow.Datacapture.Barcode.Config;
using Com.Scanflow.Datacapture.Core.Camera;
using Com.Scanflow.Datacapture.Sfbarcode;
using Java.Interop;
using Java.Lang;

namespace Com.Scanflow.Datacapture.Barcode;

[Register("com/scanflow/datacapture/barcode/SFBarcodeCaptureSession", DoNotGenerateAcw = true)]
public sealed class SFBarcodeCaptureSession : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/barcode/SFBarcodeCaptureSession", typeof(SFBarcodeCaptureSession));

	[Register("INSTANCE")]
	public static SFBarcodeCaptureSession Instance => Java.Lang.Object.GetObject<SFBarcodeCaptureSession>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal SFBarcodeCaptureSession(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("changeScanMode", "(Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V", "")]
	public unsafe void ChangeScanMode(DecodeConfig decodeConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decodeConfig?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("changeScanMode.(Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decodeConfig);
		}
	}

	[Register("clearMatrixScannedList", "()V", "")]
	public unsafe void ClearMatrixScannedList()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("clearMatrixScannedList.()V", this, null);
	}

	[Register("createScanSession", "(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "")]
	public unsafe ScanflowReader CreateScanSession(Activity appContext, string SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, DecodeConfig decodeConfig)
	{
		nint num = JNIEnv.NewString(SCANFLOW_LICENSE_KEY);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(appContext?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(sfCameraView?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(decodeConfig?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("createScanSession.(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(appContext);
			GC.KeepAlive(sfCameraView);
			GC.KeepAlive(decodeConfig);
		}
	}

	[Register("createScanSession", "(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "")]
	public unsafe ScanflowReader CreateScanSession(Activity appContext, string SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, DecodeConfig decodeConfig, float setPreZoom)
	{
		nint num = JNIEnv.NewString(SCANFLOW_LICENSE_KEY);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(appContext?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(sfCameraView?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(decodeConfig?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(setPreZoom);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("createScanSession.(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(appContext);
			GC.KeepAlive(sfCameraView);
			GC.KeepAlive(decodeConfig);
		}
	}

	[Register("scanBitmap", "(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;", "")]
	public unsafe SFBarcodeReader ScanBitmap(Activity appContext, string SCANFLOW_LICENSE_KEY, DecodeConfig decodeConfig, SFBarcodeReader.IOnBarcodeScanResultCallback callback, Bitmap bitmap)
	{
		nint num = JNIEnv.NewString(SCANFLOW_LICENSE_KEY);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(appContext?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(decodeConfig?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[4] = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SFBarcodeReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("scanBitmap.(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(appContext);
			GC.KeepAlive(decodeConfig);
			GC.KeepAlive(callback);
			GC.KeepAlive(bitmap);
		}
	}
}
