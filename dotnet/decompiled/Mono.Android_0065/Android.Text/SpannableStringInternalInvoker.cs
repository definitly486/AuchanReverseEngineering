using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text;

[Register("android/text/SpannableStringInternal", DoNotGenerateAcw = true)]
internal class SpannableStringInternalInvoker : SpannableStringInternal
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/SpannableStringInternal", typeof(SpannableStringInternalInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SpannableStringInternalInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override char CharAt(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		return _members.InstanceMethods.InvokeAbstractCharMethod("charAt.(I)C", this, ptr);
	}

	public unsafe override void GetChars(int start, int end, char[]? dest, int off)
	{
		nint num = JNIEnv.NewArray(dest);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(off);
			_members.InstanceMethods.InvokeAbstractVoidMethod("getChars.(II[CI)V", this, ptr);
		}
		finally
		{
			if (dest != null)
			{
				JNIEnv.CopyArray(num, dest);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(dest);
		}
	}

	public unsafe override int Length()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("length.()I", this, null);
	}

	public unsafe override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
