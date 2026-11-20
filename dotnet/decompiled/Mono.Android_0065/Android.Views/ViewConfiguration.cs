using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewConfiguration", DoNotGenerateAcw = true)]
public class ViewConfiguration : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewConfiguration", typeof(ViewConfiguration));

	private static Delegate? cb_getScaledTouchSlop_GetScaledTouchSlop_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static int LongPressTimeout => _members.StaticMethods.InvokeInt32Method("getLongPressTimeout.()I", null);

	public unsafe virtual int ScaledTouchSlop => _members.InstanceMethods.InvokeVirtualInt32Method("getScaledTouchSlop.()I", this, null);

	protected ViewConfiguration(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetScaledTouchSlopHandler()
	{
		return new _JniMarshal_PP_I(n_GetScaledTouchSlop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetScaledTouchSlop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewConfiguration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaledTouchSlop;
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

	public unsafe static ViewConfiguration? Get(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewConfiguration>(_members.StaticMethods.InvokeObjectMethod("get.(Landroid/content/Context;)Landroid/view/ViewConfiguration;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}
