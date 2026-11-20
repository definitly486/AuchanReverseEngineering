using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/MenuItem$OnActionExpandListener", DoNotGenerateAcw = true)]
internal class IMenuItemOnActionExpandListenerInvoker : Java.Lang.Object, IMenuItemOnActionExpandListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_MenuItem_OnActionExpandListener = new XAPeerMembers("android/view/MenuItem$OnActionExpandListener", typeof(IMenuItemOnActionExpandListenerInvoker));

	private static Delegate? cb_onMenuItemActionCollapse_OnMenuItemActionCollapse_Landroid_view_MenuItem__Z;

	private static Delegate? cb_onMenuItemActionExpand_OnMenuItemActionExpand_Landroid_view_MenuItem__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_MenuItem_OnActionExpandListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_MenuItem_OnActionExpandListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_MenuItem_OnActionExpandListener.ManagedPeerType;

	public IMenuItemOnActionExpandListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnMenuItemActionCollapse_Landroid_view_MenuItem_Handler()
	{
		return new _JniMarshal_PPL_B(n_OnMenuItemActionCollapse_Landroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMenuItemActionCollapse_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItemOnActionExpandListener? menuItemOnActionExpandListener = Java.Lang.Object.GetObject<IMenuItemOnActionExpandListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return menuItemOnActionExpandListener.OnMenuItemActionCollapse(item) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnMenuItemActionCollapse(IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members_android_view_MenuItem_OnActionExpandListener.InstanceMethods.InvokeAbstractBooleanMethod("onMenuItemActionCollapse.(Landroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetOnMenuItemActionExpand_Landroid_view_MenuItem_Handler()
	{
		return new _JniMarshal_PPL_B(n_OnMenuItemActionExpand_Landroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMenuItemActionExpand_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItemOnActionExpandListener? menuItemOnActionExpandListener = Java.Lang.Object.GetObject<IMenuItemOnActionExpandListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return menuItemOnActionExpandListener.OnMenuItemActionExpand(item) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnMenuItemActionExpand(IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members_android_view_MenuItem_OnActionExpandListener.InstanceMethods.InvokeAbstractBooleanMethod("onMenuItemActionExpand.(Landroid/view/MenuItem;)Z", this, ptr);
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
