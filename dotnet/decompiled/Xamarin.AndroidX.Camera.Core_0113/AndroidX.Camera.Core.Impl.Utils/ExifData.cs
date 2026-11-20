using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio;

namespace AndroidX.Camera.Core.Impl.Utils;

[Register("androidx/camera/core/impl/utils/ExifData", DoNotGenerateAcw = true)]
public class ExifData : Java.Lang.Object
{
	[Register("androidx/camera/core/impl/utils/ExifData$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/utils/ExifData$Builder", typeof(Builder));

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

		internal Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("build", "()Landroidx/camera/core/impl/utils/ExifData;", "")]
		public unsafe ExifData Build()
		{
			return Java.Lang.Object.GetObject<ExifData>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroidx/camera/core/impl/utils/ExifData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("removeAttribute", "(Ljava/lang/String;)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder RemoveAttribute(string tag)
		{
			nint num = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("removeAttribute.(Ljava/lang/String;)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("setAttribute", "(Ljava/lang/String;Ljava/lang/String;)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetAttribute(string tag, string value)
		{
			nint num = JNIEnv.NewString(tag);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAttribute.(Ljava/lang/String;Ljava/lang/String;)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}

		[Register("setExposureTimeNanos", "(J)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetExposureTimeNanos(long exposureTimeNs)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(exposureTimeNs);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExposureTimeNanos.(J)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setFlashState", "(Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetFlashState(CameraCaptureMetaData.FlashState flashState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(flashState?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFlashState.(Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flashState);
			}
		}

		[Register("setFocalLength", "(F)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetFocalLength(float focalLength)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(focalLength);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFocalLength.(F)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setImageHeight", "(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetImageHeight(int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(height);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setImageHeight.(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setImageWidth", "(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetImageWidth(int width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(width);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setImageWidth.(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setIso", "(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetIso(int iso)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(iso);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIso.(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setLensFNumber", "(F)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetLensFNumber(float fNumber)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fNumber);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLensFNumber.(F)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setOrientationDegrees", "(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetOrientationDegrees(int orientationDegrees)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientationDegrees);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOrientationDegrees.(I)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setWhiteBalanceMode", "(Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;)Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
		public unsafe Builder SetWhiteBalanceMode(WhiteBalanceMode whiteBalanceMode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(whiteBalanceMode?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setWhiteBalanceMode.(Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;)Landroidx/camera/core/impl/utils/ExifData$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(whiteBalanceMode);
			}
		}
	}

	[Register("androidx/camera/core/impl/utils/ExifData$WhiteBalanceMode", DoNotGenerateAcw = true)]
	public sealed class WhiteBalanceMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/utils/ExifData$WhiteBalanceMode", typeof(WhiteBalanceMode));

		[Register("AUTO")]
		public static WhiteBalanceMode? Auto => Java.Lang.Object.GetObject<WhiteBalanceMode>(_members.StaticFields.GetObjectValue("AUTO.Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MANUAL")]
		public static WhiteBalanceMode? Manual => Java.Lang.Object.GetObject<WhiteBalanceMode>(_members.StaticFields.GetObjectValue("MANUAL.Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal WhiteBalanceMode(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;", "")]
		public unsafe static WhiteBalanceMode? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<WhiteBalanceMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;", "")]
		public unsafe static WhiteBalanceMode[]? Values()
		{
			return (WhiteBalanceMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/utils/ExifData$WhiteBalanceMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(WhiteBalanceMode));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/utils/ExifData", typeof(ExifData));

	private static Delegate? cb_getByteOrder;

	private static Delegate? cb_getAttribute_Ljava_lang_String_;

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

	public unsafe virtual ByteOrder ByteOrder
	{
		[Register("getByteOrder", "()Ljava/nio/ByteOrder;", "GetGetByteOrderHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ByteOrder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getByteOrder.()Ljava/nio/ByteOrder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ExifData(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetByteOrderHandler()
	{
		if ((object)cb_getByteOrder == null)
		{
			cb_getByteOrder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetByteOrder));
		}
		return cb_getByteOrder;
	}

	private static nint n_GetByteOrder(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ExifData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ByteOrder);
	}

	[Register("builderForDevice", "()Landroidx/camera/core/impl/utils/ExifData$Builder;", "")]
	public unsafe static Builder BuilderForDevice()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builderForDevice.()Landroidx/camera/core/impl/utils/ExifData$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("create", "(Landroidx/camera/core/ImageProxy;I)Landroidx/camera/core/impl/utils/ExifData;", "")]
	public unsafe static ExifData Create(IImageProxy imageProxy, int rotationDegrees)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((imageProxy == null) ? IntPtr.Zero : ((Java.Lang.Object)imageProxy).Handle);
			ptr[1] = new JniArgumentValue(rotationDegrees);
			return Java.Lang.Object.GetObject<ExifData>(_members.StaticMethods.InvokeObjectMethod("create.(Landroidx/camera/core/ImageProxy;I)Landroidx/camera/core/impl/utils/ExifData;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(imageProxy);
		}
	}

	private static Delegate GetGetAttribute_Ljava_lang_String_Handler()
	{
		if ((object)cb_getAttribute_Ljava_lang_String_ == null)
		{
			cb_getAttribute_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetAttribute_Ljava_lang_String_));
		}
		return cb_getAttribute_Ljava_lang_String_;
	}

	private static nint n_GetAttribute_Ljava_lang_String_(nint jnienv, nint native__this, nint native_tag)
	{
		ExifData? exifData = Java.Lang.Object.GetObject<ExifData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.NewString(exifData.GetAttribute(tag));
	}

	[Register("getAttribute", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetAttribute_Ljava_lang_String_Handler")]
	public unsafe virtual string? GetAttribute(string tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAttribute.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
