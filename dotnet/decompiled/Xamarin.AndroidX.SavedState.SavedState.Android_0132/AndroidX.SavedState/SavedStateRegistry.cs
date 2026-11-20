using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.SavedState;

[Register("androidx/savedstate/SavedStateRegistry", DoNotGenerateAcw = true)]
public sealed class SavedStateRegistry : Java.Lang.Object
{
	[Register("androidx/savedstate/SavedStateRegistry$SavedStateProvider", "", "AndroidX.SavedState.SavedStateRegistry/ISavedStateProviderInvoker")]
	public interface ISavedStateProvider : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("saveState", "()Landroid/os/Bundle;", "GetSaveStateHandler:AndroidX.SavedState.SavedStateRegistry/ISavedStateProviderInvoker, Xamarin.AndroidX.SavedState.SavedState.Android")]
		Bundle SaveState();
	}

	[Register("androidx/savedstate/SavedStateRegistry$SavedStateProvider", DoNotGenerateAcw = true)]
	internal class ISavedStateProviderInvoker : Java.Lang.Object, ISavedStateProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_savedstate_SavedStateRegistry_SavedStateProvider = new XAPeerMembers("androidx/savedstate/SavedStateRegistry$SavedStateProvider", typeof(ISavedStateProviderInvoker));

		private static Delegate? cb_saveState_SaveState_Landroid_os_Bundle_;

		private static nint java_class_ref => _members_androidx_savedstate_SavedStateRegistry_SavedStateProvider.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_savedstate_SavedStateRegistry_SavedStateProvider;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_savedstate_SavedStateRegistry_SavedStateProvider.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_savedstate_SavedStateRegistry_SavedStateProvider.ManagedPeerType;

		public ISavedStateProviderInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetSaveStateHandler()
		{
			return new global::_JniMarshal_PP_L(n_SaveState);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SaveState(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISavedStateProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SaveState());
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

		public unsafe Bundle SaveState()
		{
			return Java.Lang.Object.GetObject<Bundle>(_members_androidx_savedstate_SavedStateRegistry_SavedStateProvider.InstanceMethods.InvokeAbstractObjectMethod("saveState.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/savedstate/SavedStateRegistry", typeof(SavedStateRegistry));

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

	public unsafe bool IsRestored
	{
		[Register("isRestored", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRestored.()Z", this, null);
		}
	}

	internal SavedStateRegistry(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("consumeRestoredStateForKey", "(Ljava/lang/String;)Landroid/os/Bundle;", "")]
	public unsafe Bundle? ConsumeRestoredStateForKey(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("consumeRestoredStateForKey.(Ljava/lang/String;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("getSavedStateProvider", "(Ljava/lang/String;)Landroidx/savedstate/SavedStateRegistry$SavedStateProvider;", "")]
	public unsafe ISavedStateProvider? GetSavedStateProvider(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISavedStateProvider>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSavedStateProvider.(Ljava/lang/String;)Landroidx/savedstate/SavedStateRegistry$SavedStateProvider;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("registerSavedStateProvider", "(Ljava/lang/String;Landroidx/savedstate/SavedStateRegistry$SavedStateProvider;)V", "")]
	public unsafe void RegisterSavedStateProvider(string key, ISavedStateProvider provider)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("registerSavedStateProvider.(Ljava/lang/String;Landroidx/savedstate/SavedStateRegistry$SavedStateProvider;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(provider);
		}
	}

	[Register("runOnNextRecreation", "(Ljava/lang/Class;)V", "")]
	public unsafe void RunOnNextRecreation(Class clazz)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(clazz?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("runOnNextRecreation.(Ljava/lang/Class;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(clazz);
		}
	}

	[Register("unregisterSavedStateProvider", "(Ljava/lang/String;)V", "")]
	public unsafe void UnregisterSavedStateProvider(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("unregisterSavedStateProvider.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
