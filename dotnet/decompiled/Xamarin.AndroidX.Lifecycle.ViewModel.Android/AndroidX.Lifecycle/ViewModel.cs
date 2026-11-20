using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Xamarin.KotlinX.Coroutines;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ViewModel", DoNotGenerateAcw = true)]
public abstract class ViewModel : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModel", typeof(ViewModel));

	private static Delegate? cb_addCloseable_AddCloseable_Ljava_lang_AutoCloseable__V;

	private static Delegate? cb_onCleared_OnCleared_V;

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

	protected ViewModel(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ViewModel()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "([Ljava/io/Closeable;)V", "")]
	[Obsolete("deprecated")]
	public unsafe ViewModel(params ICloseable[]? closeables)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(closeables);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([Ljava/io/Closeable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([Ljava/io/Closeable;)V", this, ptr);
		}
		finally
		{
			if (closeables != null)
			{
				JNIEnv.CopyArray(num, closeables);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(closeables);
		}
	}

	[Register(".ctor", "([Ljava/lang/AutoCloseable;)V", "")]
	public unsafe ViewModel(params IAutoCloseable[] closeables)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(closeables);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([Ljava/lang/AutoCloseable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([Ljava/lang/AutoCloseable;)V", this, ptr);
		}
		finally
		{
			if (closeables != null)
			{
				JNIEnv.CopyArray(num, closeables);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(closeables);
		}
	}

	[Register(".ctor", "(Lkotlinx/coroutines/CoroutineScope;)V", "")]
	public unsafe ViewModel(ICoroutineScope viewModelScope)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((viewModelScope == null) ? IntPtr.Zero : ((Java.Lang.Object)viewModelScope).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlinx/coroutines/CoroutineScope;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lkotlinx/coroutines/CoroutineScope;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(viewModelScope);
		}
	}

	[Register(".ctor", "(Lkotlinx/coroutines/CoroutineScope;[Ljava/lang/AutoCloseable;)V", "")]
	public unsafe ViewModel(ICoroutineScope viewModelScope, params IAutoCloseable[] closeables)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(closeables);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((viewModelScope == null) ? IntPtr.Zero : ((Java.Lang.Object)viewModelScope).Handle);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlinx/coroutines/CoroutineScope;[Ljava/lang/AutoCloseable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lkotlinx/coroutines/CoroutineScope;[Ljava/lang/AutoCloseable;)V", this, ptr);
		}
		finally
		{
			if (closeables != null)
			{
				JNIEnv.CopyArray(num, closeables);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(viewModelScope);
			GC.KeepAlive(closeables);
		}
	}

	private static Delegate GetAddCloseable_Ljava_lang_AutoCloseable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddCloseable_Ljava_lang_AutoCloseable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCloseable_Ljava_lang_AutoCloseable_(nint jnienv, nint native__this, nint native_closeable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewModel? viewModel = Java.Lang.Object.GetObject<ViewModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IAutoCloseable closeable = Java.Lang.Object.GetObject<IAutoCloseable>(native_closeable, JniHandleOwnership.DoNotTransfer);
			viewModel.AddCloseable(closeable);
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

	[Register("addCloseable", "(Ljava/lang/AutoCloseable;)V", "GetAddCloseable_Ljava_lang_AutoCloseable_Handler")]
	public unsafe virtual void AddCloseable(IAutoCloseable closeable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((closeable == null) ? IntPtr.Zero : ((Java.Lang.Object)closeable).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCloseable.(Ljava/lang/AutoCloseable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(closeable);
		}
	}

	[Register("addCloseable", "(Ljava/lang/String;Ljava/lang/AutoCloseable;)V", "")]
	public unsafe void AddCloseable(string key, IAutoCloseable closeable)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((closeable == null) ? IntPtr.Zero : ((Java.Lang.Object)closeable).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addCloseable.(Ljava/lang/String;Ljava/lang/AutoCloseable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(closeable);
		}
	}

	[Register("getCloseable", "(Ljava/lang/String;)Ljava/lang/AutoCloseable;", "")]
	[JavaTypeParameters(new string[] { "T extends java.lang.AutoCloseable" })]
	public unsafe Java.Lang.Object? GetCloseable(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCloseable.(Ljava/lang/String;)Ljava/lang/AutoCloseable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCleared(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCleared();
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

	[Register("onCleared", "()V", "GetOnClearedHandler")]
	protected unsafe virtual void OnCleared()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCleared.()V", this, null);
	}

	[UnmanagedCallersOnly]
	private static void n_OnCleared_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnCleared(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
