using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Bitmap", DoNotGenerateAcw = true)]
public sealed class Bitmap : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private enum NdkError
	{
		Success = 0,
		BadParameter = -1,
		JniException = -2,
		AllocationFailed = -3
	}

	[Register("android/graphics/Bitmap$CompressFormat", DoNotGenerateAcw = true)]
	public sealed class CompressFormat : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Bitmap$CompressFormat", typeof(CompressFormat));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal CompressFormat(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/graphics/Bitmap$Config", DoNotGenerateAcw = true)]
	public sealed class Config : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Bitmap$Config", typeof(Config));

		[Register("ARGB_8888")]
		public static Config? Argb8888 => Java.Lang.Object.GetObject<Config>(_members.StaticFields.GetObjectValue("ARGB_8888.Landroid/graphics/Bitmap$Config;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Config(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Bitmap", typeof(Bitmap));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe int Height
	{
		[Register("getHeight", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
		}
	}

	public unsafe bool IsRecycled
	{
		[Register("isRecycled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRecycled.()Z", this, null);
		}
	}

	public unsafe int Width
	{
		[Register("getWidth", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getWidth.()I", this, null);
		}
	}

	private static void CheckNdkError(string method, int r)
	{
		switch ((NdkError)r)
		{
		case NdkError.BadParameter:
			throw new ArgumentException(method + " failed! error=" + r);
		case NdkError.AllocationFailed:
		case NdkError.JniException:
		{
			NdkError ndkError = (NdkError)r;
			throw new InvalidOperationException(method + " failed! error=" + ndkError);
		}
		default:
			throw new InvalidOperationException(method + " failed! error=" + r);
		case NdkError.Success:
			break;
		}
	}

	public nint LockPixels()
	{
		nint addrPtr;
		int r = JNIEnv.AndroidBitmap_lockPixels(base.Handle, out addrPtr);
		CheckNdkError("AndroidBitmap_lockPixels", r);
		return addrPtr;
	}

	public void UnlockPixels()
	{
		int r = JNIEnv.AndroidBitmap_unlockPixels(base.Handle);
		CheckNdkError("AndroidBitmap_unlockPixels", r);
	}

	internal Bitmap(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("createBitmap", "(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;", "")]
	public unsafe static Bitmap CreateBitmap(int width, int height, Config config)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			ptr[2] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Bitmap>(_members.StaticMethods.InvokeObjectMethod("createBitmap.(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(config);
		}
	}

	[Register("describeContents", "()I", "")]
	public unsafe int DescribeContents()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
	}

	[Register("eraseColor", "(I)V", "")]
	public unsafe void EraseColor(int c)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(c);
		_members.InstanceMethods.InvokeAbstractVoidMethod("eraseColor.(I)V", this, ptr);
	}

	[Register("recycle", "()V", "")]
	public unsafe void Recycle()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("recycle.()V", this, null);
	}

	[Register("setPixels", "([IIIIIII)V", "")]
	public unsafe void SetPixels(int[] pixels, int offset, int stride, int x, int y, int width, int height)
	{
		nint num = JNIEnv.NewArray(pixels);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(offset);
			ptr[2] = new JniArgumentValue(stride);
			ptr[3] = new JniArgumentValue(x);
			ptr[4] = new JniArgumentValue(y);
			ptr[5] = new JniArgumentValue(width);
			ptr[6] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setPixels.([IIIIIII)V", this, ptr);
		}
		finally
		{
			if (pixels != null)
			{
				JNIEnv.CopyArray(num, pixels);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(pixels);
		}
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe void WriteToParcel(Parcel p, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
