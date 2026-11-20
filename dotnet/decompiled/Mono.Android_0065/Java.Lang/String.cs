using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/String", DoNotGenerateAcw = true)]
public sealed class String : Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable, ICharSequence, IEnumerable<char>, IEnumerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/String", typeof(String));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe bool IsEmpty => _members.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	public String(string toCopy)
		: base(JNIEnv.NewString(toCopy), JniHandleOwnership.TransferLocalRef)
	{
	}

	public override string ToString()
	{
		return JNIEnv.GetCharSequence(base.Handle, JniHandleOwnership.DoNotTransfer);
	}

	internal String(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe char CharAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeAbstractCharMethod("charAt.(I)C", this, ptr);
	}

	public unsafe int Length()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("length.()I", this, null);
	}

	public unsafe ICharSequence SubSequenceFormatted(int beginIndex, int endIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(beginIndex);
		ptr[1] = new JniArgumentValue(endIndex);
		return Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<char> GetEnumerator()
	{
		for (int i = 0; i < Length(); i++)
		{
			yield return CharAt(i);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
