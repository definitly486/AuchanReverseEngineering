using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views.InputMethods;

[Register("android/view/inputmethod/InputMethodManager", DoNotGenerateAcw = true)]
public sealed class InputMethodManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/inputmethod/InputMethodManager", typeof(InputMethodManager));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static InputMethodManager? FromContext(Context context)
	{
		return context.GetSystemService("input_method") as InputMethodManager;
	}

	internal InputMethodManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe bool HideSoftInputFromWindow(IBinder? windowToken, HideSoftInputFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((windowToken == null) ? IntPtr.Zero : ((Java.Lang.Object)windowToken).Handle);
			ptr[1] = new JniArgumentValue((int)flags);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("hideSoftInputFromWindow.(Landroid/os/IBinder;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(windowToken);
		}
	}

	public unsafe bool ShowSoftInput(View? view, ShowFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("showSoftInput.(Landroid/view/View;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe void ToggleSoftInput(ShowFlags showFlags, HideSoftInputFlags hideFlags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((int)showFlags);
		ptr[1] = new JniArgumentValue((int)hideFlags);
		_members.InstanceMethods.InvokeAbstractVoidMethod("toggleSoftInput.(II)V", this, ptr);
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe void ToggleSoftInputFromWindow(IBinder? windowToken, ShowSoftInputFlags showFlags, HideSoftInputFlags hideFlags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((windowToken == null) ? IntPtr.Zero : ((Java.Lang.Object)windowToken).Handle);
			ptr[1] = new JniArgumentValue((int)showFlags);
			ptr[2] = new JniArgumentValue((int)hideFlags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("toggleSoftInputFromWindow.(Landroid/os/IBinder;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(windowToken);
		}
	}
}
