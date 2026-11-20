using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Net;

[Register("java/net/Proxy", DoNotGenerateAcw = true)]
public class Proxy : Java.Lang.Object
{
	[Register("java/net/Proxy$Type", DoNotGenerateAcw = true)]
	public sealed class Type : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/Proxy$Type", typeof(Type));

		[Register("HTTP")]
		public static Type? Http => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("HTTP.Ljava/net/Proxy$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		internal Type(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/Proxy", typeof(Proxy));

	[Register("NO_PROXY")]
	public static Proxy? NoProxy => Java.Lang.Object.GetObject<Proxy>(_members.StaticFields.GetObjectValue("NO_PROXY.Ljava/net/Proxy;").Handle, JniHandleOwnership.TransferLocalRef);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	protected Proxy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe Proxy(Type? type, SocketAddress? sa)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(sa?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/net/Proxy$Type;Ljava/net/SocketAddress;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/net/Proxy$Type;Ljava/net/SocketAddress;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(type);
			GC.KeepAlive(sa);
		}
	}

	public unsafe sealed override bool Equals(Java.Lang.Object? obj)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
		}
	}

	public unsafe sealed override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
	}
}
