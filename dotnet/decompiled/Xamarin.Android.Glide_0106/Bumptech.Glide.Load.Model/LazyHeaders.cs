using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/LazyHeaders", DoNotGenerateAcw = true)]
public sealed class LazyHeaders : Java.Lang.Object, IHeaders, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/bumptech/glide/load/model/LazyHeaders$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/model/LazyHeaders$Builder", typeof(Builder));

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

		internal Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Builder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("addHeader", "(Ljava/lang/String;Lcom/bumptech/glide/load/model/LazyHeaderFactory;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", "")]
		public unsafe Builder? AddHeader(string key, ILazyHeaderFactory factory)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addHeader.(Ljava/lang/String;Lcom/bumptech/glide/load/model/LazyHeaderFactory;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(factory);
			}
		}

		[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", "")]
		public unsafe Builder? AddHeader(string key, string value)
		{
			nint num = JNIEnv.NewString(key);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}

		[Register("build", "()Lcom/bumptech/glide/load/model/LazyHeaders;", "")]
		public unsafe LazyHeaders? Build()
		{
			return Java.Lang.Object.GetObject<LazyHeaders>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/bumptech/glide/load/model/LazyHeaders;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setHeader", "(Ljava/lang/String;Lcom/bumptech/glide/load/model/LazyHeaderFactory;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", "")]
		public unsafe Builder? SetHeader(string key, ILazyHeaderFactory? factory)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHeader.(Ljava/lang/String;Lcom/bumptech/glide/load/model/LazyHeaderFactory;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(factory);
			}
		}

		[Register("setHeader", "(Ljava/lang/String;Ljava/lang/String;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", "")]
		public unsafe Builder? SetHeader(string key, string? value)
		{
			nint num = JNIEnv.NewString(key);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHeader.(Ljava/lang/String;Ljava/lang/String;)Lcom/bumptech/glide/load/model/LazyHeaders$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/model/LazyHeaders", typeof(LazyHeaders));

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

	public unsafe IDictionary<string, string>? Headers
	{
		[Register("getHeaders", "()Ljava/util/Map;", "")]
		get
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getHeaders.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal LazyHeaders(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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
