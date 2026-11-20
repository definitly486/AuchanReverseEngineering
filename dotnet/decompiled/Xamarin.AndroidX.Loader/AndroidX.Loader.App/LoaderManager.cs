using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using AndroidX.Loader.Content;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Loader.App;

[Register("androidx/loader/app/LoaderManager", DoNotGenerateAcw = true)]
public abstract class LoaderManager : Java.Lang.Object
{
	[Register("androidx/loader/app/LoaderManager$LoaderCallbacks", "", "AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker")]
	[JavaTypeParameters(new string[] { "D" })]
	public interface ILoaderCallbacks : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCreateLoader", "(ILandroid/os/Bundle;)Landroidx/loader/content/Loader;", "GetOnCreateLoader_ILandroid_os_Bundle_Handler:AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.AndroidX.Loader")]
		AndroidX.Loader.Content.Loader OnCreateLoader(int p0, Bundle? p1);

		[Register("onLoadFinished", "(Landroidx/loader/content/Loader;Ljava/lang/Object;)V", "GetOnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler:AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.AndroidX.Loader")]
		void OnLoadFinished(AndroidX.Loader.Content.Loader p0, Java.Lang.Object? p1);

		[Register("onLoaderReset", "(Landroidx/loader/content/Loader;)V", "GetOnLoaderReset_Landroidx_loader_content_Loader_Handler:AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.AndroidX.Loader")]
		void OnLoaderReset(AndroidX.Loader.Content.Loader p0);
	}

	[Register("androidx/loader/app/LoaderManager$LoaderCallbacks", DoNotGenerateAcw = true)]
	internal class ILoaderCallbacksInvoker : Java.Lang.Object, ILoaderCallbacks, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_loader_app_LoaderManager_LoaderCallbacks = new XAPeerMembers("androidx/loader/app/LoaderManager$LoaderCallbacks", typeof(ILoaderCallbacksInvoker));

		private static Delegate? cb_onCreateLoader_OnCreateLoader_ILandroid_os_Bundle__Landroidx_loader_content_Loader_;

		private static Delegate? cb_onLoadFinished_OnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object__V;

		private static Delegate? cb_onLoaderReset_OnLoaderReset_Landroidx_loader_content_Loader__V;

		private static nint java_class_ref => _members_androidx_loader_app_LoaderManager_LoaderCallbacks.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_loader_app_LoaderManager_LoaderCallbacks;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_loader_app_LoaderManager_LoaderCallbacks.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_loader_app_LoaderManager_LoaderCallbacks.ManagedPeerType;

		public ILoaderCallbacksInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnCreateLoader_ILandroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPIL_L(n_OnCreateLoader_ILandroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnCreateLoader_ILandroid_os_Bundle_(nint jnienv, nint native__this, int p0, nint native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ILoaderCallbacks? loaderCallbacks = Java.Lang.Object.GetObject<ILoaderCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Bundle p1 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(loaderCallbacks.OnCreateLoader(p0, p1));
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

		public unsafe AndroidX.Loader.Content.Loader OnCreateLoader(int p0, Bundle? p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(_members_androidx_loader_app_LoaderManager_LoaderCallbacks.InstanceMethods.InvokeAbstractObjectMethod("onCreateLoader.(ILandroid/os/Bundle;)Landroidx/loader/content/Loader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetOnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ILoaderCallbacks? loaderCallbacks = Java.Lang.Object.GetObject<ILoaderCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AndroidX.Loader.Content.Loader p = Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
				loaderCallbacks.OnLoadFinished(p, p2);
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

		public unsafe void OnLoadFinished(AndroidX.Loader.Content.Loader p0, Java.Lang.Object? p1)
		{
			nint num = JNIEnv.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				_members_androidx_loader_app_LoaderManager_LoaderCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onLoadFinished.(Landroidx/loader/content/Loader;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetOnLoaderReset_Landroidx_loader_content_Loader_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnLoaderReset_Landroidx_loader_content_Loader_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLoaderReset_Landroidx_loader_content_Loader_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ILoaderCallbacks? loaderCallbacks = Java.Lang.Object.GetObject<ILoaderCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AndroidX.Loader.Content.Loader p = Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(native_p0, JniHandleOwnership.DoNotTransfer);
				loaderCallbacks.OnLoaderReset(p);
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

		public unsafe void OnLoaderReset(AndroidX.Loader.Content.Loader p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_androidx_loader_app_LoaderManager_LoaderCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onLoaderReset.(Landroidx/loader/content/Loader;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/app/LoaderManager", typeof(LoaderManager));

	private static Delegate? cb_hasRunningLoaders_HasRunningLoaders_Z;

	private static Delegate? cb_destroyLoader_DestroyLoader_I_V;

	private static Delegate? cb_dump_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String__V;

	private static Delegate? cb_getLoader_GetLoader_I_Landroidx_loader_content_Loader_;

	private static Delegate? cb_initLoader_InitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks__Landroidx_loader_content_Loader_;

	private static Delegate? cb_markForRedelivery_MarkForRedelivery_V;

	private static Delegate? cb_restartLoader_RestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks__Landroidx_loader_content_Loader_;

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

	public unsafe virtual bool HasRunningLoaders
	{
		[Register("hasRunningLoaders", "()Z", "GetHasRunningLoadersHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasRunningLoaders.()Z", this, null);
		}
	}

	protected LoaderManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LoaderManager()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetHasRunningLoadersHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasRunningLoaders);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasRunningLoaders(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasRunningLoaders ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetDestroyLoader_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_DestroyLoader_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DestroyLoader_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DestroyLoader(p0);
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

	[Register("destroyLoader", "(I)V", "GetDestroyLoader_IHandler")]
	public abstract void DestroyLoader(int p0);

	[Obsolete]
	private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, nint native_p3)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LoaderManager? loaderManager = Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			FileDescriptor p2 = Java.Lang.Object.GetObject<FileDescriptor>(native_p1, JniHandleOwnership.DoNotTransfer);
			PrintWriter p3 = Java.Lang.Object.GetObject<PrintWriter>(native_p2, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
			loaderManager.Dump(p, p2, p3, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p3);
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

	[Obsolete("deprecated")]
	[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
	public abstract void Dump(string? p0, FileDescriptor? p1, PrintWriter? p2, string[]? p3);

	[Register("enableDebugLogging", "(Z)V", "")]
	public unsafe static void EnableDebugLogging(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.StaticMethods.InvokeVoidMethod("enableDebugLogging.(Z)V", ptr);
	}

	[Register("getInstance", "(Landroidx/lifecycle/LifecycleOwner;)Landroidx/loader/app/LoaderManager;", "")]
	[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.LifecycleOwner & androidx.lifecycle.ViewModelStoreOwner" })]
	public unsafe static LoaderManager GetInstance(Java.Lang.Object owner)
	{
		nint num = JNIEnv.ToLocalJniHandle(owner);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<LoaderManager>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Landroidx/lifecycle/LifecycleOwner;)Landroidx/loader/app/LoaderManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(owner);
		}
	}

	private static Delegate GetGetLoader_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetLoader_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLoader_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLoader(p0));
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

	[Register("getLoader", "(I)Landroidx/loader/content/Loader;", "GetGetLoader_IHandler")]
	[JavaTypeParameters(new string[] { "D" })]
	public abstract AndroidX.Loader.Content.Loader? GetLoader(int p0);

	private static Delegate GetInitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler()
	{
		return new global::_JniMarshal_PPILL_L(n_InitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_(nint jnienv, nint native__this, int p0, nint native_p1, nint native_p2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LoaderManager? loaderManager = Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p1 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
			ILoaderCallbacks p2 = Java.Lang.Object.GetObject<ILoaderCallbacks>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loaderManager.InitLoader(p0, p1, p2));
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

	[Register("initLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetInitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
	[JavaTypeParameters(new string[] { "D" })]
	public abstract AndroidX.Loader.Content.Loader InitLoader(int p0, Bundle? p1, ILoaderCallbacks p2);

	private static Delegate GetMarkForRedeliveryHandler()
	{
		return new global::_JniMarshal_PP_V(n_MarkForRedelivery);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_MarkForRedelivery(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarkForRedelivery();
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

	[Register("markForRedelivery", "()V", "GetMarkForRedeliveryHandler")]
	public abstract void MarkForRedelivery();

	private static Delegate GetRestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler()
	{
		return new global::_JniMarshal_PPILL_L(n_RestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_(nint jnienv, nint native__this, int p0, nint native_p1, nint native_p2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LoaderManager? loaderManager = Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p1 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
			ILoaderCallbacks p2 = Java.Lang.Object.GetObject<ILoaderCallbacks>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loaderManager.RestartLoader(p0, p1, p2));
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

	[Register("restartLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetRestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
	[JavaTypeParameters(new string[] { "D" })]
	public abstract AndroidX.Loader.Content.Loader RestartLoader(int p0, Bundle? p1, ILoaderCallbacks p2);
}
