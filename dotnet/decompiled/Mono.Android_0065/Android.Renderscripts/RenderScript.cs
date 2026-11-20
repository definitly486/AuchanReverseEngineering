using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Renderscripts;

[ObsoletedOSPlatform("android31.0", "This class is obsoleted in this android platform")]
[Register("android/renderscript/RenderScript", DoNotGenerateAcw = true)]
public class RenderScript : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/renderscript/RenderScript", typeof(RenderScript));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	protected RenderScript(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe static RenderScript? Create(Context? ctx)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ctx?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RenderScript>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;)Landroid/renderscript/RenderScript;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(ctx);
		}
	}
}
