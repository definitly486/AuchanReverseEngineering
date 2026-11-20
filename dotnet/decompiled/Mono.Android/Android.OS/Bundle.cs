using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Bundle", DoNotGenerateAcw = true)]
public sealed class Bundle : BaseBundle, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Bundle", typeof(Bundle));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal Bundle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Bundle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/os/Bundle;)V", "")]
	public unsafe Bundle(Bundle? b)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Bundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(b);
		}
	}

	[Register(".ctor", "(Landroid/os/PersistableBundle;)V", "")]
	public unsafe Bundle(PersistableBundle? b)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/PersistableBundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/os/PersistableBundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(b);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe Bundle(int capacity)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(capacity);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	[Register(".ctor", "(Ljava/lang/ClassLoader;)V", "")]
	public unsafe Bundle(ClassLoader? loader)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(loader?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/ClassLoader;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/ClassLoader;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(loader);
		}
	}

	[Register("containsKey", "(Ljava/lang/String;)Z", "")]
	public unsafe override bool ContainsKey(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("containsKey.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("describeContents", "()I", "")]
	public unsafe int DescribeContents()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
	}

	[Register("getBoolean", "(Ljava/lang/String;Z)Z", "")]
	public unsafe override bool GetBoolean(string? key, bool defaultValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defaultValue ? ((sbyte)1) : ((sbyte)0));
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getBoolean.(Ljava/lang/String;Z)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getFloat", "(Ljava/lang/String;)F", "")]
	public unsafe float GetFloat(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getFloat.(Ljava/lang/String;)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getInt", "(Ljava/lang/String;I)I", "")]
	public unsafe override int GetInt(string? key, int defaultValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defaultValue);
			return _members.InstanceMethods.InvokeAbstractInt32Method("getInt.(Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getInt", "(Ljava/lang/String;)I", "")]
	public unsafe override int GetInt(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractInt32Method("getInt.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[ObsoletedOSPlatform("android33.0")]
	[Register("getParcelable", "(Ljava/lang/String;)Landroid/os/Parcelable;", "")]
	[JavaTypeParameters(new string[] { "T extends android.os.Parcelable" })]
	public unsafe Java.Lang.Object? GetParcelable(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getParcelable.(Ljava/lang/String;)Landroid/os/Parcelable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getString", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
	public unsafe override string? GetString(string? key, string? defaultValue)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(defaultValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getString.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register("getString", "(Ljava/lang/String;)Ljava/lang/String;", "")]
	public unsafe override string? GetString(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getString.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("putBoolean", "(Ljava/lang/String;Z)V", "")]
	public unsafe override void PutBoolean(string? key, bool value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("putBoolean.(Ljava/lang/String;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("putFloat", "(Ljava/lang/String;F)V", "")]
	public unsafe void PutFloat(string? key, float value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("putFloat.(Ljava/lang/String;F)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("putInt", "(Ljava/lang/String;I)V", "")]
	public unsafe override void PutInt(string? key, int value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("putInt.(Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("putParcelable", "(Ljava/lang/String;Landroid/os/Parcelable;)V", "")]
	public unsafe void PutParcelable(string? key, IParcelable? value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("putParcelable.(Ljava/lang/String;Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	[Register("putString", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe override void PutString(string? key, string? value)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("putString.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe void WriteToParcel(Parcel? parcel, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parcel);
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
