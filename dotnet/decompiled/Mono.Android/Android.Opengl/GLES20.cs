using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Opengl;

[Register("android/opengl/GLES20", DoNotGenerateAcw = true)]
public class GLES20 : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/opengl/GLES20", typeof(GLES20));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected GLES20(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("glGetIntegerv", "(I[II)V", "")]
	public unsafe static void GlGetIntegerv(int pname, int[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members.StaticMethods.InvokeVoidMethod("glGetIntegerv.(I[II)V", ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	[Register("glViewport", "(IIII)V", "")]
	public unsafe static void GlViewport(int x, int y, int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(width);
		ptr[3] = new JniArgumentValue(height);
		_members.StaticMethods.InvokeVoidMethod("glViewport.(IIII)V", ptr);
	}
}
