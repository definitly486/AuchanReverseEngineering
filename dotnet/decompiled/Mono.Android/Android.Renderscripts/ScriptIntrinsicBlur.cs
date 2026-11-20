using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Renderscripts;

[ObsoletedOSPlatform("android31.0", "This class is obsoleted in this android platform")]
[Register("android/renderscript/ScriptIntrinsicBlur", DoNotGenerateAcw = true)]
public sealed class ScriptIntrinsicBlur : ScriptIntrinsic
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/renderscript/ScriptIntrinsicBlur", typeof(ScriptIntrinsicBlur));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	internal ScriptIntrinsicBlur(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android31.0")]
	[Register("create", "(Landroid/renderscript/RenderScript;Landroid/renderscript/Element;)Landroid/renderscript/ScriptIntrinsicBlur;", "")]
	public unsafe static ScriptIntrinsicBlur? Create(RenderScript? rs, Element? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(rs?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ScriptIntrinsicBlur>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/renderscript/RenderScript;Landroid/renderscript/Element;)Landroid/renderscript/ScriptIntrinsicBlur;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(rs);
			GC.KeepAlive(e);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	[Register("forEach", "(Landroid/renderscript/Allocation;)V", "")]
	public unsafe void ForEach(Allocation? aout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(aout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("forEach.(Landroid/renderscript/Allocation;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(aout);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	[Register("setInput", "(Landroid/renderscript/Allocation;)V", "")]
	public unsafe void SetInput(Allocation? ain)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ain?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setInput.(Landroid/renderscript/Allocation;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ain);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	[Register("setRadius", "(F)V", "")]
	public unsafe void SetRadius(float radius)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(radius);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setRadius.(F)V", this, ptr);
	}
}
