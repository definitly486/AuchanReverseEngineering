using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Scanflow.Datacapture.Barcode;

[Register("com/scanflow/datacapture/barcode/SFBarcodeReader", DoNotGenerateAcw = true)]
internal class SFBarcodeReaderInvoker : SFBarcodeReader
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/barcode/SFBarcodeReader", typeof(SFBarcodeReaderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SFBarcodeReaderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("setOnBarcodeScanResultCallback", "(Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;", "GetSetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_barcode_SFBarcodeReader_OnBarcodeScanResultCallback_Handler")]
	public unsafe override SFBarcodeReader SetOnBarcodeScanResultCallback(IOnBarcodeScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<SFBarcodeReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnBarcodeScanResultCallback.(Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}
}
