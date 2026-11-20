using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/Window", DoNotGenerateAcw = true)]
internal class WindowInvoker : Window
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/Window", typeof(WindowInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override View DecorView
	{
		[Register("getDecorView", "()Landroid/view/View;", "GetGetDecorViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDecorView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public WindowInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("setBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe override void SetBackgroundDrawable(Drawable? drawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawable?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setBackgroundDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawable);
		}
	}

	[ObsoletedOSPlatform("android35.0")]
	[Register("setNavigationBarColor", "(I)V", "GetSetNavigationBarColor_IHandler")]
	public unsafe override void SetNavigationBarColor(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeAbstractVoidMethod("setNavigationBarColor.(I)V", this, ptr);
	}

	[ObsoletedOSPlatform("android35.0")]
	[Register("setStatusBarColor", "(I)V", "GetSetStatusBarColor_IHandler")]
	public unsafe override void SetStatusBarColor(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeAbstractVoidMethod("setStatusBarColor.(I)V", this, ptr);
	}

	[Register("superDispatchGenericMotionEvent", "(Landroid/view/MotionEvent;)Z", "GetSuperDispatchGenericMotionEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe override bool SuperDispatchGenericMotionEvent(MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("superDispatchGenericMotionEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	[Register("superDispatchKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetSuperDispatchKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe override bool SuperDispatchKeyEvent(KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("superDispatchKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	[Register("superDispatchKeyShortcutEvent", "(Landroid/view/KeyEvent;)Z", "GetSuperDispatchKeyShortcutEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe override bool SuperDispatchKeyShortcutEvent(KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("superDispatchKeyShortcutEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	[Register("superDispatchTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetSuperDispatchTouchEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe override bool SuperDispatchTouchEvent(MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("superDispatchTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	[Register("superDispatchTrackballEvent", "(Landroid/view/MotionEvent;)Z", "GetSuperDispatchTrackballEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe override bool SuperDispatchTrackballEvent(MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("superDispatchTrackballEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}
}
