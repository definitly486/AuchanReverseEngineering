using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine;

[Register("com/bumptech/glide/load/engine/GlideException", DoNotGenerateAcw = true)]
public sealed class GlideException : Java.Lang.Exception
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/GlideException", typeof(GlideException));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe IList<Throwable>? Causes
	{
		[Register("getCauses", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<Throwable>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getCauses.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Java.Lang.Exception? Origin
	{
		[Register("getOrigin", "()Ljava/lang/Exception;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Exception>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOrigin.()Ljava/lang/Exception;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setOrigin", "(Ljava/lang/Exception;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setOrigin.(Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe IList<Throwable>? RootCauses
	{
		[Register("getRootCauses", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<Throwable>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getRootCauses.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal GlideException(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe GlideException(string? message)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
	public unsafe GlideException(string? detailMessage, Throwable? cause)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(detailMessage);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cause);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;)V", "")]
	public unsafe GlideException(string? detailMessage, IList<Throwable>? causes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(detailMessage);
		nint num2 = JavaList<Throwable>.ToLocalJniHandle(causes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(causes);
		}
	}

	[Register("logRootCauses", "(Ljava/lang/String;)V", "")]
	public unsafe void LogRootCauses(string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("logRootCauses.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
