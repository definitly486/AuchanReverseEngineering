using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Javax.Microedition.Khronos.Opengles;

namespace Android.Opengl;

[Register("android/opengl/GLDebugHelper", DoNotGenerateAcw = true)]
public class GLDebugHelper : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/opengl/GLDebugHelper", typeof(GLDebugHelper));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected GLDebugHelper(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("wrap", "(Ljavax/microedition/khronos/opengles/GL;ILjava/io/Writer;)Ljavax/microedition/khronos/opengles/GL;", "")]
	public unsafe static IGL? Wrap(IGL? gl, int configFlags, Writer? log)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((gl == null) ? IntPtr.Zero : ((Java.Lang.Object)gl).Handle);
			ptr[1] = new JniArgumentValue(configFlags);
			ptr[2] = new JniArgumentValue(log?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IGL>(_members.StaticMethods.InvokeObjectMethod("wrap.(Ljavax/microedition/khronos/opengles/GL;ILjava/io/Writer;)Ljavax/microedition/khronos/opengles/GL;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(gl);
			GC.KeepAlive(log);
		}
	}
}
