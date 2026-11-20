using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Jvm.Functions;
using Kotlin.Reflect;

namespace AndroidX.Lifecycle.ViewModels;

[Register("androidx/lifecycle/viewmodel/ViewModelInitializer", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
public sealed class ViewModelInitializer : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/viewmodel/ViewModelInitializer", typeof(ViewModelInitializer));

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

	internal ViewModelInitializer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/Class;Lkotlin/jvm/functions/Function1;)V", "")]
	public unsafe ViewModelInitializer(Class clazz, IFunction1 initializer)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(clazz?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((initializer == null) ? IntPtr.Zero : ((Java.Lang.Object)initializer).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Class;Lkotlin/jvm/functions/Function1;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Class;Lkotlin/jvm/functions/Function1;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(clazz);
			GC.KeepAlive(initializer);
		}
	}

	[Register(".ctor", "(Lkotlin/reflect/KClass;Lkotlin/jvm/functions/Function1;)V", "")]
	public unsafe ViewModelInitializer(IKClass clazz, IFunction1 initializer)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((clazz == null) ? IntPtr.Zero : ((Java.Lang.Object)clazz).Handle);
			ptr[1] = new JniArgumentValue((initializer == null) ? IntPtr.Zero : ((Java.Lang.Object)initializer).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/reflect/KClass;Lkotlin/jvm/functions/Function1;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lkotlin/reflect/KClass;Lkotlin/jvm/functions/Function1;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(clazz);
			GC.KeepAlive(initializer);
		}
	}
}
