using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Utils;

[Register("androidx/constraintlayout/motion/utils/ViewSpline", DoNotGenerateAcw = true)]
public abstract class ViewSpline : SplineSet
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/utils/ViewSpline", typeof(ViewSpline));

	private static Delegate? cb_setProperty_SetProperty_Landroid_view_View_F_V;

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

	protected ViewSpline(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ViewSpline()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("makeCustomSpline", "(Ljava/lang/String;Landroid/util/SparseArray;)Landroidx/constraintlayout/motion/utils/ViewSpline;", "")]
	public unsafe static ViewSpline? MakeCustomSpline(string? str, SparseArray? attrList)
	{
		nint num = JNIEnv.NewString(str);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(attrList?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewSpline>(_members.StaticMethods.InvokeObjectMethod("makeCustomSpline.(Ljava/lang/String;Landroid/util/SparseArray;)Landroidx/constraintlayout/motion/utils/ViewSpline;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(attrList);
		}
	}

	[Register("makeSpline", "(Ljava/lang/String;)Landroidx/constraintlayout/motion/utils/ViewSpline;", "")]
	public unsafe static ViewSpline? MakeSpline(string? str)
	{
		nint num = JNIEnv.NewString(str);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ViewSpline>(_members.StaticMethods.InvokeObjectMethod("makeSpline.(Ljava/lang/String;)Landroidx/constraintlayout/motion/utils/ViewSpline;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetProperty_Landroid_view_View_FHandler()
	{
		return new global::_JniMarshal_PPLF_V(n_SetProperty_Landroid_view_View_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProperty_Landroid_view_View_F(nint jnienv, nint native__this, nint native_p0, float p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewSpline? viewSpline = Java.Lang.Object.GetObject<ViewSpline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View p2 = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
			viewSpline.SetProperty(p2, p1);
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

	[Register("setProperty", "(Landroid/view/View;F)V", "GetSetProperty_Landroid_view_View_FHandler")]
	public abstract void SetProperty(View? p0, float p1);
}
