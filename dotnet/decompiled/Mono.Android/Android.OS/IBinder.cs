using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace Android.OS;

[Register("android/os/IBinder", "", "Android.OS.IBinderInvoker")]
public interface IBinder : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/os/IBinder$FrozenStateChangeCallback", "", "Android.OS.IBinder/IFrozenStateChangeCallbackInvoker", ApiSince = 36)]
	public interface IFrozenStateChangeCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[SupportedOSPlatform("android36.0")]
		[Register("onFrozenStateChanged", "(Landroid/os/IBinder;I)V", "GetOnFrozenStateChanged_Landroid_os_IBinder_IHandler:Android.OS.IBinder/IFrozenStateChangeCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 36)]
		void OnFrozenStateChanged(IBinder who, int state);
	}

	[Register("android/os/IBinder$FrozenStateChangeCallback", DoNotGenerateAcw = true, ApiSince = 36)]
	internal class IFrozenStateChangeCallbackInvoker : Java.Lang.Object, IFrozenStateChangeCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_os_IBinder_FrozenStateChangeCallback = new XAPeerMembers("android/os/IBinder$FrozenStateChangeCallback", typeof(IFrozenStateChangeCallbackInvoker));

		private static Delegate? cb_onFrozenStateChanged_OnFrozenStateChanged_Landroid_os_IBinder_I_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_os_IBinder_FrozenStateChangeCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_os_IBinder_FrozenStateChangeCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_os_IBinder_FrozenStateChangeCallback.ManagedPeerType;

		public IFrozenStateChangeCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[SupportedOSPlatform("android36.0")]
		private static Delegate GetOnFrozenStateChanged_Landroid_os_IBinder_IHandler()
		{
			return new _JniMarshal_PPLI_V(n_OnFrozenStateChanged_Landroid_os_IBinder_I);
		}

		[SupportedOSPlatform("android36.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFrozenStateChanged_Landroid_os_IBinder_I(nint jnienv, nint native__this, nint native_who, int state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IFrozenStateChangeCallback? frozenStateChangeCallback = Java.Lang.Object.GetObject<IFrozenStateChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IBinder who = Java.Lang.Object.GetObject<IBinder>(native_who, JniHandleOwnership.DoNotTransfer);
				frozenStateChangeCallback.OnFrozenStateChanged(who, state);
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

		[SupportedOSPlatform("android36.0")]
		public unsafe void OnFrozenStateChanged(IBinder who, int state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((who == null) ? IntPtr.Zero : ((Java.Lang.Object)who).Handle);
				ptr[1] = new JniArgumentValue(state);
				_members_android_os_IBinder_FrozenStateChangeCallback.InstanceMethods.InvokeAbstractVoidMethod("onFrozenStateChanged.(Landroid/os/IBinder;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(who);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/IBinder", typeof(IBinder), isInterface: true);

	private static Delegate? cb_addFrozenStateChangeCallback_AddFrozenStateChangeCallback_Ljava_util_concurrent_Executor_Landroid_os_IBinder_FrozenStateChangeCallback__V;

	private static Delegate? cb_removeFrozenStateChangeCallback_RemoveFrozenStateChangeCallback_Landroid_os_IBinder_FrozenStateChangeCallback__Z;

	string? InterfaceDescriptor
	{
		[Register("getInterfaceDescriptor", "()Ljava/lang/String;", "GetGetInterfaceDescriptorHandler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsBinderAlive
	{
		[Register("isBinderAlive", "()Z", "GetIsBinderAliveHandler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[SupportedOSPlatform("android30.0")]
	static unsafe int SuggestedMaxIpcSizeBytes
	{
		[Register("getSuggestedMaxIpcSizeBytes", "()I", "", ApiSince = 30)]
		get
		{
			return _members.StaticMethods.InvokeInt32Method("getSuggestedMaxIpcSizeBytes.()I", null);
		}
	}

	[Register("dump", "(Ljava/io/FileDescriptor;[Ljava/lang/String;)V", "GetDump_Ljava_io_FileDescriptor_arrayLjava_lang_String_Handler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Dump(FileDescriptor fd, string[]? args);

	[Register("dumpAsync", "(Ljava/io/FileDescriptor;[Ljava/lang/String;)V", "GetDumpAsync_Ljava_io_FileDescriptor_arrayLjava_lang_String_Handler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void DumpAsync(FileDescriptor fd, string[]? args);

	[Register("linkToDeath", "(Landroid/os/IBinder$DeathRecipient;I)V", "GetLinkToDeath_Landroid_os_IBinder_DeathRecipient_IHandler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void LinkToDeath(IBinderDeathRecipient recipient, int flags);

	[Register("pingBinder", "()Z", "GetPingBinderHandler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool PingBinder();

	[Register("queryLocalInterface", "(Ljava/lang/String;)Landroid/os/IInterface;", "GetQueryLocalInterface_Ljava_lang_String_Handler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IInterface? QueryLocalInterface(string descriptor);

	[Register("transact", "(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z", "GetTransact_ILandroid_os_Parcel_Landroid_os_Parcel_IHandler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Transact(int code, Parcel data, Parcel? reply, TransactionFlags flags);

	[Register("unlinkToDeath", "(Landroid/os/IBinder$DeathRecipient;I)Z", "GetUnlinkToDeath_Landroid_os_IBinder_DeathRecipient_IHandler:Android.OS.IBinderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool UnlinkToDeath(IBinderDeathRecipient recipient, int flags);

	[SupportedOSPlatform("android36.0")]
	private static Delegate GetAddFrozenStateChangeCallback_Ljava_util_concurrent_Executor_Landroid_os_IBinder_FrozenStateChangeCallback_Handler()
	{
		return new _JniMarshal_PPLL_V(n_AddFrozenStateChangeCallback_Ljava_util_concurrent_Executor_Landroid_os_IBinder_FrozenStateChangeCallback_);
	}

	[SupportedOSPlatform("android36.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFrozenStateChangeCallback_Ljava_util_concurrent_Executor_Landroid_os_IBinder_FrozenStateChangeCallback_(nint jnienv, nint native__this, nint native_executor, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IBinder? binder = Java.Lang.Object.GetObject<IBinder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
			IFrozenStateChangeCallback callback = Java.Lang.Object.GetObject<IFrozenStateChangeCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			binder.AddFrozenStateChangeCallback(executor, callback);
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

	[SupportedOSPlatform("android36.0")]
	[Register("addFrozenStateChangeCallback", "(Ljava/util/concurrent/Executor;Landroid/os/IBinder$FrozenStateChangeCallback;)V", "GetAddFrozenStateChangeCallback_Ljava_util_concurrent_Executor_Landroid_os_IBinder_FrozenStateChangeCallback_Handler:Android.OS.IBinder, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 36)]
	unsafe void AddFrozenStateChangeCallback(IExecutor executor, IFrozenStateChangeCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFrozenStateChangeCallback.(Ljava/util/concurrent/Executor;Landroid/os/IBinder$FrozenStateChangeCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}

	[SupportedOSPlatform("android36.0")]
	private static Delegate GetRemoveFrozenStateChangeCallback_Landroid_os_IBinder_FrozenStateChangeCallback_Handler()
	{
		return new _JniMarshal_PPL_B(n_RemoveFrozenStateChangeCallback_Landroid_os_IBinder_FrozenStateChangeCallback_);
	}

	[SupportedOSPlatform("android36.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveFrozenStateChangeCallback_Landroid_os_IBinder_FrozenStateChangeCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IBinder? binder = Java.Lang.Object.GetObject<IBinder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFrozenStateChangeCallback callback = Java.Lang.Object.GetObject<IFrozenStateChangeCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return binder.RemoveFrozenStateChangeCallback(callback) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android36.0")]
	[Register("removeFrozenStateChangeCallback", "(Landroid/os/IBinder$FrozenStateChangeCallback;)Z", "GetRemoveFrozenStateChangeCallback_Landroid_os_IBinder_FrozenStateChangeCallback_Handler:Android.OS.IBinder, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 36)]
	unsafe bool RemoveFrozenStateChangeCallback(IFrozenStateChangeCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeFrozenStateChangeCallback.(Landroid/os/IBinder$FrozenStateChangeCallback;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}
}
