using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/ViewState", DoNotGenerateAcw = true)]
public class ViewState : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/ViewState", typeof(ViewState));

	private static Delegate? cb_getState_GetState_Landroidx_constraintlayout_core_motion_MotionWidget__V;

	private static Delegate? cb_height_Height_I;

	private static Delegate? cb_width_Width_I;

	[Register("bottom")]
	public int Bottom
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("bottom.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("bottom.I", this, value);
		}
	}

	[Register("left")]
	public int Left
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("left.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("left.I", this, value);
		}
	}

	[Register("right")]
	public int Right
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("right.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("right.I", this, value);
		}
	}

	[Register("rotation")]
	public float Rotation
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("rotation.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("rotation.F", this, value);
		}
	}

	[Register("top")]
	public int Top
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("top.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("top.I", this, value);
		}
	}

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

	protected ViewState(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ViewState()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetState_Landroidx_constraintlayout_core_motion_MotionWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetState_Landroidx_constraintlayout_core_motion_MotionWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetState_Landroidx_constraintlayout_core_motion_MotionWidget_(nint jnienv, nint native__this, nint native_v)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewState? viewState = Java.Lang.Object.GetObject<ViewState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget v = Java.Lang.Object.GetObject<MotionWidget>(native_v, JniHandleOwnership.DoNotTransfer);
			viewState.GetState(v);
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

	[Register("getState", "(Landroidx/constraintlayout/core/motion/MotionWidget;)V", "GetGetState_Landroidx_constraintlayout_core_motion_MotionWidget_Handler")]
	public unsafe virtual void GetState(MotionWidget? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getState.(Landroidx/constraintlayout/core/motion/MotionWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	private static Delegate GetHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_Height);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Height(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height();
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

	[Register("height", "()I", "GetHeightHandler")]
	public unsafe virtual int Height()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("height.()I", this, null);
	}

	private static Delegate GetWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_Width);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Width(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width();
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

	[Register("width", "()I", "GetWidthHandler")]
	public unsafe virtual int Width()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("width.()I", this, null);
	}
}
