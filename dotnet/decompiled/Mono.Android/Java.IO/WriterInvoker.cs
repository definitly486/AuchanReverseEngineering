using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.IO;

[Register("java/io/Writer", DoNotGenerateAcw = true)]
internal class WriterInvoker : Writer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/Writer", typeof(WriterInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public WriterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("close", "()V", "GetCloseHandler")]
	public unsafe override void Close()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}

	[Register("flush", "()V", "GetFlushHandler")]
	public unsafe override void Flush()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
	}

	[Register("write", "([CII)V", "GetWrite_arrayCIIHandler")]
	public unsafe override void Write(char[]? cbuf, int off, int len)
	{
		nint num = JNIEnv.NewArray(cbuf);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(off);
			ptr[2] = new JniArgumentValue(len);
			_members.InstanceMethods.InvokeAbstractVoidMethod("write.([CII)V", this, ptr);
		}
		finally
		{
			if (cbuf != null)
			{
				JNIEnv.CopyArray(num, cbuf);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(cbuf);
		}
	}
}
