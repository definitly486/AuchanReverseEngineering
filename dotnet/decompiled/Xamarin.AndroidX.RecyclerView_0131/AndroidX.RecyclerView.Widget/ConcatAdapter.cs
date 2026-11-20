using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/ConcatAdapter", DoNotGenerateAcw = true)]
public sealed class ConcatAdapter : RecyclerView.Adapter
{
	[Register("androidx/recyclerview/widget/ConcatAdapter$Config", DoNotGenerateAcw = true)]
	public sealed class Config : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/ConcatAdapter$Config", typeof(Config));

		[Register("DEFAULT")]
		public static Config Default => Java.Lang.Object.GetObject<Config>(_members.StaticFields.GetObjectValue("DEFAULT.Landroidx/recyclerview/widget/ConcatAdapter$Config;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("isolateViewTypes")]
		public bool IsolateViewTypes
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("isolateViewTypes.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("isolateViewTypes.Z", this, value ? ((sbyte)1) : ((sbyte)0));
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

		internal Config(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/ConcatAdapter", typeof(ConcatAdapter));

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

	public unsafe IList<RecyclerView.Adapter> Adapters
	{
		[Register("getAdapters", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<RecyclerView.Adapter>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAdapters.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override int ItemCount
	{
		[Register("getItemCount", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getItemCount.()I", this, null);
		}
	}

	internal ConcatAdapter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/recyclerview/widget/ConcatAdapter$Config;[Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", "")]
	public unsafe ConcatAdapter(Config config, params RecyclerView.Adapter[] adapters)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(adapters);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/recyclerview/widget/ConcatAdapter$Config;[Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/recyclerview/widget/ConcatAdapter$Config;[Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", this, ptr);
		}
		finally
		{
			if (adapters != null)
			{
				JNIEnv.CopyArray(num, adapters);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(config);
			GC.KeepAlive(adapters);
		}
	}

	[Register(".ctor", "(Landroidx/recyclerview/widget/ConcatAdapter$Config;Ljava/util/List;)V", "")]
	public unsafe ConcatAdapter(Config config, IList<RecyclerView.Adapter> adapters)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList<RecyclerView.Adapter>.ToLocalJniHandle(adapters);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/recyclerview/widget/ConcatAdapter$Config;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/recyclerview/widget/ConcatAdapter$Config;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(config);
			GC.KeepAlive(adapters);
		}
	}

	[Register(".ctor", "([Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", "")]
	public unsafe ConcatAdapter(params RecyclerView.Adapter[] adapters)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(adapters);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", this, ptr);
		}
		finally
		{
			if (adapters != null)
			{
				JNIEnv.CopyArray(num, adapters);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(adapters);
		}
	}

	[Register(".ctor", "(Ljava/util/List;)V", "")]
	public unsafe ConcatAdapter(IList<RecyclerView.Adapter> adapters)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList<RecyclerView.Adapter>.ToLocalJniHandle(adapters);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(adapters);
		}
	}

	[Register("addAdapter", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;)Z", "")]
	public unsafe bool AddAdapter(RecyclerView.Adapter adapter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("addAdapter.(Landroidx/recyclerview/widget/RecyclerView$Adapter;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}

	[Register("addAdapter", "(ILandroidx/recyclerview/widget/RecyclerView$Adapter;)Z", "")]
	public unsafe bool AddAdapter(int index, RecyclerView.Adapter adapter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(index);
			ptr[1] = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("addAdapter.(ILandroidx/recyclerview/widget/RecyclerView$Adapter;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}

	[Register("getWrappedAdapterAndPosition", "(I)Landroid/util/Pair;", "")]
	public unsafe Pair GetWrappedAdapterAndPosition(int globalPosition)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(globalPosition);
		return Java.Lang.Object.GetObject<Pair>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWrappedAdapterAndPosition.(I)Landroid/util/Pair;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "")]
	public unsafe override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onBindViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(holder);
		}
	}

	[Register("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "")]
	public unsafe override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(viewType);
			return Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(_members.InstanceMethods.InvokeAbstractObjectMethod("onCreateViewHolder.(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(parent);
		}
	}

	[Register("onFailedToRecycleView", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "")]
	public unsafe override bool OnFailedToRecycleView(Java.Lang.Object holder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("onFailedToRecycleView.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(holder);
		}
	}

	[Register("onViewAttachedToWindow", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "")]
	public unsafe override void OnViewAttachedToWindow(Java.Lang.Object holder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onViewAttachedToWindow.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(holder);
		}
	}

	[Register("onViewDetachedFromWindow", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "")]
	public unsafe override void OnViewDetachedFromWindow(Java.Lang.Object holder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onViewDetachedFromWindow.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(holder);
		}
	}

	[Register("onViewRecycled", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "")]
	public unsafe override void OnViewRecycled(Java.Lang.Object holder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onViewRecycled.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(holder);
		}
	}

	[Register("removeAdapter", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;)Z", "")]
	public unsafe bool RemoveAdapter(RecyclerView.Adapter adapter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("removeAdapter.(Landroidx/recyclerview/widget/RecyclerView$Adapter;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}
}
