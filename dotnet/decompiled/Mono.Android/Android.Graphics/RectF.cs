using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/RectF", DoNotGenerateAcw = true)]
public class RectF : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/RectF", typeof(RectF));

	private static Delegate? cb_describeContents_DescribeContents_I;

	private static Delegate? cb_inset_Inset_FF_V;

	private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

	[Register("bottom")]
	public float Bottom
	{
		set
		{
			_members.InstanceFields.SetValue("bottom.F", this, value);
		}
	}

	[Register("left")]
	public float Left
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("left.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("left.F", this, value);
		}
	}

	[Register("right")]
	public float Right
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("right.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("right.F", this, value);
		}
	}

	[Register("top")]
	public float Top
	{
		set
		{
			_members.InstanceFields.SetValue("top.F", this, value);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected RectF(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/graphics/Rect;)V", "")]
	public unsafe RectF(Rect? r)
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

	[Register(".ctor", "(FFFF)V", "")]
	public unsafe RectF(float left, float top, float right, float bottom)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FFFF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FFFF)V", this, ptr);
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
			return Java.Lang.Object.GetObject<RectF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

	[Register("describeContents", "()I", "GetDescribeContentsHandler")]
	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	private static Delegate GetInset_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_Inset_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Inset_FF(nint jnienv, nint native__this, float dx, float dy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RectF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Inset(dx, dy);
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

	[Register("inset", "(FF)V", "GetInset_FFHandler")]
	public unsafe virtual void Inset(float dx, float dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("inset.(FF)V", this, ptr);
	}

	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native__out, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RectF? rectF = Java.Lang.Object.GetObject<RectF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			rectF.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
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

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
	public unsafe virtual void WriteToParcel(Parcel? @out, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@out);
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
