using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Renderscripts;

[ObsoletedOSPlatform("android31.0", "This class is obsoleted in this android platform")]
[Register("android/renderscript/Element", DoNotGenerateAcw = true)]
public class Element : BaseObj
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/renderscript/Element", typeof(Element));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	protected Element(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe static Element? U8_4(RenderScript? rs)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rs?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Element>(_members.StaticMethods.InvokeObjectMethod("U8_4.(Landroid/renderscript/RenderScript;)Landroid/renderscript/Element;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(rs);
		}
	}
}
