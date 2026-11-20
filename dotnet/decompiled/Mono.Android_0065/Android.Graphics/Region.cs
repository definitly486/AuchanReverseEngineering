using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Region", DoNotGenerateAcw = true)]
public class Region : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Region", typeof(Region));

	private static Delegate? cb_describeContents_DescribeContents_I;

	private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Region(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe Region()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	public unsafe Region(Rect r)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/Rect;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(r);
		}
	}

	public unsafe Region(Region region)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(region?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/Region;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/Region;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(region);
		}
	}

	public unsafe Region(int left, int top, int right, int bottom)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
		}
	}

	private static Delegate GetDescribeContentsHandler()
	{
		return new _JniMarshal_PP_I(n_DescribeContents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_DescribeContents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_p, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Region? region = Java.Lang.Object.GetObject<Region>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel p = Java.Lang.Object.GetObject<Parcel>(native_p, JniHandleOwnership.DoNotTransfer);
			region.WriteToParcel(p, (ParcelableWriteFlags)native_flags);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual void WriteToParcel(Parcel? p, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
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
