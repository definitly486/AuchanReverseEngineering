using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/StringBuilder", DoNotGenerateAcw = true)]
public sealed class StringBuilder : AbstractStringBuilder, ISerializable, IJavaObject, IDisposable, IJavaPeerable, IAppendable, ICharSequence, IEnumerable<char>, IEnumerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/StringBuilder", typeof(StringBuilder));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal StringBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe StringBuilder()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	public unsafe override IAppendable Append(char c)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)c);
		return Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeAbstractObjectMethod("append.(C)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe IAppendable Append(int i)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(i);
		return Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeAbstractObjectMethod("append.(I)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe override IAppendable Append(ICharSequence? s, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			return Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeAbstractObjectMethod("append.(Ljava/lang/CharSequence;II)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
		}
	}

	public unsafe override IAppendable Append(ICharSequence? s)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeAbstractObjectMethod("append.(Ljava/lang/CharSequence;)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
		}
	}

	public unsafe override char CharAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeAbstractCharMethod("charAt.(I)C", this, ptr);
	}

	public unsafe StringBuilder Delete(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Object.GetObject<StringBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("delete.(II)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe override int Length()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("length.()I", this, null);
	}

	public unsafe override ICharSequence SubSequenceFormatted(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		return Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("subSequence.(II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public new IEnumerator<char> GetEnumerator()
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
