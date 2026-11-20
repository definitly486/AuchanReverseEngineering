using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/MutableOptionsBundle", DoNotGenerateAcw = true)]
public sealed class MutableOptionsBundle : OptionsBundle, IMutableConfig, IConfig, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/MutableOptionsBundle", typeof(MutableOptionsBundle));

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

	internal MutableOptionsBundle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("create", "()Landroidx/camera/core/impl/MutableOptionsBundle;", "")]
	public unsafe static MutableOptionsBundle Create()
	{
		return Java.Lang.Object.GetObject<MutableOptionsBundle>(_members.StaticMethods.InvokeObjectMethod("create.()Landroidx/camera/core/impl/MutableOptionsBundle;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("from", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/MutableOptionsBundle;", "")]
	public new unsafe static MutableOptionsBundle From(IConfig otherConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((otherConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)otherConfig).Handle);
			return Java.Lang.Object.GetObject<MutableOptionsBundle>(_members.StaticMethods.InvokeObjectMethod("from.(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/MutableOptionsBundle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(otherConfig);
		}
	}

	[Register("insertOption", "(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;Ljava/lang/Object;)V", "")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	public unsafe void InsertOption(ConfigOption opt, ConfigOptionPriority priority, Java.Lang.Object? value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(opt?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("insertOption.(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(opt);
			GC.KeepAlive(priority);
			GC.KeepAlive(value);
		}
	}

	[Register("insertOption", "(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V", "")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	public unsafe void InsertOption(ConfigOption opt, Java.Lang.Object? value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(opt?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("insertOption.(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(opt);
			GC.KeepAlive(value);
		}
	}

	[Register("removeOption", "(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;", "")]
	[JavaTypeParameters(new string[] { "ValueT" })]
	public unsafe Java.Lang.Object? RemoveOption(ConfigOption opt)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(opt?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("removeOption.(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(opt);
		}
	}
}
