using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Binder", DoNotGenerateAcw = true)]
public class Binder : Java.Lang.Object, IBinder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Binder", typeof(Binder));

	private static Delegate? cb_getInterfaceDescriptor_GetInterfaceDescriptor_Ljava_lang_String_;

	private static Delegate? cb_isBinderAlive_IsBinderAlive_Z;

	private static Delegate? cb_dump_Dump_Ljava_io_FileDescriptor_arrayLjava_lang_String__V;

	private static Delegate? cb_dumpAsync_DumpAsync_Ljava_io_FileDescriptor_arrayLjava_lang_String__V;

	private static Delegate? cb_linkToDeath_LinkToDeath_Landroid_os_IBinder_DeathRecipient_I_V;

	private static Delegate? cb_pingBinder_PingBinder_Z;

	private static Delegate? cb_queryLocalInterface_QueryLocalInterface_Ljava_lang_String__Landroid_os_IInterface_;

	private static Delegate? cb_unlinkToDeath_UnlinkToDeath_Landroid_os_IBinder_DeathRecipient_I_Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual string? InterfaceDescriptor
	{
		[Register("getInterfaceDescriptor", "()Ljava/lang/String;", "GetGetInterfaceDescriptorHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterfaceDescriptor.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsBinderAlive
	{
		[Register("isBinderAlive", "()Z", "GetIsBinderAliveHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isBinderAlive.()Z", this, null);
		}
	}

	protected Binder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Binder()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetInterfaceDescriptorHandler()
	{
		return new _JniMarshal_PP_L(n_GetInterfaceDescriptor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInterfaceDescriptor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InterfaceDescriptor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsBinderAliveHandler()
	{
		return new _JniMarshal_PP_B(n_IsBinderAlive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsBinderAlive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsBinderAlive ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetDump_Ljava_io_FileDescriptor_arrayLjava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_Dump_Ljava_io_FileDescriptor_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dump_Ljava_io_FileDescriptor_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_fd, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Binder? binder = Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			binder.Dump(fd, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_args);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dump", "(Ljava/io/FileDescriptor;[Ljava/lang/String;)V", "GetDump_Ljava_io_FileDescriptor_arrayLjava_lang_String_Handler")]
	public unsafe virtual void Dump(FileDescriptor fd, string[]? args)
	{
		nint num = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Ljava/io/FileDescriptor;[Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (args != null)
			{
				JNIEnv.CopyArray(num, args);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(fd);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetDumpAsync_Ljava_io_FileDescriptor_arrayLjava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_DumpAsync_Ljava_io_FileDescriptor_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DumpAsync_Ljava_io_FileDescriptor_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_fd, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Binder? binder = Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			binder.DumpAsync(fd, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_args);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dumpAsync", "(Ljava/io/FileDescriptor;[Ljava/lang/String;)V", "GetDumpAsync_Ljava_io_FileDescriptor_arrayLjava_lang_String_Handler")]
	public unsafe virtual void DumpAsync(FileDescriptor fd, string[]? args)
	{
		nint num = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dumpAsync.(Ljava/io/FileDescriptor;[Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (args != null)
			{
				JNIEnv.CopyArray(num, args);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(fd);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetLinkToDeath_Landroid_os_IBinder_DeathRecipient_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_LinkToDeath_Landroid_os_IBinder_DeathRecipient_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LinkToDeath_Landroid_os_IBinder_DeathRecipient_I(nint jnienv, nint native__this, nint native_recipient, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Binder? binder = Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBinderDeathRecipient recipient = Java.Lang.Object.GetObject<IBinderDeathRecipient>(native_recipient, JniHandleOwnership.DoNotTransfer);
			binder.LinkToDeath(recipient, flags);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("linkToDeath", "(Landroid/os/IBinder$DeathRecipient;I)V", "GetLinkToDeath_Landroid_os_IBinder_DeathRecipient_IHandler")]
	public unsafe virtual void LinkToDeath(IBinderDeathRecipient recipient, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((recipient == null) ? IntPtr.Zero : ((Java.Lang.Object)recipient).Handle);
			ptr[1] = new JniArgumentValue(flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("linkToDeath.(Landroid/os/IBinder$DeathRecipient;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(recipient);
		}
	}

	private static Delegate GetPingBinderHandler()
	{
		return new _JniMarshal_PP_B(n_PingBinder);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PingBinder(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PingBinder() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("pingBinder", "()Z", "GetPingBinderHandler")]
	public unsafe virtual bool PingBinder()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("pingBinder.()Z", this, null);
	}

	private static Delegate GetQueryLocalInterface_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_QueryLocalInterface_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_QueryLocalInterface_Ljava_lang_String_(nint jnienv, nint native__this, nint native_descriptor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Binder? binder = Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string descriptor = JNIEnv.GetString(native_descriptor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(binder.QueryLocalInterface(descriptor));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("queryLocalInterface", "(Ljava/lang/String;)Landroid/os/IInterface;", "GetQueryLocalInterface_Ljava_lang_String_Handler")]
	public unsafe virtual IInterface? QueryLocalInterface(string descriptor)
	{
		nint num = JNIEnv.NewString(descriptor);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IInterface>(_members.InstanceMethods.InvokeVirtualObjectMethod("queryLocalInterface.(Ljava/lang/String;)Landroid/os/IInterface;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("transact", "(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z", "")]
	public unsafe bool Transact(int code, Parcel data, Parcel? reply, TransactionFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(code);
			ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(reply?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((int)flags);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("transact.(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
			GC.KeepAlive(reply);
		}
	}

	private static Delegate GetUnlinkToDeath_Landroid_os_IBinder_DeathRecipient_IHandler()
	{
		return new _JniMarshal_PPLI_B(n_UnlinkToDeath_Landroid_os_IBinder_DeathRecipient_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_UnlinkToDeath_Landroid_os_IBinder_DeathRecipient_I(nint jnienv, nint native__this, nint native_recipient, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Binder? binder = Java.Lang.Object.GetObject<Binder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBinderDeathRecipient recipient = Java.Lang.Object.GetObject<IBinderDeathRecipient>(native_recipient, JniHandleOwnership.DoNotTransfer);
			return binder.UnlinkToDeath(recipient, flags) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("unlinkToDeath", "(Landroid/os/IBinder$DeathRecipient;I)Z", "GetUnlinkToDeath_Landroid_os_IBinder_DeathRecipient_IHandler")]
	public unsafe virtual bool UnlinkToDeath(IBinderDeathRecipient recipient, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((recipient == null) ? IntPtr.Zero : ((Java.Lang.Object)recipient).Handle);
			ptr[1] = new JniArgumentValue(flags);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("unlinkToDeath.(Landroid/os/IBinder$DeathRecipient;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(recipient);
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
