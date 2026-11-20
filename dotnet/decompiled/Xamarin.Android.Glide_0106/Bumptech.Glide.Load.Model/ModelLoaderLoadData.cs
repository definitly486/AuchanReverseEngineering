using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Bumptech.Glide.Load.Data;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/ModelLoader$LoadData", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "Data" })]
public class ModelLoaderLoadData : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/model/ModelLoader$LoadData", typeof(ModelLoaderLoadData));

	[Register("alternateKeys")]
	public IList? AlternateKeys
	{
		get
		{
			return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("alternateKeys.Ljava/util/List;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaList.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("alternateKeys.Ljava/util/List;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("fetcher")]
	public IDataFetcher? Fetcher
	{
		get
		{
			return Java.Lang.Object.GetObject<IDataFetcher>(_members.InstanceFields.GetObjectValue("fetcher.Lcom/bumptech/glide/load/data/DataFetcher;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("fetcher.Lcom/bumptech/glide/load/data/DataFetcher;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("sourceKey")]
	public IKey? SourceKey
	{
		get
		{
			return Java.Lang.Object.GetObject<IKey>(_members.InstanceFields.GetObjectValue("sourceKey.Lcom/bumptech/glide/load/Key;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("sourceKey.Lcom/bumptech/glide/load/Key;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	protected ModelLoaderLoadData(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/bumptech/glide/load/Key;Lcom/bumptech/glide/load/data/DataFetcher;)V", "")]
	public unsafe ModelLoaderLoadData(IKey sourceKey, IDataFetcher fetcher)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((sourceKey == null) ? IntPtr.Zero : ((Java.Lang.Object)sourceKey).Handle);
			ptr[1] = new JniArgumentValue((fetcher == null) ? IntPtr.Zero : ((Java.Lang.Object)fetcher).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/bumptech/glide/load/Key;Lcom/bumptech/glide/load/data/DataFetcher;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/bumptech/glide/load/Key;Lcom/bumptech/glide/load/data/DataFetcher;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(sourceKey);
			GC.KeepAlive(fetcher);
		}
	}

	[Register(".ctor", "(Lcom/bumptech/glide/load/Key;Ljava/util/List;Lcom/bumptech/glide/load/data/DataFetcher;)V", "")]
	public unsafe ModelLoaderLoadData(IKey sourceKey, IList<IKey> alternateKeys, IDataFetcher fetcher)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList<IKey>.ToLocalJniHandle(alternateKeys);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((sourceKey == null) ? IntPtr.Zero : ((Java.Lang.Object)sourceKey).Handle);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue((fetcher == null) ? IntPtr.Zero : ((Java.Lang.Object)fetcher).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/bumptech/glide/load/Key;Ljava/util/List;Lcom/bumptech/glide/load/data/DataFetcher;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/bumptech/glide/load/Key;Ljava/util/List;Lcom/bumptech/glide/load/data/DataFetcher;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(sourceKey);
			GC.KeepAlive(alternateKeys);
			GC.KeepAlive(fetcher);
		}
	}
}
