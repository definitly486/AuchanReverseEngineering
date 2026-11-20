using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/MenuItem$OnMenuItemClickListener", DoNotGenerateAcw = true)]
internal class IMenuItemOnMenuItemClickListenerInvoker : Java.Lang.Object, IMenuItemOnMenuItemClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_MenuItem_OnMenuItemClickListener = new XAPeerMembers("android/view/MenuItem$OnMenuItemClickListener", typeof(IMenuItemOnMenuItemClickListenerInvoker));

	private static Delegate? cb_onMenuItemClick_OnMenuItemClick_Landroid_view_MenuItem__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_MenuItem_OnMenuItemClickListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_MenuItem_OnMenuItemClickListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_MenuItem_OnMenuItemClickListener.ManagedPeerType;

	public IMenuItemOnMenuItemClickListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnMenuItemClick_Landroid_view_MenuItem_Handler()
	{
		return new _JniMarshal_PPL_B(n_OnMenuItemClick_Landroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMenuItemClick_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItemOnMenuItemClickListener? menuItemOnMenuItemClickListener = Java.Lang.Object.GetObject<IMenuItemOnMenuItemClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return menuItemOnMenuItemClickListener.OnMenuItemClick(item) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnMenuItemClick(IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members_android_view_MenuItem_OnMenuItemClickListener.InstanceMethods.InvokeAbstractBooleanMethod("onMenuItemClick.(Landroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
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
