using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Xamarin.TensorFlow.Lite;

[Register("org/tensorflow/lite/DataType", DoNotGenerateAcw = true)]
public sealed class DataType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("org/tensorflow/lite/DataType", typeof(DataType));

	[Register("BOOL")]
	public static DataType? Bool => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("BOOL.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FLOAT32")]
	public static DataType? Float32 => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("FLOAT32.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INT16")]
	public static DataType? Int16 => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("INT16.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INT32")]
	public static DataType? Int32 => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("INT32.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INT64")]
	public static DataType? Int64 => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("INT64.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INT8")]
	public static DataType? Int8 => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("INT8.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("STRING")]
	public static DataType? String => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("STRING.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UINT8")]
	public static DataType? Uint8 => Java.Lang.Object.GetObject<DataType>(_members.StaticFields.GetObjectValue("UINT8.Lorg/tensorflow/lite/DataType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal DataType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("byteSize", "()I", "")]
	public unsafe int ByteSize()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("byteSize.()I", this, null);
	}

	[Register("valueOf", "(Ljava/lang/String;)Lorg/tensorflow/lite/DataType;", "")]
	public unsafe static DataType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<DataType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lorg/tensorflow/lite/DataType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lorg/tensorflow/lite/DataType;", "")]
	public unsafe static DataType[]? Values()
	{
		return (DataType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lorg/tensorflow/lite/DataType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DataType));
	}
}
