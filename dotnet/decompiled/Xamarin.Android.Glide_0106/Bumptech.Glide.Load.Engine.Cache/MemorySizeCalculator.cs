using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/MemorySizeCalculator", DoNotGenerateAcw = true)]
public sealed class MemorySizeCalculator : Java.Lang.Object
{
	[Register("com/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder", typeof(Builder));

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

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Builder(Context? context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("build", "()Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator;", "")]
		public unsafe MemorySizeCalculator? Build()
		{
			return Java.Lang.Object.GetObject<MemorySizeCalculator>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setArrayPoolSize", "(I)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", "")]
		public unsafe Builder? SetArrayPoolSize(int arrayPoolSizeBytes)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(arrayPoolSizeBytes);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setArrayPoolSize.(I)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setBitmapPoolScreens", "(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", "")]
		public unsafe Builder? SetBitmapPoolScreens(float bitmapPoolScreens)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bitmapPoolScreens);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBitmapPoolScreens.(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setLowMemoryMaxSizeMultiplier", "(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", "")]
		public unsafe Builder? SetLowMemoryMaxSizeMultiplier(float lowMemoryMaxSizeMultiplier)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(lowMemoryMaxSizeMultiplier);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLowMemoryMaxSizeMultiplier.(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setMaxSizeMultiplier", "(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", "")]
		public unsafe Builder? SetMaxSizeMultiplier(float maxSizeMultiplier)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maxSizeMultiplier);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMaxSizeMultiplier.(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setMemoryCacheScreens", "(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", "")]
		public unsafe Builder? SetMemoryCacheScreens(float memoryCacheScreens)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(memoryCacheScreens);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMemoryCacheScreens.(F)Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/cache/MemorySizeCalculator", typeof(MemorySizeCalculator));

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

	public unsafe int ArrayPoolSizeInBytes
	{
		[Register("getArrayPoolSizeInBytes", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getArrayPoolSizeInBytes.()I", this, null);
		}
	}

	public unsafe int BitmapPoolSize
	{
		[Register("getBitmapPoolSize", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBitmapPoolSize.()I", this, null);
		}
	}

	public unsafe int MemoryCacheSize
	{
		[Register("getMemoryCacheSize", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getMemoryCacheSize.()I", this, null);
		}
	}

	internal MemorySizeCalculator(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
