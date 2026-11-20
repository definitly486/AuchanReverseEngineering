using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Graphics.Drawables;

[Register("android/graphics/drawable/Drawable", DoNotGenerateAcw = true)]
internal class DrawableInvoker : Drawable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/Drawable", typeof(DrawableInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[ObsoletedOSPlatform("android29.0")]
	public unsafe override int Opacity => _members.InstanceMethods.InvokeAbstractInt32Method("getOpacity.()I", this, null);

	public DrawableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void Draw(Canvas canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("draw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	public unsafe override void SetAlpha(int alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(alpha);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setAlpha.(I)V", this, ptr);
	}

	public unsafe override void SetColorFilter(ColorFilter? colorFilter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colorFilter?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setColorFilter.(Landroid/graphics/ColorFilter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(colorFilter);
		}
	}
}
