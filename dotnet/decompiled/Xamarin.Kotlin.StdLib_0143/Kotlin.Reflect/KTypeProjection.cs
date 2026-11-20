using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KTypeProjection", DoNotGenerateAcw = true)]
public sealed class KTypeProjection : Java.Lang.Object
{
	[Register("kotlin/reflect/KTypeProjection$Companion", DoNotGenerateAcw = true)]
	public sealed class CompanionStatic : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlin/reflect/KTypeProjection$Companion", typeof(CompanionStatic));

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

		public unsafe KTypeProjection STAR
		{
			[Register("getSTAR", "()Lkotlin/reflect/KTypeProjection;", "")]
			get
			{
				return Java.Lang.Object.GetObject<KTypeProjection>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSTAR.()Lkotlin/reflect/KTypeProjection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CompanionStatic(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("contravariant", "(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", "")]
		public unsafe KTypeProjection Contravariant(IKType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<KTypeProjection>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("contravariant.(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("covariant", "(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", "")]
		public unsafe KTypeProjection Covariant(IKType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<KTypeProjection>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("covariant.(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("invariant", "(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", "")]
		public unsafe KTypeProjection Invariant(IKType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<KTypeProjection>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("invariant.(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("kotlin/reflect/KTypeProjection", typeof(KTypeProjection));

	[Register("Companion")]
	public static CompanionStatic Companion => Java.Lang.Object.GetObject<CompanionStatic>(_members.StaticFields.GetObjectValue("Companion.Lkotlin/reflect/KTypeProjection$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("star")]
	public static KTypeProjection Star => Java.Lang.Object.GetObject<KTypeProjection>(_members.StaticFields.GetObjectValue("star.Lkotlin/reflect/KTypeProjection;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe IKType? Type
	{
		[Register("getType", "()Lkotlin/reflect/KType;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IKType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getType.()Lkotlin/reflect/KType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe KVariance? Variance
	{
		[Register("getVariance", "()Lkotlin/reflect/KVariance;", "")]
		get
		{
			return Java.Lang.Object.GetObject<KVariance>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getVariance.()Lkotlin/reflect/KVariance;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal KTypeProjection(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lkotlin/reflect/KVariance;Lkotlin/reflect/KType;)V", "")]
	public unsafe KTypeProjection(KVariance? variance, IKType? type)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(variance?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/reflect/KVariance;Lkotlin/reflect/KType;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lkotlin/reflect/KVariance;Lkotlin/reflect/KType;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(variance);
			GC.KeepAlive(type);
		}
	}

	[Register("component1", "()Lkotlin/reflect/KVariance;", "")]
	public unsafe KVariance? Component1()
	{
		return Java.Lang.Object.GetObject<KVariance>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Lkotlin/reflect/KVariance;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component2", "()Lkotlin/reflect/KType;", "")]
	public unsafe IKType? Component2()
	{
		return Java.Lang.Object.GetObject<IKType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Lkotlin/reflect/KType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("contravariant", "(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", "")]
	public unsafe static KTypeProjection Contravariant(IKType type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
			return Java.Lang.Object.GetObject<KTypeProjection>(_members.StaticMethods.InvokeObjectMethod("contravariant.(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	[Register("copy", "(Lkotlin/reflect/KVariance;Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", "")]
	public unsafe KTypeProjection Copy(KVariance? variance, IKType? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(variance?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
			return Java.Lang.Object.GetObject<KTypeProjection>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Lkotlin/reflect/KVariance;Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(variance);
			GC.KeepAlive(type);
		}
	}

	[Register("covariant", "(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", "")]
	public unsafe static KTypeProjection Covariant(IKType type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
			return Java.Lang.Object.GetObject<KTypeProjection>(_members.StaticMethods.InvokeObjectMethod("covariant.(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	[Register("invariant", "(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", "")]
	public unsafe static KTypeProjection Invariant(IKType type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
			return Java.Lang.Object.GetObject<KTypeProjection>(_members.StaticMethods.InvokeObjectMethod("invariant.(Lkotlin/reflect/KType;)Lkotlin/reflect/KTypeProjection;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}
}
