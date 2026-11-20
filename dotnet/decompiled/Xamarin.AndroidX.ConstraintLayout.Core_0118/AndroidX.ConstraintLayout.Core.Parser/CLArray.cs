using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Parser;

[Register("androidx/constraintlayout/core/parser/CLArray", DoNotGenerateAcw = true)]
public class CLArray : CLContainer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/parser/CLArray", typeof(CLArray));

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected CLArray(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "([C)V", "")]
	public unsafe CLArray(char[]? content)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(content);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([C)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([C)V", this, ptr);
		}
		finally
		{
			if (content != null)
			{
				JNIEnv.CopyArray(num, content);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(content);
		}
	}

	[Register("allocate", "([C)Landroidx/constraintlayout/core/parser/CLElement;", "")]
	public new unsafe static CLElement? Allocate(char[]? content)
	{
		nint num = JNIEnv.NewArray(content);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CLElement>(_members.StaticMethods.InvokeObjectMethod("allocate.([C)Landroidx/constraintlayout/core/parser/CLElement;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (content != null)
			{
				JNIEnv.CopyArray(num, content);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(content);
		}
	}
}
